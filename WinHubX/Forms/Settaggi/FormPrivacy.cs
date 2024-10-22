﻿using Microsoft.Win32;
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
            LoadCheckboxStates();

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
        private void SetCheckboxState(string itemName, bool isChecked)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\WinHubX"))
            {
                key.SetValue(itemName, isChecked ? 1 : 0, RegistryValueKind.DWord);
            }
        }

        private bool GetCheckboxState(string itemName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinHubX"))
            {
                if (key != null)
                {
                    object value = key.GetValue(itemName);
                    if (value != null)
                    {
                        return (int)value == 1;
                    }
                }
            }
            return false;
        }

        private void LoadCheckboxStates()
        {
            int index = DisabilitaPrivacy.Items.IndexOf("Disabilita Opzioni Lingua");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaOpzioniLingua"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Suggerimenti App");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaSuggerimentiApp"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Telemetria");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaTelemetria"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Tracking");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaTracking"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Segnalazione Errori");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaSegnalazioneErrori"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Tracking Diagnostica");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaTrackingDiagnostica"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita WAP Push Service");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaWAPPushService"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disbailita Home Group");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisbailitaHomeGroup"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Assistenza Remota");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaAssistenzaRemota"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Storage Check");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaStorageCheck"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Superfetch");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaSuperfetch"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Ibernazione");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaIbernazione"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Ottimizzazione FullScreen");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaOttimizzazioneFullScreen"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disbailita Schedul Defrag");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisbailitaSchedulDefrag"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Xbox Features");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaXboxFeatures"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Avvio Rapido");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaAvvioRapido"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Normal Bandwidth");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("NormalBandwidth"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Auto Manteinance");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaAutoManteinance"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Spazio Riservato");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaSpazioRiservato"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Tweaks Game DVR");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaTweaksGameDVR"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Storia Attivita");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaStoriaAttivita"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Opzioni Lingua");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaOpzioniLingua"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Suggerimenti App");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaSuggerimentiApp"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Telemetria");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaTelemetria"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Tracking");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaTracking"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Segnalazione Errori");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaSegnalazioneErrori"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Tracking Diagnostica");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaTrackingDiagnostica"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita WAP Push Service");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaWAPPushService"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Home Group");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaHomeGroup"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Assistenza Remota");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaAssistenzaRemota"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Storage Check");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaStorageCheck"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Superfetch");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaSuperfetch"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Ottimizzazione FullScreen");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaOttimizzazioneFullScreen"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Schedul Defrag");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaSchedulDefrag"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Xbox Features");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaXboxFeatures"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Avvio Rapido");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaAvvioRapido"));
            }
            index = AbilitaPrivacy.Items.IndexOf("All Bandwidth");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AllBandwidth"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Auto Manteinance");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaAutoManteinance"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Spazio Riservato");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaSpazioRiservato"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Tweaks Game DVR");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaTweaksGameDVR"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Storie Attivita");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaStoriaAttivita"));
            }
        }

        private void ExecutePowerShellScript(string script)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = script,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        if (process != null)
                        {
                            process.WaitForExit();

                            var output = process.StandardOutput.ReadToEnd();
                            var error = process.StandardError.ReadToEnd();

                            // Log or handle output and errors
                            if (!string.IsNullOrEmpty(output))
                            {
                                Console.WriteLine("Output:");
                                Console.WriteLine(output);
                            }

                            if (!string.IsNullOrEmpty(error))
                            {
                                Console.WriteLine("Error:");
                                Console.WriteLine(error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to start PowerShell process.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception during PowerShell execution: {ex.Message}");
                }
            });

            thread.Start();
        }

        private void btnAvviaSelezionati_Click(object sender, EventArgs e)
        {
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Opzioni Lingua"))
            {
                SetCheckboxState("DisabilitaOpzioniLingua", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path ""HKCU:\Control Panel\International\User Profile"" -Name ""HttpAcceptLanguageOptOut"" -Type DWord -Value 1");
            }
            else
            {
                SetCheckboxState("DisabilitaOpzioniLingua", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Suggerimenti App"))
            {
                SetCheckboxState("DisabilitaSuggerimentiApp", true);
                ExecutePowerShellScript(@"
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
    Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338388Enabled"" -Type DWord -Value 0;
    Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338389Enabled"" -Type DWord -Value 0;
    Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-353698Enabled"" -Type DWord -Value 0;
    Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SystemPaneSuggestionsEnabled"" -Type DWord -Value 0;
    Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableWindowsConsumerFeatures"" -Type DWord -Value 1;
");
            }
            else
            {
                SetCheckboxState("DisabilitaSuggerimentiApp", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Telemetria"))
            {
                SetCheckboxState("DisabilitaTelemetria", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection"""" -Name """"AllowTelemetry"""" -Type DWord -Value 0; "" +
                    @""Set-ItemProperty -Path """"HKLM:\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\DataCollection"""" -Name """"AllowTelemetry"""" -Type DWord -Value 0; "" +
                    @""Set-ItemProperty -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection"""" -Name """"AllowTelemetry"""" -Type DWord -Value 0; "" +
                    @""Disable-ScheduledTask -TaskName """"Microsoft\Windows\Application Experience\Microsoft Compatibility Appraiser""""; "" +
                    @""Disable-ScheduledTask -TaskName """"Microsoft\Windows\Application Experience\ProgramDataUpdater""""; "" +
                    @""Disable-ScheduledTask -TaskName """"Microsoft\Windows\Autochk\Proxy""""; "" +
                    @""Disable-ScheduledTask -TaskName """"Microsoft\Windows\Customer Experience Improvement Program\Consolidator""""; "" +
                    @""Disable-ScheduledTask -TaskName """"Microsoft\Windows\Customer Experience Improvement Program\UsbCeip""""; "" +
                    @""Disable-ScheduledTask -TaskName """"Microsoft\Windows\DiskDiagnostic\Microsoft-Windows-DiskDiagnosticDataCollector""");
            }
            else
            {
                SetCheckboxState("DisabilitaTelemetria", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tracking"))
            {
                SetCheckboxState("DisabilitaTracking", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location"""" -Name """"Value"""" -Type String -Value """"Deny"""";
                             Set-ItemProperty -Path """"HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Sensor\Overrides\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}"""" -Name """"SensorPermissionState"""" -Type DWord -Value 0;
                             Set-ItemProperty -Path """"HKLM:\SYSTEM\CurrentControlSet\Services\lfsvc\Service\Configuration"""" -Name """"Status"""" -Type DWord -Value 0""");
            }
            else
            {
                SetCheckboxState("DisabilitaTracking", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Segnalazione Errori"))
            {
                SetCheckboxState("DisabilitaSegnalazioneErrori", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\Windows Error Reporting"" -Name ""Disabled"" -Type DWord -Value 1;
                                        Disable-ScheduledTask -TaskName """"Microsoft\Windows\Windows Error Reporting\QueueReporting""");
            }
            else
            {
                SetCheckboxState("DisabilitaSegnalazioneErrori", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tracking Diagnostica"))
            {
                SetCheckboxState("DisabilitaTrackingDiagnostica", true);
                ExecutePowerShellScript(@"Stop-Service -Name """"DiagTrack"""" -Force -ErrorAction SilentlyContinue;
                             Set-Service -Name """"DiagTrack"""" -StartupType Disabled -ErrorAction SilentlyContinue""");
            }
            else
            {
                SetCheckboxState("DisabilitaTrackingDiagnostica", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita WAP Push Service"))
            {
                SetCheckboxState("DisabilitaWAPPushService", true);
                ExecutePowerShellScript(@"Stop-Service """"dmwappushservice"""" -WarningAction SilentlyContinue;
                Set-Service """"dmwappushservice"""" -StartupType Disabled""");
            }
            else
            {
                SetCheckboxState("DisabilitaWAPPushService", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disbailita Home Group"))
            {
                SetCheckboxState("DisbailitaHomeGroup", true);
                ExecutePowerShellScript(@"Stop-Service """"HomeGroupListener"""" -WarningAction SilentlyContinue;
                Set-Service """"HomeGroupListener"""" -StartupType Disabled;
                Stop-Service """"HomeGroupProvider"""" -WarningAction SilentlyContinue;
                Set-Service """"HomeGroupProvider"""" -StartupType Disabled""");
            }
            else
            {
                SetCheckboxState("DisbailitaHomeGroup", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Assistenza Remota"))
            {
                SetCheckboxState("DisabilitaAssistenzaRemota", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKLM:\SYSTEM\CurrentControlSet\Control\Remote Assistance"""" -Name """"fAllowToGetHelp"""" -Type DWord -Value 0""");
            }
            else
            {
                SetCheckboxState("DisabilitaAssistenzaRemota", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Storage Check"))
            {
                SetCheckboxState("DisabilitaStorageCheck", true);
                ExecutePowerShellScript(@"Remove-Item -Path \""HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\StorageSense\\Parameters\\StoragePolicy\"" -Recurse -ErrorAction SilentlyContinue""");
            }
            else
            {
                SetCheckboxState("DisabilitaStorageCheck", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Superfetch"))
            {
                SetCheckboxState("DisabilitaSuperfetch", true);
                ExecutePowerShellScript(@"Stop-Service """"SysMain"""" -WarningAction SilentlyContinue;
                Set-Service """"SysMain"""" -StartupType Disabled""");
            }
            else
            {
                SetCheckboxState("DisabilitaSuperfetch", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Ibernazione"))
            {
                SetCheckboxState("DisabilitaIbernazione", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKLM:\System\CurrentControlSet\Control\Session Manager\Power"""" -Name """"HibernateEnabled"""" -Type DWord -Value 0;
                Set-ItemProperty -Path """"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings"""" -Name """"ShowHibernateOption"""" -Type DWord -Value 0;
                powercfg /HIBERNATE OFF""");
            }
            else
            {
                SetCheckboxState("DisabilitaIbernazione", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Ottimizzazione FullScreen"))
            {
                SetCheckboxState("DisabilitaOttimizzazioneFullScreen", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKCU:\System\GameConfigStore"""" -Name """"GameDVR_DXGIHonorFSEWindowsCompatible"""" -Type DWord -Value 1;
                Set-ItemProperty -Path """"HKCU:\System\GameConfigStore"""" -Name """"GameDVR_FSEBehavior"""" -Type DWord -Value 2;
                Set-ItemProperty -Path """"HKCU:\System\GameConfigStore"""" -Name """"GameDVR_FSEBehaviorMode"""" -Type DWord -Value 2;
                Set-ItemProperty -Path """"HKCU:\System\GameConfigStore"""" -Name """"GameDVR_HonorUserFSEBehaviorMode"""" -Type DWord -Value 1""");
            }
            else
            {
                SetCheckboxState("DisabilitaOttimizzazioneFullScreen", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disbailita Schedul Defrag"))
            {
                SetCheckboxState("DisbailitaSchedulDefrag", true);
                ExecutePowerShellScript(@"Disable-ScheduledTask -TaskName \""Microsoft\\Windows\\Defrag\\ScheduledDefrag\""");
            }
            else
            {
                SetCheckboxState("DisbailitaSchedulDefrag", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Xbox Features"))
            {
                SetCheckboxState("DisabilitaXboxFeatures", true);
                ExecutePowerShellScript(@"
                 Get-AppxPackage ""Microsoft.XboxApp"" | Remove-AppxPackage;
                 Get-AppxPackage ""Microsoft.XboxIdentityProvider"" | Remove-AppxPackage -ErrorAction SilentlyContinue;
                 Get-AppxPackage ""Microsoft.XboxSpeechToTextOverlay"" | Remove-AppxPackage;
                 Get-AppxPackage ""Microsoft.XboxGameOverlay"" | Remove-AppxPackage;
                 Get-AppxPackage ""Microsoft.Xbox.TCUI"" | Remove-AppxPackage;
                 Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -Type DWord -Value 0;
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\GameDVR"" -Name ""AllowGameDVR"" -Type DWord -Value 0;
                ");

            }
            else
            {
                SetCheckboxState("DisabilitaXboxFeatures", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Avvio Rapido"))
            {
                SetCheckboxState("DisabilitaAvvioRapido", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path \""HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power\"" -Name \""HiberbootEnabled\"" -Type DWord -Value 0""");
            }
            else
            {
                SetCheckboxState("DisabilitaAvvioRapido", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Normal Bandwidth"))
            {
                SetCheckboxState("NormalBandwidth", true);
                ExecutePowerShellScript(@"Remove-ItemProperty -Path \""HKLM:\\SOFTWARE\\Policies\\Microsoft\\Psched\"" -Name \""NonBestEffortLimit\""");
            }
            else
            {
                SetCheckboxState("NormalBandwidth", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Auto Manteinance"))
            {
                SetCheckboxState("DisabilitaAutoManteinance", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path \""HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\Maintenance\"" -Name \""MaintenanceDisabled\"" -Type dword -Value 1""");
            }
            else
            {
                SetCheckboxState("DisabilitaAutoManteinance", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Spazio Riservato"))
            {
                SetCheckboxState("DisabilitaSpazioRiservato", true);
                ExecutePowerShellScript(@"Set-WindowsReservedStorageState -State Disabled");
            }
            else
            {
                SetCheckboxState("DisabilitaSpazioRiservato", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tweaks Game DVR"))
            {
                SetCheckboxState("DisabilitaTweaksGameDVR", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKLM:\System\GameConfigStore"""" -Name """"GameDVR_DXGIHonorFSEWindowsCompatible"""" -Type Hex -Value 00000000;
                 Set-ItemProperty -Path """"HKLM:\System\GameConfigStore"""" -Name """"GameDVR_HonorUserFSEBehaviorMode"""" -Type Hex -Value 00000000;
                 Set-ItemProperty -Path """"HKLM:\System\GameConfigStore"""" -Name """"GameDVR_EFSEFeatureFlags"""" -Type Hex -Value 00000000;
                 Set-ItemProperty -Path """"HKLM:\System\GameConfigStore"""" -Name """"GameDVR_Enabled"""" -Type DWord -Value 00000000""");
            }
            else
            {
                SetCheckboxState("DisabilitaTweaksGameDVR", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Storia Attivita"))
            {
                SetCheckboxState("DisabilitaStoriaAttivita", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"""" -Name """"EnableActivityFeed"""" -Type DWord -Value 0;
                          Set-ItemProperty -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"""" -Name """"PublishUserActivities"""" -Type DWord -Value 0;
                          Set-ItemProperty -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"""" -Name """"UploadUserActivities"""" -Type DWord -Value 0""");
            }
            else
            {
                SetCheckboxState("DisabilitaStoriaAttivita", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Opzioni Lingua"))
            {
                SetCheckboxState("AbilitaOpzioniLingua", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path \""HKCU:\\Control Panel\\International\\User Profile\"" -Name \""HttpAcceptLanguageOptOut\"" -Type DWord -Value 0""");
            }
            else
            {
                SetCheckboxState("AbilitaOpzioniLingua", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Suggerimenti App"))
            {
                SetCheckboxState("AbilitaSuggerimentiApp", true);
                ExecutePowerShellScript(@"
                 Set-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager' -Name 'ContentDeliveryAllowed' -Type DWord -Value 1;
                 Set-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager' -Name 'OemPreInstalledAppsEnabled' -Type DWord -Value 1;
                 Set-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager' -Name 'PreInstalledAppsEnabled' -Type DWord -Value 1;
                 Set-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager' -Name 'PreInstalledAppsEverEnabled' -Type DWord -Value 1;
                 Set-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager' -Name 'SilentInstalledAppsEnabled' -Type DWord -Value 1;
                 Set-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager' -Name 'SubscribedContent-338388Enabled' -Type DWord -Value 1;
                 Set-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager' -Name 'SubscribedContent-338389Enabled' -Type DWord -Value 1;
                 Set-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager' -Name 'SystemPaneSuggestionsEnabled' -Type DWord -Value 1;
                 Remove-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager' -Name 'SubscribedContent-338387Enabled' -ErrorAction SilentlyContinue;
                 Remove-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager' -Name 'SubscribedContent-353698Enabled' -ErrorAction SilentlyContinue;
                 Remove-ItemProperty -Path 'HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent' -Name 'DisableWindowsConsumerFeatures' -ErrorAction SilentlyContinue;
               ");
            }
            else
            {
                SetCheckboxState("AbilitaSuggerimentiApp", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Telemetria"))
            {
                SetCheckboxState("AbilitaTelemetria", true);
                ExecutePowerShellScript(@"
                 Set-ItemProperty -Path 'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection' -Name 'AllowTelemetry' -Type DWord -Value 3;
                 Set-ItemProperty -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\DataCollection' -Name 'AllowTelemetry' -Type DWord -Value 3;
                 Set-ItemProperty -Path 'HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection' -Name 'AllowTelemetry' -Type DWord -Value 3;
                 Start-Service -Name 'DiagTrack' | Set-Service -StartupType Automatic;
                 Start-Service -Name 'dmwappushservice' | Set-Service -StartupType Automatic;
               ");
            }
            else
            {
                SetCheckboxState("AbilitaTelemetria", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tracking"))
            {
                SetCheckboxState("AbilitaTracking", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location"""" -Name """"Value"""" -Type String -Value """"Allow"""";
                     Set-ItemProperty -Path """"HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Sensor\Overrides\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}"""" -Name """"SensorPermissionState"""" -Type DWord -Value 1;
                     Set-ItemProperty -Path """"HKLM:\SYSTEM\CurrentControlSet\Services\lfsvc\Service\Configuration"""" -Name """"Status"""" -Type DWord -Value 1""");
            }
            else
            {
                SetCheckboxState("AbilitaTracking", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Segnalazione Errori"))
            {
                SetCheckboxState("AbilitaSegnalazioneErrori", true);
                ExecutePowerShellScript(@"
                  Remove-ItemProperty -Path 'HKLM:\SOFTWARE\Microsoft\Windows\Windows Error Reporting' -Name 'Disabled' -ErrorAction SilentlyContinue;
                  Enable-ScheduledTask -TaskName 'Microsoft\Windows\Windows Error Reporting\QueueReporting';
                ");

            }
            else
            {
                SetCheckboxState("AbilitaSegnalazioneErrori", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tracking Diagnostica"))
            {
                SetCheckboxState("AbilitaTrackingDiagnostica", true);
                ExecutePowerShellScript(@"Set-Service """"DiagTrack"""" -StartupType Automatic;
                     Start-Service """"DiagTrack"""" -WarningAction SilentlyContinue"",
                        UseShellExecute = false");
            }
            else
            {
                SetCheckboxState("AbilitaTrackingDiagnostica", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita WAP Push Service"))
            {
                SetCheckboxState("AbilitaWAPPushService", true);
                ExecutePowerShellScript(@"Set-Service """"dmwappushservice"""" -StartupType Automatic;
                     Start-Service """"dmwappushservice"""" -WarningAction SilentlyContinue;
                     Set-ItemProperty -Path """"HKLM:\SYSTEM\CurrentControlSet\Services\dmwappushservice"""" -Name """"DelayedAutoStart"""" -Type DWord -Value 1""");
            }
            else
            {
                SetCheckboxState("AbilitaWAPPushService", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Home Group"))
            {
                SetCheckboxState("AbilitaHomeGroup", true);
                ExecutePowerShellScript(@"Stop-Service """"HomeGroupListener"""" -WarningAction SilentlyContinue;
                     Set-Service """"HomeGroupListener"""" -StartupType Manual;
                     Stop-Service """"HomeGroupProvider"""" -WarningAction SilentlyContinue;
                     Set-Service """"HomeGroupProvider"""" -StartupType Manual""");
            }
            else
            {
                SetCheckboxState("AbilitaHomeGroup", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Assistenza Remota"))
            {
                SetCheckboxState("AbilitaAssistenzaRemota", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path \""HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Remote Assistance\"" -Name \""fAllowToGetHelp\"" -Type DWord -Value 1""");
            }
            else
            {
                SetCheckboxState("AbilitaAssistenzaRemota", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Storage Check"))
            {
                SetCheckboxState("AbilitaStorageCheck", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"""" -Name """"01"""" -Type DWord -Value 1;
                     Set-ItemProperty -Path """"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"""" -Name """"04"""" -Type DWord -Value 1;
                     Set-ItemProperty -Path """"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"""" -Name """"08"""" -Type DWord -Value 1;
                     Set-ItemProperty -Path """"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"""" -Name """"32"""" -Type DWord -Value 0;
                     Set-ItemProperty -Path """"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"""" -Name """"StoragePoliciesNotified"""" -Type DWord -Value 1""");
            }
            else
            {
                SetCheckboxState("AbilitaStorageCheck", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Superfetch"))
            {
                SetCheckboxState("AbilitaSuperfetch", true);
                ExecutePowerShellScript(@"Set-Service """"SysMain"""" -StartupType Automatic;
                     Start-Service """"SysMain"""" -WarningAction SilentlyContinue""");
            }
            else
            {
                SetCheckboxState("AbilitaSuperfetch", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Ibernazione"))
            {
                SetCheckboxState("AbilitaIbernazione", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKLM:\System\CurrentControlSet\Control\Session Manager\Power"""" -Name """"HibernteEnabled"""" -Type Dword -Value 1;
                     Set-ItemProperty -Path """"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings"""" -Name """"ShowHibernateOption"""" -Type Dword -Value 1""");
            }
            else
            {
                SetCheckboxState("AbilitaIbernazione", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Ottimizzazione FullScreen"))
            {
                SetCheckboxState("AbilitaOttimizzazioneFullScreen", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKCU:\System\GameConfigStore"""" -Name """"GameDVR_DXGIHonorFSEWindowsCompatible"""" -Type DWord -Value 0;
                     Remove-ItemProperty -Path """"HKCU:\System\GameConfigStore"""" -Name """"GameDVR_FSEBehavior"""" -ErrorAction SilentlyContinue;
                     Set-ItemProperty -Path """"HKCU:\System\GameConfigStore"""" -Name """"GameDVR_FSEBehaviorMode"""" -Type DWord -Value 0;
                     Set-ItemProperty -Path """"HKCU:\System\GameConfigStore"""" -Name """"GameDVR_HonorUserFSEBehaviorMode"""" -Type DWord -Value 0""");
            }
            else
            {
                SetCheckboxState("AbilitaOttimizzazioneFullScreen", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Schedul Defrag"))
            {
                SetCheckboxState("AbilitaSchedulDefrag", true);
                ExecutePowerShellScript(@"Enable-ScheduledTask -TaskName \""Microsoft\\Windows\\Defrag\\ScheduledDefrag\""");
            }
            else
            {
                SetCheckboxState("AbilitaSchedulDefrag", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Xbox Features"))
            {
                SetCheckboxState("AbilitaXboxFeatures", true);
                ExecutePowerShellScript(@"Get-AppxPackage -AllUsers """"Microsoft.XboxApp"""" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register """"$($_.InstallLocation)\AppXManifest.xml""""};
                     Get-AppxPackage -AllUsers """"Microsoft.XboxIdentityProvider"""" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register """"$($_.InstallLocation)\AppXManifest.xml""""};
                     Get-AppxPackage -AllUsers """"Microsoft.XboxSpeechToTextOverlay"""" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register """"$($_.InstallLocation)\AppXManifest.xml""""};
                     Get-AppxPackage -AllUsers """"Microsoft.XboxGameOverlay"""" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register """"$($_.InstallLocation)\AppXManifest.xml""""};
                     Get-AppxPackage -AllUsers """"Microsoft.Xbox.TCUI"""" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register """"$($_.InstallLocation)\AppXManifest.xml""""};
                     Set-ItemProperty -Path """"HKCU:\System\GameConfigStore"""" -Name """"GameDVR_Enabled"""" -Type DWord -Value 1;
                     Remove-ItemProperty -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Windows\GameDVR"""" -Name """"AllowGameDVR"""" -ErrorAction SilentlyContinue""");
            }
            else
            {
                SetCheckboxState("AbilitaXboxFeatures", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Avvio Rapido"))
            {
                SetCheckboxState("AbilitaAvvioRapido", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path \""HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power\"" -Name \""HiberbootEnabled\"" -Type DWord -Value 1""");
            }
            else
            {
                SetCheckboxState("AbilitaAvvioRapido", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("All Bandwidth"))
            {
                SetCheckboxState("AllBandwidth", true);
                ExecutePowerShellScript(@"New-Item -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Psched"""" -ItemType Directory -Force;
                     Set-ItemProperty -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Psched"""" -Name """"NonBestEffortLimit"""" -Type DWord -Value 0""");
            }
            else
            {
                SetCheckboxState("AllBandwidth", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Auto Manteinance"))
            {
                SetCheckboxState("AbilitaAutoManteinance", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path \""HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\Maintenance\"" -Name \""MaintenanceDisabled\"" -Type dword -Value 0""");
            }
            else
            {
                SetCheckboxState("AbilitaAutoManteinance", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Spazio Riservato"))
            {
                SetCheckboxState("AbilitaSpazioRiservato", true);
                ExecutePowerShellScript(@"Set-WindowsReservedStorageState -State Enabled");
            }
            else
            {
                SetCheckboxState("AbilitaSpazioRiservato", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tweaks Game DVR"))
            {
                SetCheckboxState("AbilitaTweaksGameDVR", true);
                ExecutePowerShellScript(@"Remove-ItemProperty -Path """"HKLM:\System\GameConfigStore"""" -Name """"GameDVR_DXGIHonorFSEWindowsCompatible"""" -ErrorAction SilentlyContinue;
                      Remove-ItemProperty -Path """"HKLM:\System\GameConfigStore"""" -Name """"GameDVR_HonorUserFSEBehaviorMode"""" -ErrorAction SilentlyContinue;
                      Remove-ItemProperty -Path """"HKLM:\System\GameConfigStore"""" -Name """"GameDVR_EFSEFeatureFlags"""" -ErrorAction SilentlyContinue;
                      Remove-ItemProperty -Path """"HKLM:\System\GameConfigStore"""" -Name """"GameDVR_Enabled"""" -ErrorAction SilentlyContinue;""");
            }
            else
            {
                SetCheckboxState("AbilitaTweaksGameDVR", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Storie Attivita"))
            {
                SetCheckboxState("AbilitaStoriaAttivita", true);
                ExecutePowerShellScript(@"Set-ItemProperty -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"""" -Name """"EnableActivityFeed"""" -Type DWord -Value 1;
                          Set-ItemProperty -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"""" -Name """"PublishUserActivities"""" -Type DWord -Value 1;
                          Set-ItemProperty -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"""" -Name """"UploadUserActivities"""" -Type DWord -Value 1""");
            }
            else
            {
                SetCheckboxState("AbilitaStoriaAttivita", false);
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
