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

# Create form
$form = New-Object System.Windows.Forms.Form
$form.Text = "Windows Custom ISO Maker"
$form.Size = New-Object System.Drawing.Size(480,500) 
$form.StartPosition = "CenterScreen"
$form.FormBorderStyle = 'FixedDialog'

# Set form background color to dark
$form.BackColor = [System.Drawing.Color]::FromArgb(40, 40, 40)

# Set text color to white
$form.ForeColor = [System.Drawing.Color]::White

# Create label for ISO file
$labelISOFile = New-Object System.Windows.Forms.Label
$labelISOFile.Location = New-Object System.Drawing.Point(10,20)
$labelISOFile.Size = New-Object System.Drawing.Size(260,20)
$labelISOFile.Text = "Seleziona file ISO:"
$form.Controls.Add($labelISOFile)

# Create textbox for ISO file
$textBoxISOFile = New-Object System.Windows.Forms.TextBox
$textBoxISOFile.Location = New-Object System.Drawing.Point(10,40)
$textBoxISOFile.Size = New-Object System.Drawing.Size(350,20) 
$form.Controls.Add($textBoxISOFile)

# Create browse button
$browseButton = New-Object System.Windows.Forms.Button
$browseButton.Location = New-Object System.Drawing.Point(370,38) 
$browseButton.Size = New-Object System.Drawing.Size(80,20)
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
    }
})
$form.Controls.Add($browseButton)

# Create group box for System Info
$groupBoxSystemInfo = New-Object System.Windows.Forms.GroupBox
$groupBoxSystemInfo.Location = New-Object System.Drawing.Point(240, 310)
$groupBoxSystemInfo.Size = New-Object System.Drawing.Size(230, 90) 
$groupBoxSystemInfo.Text = "System Info"
$groupBoxSystemInfo.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxSystemInfo)

# Get Windows version, architecture
$winVersion = Get-ComputerInfo | Select-Object -ExpandProperty OSName
$arch = Get-ComputerInfo | Select-Object -ExpandProperty OsArchitecture

# Create label text with the gathered information
$labelText = "Windows Version: $winVersion`n`nArchitecture: $arch`n`n"

# Create label to display system info
$labelSystemInfo = New-Object System.Windows.Forms.Label
$labelSystemInfo.Location = New-Object System.Drawing.Point(10, 20)
$labelSystemInfo.Size = New-Object System.Drawing.Size(180, 60)
$labelSystemInfo.Text = $labelText

# Add label to group box
$groupBoxSystemInfo.Controls.Add($labelSystemInfo)

# Create group box for Ottimizzare SO
$groupBoxDebloat = New-Object System.Windows.Forms.GroupBox
$groupBoxDebloat.Location = New-Object System.Drawing.Point(240, 150) 
$groupBoxDebloat.Size = New-Object System.Drawing.Size(220,70)   
$groupBoxDebloat.Text = "Ottimizzare SO"
$groupBoxDebloat.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxDebloat)

# Create radio buttons for Windows version
$radioButtonOttimizza = New-Object System.Windows.Forms.RadioButton
$radioButtonOttimizza.Location = New-Object System.Drawing.Point(10,20)
$radioButtonOttimizza.Size = New-Object System.Drawing.Size(120,20)
$radioButtonOttimizza.Text = "Ottimizza"
$groupBoxDebloat.Controls.Add($radioButtonOttimizza)

$radioButtonNonOttimizza = New-Object System.Windows.Forms.RadioButton
$radioButtonNonOttimizza.Location = New-Object System.Drawing.Point(10,45)
$radioButtonNonOttimizza.Size = New-Object System.Drawing.Size(120,20)
$radioButtonNonOttimizza.Text = "Non Ottimizzare"
$groupBoxDebloat.Controls.Add($radioButtonNonOttimizza)

# Create group box for Debloat APP
$groupBoxDebloatapp = New-Object System.Windows.Forms.GroupBox
$groupBoxDebloatapp.Location = New-Object System.Drawing.Point(240, 70) 
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
$donateButton.Location = New-Object System.Drawing.Point(240, 440) 
$donateButton.Size = New-Object System.Drawing.Size(100,23) 
$donateButton.Text = "Donate"
$donateButton.Add_Click({
    Start-Process "https://ko-fi.com/winhubx"
})
$form.Controls.Add($donateButton)

# Create group box for Windows version
$groupBoxWindowsVersion = New-Object System.Windows.Forms.GroupBox
$groupBoxWindowsVersion.Location = New-Object System.Drawing.Point(10, 70)
$groupBoxWindowsVersion.Size = New-Object System.Drawing.Size(220,70)
$groupBoxWindowsVersion.Text = "Seleziona versione Windows"
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
$radioButtonWindows11.Add_CheckedChanged({
UpdateUnattendGroup $radioButtonWindows11.Checked
})


# Unattend
function UpdateUnattendGroup($isChecked) {
    # Remove the group box if it exists to reset the state
    if ($script:groupBoxUnattend) {
        $form.Controls.Remove($script:groupBoxUnattend)
        $script:groupBoxUnattend.Dispose()
        $script:groupBoxUnattend = $null
}

if ($isChecked) {
$groupBoxUnattend = New-Object System.Windows.Forms.GroupBox
$groupBoxUnattend.Location = New-Object System.Drawing.Point(240, 230)
$groupBoxUnattend.Size = New-Object System.Drawing.Size(220,70)
$groupBoxUnattend.Text = "Seleziona Bypass Windows11"
$groupBoxUnattend.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxUnattend)

# Create radio buttons for Windows version
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
}
}

# Create group box for Edge removal preference
$groupBoxEdgeRemoval = New-Object System.Windows.Forms.GroupBox
$groupBoxEdgeRemoval.Location = New-Object System.Drawing.Point(10, 150)
$groupBoxEdgeRemoval.Size = New-Object System.Drawing.Size(220,70)
$groupBoxEdgeRemoval.Text = "Seleziona preferenza Microsoft Edge"
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
$groupBoxDefenderPreference.Location = New-Object System.Drawing.Point(10, 230)
$groupBoxDefenderPreference.Size = New-Object System.Drawing.Size(220,70)
$groupBoxDefenderPreference.Text = "Seleziona preferenza Windows Defender"
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
$radioButtonDoNotDisableDefender.Text = "Non disabilitare Windows Defender"
$groupBoxDefenderPreference.Controls.Add($radioButtonDoNotDisableDefender)

# Create group box for Windows Edition
$groupBoxWindowsEdition = New-Object System.Windows.Forms.GroupBox
$groupBoxWindowsEdition.Location = New-Object System.Drawing.Point(10, 310)
$groupBoxWindowsEdition.Size = New-Object System.Drawing.Size(220,70)
$groupBoxWindowsEdition.Text = "Seleziona Edizione Windows"
$groupBoxWindowsEdition.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxWindowsEdition)

# Create radio buttons for Windows Edition
$radioButtonHome = New-Object System.Windows.Forms.RadioButton
$radioButtonHome.Location = New-Object System.Drawing.Point(10,20)
$radioButtonHome.Size = New-Object System.Drawing.Size(120,20)
$radioButtonHome.Text = "Home"
$groupBoxWindowsEdition.Controls.Add($radioButtonHome)

$radioButtonPro = New-Object System.Windows.Forms.RadioButton
$radioButtonPro.Location = New-Object System.Drawing.Point(10,45)
$radioButtonPro.Size = New-Object System.Drawing.Size(120,20)
$radioButtonPro.Text = "Pro"
$groupBoxWindowsEdition.Controls.Add($radioButtonPro)


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
$buildButton.Location = New-Object System.Drawing.Point(360,440) 
$buildButton.Size = New-Object System.Drawing.Size(100,23) 
$buildButton.Text = "Build!"
$buildButton.Add_Click({
    if ($textBoxISOFile.Text -eq "") {
        [System.Windows.Forms.MessageBox]::Show("Please select an ISO file.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
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

    if (-not ($radioButtonHome.Checked -or $radioButtonPro.Checked)) {
        [System.Windows.Forms.MessageBox]::Show("Seleziona l'edizione Windows.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
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

    if (-not ($radioButtonOttimizza.Checked -or $radioButtonNonOttimizza.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se Ottimizzare il SO.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    $selectedFile = $textBoxISOFile.Text
    $windowsVersion = if ($radioButtonWindows10.Checked) { "Windows 10" } else { "Windows 11" }
    $edgeRemovalPreference = if ($radioButtonRemoveEdge.Checked) { "RemoveEdge" } else { "Do Not Remove Edge" }
    $defenderPreference = if ($radioButtonDisableDefender.Checked) { "DisableWindowsDefender" } else { "Do Not Disable Windows Defender" }
    $windowsEdition = if ($radioButtonHome.Checked) { "Home" } else { "Pro" }
    $Processi = if ($radioButtonRimuoviProcessi.Checked) { "RimuoviProcessi" } else { "NonRimuovereProcessi" }
    $Unattend = if ($radioButtonStock.Checked) { "Stock" } else { "Bypass" }
    $OttimizzaSO = if ($radioButtonOttimizza.Checked) { "Ottimizza" } else { "NonOttimizza" }
    $DebloatApp = if ($radioButtonDebloatAPP.Checked) { "Debloat" } else { "NonDebloat" }

    cls

        $arguments = @(
        """$selectedFile""",
        """$windowsVersion""",
        """$edgeRemovalPreference""",
        """$defenderPreference""",
        """$windowsEdition"""
        """$Processi"""
        """$Unattend"""
        """$OttimizzaSO"""
        """$DebloatApp"""
    )

    $argumentString = $arguments -join ' '

    if ($windowsVersion -eq "Windows 10") {
        Start-Process -FilePath "$path_to_use\isotool10.bat" -ArgumentList "$argumentString" 
    }
    else {
        Start-Process -FilePath "$path_to_use\isotool11.bat" -ArgumentList "$argumentString"
    }

    $form.DialogResult = [System.Windows.Forms.DialogResult]::OK
    $form.Close()
})
$form.Controls.Add($buildButton)

# Add event handler for OK button click
$form.Add_Shown({$form.Activate()})
$form.ShowDialog() | Out-Null
####################################
