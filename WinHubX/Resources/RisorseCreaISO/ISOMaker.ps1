#################################### download script
$path_to_use = Get-Location

# Set location without displaying it
Set-Location $path_to_use | Out-Null
#################################### edit quickedit
# Set the registry key path
$regKeyPath = "HKCU:\Console"

# Set the registry value name and data
$valueName = "QuickEdit"
$valueData = 0

# Create the registry value
New-ItemProperty -Path $regKeyPath -Name $valueName -Value $valueData -PropertyType DWORD -Force | Out-Null
####################################
####################################
# Hide Console
# Define the function to hide the console
Add-Type -Name Window -Namespace Console -MemberDefinition '
[DllImport("Kernel32.dll")]
public static extern IntPtr GetConsoleWindow();

[DllImport("user32.dll")]
public static extern bool ShowWindow(IntPtr hWnd, Int32 nCmdShow);
'

function Hide-Console {
    $consolePtr = [Console.Window]::GetConsoleWindow()
    [Console.Window]::ShowWindow($consolePtr, 0)
}

# Call the Hide-Console function
Hide-Console
####################################
#################################### start gui
Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$global:selectedFile = $null
$smonto = ""
# Create form
$form = New-Object System.Windows.Forms.Form
$form.Text = "Windows Custom ISO Maker"
$form.Size = New-Object System.Drawing.Size(500,560) 
$form.StartPosition = "CenterScreen"
$form.FormBorderStyle = 'FixedDialog'

# Set form background color to dark
$form.BackColor = [System.Drawing.Color]::FromArgb(40, 40, 40)

# Set text color to white
$form.ForeColor = [System.Drawing.Color]::White

# Create label for ISO file
$labelISOFile = New-Object System.Windows.Forms.Label
$labelISOFile.Location = New-Object System.Drawing.Point(10, 20)
$labelISOFile.Size = New-Object System.Drawing.Size(260, 20)
$labelISOFile.Text = "Seleziona file ISO:"
$form.Controls.Add($labelISOFile)

# Create textbox for ISO file
$textBoxISOFile = New-Object System.Windows.Forms.TextBox
$textBoxISOFile.Location = New-Object System.Drawing.Point(10, 40)
$textBoxISOFile.Size = New-Object System.Drawing.Size(350, 20)
$form.Controls.Add($textBoxISOFile)

# Create browse button
$browseButton = New-Object System.Windows.Forms.Button
$browseButton.Location = New-Object System.Drawing.Point(370, 38)
$browseButton.Size = New-Object System.Drawing.Size(80, 20)
$browseButton.Text = "Browse"
$browseButton.Add_Click({
    $openFileDialog = New-Object System.Windows.Forms.OpenFileDialog
    $openFileDialog.Filter = "ISO Files (*.iso)|*.iso|All files (*.*)|*.*"
    $openFileDialog.Title = "Seleziona file ISO"
    $openFileDialog.Multiselect = $false
    $result = $openFileDialog.ShowDialog()
    if ($result -eq 'OK') {
        $selectedFile = $openFileDialog.FileName
        $textBoxISOFile.Text = $selectedFile
        Mount-DiskImage -ImagePath $selectedFile
        $driveLetter = (Get-DiskImage -ImagePath $selectedFile | Get-Volume).DriveLetter

        # Get the install.wim or install.esd path
        $installWimPath = ""
        $imageFiles = Get-ChildItem -Path "${driveLetter}:\sources" -Filter "install.*"
        if ($imageFiles.Count -eq 1) {
            $installWimPath = $imageFiles[0].FullName
        } elseif ($imageFiles.Count -gt 1) {
            # If there are multiple image files, prompt the user to select one
            $installWimPath = $imageFiles | Out-GridView -Title "Select Image File" -PassThru
        } else {
            Write-Host "No install.wim or install.esd file found in the ISO."
            return
        }

        # Get the index information using DISM
        $dismOutput = & dism /Get-WimInfo /WimFile:$installWimPath
        $wimInfo = $dismOutput | Out-String

        # Check if DISM output is empty or null
        if ([string]::IsNullOrWhiteSpace($wimInfo)) {
            Write-Host "DISM output is empty or null. Please verify the DISM command and try again."
        } else {
            # Display the list of available editions in the Windows Edition selection box
            $windowsEditionComboBox.Items.Clear()
            $dismOutput | ForEach-Object {
                if ($_ -match "^Indice:\s+(\d+)$") {
                    $index = $matches[1]
                }
                if ($_ -match "^Nome:\s+(.+)$") {
                    $editionName = $matches[1]
                    $windowsEditionComboBox.Items.Add("Indice $index $editionName")
                }
            }
        }
        $script:smonto = $selectedFile
    }
})
$form.Controls.Add($browseButton)


# Create label for ISO index selection
$labelISOIndex = New-Object System.Windows.Forms.Label
$labelISOIndex.Location = New-Object System.Drawing.Point(10, 70)
$labelISOIndex.Size = New-Object System.Drawing.Size(200, 20)
$labelISOIndex.Text = "Seleziona Indice ISO:"
$form.Controls.Add($labelISOIndex)

# Create Windows Edition selection ComboBox
$windowsEditionComboBox = New-Object System.Windows.Forms.ComboBox
$windowsEditionComboBox.Location = New-Object System.Drawing.Point(10, 90)
$windowsEditionComboBox.Size = New-Object System.Drawing.Size(440, 20)
$windowsEditionComboBox.DropDownStyle = [System.Windows.Forms.ComboBoxStyle]::DropDownList
$windowsEditionComboBox.Add_SelectedIndexChanged({
    # Assegna il valore selezionato a $windowsEdition
    $global:windowsEdition = $windowsEditionComboBox.SelectedItem.ToString()
})
$form.Controls.Add($windowsEditionComboBox)

# Create group box for Debloat APP
$groupBoxDebloatapp = New-Object System.Windows.Forms.GroupBox
$groupBoxDebloatapp.Location = New-Object System.Drawing.Point(240, 130) 
$groupBoxDebloatapp.Size = New-Object System.Drawing.Size(220,70)   
$groupBoxDebloatapp.Text = "Debloat APP"
$form.Controls.Add($groupBoxDebloatapp)

# Create radio buttons for Windows version
$radioButtonDebloatAPP = New-Object System.Windows.Forms.RadioButton
$radioButtonDebloatAPP.Location = New-Object System.Drawing.Point(10,20)
$radioButtonDebloatAPP.Size = New-Object System.Drawing.Size(120,20)
$radioButtonDebloatAPP.Text = "Debloat APP"
$groupBoxDebloatapp.ForeColor = [System.Drawing.Color]::White
$groupBoxDebloatapp.Controls.Add($radioButtonDebloatAPP)

$radioButtonNonDebloatAPP = New-Object System.Windows.Forms.RadioButton
$radioButtonNonDebloatAPP.Location = New-Object System.Drawing.Point(10,45)
$radioButtonNonDebloatAPP.Size = New-Object System.Drawing.Size(120,20)
$radioButtonNonDebloatAPP.Text = "Stock APP"
$groupBoxDebloatapp.Controls.Add($radioButtonNonDebloatAPP)

# Create donate button
$donateButton = New-Object System.Windows.Forms.Button
$donateButton.Location = New-Object System.Drawing.Point(240,490) 
$donateButton.Size = New-Object System.Drawing.Size(100,23) 
$donateButton.Text = "Donazione"
$donateButton.Add_Click({
    Start-Process "https://ko-fi.com/winhubx"
})
$form.Controls.Add($donateButton)

# Create group box for Windows version
$groupBoxWindowsVersion = New-Object System.Windows.Forms.GroupBox
$groupBoxWindowsVersion.Location = New-Object System.Drawing.Point(10, 130)
$groupBoxWindowsVersion.Size = New-Object System.Drawing.Size(220,70)
$groupBoxWindowsVersion.Text = "Seleziona versione ISO Windows"
$groupBoxWindowsVersion.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxWindowsVersion)

# Create radio buttons for Windows version
$radioButtonWindows10 = New-Object System.Windows.Forms.RadioButton
$radioButtonWindows10.Location = New-Object System.Drawing.Point(10,20)
$radioButtonWindows10.Size = New-Object System.Drawing.Size(120,20)
$radioButtonWindows10.Text = "Windows 10"
$groupBoxWindowsVersion.Controls.Add($radioButtonWindows10)

$radioButtonWindows11 = New-Object System.Windows.Forms.RadioButton
$radioButtonWindows11.Location = New-Object System.Drawing.Point(10,45)
$radioButtonWindows11.Size = New-Object System.Drawing.Size(120,20)
$radioButtonWindows11.Text = "Windows 11"
$groupBoxWindowsVersion.Controls.Add($radioButtonWindows11)

# Add CheckedChanged event listeners
$radioButtonWindows10.Add_CheckedChanged({
    if ($radioButtonWindows10.Checked) {
        UpdateUnattendGroup $false
    }
})

# Windows 11 CheckedChanged event
$radioButtonWindows11.Add_CheckedChanged({
    if ($radioButtonWindows11.Checked) {
        UpdateUnattendGroup $true
    }
})

function UpdateUnattendGroup {
    param(
        [bool]$isWindows11
    )

    if ($script:groupBoxUnattend) {
        $form.Controls.Remove($script:groupBoxUnattend)
        $script:groupBoxUnattend.Dispose()
        $script:groupBoxUnattend = $null
    }

    if ($script:groupBoxArchitettura) {
        $form.Controls.Remove($script:groupBoxArchitettura)
        $script:groupBoxArchitettura.Dispose()
        $script:groupBoxArchitettura = $null
    }

    if ($isWindows11) {
        $script:groupBoxUnattend = New-Object System.Windows.Forms.GroupBox
        $script:groupBoxUnattend.Location = New-Object System.Drawing.Point(245,305)
        $script:groupBoxUnattend.Size = New-Object System.Drawing.Size(215,70)
        $script:groupBoxUnattend.Text = "Seleziona Bypass Windows 11"
        $script:groupBoxUnattend.ForeColor = [System.Drawing.Color]::White
        $form.Controls.Add($script:groupBoxUnattend)

        # Add radio buttons for bypass options
        $radioButtonStock = New-Object System.Windows.Forms.RadioButton
        $radioButtonStock.Location = New-Object System.Drawing.Point(10,20)
        $radioButtonStock.Size = New-Object System.Drawing.Size(120,20)
        $radioButtonStock.Text = "Stock"
        $groupBoxUnattend.Controls.Add($radioButtonStock)

        $radioButtonBypass = New-Object System.Windows.Forms.RadioButton
        $radioButtonBypass.Location = New-Object System.Drawing.Point(10,45)
        $radioButtonBypass.Size = New-Object System.Drawing.Size(120,20)
        $radioButtonBypass.Text = "Bypass"
        $groupBoxUnattend.Controls.Add($radioButtonBypass)
    } else {
        $script:groupBoxArchitettura = New-Object System.Windows.Forms.GroupBox
        $script:groupBoxArchitettura.Location = New-Object System.Drawing.Point(240, 220) 
        $script:groupBoxArchitettura.Size = New-Object System.Drawing.Size(220,70)   
        $script:groupBoxArchitettura.Text = "Architettura"
        $script:groupBoxArchitettura.ForeColor = [System.Drawing.Color]::White
        $form.Controls.Add($script:groupBoxArchitettura)

        # Add radio buttons for architecture options
        $radioButtonx64 = New-Object System.Windows.Forms.RadioButton
        $radioButtonx64.Location = New-Object System.Drawing.Point(10,20)
        $radioButtonx64.Size = New-Object System.Drawing.Size(120,20)
        $radioButtonx64.Text = "x64"
        $groupBoxArchitettura.Controls.Add($radioButtonx64)

        $radioButtonx32 = New-Object System.Windows.Forms.RadioButton
        $radioButtonx32.Location = New-Object System.Drawing.Point(10,45)
        $radioButtonx32.Size = New-Object System.Drawing.Size(120,20)
        $radioButtonx32.Text = "x32"
        $groupBoxArchitettura.Controls.Add($radioButtonx32)
    }
}

# Create group box for Edge removal preference
$groupBoxEdgeRemoval = New-Object System.Windows.Forms.GroupBox
$groupBoxEdgeRemoval.Location = New-Object System.Drawing.Point(10, 220)
$groupBoxEdgeRemoval.Size = New-Object System.Drawing.Size(220,70)
$groupBoxEdgeRemoval.Text = "Seleziona preferenza Edge"
$groupBoxEdgeRemoval.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxEdgeRemoval)

# Create radio buttons for Edge removal preference
$radioButtonRemoveEdge = New-Object System.Windows.Forms.RadioButton
$radioButtonRemoveEdge.Location = New-Object System.Drawing.Point(10,20)
$radioButtonRemoveEdge.Size = New-Object System.Drawing.Size(150,20)
$radioButtonRemoveEdge.Text = "Rimuovi Edge"
$groupBoxEdgeRemoval.Controls.Add($radioButtonRemoveEdge)

$radioButtonDoNotRemoveEdge = New-Object System.Windows.Forms.RadioButton
$radioButtonDoNotRemoveEdge.Location = New-Object System.Drawing.Point(10,45)
$radioButtonDoNotRemoveEdge.Size = New-Object System.Drawing.Size(150,20)
$radioButtonDoNotRemoveEdge.Text = "Non rimuovere Edge"
$groupBoxEdgeRemoval.Controls.Add($radioButtonDoNotRemoveEdge)

# Create group box for Windows Defender preference
$groupBoxDefenderPreference = New-Object System.Windows.Forms.GroupBox
$groupBoxDefenderPreference.Location = New-Object System.Drawing.Point(10, 305)
$groupBoxDefenderPreference.Size = New-Object System.Drawing.Size(230,70)
$groupBoxDefenderPreference.Text = "Seleziona preferenza Defender"
$groupBoxDefenderPreference.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxDefenderPreference)

# Create radio buttons for Windows Defender preference
$radioButtonDisableDefender = New-Object System.Windows.Forms.RadioButton
$radioButtonDisableDefender.Location = New-Object System.Drawing.Point(10,20)
$radioButtonDisableDefender.Size = New-Object System.Drawing.Size(200,20)
$radioButtonDisableDefender.Text = "Disabilita Windows Defender"
$groupBoxDefenderPreference.Controls.Add($radioButtonDisableDefender)

$radioButtonDoNotDisableDefender = New-Object System.Windows.Forms.RadioButton
$radioButtonDoNotDisableDefender.Location = New-Object System.Drawing.Point(10,45)
$radioButtonDoNotDisableDefender.Size = New-Object System.Drawing.Size(200,20)
$radioButtonDoNotDisableDefender.Text = "Abilita Windows Defender"
$groupBoxDefenderPreference.Controls.Add($radioButtonDoNotDisableDefender)

#Rimozione Processi
$groupBoxRimozioneProcessi= New-Object System.Windows.Forms.GroupBox
$groupBoxRimozioneProcessi.Location = New-Object System.Drawing.Point(10, 390)
$groupBoxRimozioneProcessi.Size = New-Object System.Drawing.Size(220,70)
$groupBoxRimozioneProcessi.Text = "Elimina processi"
$groupBoxRimozioneProcessi.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxRimozioneProcessi)

$radioButtonRimuoviProcessi = New-Object System.Windows.Forms.RadioButton
$radioButtonRimuoviProcessi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonRimuoviProcessi.Size = New-Object System.Drawing.Size(150,20)
$radioButtonRimuoviProcessi.Text = "Rimuovi Processi"
$groupBoxRimozioneProcessi.Controls.Add($radioButtonRimuoviProcessi)

$radioButtonNonRimuoviProcessi = New-Object System.Windows.Forms.RadioButton
$radioButtonNonRimuoviProcessi.Location = New-Object System.Drawing.Point(10,45)
$radioButtonNonRimuoviProcessi.Size = New-Object System.Drawing.Size(160,20)
$radioButtonNonRimuoviProcessi.Text = "Non rimuovere processi"
$groupBoxRimozioneProcessi.Controls.Add($radioButtonNonRimuoviProcessi)


# Create OK button
$buildButton = New-Object System.Windows.Forms.Button
$buildButton.Location = New-Object System.Drawing.Point(360,490) 
$buildButton.Size = New-Object System.Drawing.Size(100,23) 
$buildButton.Text = "Crea!"
$buildButton.Add_Click({
    if ($textBoxISOFile.Text -eq "") {
        [System.Windows.Forms.MessageBox]::Show("Seleziona una ISO.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
        return
    }

    if (-not ($radioButtonWindows10.Checked -or $radioButtonWindows11.Checked)) {
        [System.Windows.Forms.MessageBox]
        ::Show("Seleziona versione Windows.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
        return
    }

    if (-not ($radioButtonRemoveEdge.Checked -or $radioButtonDoNotRemoveEdge.Checked)) {
        [System.Windows.Forms.MessageBox]::Show("Seleziona preferenza Microsoft Edge.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
        return
    }

    if (-not ($radioButtonDisableDefender.Checked -or $radioButtonDoNotDisableDefender.Checked)) {
        [System.Windows.Forms.MessageBox]::Show("Seleziona preferenza Windows Defender.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
        return
    }

    if ($windowsEditionComboBox.SelectedIndex -eq -1) {
        [System.Windows.Forms.MessageBox]::Show("Seleziona un indice ISO.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    if (-not ($radioButtonRimuoviProcessi.Checked -or $radioButtonNonRimuoviProcessi.Checked)) {
       [System.Windows.Forms.MessageBox]::Show("Seleziona se rimuovere i processi.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
       return
    }
     
    if (-not ($radioButtonDebloatAPP.Checked -or $radioButtonNonDebloatAPP.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se rimuovere le APP bloatware.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    $selectedFile = $textBoxISOFile.Text
    $windowsVersion = if ($radioButtonWindows10.Checked) { "Windows 10" } else { "Windows 11" }
    $edgeRemovalPreference = if ($radioButtonRemoveEdge.Checked) { "RemoveEdge" } else { "Do Not Remove Edge" }
    $defenderPreference = if ($radioButtonDisableDefender.Checked) { "DisableWindowsDefender" } else { "Do Not Disable Windows Defender" }
    $Processi = if ($radioButtonRimuoviProcessi.Checked) { "RimuoviProcessi" } else { "NonRimuovereProcessi" }
    $Unattend = if ($radioButtonStock.Checked) { "Stock" } else { "Bypass" }
    $Architettura = if ($radioButtonx64.Checked) { "x64" } else { "x32" }
    $DebloatApp = if ($radioButtonDebloatAPP.Checked) { "Debloat" } else { "NonDebloat" }

    Dismount-DiskImage -ImagePath $smonto | out-null
    Write-Host "$global:windowsEdition"

$arguments = @(
    """$selectedFile""",
    """$windowsVersion""",
    """$edgeRemovalPreference""",
    """$defenderPreference""",
    """$global:windowsEdition""",
    """$Processi""",
    """$Unattend""",
    """$Architettura""",
    """$DebloatApp"""
)

$argumentString = $arguments -join ' '

    if ($windowsVersion -eq "Windows 10") {
        Start-Process -FilePath "$env:TEMP\RisorseCreaISO\isotool10.bat" -ArgumentList "$argumentString" 
    }
    else {
        Start-Process -FilePath "$env:TEMP\RisorseCreaISO\isotool11.bat" -ArgumentList "$argumentString"
    }

})
$form.Controls.Add($buildButton)
# Add the closing event to the form to ensure the ISO is dismounted when the form is closed
$form.Add_Closing({
        Dismount-DiskImage -ImagePath $smonto
})
$form.Add_Closed({
        Dismount-DiskImage -ImagePath $smonto
})

# Add event handler for OK button click
$form.Add_Shown({$form.Activate()})
$form.ShowDialog() | Out-Null
####################################
