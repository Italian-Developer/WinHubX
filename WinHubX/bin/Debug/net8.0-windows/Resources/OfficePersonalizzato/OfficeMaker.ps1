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
$form.Text = "Office Custom Maker"
$form.Size = New-Object System.Drawing.Size(480,515) 
$form.StartPosition = "CenterScreen"
$form.FormBorderStyle = 'FixedDialog'

# Set form background color to dark
$form.BackColor = [System.Drawing.Color]::FromArgb(40, 40, 40)

# Set text color to white
$form.ForeColor = [System.Drawing.Color]::White

# Create x64 or x32
$groupBoxArchitettura = New-Object System.Windows.Forms.GroupBox
$groupBoxArchitettura.Location = New-Object System.Drawing.Point(10,20)
$groupBoxArchitettura.Size = New-Object System.Drawing.Size(220,70)
$groupBoxArchitettura.Text = "Seleziona Architettura"
$groupBoxArchitettura.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxArchitettura)

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

# Create group box for Office
$groupBoxVersioneOffice = New-Object System.Windows.Forms.GroupBox
$groupBoxVersioneOffice.Location = New-Object System.Drawing.Point(10,90) 
$groupBoxVersioneOffice.Size = New-Object System.Drawing.Size(220,70)   
$groupBoxVersioneOffice.Text = "Seleziona Versione Office"
$groupBoxVersioneOffice.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxVersioneOffice)

$radioButton2021 = New-Object System.Windows.Forms.RadioButton
$radioButton2021.Location = New-Object System.Drawing.Point(10,20)
$radioButton2021.Size = New-Object System.Drawing.Size(120,20)
$radioButton2021.Text = "Office 2021"
$groupBoxVersioneOffice.Controls.Add($radioButton2021)

$radioButton365 = New-Object System.Windows.Forms.RadioButton
$radioButton365.Location = New-Object System.Drawing.Point(10,45)
$radioButton365.Size = New-Object System.Drawing.Size(120,20)
$radioButton365.Text = "Office 365"
$groupBoxVersioneOffice.Controls.Add($radioButton365)

# Create group box for Word
$groupBoxWord = New-Object System.Windows.Forms.GroupBox
$groupBoxWord.Location = New-Object System.Drawing.Point(10,160)
$groupBoxWord.Size = New-Object System.Drawing.Size(220,70)
$groupBoxWord.Text = "Vuoi Word?"
$groupBoxWord.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxWord)

$radioButtonWordSi = New-Object System.Windows.Forms.RadioButton
$radioButtonWordSi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonWordSi.Size = New-Object System.Drawing.Size(120,20)
$radioButtonWordSi.Text = "Si"
$groupBoxWord.Controls.Add($radioButtonWordSi)

$radioButtonWordNo = New-Object System.Windows.Forms.RadioButton
$radioButtonWordNo.Location = New-Object System.Drawing.Point(10,45)
$radioButtonWordNo.Size = New-Object System.Drawing.Size(120,20)
$radioButtonWordNo.Text = "No"
$groupBoxWord.Controls.Add($radioButtonWordNo)

# Create group box for Excel
$groupBoxExcel = New-Object System.Windows.Forms.GroupBox
$groupBoxExcel.Location = New-Object System.Drawing.Point(10,230)
$groupBoxExcel.Size = New-Object System.Drawing.Size(220,70)
$groupBoxExcel.Text = "Vuoi Excel?"
$groupBoxExcel.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxExcel)

$radioButtonExcelSi = New-Object System.Windows.Forms.RadioButton
$radioButtonExcelSi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonExcelSi.Size = New-Object System.Drawing.Size(120,20)
$radioButtonExcelSi.Text = "Si"
$groupBoxExcel.Controls.Add($radioButtonExcelSi)

$radioButtonExcelNo = New-Object System.Windows.Forms.RadioButton
$radioButtonExcelNo.Location = New-Object System.Drawing.Point(10,45)
$radioButtonExcelNo.Size = New-Object System.Drawing.Size(120,20)
$radioButtonExcelNo.Text = "No"
$groupBoxExcel.Controls.Add($radioButtonExcelNo)

# Create group box for PowerPoint
$groupBoxPowerPoint = New-Object System.Windows.Forms.GroupBox
$groupBoxPowerPoint.Location = New-Object System.Drawing.Point(10,300)
$groupBoxPowerPoint.Size = New-Object System.Drawing.Size(220,70)
$groupBoxPowerPoint.Text = "Vuoi PowerPoint?"
$groupBoxPowerPoint.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxPowerPoint)

$radioButtonPowerPointSi = New-Object System.Windows.Forms.RadioButton
$radioButtonPowerPointSi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonPowerPointSi.Size = New-Object System.Drawing.Size(120,20)
$radioButtonPowerPointSi.Text = "Si"
$groupBoxPowerPoint.Controls.Add($radioButtonPowerPointSi)

$radioButtonPowerPointNo = New-Object System.Windows.Forms.RadioButton
$radioButtonPowerPointNo.Location = New-Object System.Drawing.Point(10,45)
$radioButtonPowerPointNo.Size = New-Object System.Drawing.Size(120,20)
$radioButtonPowerPointNo.Text = "No"
$groupBoxPowerPoint.Controls.Add($radioButtonPowerPointNo)

# Create group box for Access
$groupBoxAccess = New-Object System.Windows.Forms.GroupBox
$groupBoxAccess.Location = New-Object System.Drawing.Point(10,370)
$groupBoxAccess.Size = New-Object System.Drawing.Size(220,70)
$groupBoxAccess.Text = "Vuoi Access?"
$groupBoxAccess.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxAccess)

$radioButtonAccessSi = New-Object System.Windows.Forms.RadioButton
$radioButtonAccessSi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonAccessSi.Size = New-Object System.Drawing.Size(120,20)
$radioButtonAccessSi.Text = "Si"
$groupBoxAccess.Controls.Add($radioButtonAccessSi)

$radioButtonAccessNo = New-Object System.Windows.Forms.RadioButton
$radioButtonAccessNo.Location = New-Object System.Drawing.Point(10,45)
$radioButtonAccessNo.Size = New-Object System.Drawing.Size(120,20)
$radioButtonAccessNo.Text = "No"
$groupBoxAccess.Controls.Add($radioButtonAccessNo)

# Create group box for Onedrive
$groupBoxOneDrive = New-Object System.Windows.Forms.GroupBox
$groupBoxOneDrive.Location = New-Object System.Drawing.Point(240,20)
$groupBoxOneDrive.Size = New-Object System.Drawing.Size(220,70)
$groupBoxOneDrive.Text = "Vuoi OneDrive?"
$groupBoxOneDrive.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxOneDrive)

$radioButtonOneDriveSi = New-Object System.Windows.Forms.RadioButton
$radioButtonOneDriveSi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonOneDriveSi.Size = New-Object System.Drawing.Size(120,20)
$radioButtonOneDriveSi.Text = "Si"
$groupBoxOneDrive.Controls.Add($radioButtonOneDriveSi)

$radioButtonOneDriveNo = New-Object System.Windows.Forms.RadioButton
$radioButtonOneDriveNo.Location = New-Object System.Drawing.Point(10,45)
$radioButtonOneDriveNo.Size = New-Object System.Drawing.Size(120,20)
$radioButtonOneDriveNo.Text = "No"
$groupBoxOneDrive.Controls.Add($radioButtonOneDriveNo)

# Create group box for OneNote
$groupBoxOneNote = New-Object System.Windows.Forms.GroupBox
$groupBoxOneNote.Location = New-Object System.Drawing.Point(240,90)
$groupBoxOneNote.Size = New-Object System.Drawing.Size(220,70)
$groupBoxOneNote.Text = "Vuoi OneNote?"
$groupBoxOneNote.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxOneNote)

$radioButtonOneNoteSi = New-Object System.Windows.Forms.RadioButton
$radioButtonOneNoteSi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonOneNoteSi.Size = New-Object System.Drawing.Size(120,20)
$radioButtonOneNoteSi.Text = "Si"
$groupBoxOneNote.Controls.Add($radioButtonOneNoteSi)

$radioButtonOneNoteNo = New-Object System.Windows.Forms.RadioButton
$radioButtonOneNoteNo.Location = New-Object System.Drawing.Point(10,45)
$radioButtonOneNoteNo.Size = New-Object System.Drawing.Size(120,20)
$radioButtonOneNoteNo.Text = "No"
$groupBoxOneNote.Controls.Add($radioButtonOneNoteNo)

# Create group box for Outlook
$groupBoxOutlook = New-Object System.Windows.Forms.GroupBox
$groupBoxOutlook.Location = New-Object System.Drawing.Point(240,160)
$groupBoxOutlook.Size = New-Object System.Drawing.Size(220,70)
$groupBoxOutlook.Text = "Vuoi Outlook?"
$groupBoxOutlook.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxOutlook)

$radioButtonOutlookSi = New-Object System.Windows.Forms.RadioButton
$radioButtonOutlookSi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonOutlookSi.Size = New-Object System.Drawing.Size(120,20)
$radioButtonOutlookSi.Text = "Si"
$groupBoxOutlook.Controls.Add($radioButtonOutlookSi)

$radioButtonOutlookNo = New-Object System.Windows.Forms.RadioButton
$radioButtonOutlookNo.Location = New-Object System.Drawing.Point(10,45)
$radioButtonOutlookNo.Size = New-Object System.Drawing.Size(120,20)
$radioButtonOutlookNo.Text = "No"
$groupBoxOutlook.Controls.Add($radioButtonOutlookNo)

# Create group box for Publisher
$groupBoxPublisher = New-Object System.Windows.Forms.GroupBox
$groupBoxPublisher.Location = New-Object System.Drawing.Point(240,300)
$groupBoxPublisher.Size = New-Object System.Drawing.Size(220,70)
$groupBoxPublisher.Text = "Vuoi Publisher?"
$groupBoxPublisher.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxPublisher)

$radioButtonPublisherSi = New-Object System.Windows.Forms.RadioButton
$radioButtonPublisherSi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonPublisherSi.Size = New-Object System.Drawing.Size(120,20)
$radioButtonPublisherSi.Text = "Si"
$groupBoxPublisher.Controls.Add($radioButtonPublisherSi)

$radioButtonPublisherNo = New-Object System.Windows.Forms.RadioButton
$radioButtonPublisherNo.Location = New-Object System.Drawing.Point(10,45)
$radioButtonPublisherNo.Size = New-Object System.Drawing.Size(120,20)
$radioButtonPublisherNo.Text = "No"
$groupBoxPublisher.Controls.Add($radioButtonPublisherNo)

# Create group box for Visio
$groupBoxVisio = New-Object System.Windows.Forms.GroupBox
$groupBoxVisio.Location = New-Object System.Drawing.Point(240,230)
$groupBoxVisio.Size = New-Object System.Drawing.Size(220,70)
$groupBoxVisio.Text = "Vuoi Visio?"
$groupBoxVisio.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxVisio)

$radioButtonVisioSi = New-Object System.Windows.Forms.RadioButton
$radioButtonVisioSi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonVisioSi.Size = New-Object System.Drawing.Size(120,20)
$radioButtonVisioSi.Text = "Si"
$groupBoxVisio.Controls.Add($radioButtonVisioSi)

$radioButtonVisioNo = New-Object System.Windows.Forms.RadioButton
$radioButtonVisioNo.Location = New-Object System.Drawing.Point(10,45)
$radioButtonVisioNo.Size = New-Object System.Drawing.Size(120,20)
$radioButtonVisioNo.Text = "No"
$groupBoxVisio.Controls.Add($radioButtonVisioNo)

# Create group box for Project
$groupBoxProject = New-Object System.Windows.Forms.GroupBox
$groupBoxProject.Location = New-Object System.Drawing.Point(240,370)
$groupBoxProject.Size = New-Object System.Drawing.Size(220,70)
$groupBoxProject.Text = "Vuoi Project?"
$groupBoxProject.ForeColor = [System.Drawing.Color]::White
$form.Controls.Add($groupBoxProject)

$radioButtonProjectSi = New-Object System.Windows.Forms.RadioButton
$radioButtonProjectSi.Location = New-Object System.Drawing.Point(10,20)
$radioButtonProjectSi.Size = New-Object System.Drawing.Size(120,20)
$radioButtonProjectSi.Text = "Si"
$groupBoxProject.Controls.Add($radioButtonProjectSi)

$radioButtonProjectNo = New-Object System.Windows.Forms.RadioButton
$radioButtonProjectNo.Location = New-Object System.Drawing.Point(10,45)
$radioButtonProjectNo.Size = New-Object System.Drawing.Size(120,20)
$radioButtonProjectNo.Text = "No"
$groupBoxProject.Controls.Add($radioButtonProjectNo)

# Create donate button
$donateButton = New-Object System.Windows.Forms.Button
$donateButton.Location = New-Object System.Drawing.Point(240, 455) 
$donateButton.Size = New-Object System.Drawing.Size(100,23) 
$donateButton.Text = "Donate"
$donateButton.Add_Click({
    Start-Process "https://ko-fi.com/winhubx"
})
$form.Controls.Add($donateButton)

# Create OK button
$buildButton = New-Object System.Windows.Forms.Button
$buildButton.Location = New-Object System.Drawing.Point(360,455) 
$buildButton.Size = New-Object System.Drawing.Size(100,23) 
$buildButton.Text = "Build!"
$buildButton.Add_Click({

    if (-not ($radioButtonx64.Checked -or $radioButtonx32.Checked -or $radioButtonarm64.Checked )) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona la tua architettura.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
     return
    }

    if (-not ($radioButton2021.Checked -or $radioButton365.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona quale versione di Office installare.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
     return
    }

    if (-not ($radioButtonWordSi.Checked -or $radioButtonWordNo.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se vuoi Word.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
     return
    }

    if (-not ($radioButtonExcelSi.Checked -or $radioButtonExcelNo.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se vuoi Excel.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    if (-not ($radioButtonPowerPointSi.Checked -or $radioButtonPowerPointNo.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se vuoi PowerPoint.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    if (-not ($radioButtonAccessSi.Checked -or $radioButtonAccessNo.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se vuoi Access.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    if (-not ($radioButtonOneDriveSi.Checked -or $radioButtonOneDriveNo.Checked)) {
       [System.Windows.Forms.MessageBox]::Show("Seleziona se vuoi OneDrive.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
       return
    }
     
    if (-not ($radioButtonOneNoteSi.Checked -or $radioButtonOneNoteNo.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se vuoi OneNote.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    if (-not ($radioButtonOutlookSi.Checked -or $radioButtonOutlookNo.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se vuoi Outlook.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    if (-not ($radioButtonPublisherSi.Checked -or $radioButtonPublisherNo.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se vuoi Publisher.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    if (-not ($radioButtonVisioSi.Checked -or $radioButtonVisioNo.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se vuoi Visio.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    if (-not ($radioButtonProjectSi.Checked -or $radioButtonProjectNo.Checked)) {
    [System.Windows.Forms.MessageBox]::Show("Seleziona se vuoi Project.", "Error", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Error)
    return
    }

    $architettura = if ($radioButtonx64.Checked) { "x64" } if ($radioButtonarm64.Cheked) { "arm64" } else { "x32" }
    $VersioneOffice = if ($radioButton2021.Checked) { "2021" } else { "365" }
    $word = if ($radioButtonWordSi.Checked) { "Word" } else { "" }
    $excel = if ($radioButtonExcelSi.Checked) { "Excel" } else { "" }
    $powerpoint = if ($radioButtonPowerPointSi.Checked) { "PowerPoint" } else { "" }
    $acces = if ($radioButtonAccessSi.Checked) { "Access" } else { "" }
    $onedrive = if ($radioButtonOneDriveSi.Checked) { "OneDrive" } else { "" }
    $OneNote = if ($radioButtonOneNoteSi.Checked) { "OneNote" } else { "" }
    $outlook= if ($radioButtonOutlookSi.Checked) { "Outlook" } else { "" }
    $publisher = if ($radioButtonPublisherSi.Checked) { "Publisher" } else { "" }
    
 if ($VersioneOffice -eq "2021") {
    # Create the configuration XML
    $configXML = @"
    <Configuration ID="37d1a293-ccee-4ee2-a953-86c3143f0337">
    <Add OfficeClientEdition="$architettura" Channel="PerpetualVL2021" MigrateArch="TRUE">
    <Product ID="ProPlus2021Volume" PIDKEY="FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH">
      <Language ID="it-it" />
      <ExcludeApp ID="$acces" />
      <ExcludeApp ID="$excel" />
      <ExcludeApp ID="Lync" />
      <ExcludeApp ID="$onedrive" />
      <ExcludeApp ID="$OneNote" />
      <ExcludeApp ID="$outlook" />
      <ExcludeApp ID="$powerpoint" />
      <ExcludeApp ID="$publisher" />
      <ExcludeApp ID="$word" />
    </Product>
"@

# Save the configuration to a file
$configXML | Out-File -FilePath "C:\configuration-$architettura-complete.xml" -Encoding UTF8

$visio = if ($radioButtonVisioSi.Checked) {
@"
<Product ID="VisioPro2021Volume" PIDKEY="KNH8D-FGHT4-T8RK3-CTDYJ-K2HT4">
  <Language ID="it-it" />
  <ExcludeApp ID="$acces" />
  <ExcludeApp ID="$excel" />
  <ExcludeApp ID="Lync" />
  <ExcludeApp ID="$onedrive" />
  <ExcludeApp ID="$OneNote" />
  <ExcludeApp ID="$outlook" />
  <ExcludeApp ID="$powerpoint" />
  <ExcludeApp ID="$publisher" />
  <ExcludeApp ID="$word" />
  <ExcludeApp ID="Lync" />
</Product>
"@ | Out-File -Append -FilePath "C:\configuration-x64-complete.xml" -Encoding UTF8
}

$project = if ($radioButtonProjectSi.Checked) {
    @"
<Product ID="ProjectPro2021Volume" PIDKEY="FTNWT-C6WBT-8HMGF-K9PRX-QV9H8">
  <Language ID="it-it" />
  <ExcludeApp ID="$acces" />
  <ExcludeApp ID="$excel" />
  <ExcludeApp ID="Lync" />
  <ExcludeApp ID="$onedrive" />
  <ExcludeApp ID="$OneNote" />
  <ExcludeApp ID="$outlook" />
  <ExcludeApp ID="$powerpoint" />
  <ExcludeApp ID="$publisher" />
  <ExcludeApp ID="$word" />
  <ExcludeApp ID="Lync" />
</Product>
 </Add>
<Property Name="SharedComputerLicensing" Value="0" />
<Property Name="FORCEAPPSHUTDOWN" Value="FALSE" />
<Property Name="DeviceBasedLicensing" Value="0" />
<Property Name="SCLCacheOverride" Value="0" />
<Property Name="AUTOACTIVATE" Value="1" />
<Updates Enabled="TRUE" />
<RemoveMSI />
</Configuration>
"@ | Out-File -Append -FilePath "C:\configuration-$architettura-complete.xml" -Encoding UTF8
}
else {
    @"
</Add>
<Property Name="SharedComputerLicensing" Value="0" />
<Property Name="FORCEAPPSHUTDOWN" Value="FALSE" />
<Property Name="DeviceBasedLicensing" Value="0" />
<Property Name="SCLCacheOverride" Value="0" />
<Property Name="AUTOACTIVATE" Value="1" />
<Updates Enabled="TRUE" />
<RemoveMSI />
</Configuration>
"@ | Out-File -Append -FilePath "C:\configuration-$architettura-complete.xml" -Encoding UTF8
}
}

 if ($VersioneOffice -eq "365") {
    # Create the configuration XML
    $configXML = @"
    <Configuration ID="c229623f-798c-40c1-af05-257cd95c8998">
    <Add OfficeClientEdition="$architettura" Channel="SemiAnnual">
    <Product ID="O365BusinessRetail">
      <Language ID="it-it" />
      <ExcludeApp ID="$acces" />
      <ExcludeApp ID="$excel" />
      <ExcludeApp ID="Lync" />
      <ExcludeApp ID="$onedrive" />
      <ExcludeApp ID="$OneNote" />
      <ExcludeApp ID="$outlook" />
      <ExcludeApp ID="$powerpoint" />
      <ExcludeApp ID="$publisher" />
      <ExcludeApp ID="Teams" />
      <ExcludeApp ID="$word" />
    </Product>
"@
$configXML | Out-File -FilePath "C:\configuration-$architettura-complete.xml" -Encoding UTF8

$visio = if ($radioButtonVisioSi.Checked) {
@"
<Product ID="VisioPro2021Volume" PIDKEY="KNH8D-FGHT4-T8RK3-CTDYJ-K2HT4">
  <Language ID="it-it" />
  <ExcludeApp ID="Lync" />
</Product>
"@ | Out-File -Append -FilePath "C:\configuration-$architettura-complete.xml" -Encoding UTF8
}

$project = if ($radioButtonProjectSi.Checked) {
    @"
<Product ID="ProjectPro2021Volume" PIDKEY="FTNWT-C6WBT-8HMGF-K9PRX-QV9H8">
  <Language ID="it-it" />
  <ExcludeApp ID="Lync" />
</Product>
 </Add>
<Property Name="SharedComputerLicensing" Value="0" />
<Property Name="FORCEAPPSHUTDOWN" Value="FALSE" />
<Property Name="DeviceBasedLicensing" Value="0" />
<Property Name="SCLCacheOverride" Value="0" />
<Property Name="AUTOACTIVATE" Value="1" />
<Updates Enabled="TRUE" />
<RemoveMSI />
</Configuration>
"@ | Out-File -Append -FilePath "C:\configuration-$architettura-complete.xml" -Encoding UTF8
}
else {
    @"
</Add>
<Property Name="SharedComputerLicensing" Value="0" />
<Property Name="FORCEAPPSHUTDOWN" Value="FALSE" />
<Property Name="DeviceBasedLicensing" Value="0" />
<Property Name="SCLCacheOverride" Value="0" />
<Property Name="AUTOACTIVATE" Value="1" />
<Updates Enabled="TRUE" />
<RemoveMSI />
</Configuration>
"@ | Out-File -Append -FilePath "C:\configuration-$architettura-complete.xml" -Encoding UTF8
}
}

cls
        $arguments = @(
        """$architettura"""
    )

    $argumentString = $arguments -join ' '
    Start-Process -FilePath "$path_to_use\installeroffice.bat" -ArgumentList "$argumentString" 



    $form.DialogResult = [System.Windows.Forms.DialogResult]::OK
    $form.Close()
})
$form.Controls.Add($buildButton)

# Add event handler for OK button click
$form.Add_Shown({$form.Activate()})
$form.ShowDialog() | Out-Null
####################################
