using System.Management.Automation;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.Settaggi
{
    public partial class FormPrivacy : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormPrivacy(FormSettaggi formSettaggi, Form1 form1)
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAvviaSelezionati_Click(object sender, EventArgs e)
        {
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Opzioni Lingua"))
            {
                using (PowerShell PowerShellInstanceDisabilitaOpzioniLingua = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaOpzioniLingua.AddScript(@"Set-ItemProperty -Path ""HKCU:\Control Panel\International\User Profile"" -Name ""HttpAcceptLanguageOptOut"" -Type DWord -Value 1");
                    var result = PowerShellInstanceDisabilitaOpzioniLingua.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Suggerimenti App"))
            {
                using (PowerShell PowerShellInstanceDisabilitaSuggerimentiApp = PowerShell.Create())
                {
                    string scriptDisabilitaSuggerimentiApp = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableThirdPartySuggestions"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableWindowsConsumerFeatures"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Device Metadata"" -Name ""PreventDeviceMetadataFromNetwork"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\MRT"" -Name ""DontOfferThroughWUAU"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\SQMClient\Windows"" -Name ""CEIPEnable"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppCompat"" -Name ""AITEnable"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppCompat"" -Name ""DisableUAR"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\WMI\AutoLogger\AutoLogger-Diagtrack-Listener"" -Name ""Start"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\WMI\AutoLogger\SQMLogger"" -Name ""Start"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SilentInstalledAppsEnabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SystemPaneSuggestionsEnabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SoftLandingEnabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-310093Enabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-314559Enabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338393Enabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-353694Enabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-353698Enabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SystemPaneSuggestionsEnabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""ContentDeliveryAllowed"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""OemPreInstalledAppsEnabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""PreInstalledAppsEnabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""PreInstalledAppsEverEnabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SilentInstalledAppsEnabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338387Enabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338388Enabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338389Enabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-353698Enabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SystemPaneSuggestionsEnabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableWindowsConsumerFeatures"" -Type DWord -Value 1";
                    PowerShellInstanceDisabilitaSuggerimentiApp.AddScript(scriptDisabilitaSuggerimentiApp);
                    var result = PowerShellInstanceDisabilitaSuggerimentiApp.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Telemetria"))
            {
                using (PowerShell PowerShellInstanceDisabilitaTelemetria = PowerShell.Create())
                {
                    string scriptDisabilitaTelemetria = @"
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 0;
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\DataCollection"" - Name ""AllowTelemetry"" -Type DWord -Value 0;
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 0;
                 Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\Microsoft Compatibility Appraiser"";
                 Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\ProgramDataUpdater"";
                 Disable-ScheduledTask -TaskName ""Microsoft\Windows\Autochk\Proxy"";
                 Disable-ScheduledTask -TaskName ""Microsoft\Windows\Customer Experience Improvement Program\Consolidator"";
                 Disable-ScheduledTask -TaskName ""Microsoft\Windows\Customer Experience Improvement Program\UsbCeip"";
                 Disable-ScheduledTask -TaskName ""Microsoft\Windows\DiskDiagnostic\Microsoft-Windows-DiskDiagnosticDataCollector""";
                    PowerShellInstanceDisabilitaTelemetria.AddScript(scriptDisabilitaTelemetria);
                    var result = PowerShellInstanceDisabilitaTelemetria.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tracking"))
            {
                using (PowerShell PowerShellInstanceDisabilitaTracking = PowerShell.Create())
                {
                    string scriptDisabilitaTracking = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location"" -Name ""Value"" -Type String -Value ""Deny"";
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Sensor\Overrides\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}"" -Name ""SensorPermissionState"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\lfsvc\Service\Configuration"" -Name ""Status"" -Type DWord -Value 0";
                    PowerShellInstanceDisabilitaTracking.AddScript(scriptDisabilitaTracking);
                    var result = PowerShellInstanceDisabilitaTracking.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Segnalazione Errori"))
            {
                using (PowerShell PowerShellInstanceDisabilitaSegnalazioneErrori = PowerShell.Create())
                {
                    string scriptDisabilitaSegnalazioneErrori = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\Windows Error Reporting"" -Name ""Disabled"" -Type DWord -Value 1;
                     Disable-ScheduledTask -TaskName ""Microsoft\Windows\Windows Error Reporting\QueueReporting""";
                    PowerShellInstanceDisabilitaSegnalazioneErrori.AddScript(scriptDisabilitaSegnalazioneErrori);
                    var result = PowerShellInstanceDisabilitaSegnalazioneErrori.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tracking Diagnostica"))
            {
                using (PowerShell PowerShellInstanceDisabilitaTrackingDiagnostica = PowerShell.Create())
                {
                    string scriptDisabilitaTrackingDiagnostica = @"
                     Stop-Service -Name ""DiagTrack"" -Force -ErrorAction SilentlyContinue;
                     Set-Service -Name ""DiagTrack"" -StartupType Disabled -ErrorAction SilentlyContinue";
                    PowerShellInstanceDisabilitaTrackingDiagnostica.AddScript(scriptDisabilitaTrackingDiagnostica);
                    var result = PowerShellInstanceDisabilitaTrackingDiagnostica.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita WAP Push Service"))
            {
                using (PowerShell PowerShellInstanceDisabilitaWAPPushService = PowerShell.Create())
                {
                    string scriptDisabilitaWAPPushService = @"
                     Stop-Service ""dmwappushservice"" -WarningAction SilentlyContinue;
                     Set-Service ""dmwappushservice"" -StartupType Disabled";
                    PowerShellInstanceDisabilitaWAPPushService.AddScript(scriptDisabilitaWAPPushService);
                    var result = PowerShellInstanceDisabilitaWAPPushService.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disbailita Home Group"))
            {
                using (PowerShell PowerShellInstanceDisbailitaHomeGroup = PowerShell.Create())
                {
                    string scriptDisbailitaHomeGroup = @"
                     Stop-Service ""HomeGroupListener"" -WarningAction SilentlyContinue;
                     Set-Service ""HomeGroupListener"" -StartupType Disabled;
                     Stop-Service ""HomeGroupProvider"" -WarningAction SilentlyContinue;
                     Set-Service ""HomeGroupProvider"" -StartupType Disabled";
                    PowerShellInstanceDisbailitaHomeGroup.AddScript(scriptDisbailitaHomeGroup);
                    var result = PowerShellInstanceDisbailitaHomeGroup.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Assistenza Remota"))
            {
                using (PowerShell PowerShellInstanceDisabilitaAssistenzaRemota = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaAssistenzaRemota.AddScript(@"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Remote Assistance"" -Name ""fAllowToGetHelp"" -Type DWord -Value 0");
                    var result = PowerShellInstanceDisabilitaAssistenzaRemota.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Storage Check"))
            {
                using (PowerShell PowerShellInstanceDisabilitaStorageCheck = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaStorageCheck.AddScript(@"Remove-Item -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Recurse -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceDisabilitaStorageCheck.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Superfetch"))
            {
                using (PowerShell PowerShellInstanceDisabilitaSuperfetch = PowerShell.Create())
                {
                    string scriptDisabilitaSuperfetch = @"
                     Stop-Service ""SysMain"" -WarningAction SilentlyContinue;
                     Set-Service ""SysMain"" -StartupType Disabled";
                    PowerShellInstanceDisabilitaSuperfetch.AddScript(scriptDisabilitaSuperfetch);
                    var result = PowerShellInstanceDisabilitaSuperfetch.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Ibernazione"))
            {
                using (PowerShell PowerShellInstanceDisabilitaIbernazione = PowerShell.Create())
                {
                    string scriptDisabilitaIbernazione = @"
                     Set-ItemProperty -Path ""HKLM:\System\CurrentControlSet\Control\Session Manager\Power"" -Name ""HibernateEnabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings"" -Name ""ShowHibernateOption"" -Type DWord -Value 0;
                     powercfg /HIBERNATE OFF";
                    PowerShellInstanceDisabilitaIbernazione.AddScript(scriptDisabilitaIbernazione);
                    var result = PowerShellInstanceDisabilitaIbernazione.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Ottimizzazione FullScreen"))
            {
                using (PowerShell PowerShellInstanceDisabilitaOttimizzazioneFullScreen = PowerShell.Create())
                {
                    string scriptDisabilitaOttimizzazioneFullScreen = @"
                     Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_DXGIHonorFSEWindowsCompatible"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_FSEBehavior"" -Type DWord -Value 2;
	                 Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_FSEBehaviorMode"" -Type DWord -Value 2;
	                 Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_HonorUserFSEBehaviorMode"" -Type DWord -Value 1";
                    PowerShellInstanceDisabilitaOttimizzazioneFullScreen.AddScript(scriptDisabilitaOttimizzazioneFullScreen);
                    var result = PowerShellInstanceDisabilitaOttimizzazioneFullScreen.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disbailita Schedul Defrag"))
            {
                using (PowerShell PowerShellInstanceDisbailitaSchedulDefrag = PowerShell.Create())
                {
                    PowerShellInstanceDisbailitaSchedulDefrag.AddScript(@"Disable-ScheduledTask -TaskName ""Microsoft\Windows\Defrag\ScheduledDefrag""");
                    var result = PowerShellInstanceDisbailitaSchedulDefrag.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Xbox Features"))
            {
                using (PowerShell PowerShellInstanceDisabilitaXboxFeatures = PowerShell.Create())
                {
                    string scriptDisabilitaXboxFeatures = @"
                     Get-AppxPackage ""Microsoft.XboxApp"" | Remove-AppxPackage;
                     Get-AppxPackage ""Microsoft.XboxIdentityProvider"" | Remove-AppxPackage -ErrorAction SilentlyContinue;
                     Get-AppxPackage ""Microsoft.XboxSpeechToTextOverlay"" | Remove-AppxPackage;
                     Get-AppxPackage ""Microsoft.XboxGameOverlay"" | Remove-AppxPackage;
                     Get-AppxPackage ""Microsoft.Xbox.TCUI"" | Remove-AppxPackage
                     Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\GameDVR"" -Name ""AllowGameDVR"" -Type DWord -Value 0";
                    PowerShellInstanceDisabilitaXboxFeatures.AddScript(scriptDisabilitaXboxFeatures);
                    var result = PowerShellInstanceDisabilitaXboxFeatures.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Avvio Rapido"))
            {
                using (PowerShell PowerShellInstanceDisabilitaAvvioRapido = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaAvvioRapido.AddScript(@"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Session Manager\Power"" -Name ""HiberbootEnabled"" -Type DWord -Value 0");
                    var result = PowerShellInstanceDisabilitaAvvioRapido.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Normal Bandwidth"))
            {
                using (PowerShell PowerShellInstanceNormalBandwidth = PowerShell.Create())
                {
                    PowerShellInstanceNormalBandwidth.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Psched"" -Name ""NonBestEffortLimit""");
                    var result = PowerShellInstanceNormalBandwidth.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Auto Manteinance"))
            {
                using (PowerShell PowerShellInstanceDisabilitaAutoManteinance = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaAutoManteinance.AddScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance"" -Name ""MaintenanceDisabled"" -Type dword -Value 1");
                    var result = PowerShellInstanceDisabilitaAutoManteinance.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Spazio Riservato"))
            {
                using (PowerShell PowerShellInstanceDisabilitaSpazioRiservato = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaSpazioRiservato.AddScript(@"Set-WindowsReservedStorageState -State Disabled");
                    var result = PowerShellInstanceDisabilitaSpazioRiservato.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tweaks Game DVR"))
            {
                using (PowerShell PowerShellInstanceDisabilitaTweaksGameDVR = PowerShell.Create())
                {
                    string scriptDisabilitaTweaksGameDVR = @"
                     Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_DXGIHonorFSEWindowsCompatible"" -Type Hex -Value 00000000;
                     Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_HonorUserFSEBehaviorMode"" -Type Hex -Value 00000000;
                     Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_EFSEFeatureFlags"" -Type Hex -Value 00000000;
                     Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -Type DWord -Value 00000000";
                    PowerShellInstanceDisabilitaTweaksGameDVR.AddScript(scriptDisabilitaTweaksGameDVR);
                    var result = PowerShellInstanceDisabilitaTweaksGameDVR.Invoke();
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Storia Attivita"))
            {
                using (PowerShell PowerShellInstanceDisabilitaStoriaAttivita = PowerShell.Create())
                {
                    string scriptDisabilitaStoriaAttivita = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableActivityFeed"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""PublishUserActivities"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""UploadUserActivities"" -Type DWord -Value 0";
                    PowerShellInstanceDisabilitaStoriaAttivita.AddScript(scriptDisabilitaStoriaAttivita);
                    var result = PowerShellInstanceDisabilitaStoriaAttivita.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Opzioni Lingua"))
            {
                using (PowerShell PowerShellInstanceAbilitaOpzioniLingua = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaOpzioniLingua.AddScript(@"Set-ItemProperty -Path ""HKCU:\Control Panel\International\User Profile"" -Name ""HttpAcceptLanguageOptOut"" -Type DWord -Value 0");
                    var result = PowerShellInstanceAbilitaOpzioniLingua.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Suggerimenti App"))
            {
                using (PowerShell PowerShellInstanceAbilitaSuggerimentiApp = PowerShell.Create())
                {
                    string scriptAbilitaSuggerimentiApp = @"
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""ContentDeliveryAllowed"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""OemPreInstalledAppsEnabled"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""PreInstalledAppsEnabled"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""PreInstalledAppsEverEnabled"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SilentInstalledAppsEnabled"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338388Enabled"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338389Enabled"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SystemPaneSuggestionsEnabled"" -Type DWord -Value 1;
                     Remove-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338387Enabled"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-353698Enabled"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableWindowsConsumerFeatures"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceAbilitaSuggerimentiApp.AddScript(scriptAbilitaSuggerimentiApp);
                    var result = PowerShellInstanceAbilitaSuggerimentiApp.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Telemetria"))
            {
                using (PowerShell PowerShellInstanceAbilitaTelemetria = PowerShell.Create())
                {
                    string scriptAbilitaTelemetria = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 3;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 3;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 3;
                     Start-Service DiagTrack | Set-Service -StartupType Automatic;
                     Start-Service dmwappushservice | Set-Service -StartupType Automatic";
                    PowerShellInstanceAbilitaTelemetria.AddScript(scriptAbilitaTelemetria);
                    var result = PowerShellInstanceAbilitaTelemetria.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tracking"))
            {
                using (PowerShell PowerShellInstanceAbilitaTracking = PowerShell.Create())
                {
                    string scriptAbilitaTracking = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location"" -Name ""Value"" -Type String -Value ""Allow"";
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Sensor\Overrides\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}"" -Name ""SensorPermissionState"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\lfsvc\Service\Configuration"" -Name ""Status"" -Type DWord -Value 1";
                    PowerShellInstanceAbilitaTracking.AddScript(scriptAbilitaTracking);
                    var result = PowerShellInstanceAbilitaTracking.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Segnalazione Errori"))
            {
                using (PowerShell PowerShellInstanceAbilitaSegnalazioneErrori = PowerShell.Create())
                {
                    string scriptAbilitaSegnalazioneErrori = @"
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\Windows Error Reporting"" -Name ""Disabled"" -ErrorAction SilentlyContinue;
                     Enable-ScheduledTask -TaskName ""Microsoft\Windows\Windows Error Reporting\QueueReporting""";
                    PowerShellInstanceAbilitaSegnalazioneErrori.AddScript(scriptAbilitaSegnalazioneErrori);
                    var result = PowerShellInstanceAbilitaSegnalazioneErrori.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tracking Diagnostica"))
            {
                using (PowerShell PowerShellInstanceAbilitaTrackingDiagnostica = PowerShell.Create())
                {
                    string scriptAbilitaTrackingDiagnostica = @"
                     Set-Service ""DiagTrack"" -StartupType Automatic;
                     Start-Service ""DiagTrack"" -WarningAction SilentlyContinue";
                    PowerShellInstanceAbilitaTrackingDiagnostica.AddScript(scriptAbilitaTrackingDiagnostica);
                    var result = PowerShellInstanceAbilitaTrackingDiagnostica.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita WAP Push Service"))
            {
                using (PowerShell PowerShellInstanceAbilitaWAPPushService = PowerShell.Create())
                {
                    string scriptAbilitaWAPPushService = @"
                     Set-Service ""dmwappushservice"" -StartupType Automatic;
                     Start-Service ""dmwappushservice"" -WarningAction SilentlyContinue;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\dmwappushservice"" -Name ""DelayedAutoStart"" -Type DWord -Value 1";
                    PowerShellInstanceAbilitaWAPPushService.AddScript(scriptAbilitaWAPPushService);
                    var result = PowerShellInstanceAbilitaWAPPushService.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Home Group"))
            {
                using (PowerShell PowerShellInstanceAbilitaHomeGroup = PowerShell.Create())
                {
                    string scriptAbilitaHomeGroup = @"
                     Stop-Service ""HomeGroupListener"" -WarningAction SilentlyContinue
                     Set-Service ""HomeGroupListener"" -StartupType Manual
                     Stop-Service ""HomeGroupProvider"" -WarningAction SilentlyContinue
                     Set-Service ""HomeGroupProvider"" -StartupType Manual";
                    PowerShellInstanceAbilitaHomeGroup.AddScript(scriptAbilitaHomeGroup);
                    var result = PowerShellInstanceAbilitaHomeGroup.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Assistenza Remota"))
            {
                using (PowerShell PowerShellInstanceAbilitaAssistenzaRemota = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaAssistenzaRemota.AddScript(@"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Remote Assistance"" -Name ""fAllowToGetHelp"" -Type DWord -Value 1");
                    var result = PowerShellInstanceAbilitaAssistenzaRemota.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Storage Check"))
            {
                using (PowerShell PowerShellInstanceAbilitaStorageCheck = PowerShell.Create())
                {
                    string scriptAbilitaStorageCheck = @"
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Name ""01"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Name ""04"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Name ""08"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Name ""32"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Name ""StoragePoliciesNotified"" -Type DWord -Value 1";
                    PowerShellInstanceAbilitaStorageCheck.AddScript(scriptAbilitaStorageCheck);
                    var result = PowerShellInstanceAbilitaStorageCheck.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Superfetch"))
            {
                using (PowerShell PowerShellInstanceAbilitaSuperfetch = PowerShell.Create())
                {
                    string scriptAbilitaSuperfetch = @"
                     Set-Service ""SysMain"" -StartupType Automatic;
                     Start-Service ""SysMain"" -WarningAction SilentlyContinue";
                    PowerShellInstanceAbilitaSuperfetch.AddScript(scriptAbilitaSuperfetch);
                    var result = PowerShellInstanceAbilitaSuperfetch.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Ibernazione"))
            {
                using (PowerShell PowerShellInstanceAbilitaIbernazione = PowerShell.Create())
                {
                    string scriptAbilitaIbernazione = @"
                     Set-ItemProperty -Path ""HKLM:\System\CurrentControlSet\Control\Session Manager\Power"" -Name ""HibernteEnabled"" -Type Dword -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings"" -Name ""ShowHibernateOption"" -Type Dword -Value 1";
                    PowerShellInstanceAbilitaIbernazione.AddScript(scriptAbilitaIbernazione);
                    var result = PowerShellInstanceAbilitaIbernazione.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Ottimizzazione FullScreen"))
            {
                using (PowerShell PowerShellInstanceAbilitaOttimizzazioneFullScreen = PowerShell.Create())
                {
                    string scriptAbilitaOttimizzazioneFullScreen = @"
                     Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_DXGIHonorFSEWindowsCompatible"" -Type DWord -Value 0;
                     Remove-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_FSEBehavior"" -ErrorAction SilentlyContinue;
                     Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_FSEBehaviorMode"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_HonorUserFSEBehaviorMode"" -Type DWord -Value 0";
                    PowerShellInstanceAbilitaOttimizzazioneFullScreen.AddScript(scriptAbilitaOttimizzazioneFullScreen);
                    var result = PowerShellInstanceAbilitaOttimizzazioneFullScreen.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Schedul Defrag"))
            {
                using (PowerShell PowerShellInstanceAbilitaSchedulDefrag = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaSchedulDefrag.AddScript(@"Enable-ScheduledTask -TaskName ""Microsoft\Windows\Defrag\ScheduledDefrag""");
                    var result = PowerShellInstanceAbilitaSchedulDefrag.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Xbox Features"))
            {
                using (PowerShell PowerShellInstanceAbilitaXboxFeatures = PowerShell.Create())
                {
                    string scriptAbilitaXboxFeatures = @"
                     Get-AppxPackage -AllUsers ""Microsoft.XboxApp"" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register ""$($_.InstallLocation)\AppXManifest.xml""};
                     Get-AppxPackage -AllUsers ""Microsoft.XboxIdentityProvider"" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register ""$($_.InstallLocation)\AppXManifest.xml""};
                     Get-AppxPackage -AllUsers ""Microsoft.XboxSpeechToTextOverlay"" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register ""$($_.InstallLocation)\AppXManifest.xml""};
                     Get-AppxPackage -AllUsers ""Microsoft.XboxGameOverlay"" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register ""$($_.InstallLocation)\AppXManifest.xml""};
                     Get-AppxPackage -AllUsers ""Microsoft.Xbox.TCUI"" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register ""$($_.InstallLocation)\AppXManifest.xml""};
                     Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -Type DWord -Value 1;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\GameDVR"" -Name ""AllowGameDVR"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceAbilitaXboxFeatures.AddScript(scriptAbilitaXboxFeatures);
                    var result = PowerShellInstanceAbilitaXboxFeatures.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Avvio Rapido"))
            {
                using (PowerShell PowerShellInstanceAbilitaAvvioRapido = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaAvvioRapido.AddScript(@"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Session Manager\Power"" -Name ""HiberbootEnabled"" -Type DWord -Value 1");
                    var result = PowerShellInstanceAbilitaAvvioRapido.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("All Bandwidth"))
            {
                using (PowerShell PowerShellInstanceAllBandwidths = PowerShell.Create())
                {
                    string scriptAllBandwidths = @"
                     New-Item -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Psched"" -ItemType Directory -Force;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Psched"" -Name ""NonBestEffortLimit"" -Type DWord -Value 0";
                    PowerShellInstanceAllBandwidths.AddScript(scriptAllBandwidths);
                    var result = PowerShellInstanceAllBandwidths.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Auto Manteinance"))
            {
                using (PowerShell PowerShellInstanceAbilitaAutoManteinance = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaAutoManteinance.AddScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance"" -Name ""MaintenanceDisabled"" -Type dword -Value 0");
                    var result = PowerShellInstanceAbilitaAutoManteinance.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Spazio Riservato"))
            {
                using (PowerShell PowerShellInstanceAbilitaSpazioRiservato = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaSpazioRiservato.AddScript(@"Set-WindowsReservedStorageState -State Enabled");
                    var result = PowerShellInstanceAbilitaSpazioRiservato.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tweaks Game DVR"))
            {
                using (PowerShell PowerShellInstanceAbilitaTweaksGameDVR = PowerShell.Create())
                {
                    string scriptAbilitaTweaksGameDVR = @"
                     Remove-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_DXGIHonorFSEWindowsCompatible"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_HonorUserFSEBehaviorMode"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_EFSEFeatureFlags"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceAbilitaTweaksGameDVR.AddScript(scriptAbilitaTweaksGameDVR);
                    var result = PowerShellInstanceAbilitaTweaksGameDVR.Invoke();
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tweaks Game DVR"))
            {
                using (PowerShell PowerShellInstanceAbilitaTweaksGameDVR = PowerShell.Create())
                {
                    string scriptAbilitaTweaksGameDVR = @"
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableActivityFeed"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""PublishUserActivities"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""UploadUserActivities"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceAbilitaTweaksGameDVR.AddScript(scriptAbilitaTweaksGameDVR);
                    var result = PowerShellInstanceAbilitaTweaksGameDVR.Invoke();
                }
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
