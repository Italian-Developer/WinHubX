using System.Management.Automation;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.Settaggi
{
    public partial class FormUtility : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormUtility(FormSettaggi formSettaggi, Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formSettaggi = formSettaggi;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Settaggi";
            form1.PnlFormLoader.Controls.Clear();
            formSettaggi = new FormSettaggi(form1)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            form1.PnlFormLoader.Controls.Add(formSettaggi);
            formSettaggi.Show();
        }

        private void btnAvviaSelezionatiUti_Click(object sender, EventArgs e)
        {
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Background App"))
            {
                using (PowerShell PowerShellInstanceDisabilitaBackgroundApp = PowerShell.Create())
                {
                    string scriptDisabilitaBackgroundApp = @"
                     Get-ChildItem -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications"" -Exclude ""Microsoft.Windows.Cortana*"" | ForEach {
                     Set-ItemProperty -Path $_.PsPath -Name ""Disabled"" -Type DWord -Value 1
                     Set-ItemProperty -Path $_.PsPath -Name ""DisabledByUser"" -Type DWord -Value 1}";
                    PowerShellInstanceDisabilitaBackgroundApp.AddScript(scriptDisabilitaBackgroundApp);
                    var result = PowerShellInstanceDisabilitaBackgroundApp.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita Feedback"))
            {
                using (PowerShell PowerShellInstanceDisabilitaFeedback = PowerShell.Create())
                {
                    string scriptDisabilitaFeedback = @"
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Siuf\Rules"" -Name ""NumberOfSIUFInPeriod"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection"" -Name ""DoNotShowFeedbackNotifications"" -Type DWord -Value 1;
                     Disable-ScheduledTask -TaskName ""Microsoft\Windows\Feedback\Siuf\DmClient"" -ErrorAction SilentlyContinue;
                     Disable-ScheduledTask -TaskName ""Microsoft\Windows\Feedback\Siuf\DmClientOnScenarioDownload"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceDisabilitaFeedback.AddScript(scriptDisabilitaFeedback);
                    var result = PowerShellInstanceDisabilitaFeedback.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita Advertising ID"))
            {
                using (PowerShell PowerShellInstanceDisabilitaAdvertisingID = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaAdvertisingID.AddScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AdvertisingInfo"" -Name ""DisabledByGroupPolicy"" -Type DWord -Value 1");
                    var result = PowerShellInstanceDisabilitaAdvertisingID.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita Filtro Smart Screen"))
            {
                using (PowerShell PowerShellInstanceDisabilitaFiltroSmartScreen = PowerShell.Create())
                {
                    string scriptDisabilitaFiltroSmartScreen = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableSmartScreen"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter"" -Name ""EnabledV9"" -Type DWord -Value 0";
                    PowerShellInstanceDisabilitaFiltroSmartScreen.AddScript(scriptDisabilitaFiltroSmartScreen);
                    var result = PowerShellInstanceDisabilitaFiltroSmartScreen.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita Wifi Sense"))
            {
                using (PowerShell PowerShellInstanceDisabilitaWifiSense = PowerShell.Create())
                {
                    string scriptDisabilitaWifiSense = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowWiFiHotSpotReporting"" -Name ""Value"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowAutoConnectToWiFiSenseHotspots"" -Name ""Value"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config"" -Name ""AutoConnectAllowedOEM"" -Type Dword -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config"" -Name ""WiFISenseAllowed"" -Type Dword -Value 0";
                    PowerShellInstanceDisabilitaWifiSense.AddScript(scriptDisabilitaWifiSense);
                    var result = PowerShellInstanceDisabilitaWifiSense.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita Desktop Remoto"))
            {
                using (PowerShell PowerShellInstanceDisabilitaDesktopRemoto = PowerShell.Create())
                {
                    string scriptDisabilitaDesktopRemoto = @"
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server"" -Name ""fDenyTSConnections"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp"" -Name ""UserAuthentication"" -Type DWord -Value 1";
                    PowerShellInstanceDisabilitaDesktopRemoto.AddScript(scriptDisabilitaDesktopRemoto);
                    var result = PowerShellInstanceDisabilitaDesktopRemoto.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita attivazione del Numlock in avvio"))
            {
                using (PowerShell PowerShellInstanceDisabilitaattivazionedelNumlockinavvio = PowerShell.Create())
                {
                    string scriptDisabilitaattivazionedelNumlockinavvio = @"
		             New-PSDrive -Name ""HKU"" -PSProvider ""Registry"" -Root ""HKEY_USERS"" | Out-Null
	               	 Set-ItemProperty -Path ""HKU:\.DEFAULT\Control Panel\Keyboard"" -Name ""InitialKeyboardIndicators"" -Type DWord -Value 2147483648
	                 Add-Type -AssemblyName System.Windows.Forms
	                 If ([System.Windows.Forms.Control]::IsKeyLocked('NumLock')) {
		             $wsh = New-Object -ComObject WScript.Shell
		             $wsh.SendKeys('{NUMLOCK}')
	                 }";
                    PowerShellInstanceDisabilitaattivazionedelNumlockinavvio.AddScript(scriptDisabilitaattivazionedelNumlockinavvio);
                    var result = PowerShellInstanceDisabilitaattivazionedelNumlockinavvio.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita News e Interessi"))
            {
                using (PowerShell PowerShellInstanceDisabilitaNewseInteressi = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaNewseInteressi.AddScript(@"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Policies\Microsoft\Windows\Windows Feeds"" -Name ""EnableFeeds"" -Type DWord -Value 0");
                    var result = PowerShellInstanceDisabilitaNewseInteressi.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita Index File"))
            {
                using (PowerShell PowerShellInstanceDisabilitaIndexFile = PowerShell.Create())
                {
                    string scriptDisabilitaIndexFile = @"
                     $obj = Get-WmiObject -Class Win32_Volume -Filter ""DriveLetter='$Drive'""
                     $indexing = $obj.IndexingEnabled
                     if(""$indexing"" -eq $True){
                     write-host ""Disabling indexing of drive $Drive""
                     $obj | Set-WmiInstance -Arguments @{IndexingEnabled=$False} | Out-Null
                     }";
                    PowerShellInstanceDisabilitaIndexFile.AddScript(scriptDisabilitaIndexFile);
                    var result = PowerShellInstanceDisabilitaIndexFile.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita Edge PDF"))
            {
                using (PowerShell PowerShellInstanceDisabilitaEdgePDF = PowerShell.Create())
                {
                    string scriptDisabilitaEdgePDF = @"
                     $NoPDF = ""HKCR:\.pdf""
                     $NoProgids = ""HKCR:\.pdf\OpenWithProgids""
                     $NoWithList = ""HKCR:\.pdf\OpenWithList"" 
                     New-ItemProperty $NoPDF NoOpenWith 
                     New-ItemProperty $NoPDF  NoStaticDefaultVerb 
                     New-ItemProperty $NoProgids  NoOpenWith 
                     New-ItemProperty $NoProgids  NoStaticDefaultVerb 
                     New-ItemProperty $NoWithList  NoOpenWith
                     New-ItemProperty $NoWithList  NoStaticDefaultVerb 
                     $Edge = ""HKCR:\AppXd4nrz8ff68srnhf9t5a8sbjyar1cr723_""
                     If (Test-Path $Edge) {
                     Set-Item $Edge AppXd4nrz8ff68srnhf9t5a8sbjyar1cr723_ 
                     } ";
                    PowerShellInstanceDisabilitaEdgePDF.AddScript(scriptDisabilitaEdgePDF);
                    var result = PowerShellInstanceDisabilitaEdgePDF.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita Mappe"))
            {
                using (PowerShell PowerShellInstanceDisabilitaMappe = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaMappe.AddScript(@"Set-ItemProperty -Path ""HKLM:\SYSTEM\Maps"" -Name ""AutoUpdateEnabled"" -Type DWord -Value 0");
                    var result = PowerShellInstanceDisabilitaMappe.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita UWP apps"))
            {
                using (PowerShell PowerShellInstanceDisabilitaUWPapps = PowerShell.Create())
                {
                    string scriptDisabilitaUWPapps = @"
                     If ([System.Environment]::OSVersion.Version.Build -ge 17763) {
                     If (!(Test-Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"")) {
                     New-Item -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Force
                     }
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsRunInBackground"" -Type DWord -Value 2
                     } Else {
                     Get-ChildItem -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications"" -Exclude ""Microsoft.Windows.Cortana*"", ""Microsoft.Windows.ShellExperienceHost*"" | ForEach-Object {
                     Set-ItemProperty -Path $_.PsPath -Name ""Disabled"" -Type DWord -Value 1
                     Set-ItemProperty -Path $_.PsPath -Name ""DisabledByUser"" -Type DWord -Value 1
                       }
                     }
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsActivateWithVoice"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsActivateWithVoiceAboveLock"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessNotifications"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessAccountInfo"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessContacts"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessCalendar"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessPhone"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessCallHistory"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessEmail"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessTasks"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessMessaging"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessRadios"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsSyncWithDevices"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsGetDiagnosticInfo"" -Type DWord -Value 2
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\documentsLibrary"" -Name ""Value"" -Type String -Value ""Deny""
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\picturesLibrary"" -Name ""Value"" -Type String -Value ""Deny""
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\videosLibrary"" -Name ""Value"" -Type String -Value ""Deny""
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\broadFileSystemAccess"" -Name ""Value"" -Type String -Value ""Deny""
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management"" -Name ""SwapfileControl"" -Type Dword -Value 0";
                    PowerShellInstanceDisabilitaUWPapps.AddScript(scriptDisabilitaUWPapps);
                    var result = PowerShellInstanceDisabilitaUWPapps.Invoke();
                }
            }
            else if (DisabilitaUtility.CheckedItems.Contains("Disabilita Esperienze Personalizzate Microsoft"))
            {
                using (PowerShell PowerShellInstanceDisabilitaEsperienzePersonalizzateMicrosoft = PowerShell.Create())
                {
                    string scriptDisabilitaEsperienzePersonalizzateMicrosoft = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableCdp"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableMmx"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableTailoredExperiencesWithDiagnosticData"" -Type DWord -Value 1";
                    PowerShellInstanceDisabilitaEsperienzePersonalizzateMicrosoft.AddScript(scriptDisabilitaEsperienzePersonalizzateMicrosoft);
                    var result = PowerShellInstanceDisabilitaEsperienzePersonalizzateMicrosoft.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita Background App"))
            {
                using (PowerShell PowerShellInstanceAbilitaBackgroundApp = PowerShell.Create())
                {
                    string scriptAbilitaBackgroundApp = @"
                     Get-ChildItem -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications"" -Exclude ""Microsoft.Windows.Cortana*"" | ForEach {
                     Remove-ItemProperty -Path $_.PsPath -Name ""Disabled"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path $_.PsPath -Name ""DisabledByUser"" -ErrorAction SilentlyContinue
                     }";
                    PowerShellInstanceAbilitaBackgroundApp.AddScript(scriptAbilitaBackgroundApp);
                    var result = PowerShellInstanceAbilitaBackgroundApp.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita Feedback"))
            {
                using (PowerShell PowerShellInstanceAbilitaFeedback = PowerShell.Create())
                {
                    string scriptAbilitaFeedback = @"
                     Remove-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Siuf\Rules"" -Name ""NumberOfSIUFInPeriod"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection"" -Name ""DoNotShowFeedbackNotifications"" -ErrorAction SilentlyContinue;
                     Enable-ScheduledTask -TaskName ""Microsoft\Windows\Feedback\Siuf\DmClient"" -ErrorAction SilentlyContinue;
                     Enable-ScheduledTask -TaskName ""Microsoft\Windows\Feedback\Siuf\DmClientOnScenarioDownload"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceAbilitaFeedback.AddScript(scriptAbilitaFeedback);
                    var result = PowerShellInstanceAbilitaFeedback.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita Advertising ID"))
            {
                using (PowerShell PowerShellInstanceAbilitaAdvertisingID = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaAdvertisingID.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AdvertisingInfo"" -Name ""DisabledByGroupPolicy"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaAdvertisingID.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita Filtro Smart Screen"))
            {
                using (PowerShell PowerShellInstanceAbilitaFiltroSmartScreen = PowerShell.Create())
                {
                    string scriptAbilitaFiltroSmartScreen = @"
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableSmartScreen"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter"" -Name ""EnabledV9"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceAbilitaFiltroSmartScreen.AddScript(scriptAbilitaFiltroSmartScreen);
                    var result = PowerShellInstanceAbilitaFiltroSmartScreen.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita Wifi Sense"))
            {
                using (PowerShell PowerShellInstanceAbilitaWifiSense = PowerShell.Create())
                {
                    string scriptAbilitaWifiSense = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowWiFiHotSpotReporting"" -Name ""Value"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowAutoConnectToWiFiSenseHotspots"" -Name ""Value"" -Type DWord -Value 1;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config"" -Name ""AutoConnectAllowedOEM"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config"" -Name ""WiFISenseAllowed"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceAbilitaWifiSense.AddScript(scriptAbilitaWifiSense);
                    var result = PowerShellInstanceAbilitaWifiSense.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita Desktop Remoto"))
            {
                using (PowerShell PowerShellInstanceAbilitaDesktopRemoto = PowerShell.Create())
                {
                    string scriptAbilitaDesktopRemoto = @"
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server"" -Name ""fDenyTSConnections"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp"" -Name ""UserAuthentication"" -Type DWord -Value 0;
                     Enable-NetFirewallRule -Name ""RemoteDesktop*""";
                    PowerShellInstanceAbilitaDesktopRemoto.AddScript(scriptAbilitaDesktopRemoto);
                    var result = PowerShellInstanceAbilitaDesktopRemoto.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita attivazione del Numlock in avvio"))
            {
                using (PowerShell PowerShellInstanceAbilitaattivazionedelNumlockinavvio = PowerShell.Create())
                {
                    string scriptAbilitaattivazionedelNumlockinavvio = @"
	                 If (!(Test-Path ""HKU:"")) {
		             New-PSDrive -Name ""HKU"" -PSProvider ""Registry"" -Root ""HKEY_USERS"" | Out-Null
	                 }
	                 Set-ItemProperty -Path ""HKU:\.DEFAULT\Control Panel\Keyboard"" -Name ""InitialKeyboardIndicators"" -Type DWord -Value 2147483650
	                 Add-Type -AssemblyName System.Windows.Forms
	                 If (!([System.Windows.Forms.Control]::IsKeyLocked('NumLock'))) {
		             $wsh = New-Object -ComObject WScript.Shell
		             $wsh.SendKeys('{NUMLOCK}')
	                 }";
                    PowerShellInstanceAbilitaattivazionedelNumlockinavvio.AddScript(scriptAbilitaattivazionedelNumlockinavvio);
                    var result = PowerShellInstanceAbilitaattivazionedelNumlockinavvio.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita News e Interessi"))
            {
                using (PowerShell PowerShellInstanceAbilitaNewseInteressi = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaNewseInteressi.AddScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\Windows Feeds"" -Name ""EnableFeeds"" -Type DWord -Value 1");
                    var result = PowerShellInstanceAbilitaNewseInteressi.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita Risparmio Energetico Personalizzato"))
            {
                using (PowerShell PowerShellInstanceAbilitaRisparmioEnergeticoPersonalizzato = PowerShell.Create())
                {
                    string scriptAbilitaRisparmioEnergeticoPersonalizzato = @"
                     powercfg -duplicatescheme a1841308-3541-4fab-bc81-f71556f20b4a;
                     powercfg -duplicatescheme 381b4222-f694-41f0-9685-ff5bb260df2e;
                     powercfg -duplicatescheme 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c;
                     powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61";
                    PowerShellInstanceAbilitaRisparmioEnergeticoPersonalizzato.AddScript(scriptAbilitaRisparmioEnergeticoPersonalizzato);
                    var result = PowerShellInstanceAbilitaRisparmioEnergeticoPersonalizzato.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Migliora uso SSD"))
            {
                using (PowerShell PowerShellInstanceMigliorausoSSD = PowerShell.Create())
                {
                    string scriptMigliorausoSSD = @"
                     fsutil behavior set DisableLastAccess 1;
                     fsutil behavior set EncryptPagingFile 0";
                    PowerShellInstanceMigliorausoSSD.AddScript(scriptMigliorausoSSD);
                    var result = PowerShellInstanceMigliorausoSSD.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita Mappe"))
            {
                using (PowerShell PowerShellInstanceAbilitaMappe = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaMappe.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SYSTEM\Maps"" -Name ""AutoUpdateEnabled"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaMappe.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita UWP apps"))
            {
                using (PowerShell PowerShellInstanceAbilitaUWPapps = PowerShell.Create())
                {
                    string scriptAbilitaUWPapps = @"
                     Remove-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management"" -Name ""SwapfileControl"" -ErrorAction SilentlyContinue
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\documentsLibrary"" -Name ""Value"" -Type String -Value ""Allow""
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\picturesLibrary"" -Name ""Value"" -Type String -Value ""Allow""
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\videosLibrary"" -Name ""Value"" -Type String -Value ""Allow""
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\broadFileSystemAccess"" -Name ""Value"" -Type String -Value ""Allow""
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsGetDiagnosticInfo"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsSyncWithDevices"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessRadios"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessMessaging"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessTasks"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessEmail"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessCallHistory"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessPhone"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessCalendar"" -ErrorAction SilentlyContinue 
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessContacts"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessAccountInfo"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsAccessNotifications"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsActivateWithVoice"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsActivateWithVoiceAboveLock"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsRunInBackground"" -ErrorAction SilentlyContinue
                     Get-ChildItem -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications"" | ForEach-Object {
                     Remove-ItemProperty -Path $_.PsPath -Name ""Disabled"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path $_.PsPath -Name ""DisabledByUser"" -ErrorAction SilentlyContinue
                     }";
                    PowerShellInstanceAbilitaUWPapps.AddScript(scriptAbilitaUWPapps);
                    var result = PowerShellInstanceAbilitaUWPapps.Invoke();
                }
            }
            else if (AbilitaUtility.CheckedItems.Contains("Abilita Esperienze Personalizzate Microsoft"))
            {
                using (PowerShell PowerShellInstanceAbilitaEsperienzePersonalizzateMicrosoft = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaEsperienzePersonalizzateMicrosoft.AddScript(@"Remove-ItemProperty -Path ""HKCU:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableTailoredExperiencesWithDiagnosticData"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaEsperienzePersonalizzateMicrosoft.Invoke();
                }
            }





        }
    }
}
