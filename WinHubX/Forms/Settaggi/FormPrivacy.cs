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
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKCU:\\Control Panel\\International\\User Profile\" -Name \"HttpAcceptLanguageOptOut\" -Type DWord -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();

                    }
                } finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Suggerimenti App"))
            {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableThirdPartySuggestions"" -Type DWord -Value 1; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableWindowsConsumerFeatures"" -Type DWord -Value 1; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Device Metadata"" -Name ""PreventDeviceMetadataFromNetwork"" -Type DWord -Value 1; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\MRT"" -Name ""DontOfferThroughWUAU"" -Type DWord -Value 1; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\SQMClient\Windows"" -Name ""CEIPEnable"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppCompat"" -Name ""AITEnable"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppCompat"" -Name ""DisableUAR"" -Type DWord -Value 1; " +
            @"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\WMI\AutoLogger\AutoLogger-Diagtrack-Listener"" -Name ""Start"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\WMI\AutoLogger\SQMLogger"" -Name ""Start"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SilentInstalledAppsEnabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SystemPaneSuggestionsEnabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SoftLandingEnabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-310093Enabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-314559Enabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338393Enabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-353694Enabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-353698Enabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SystemPaneSuggestionsEnabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""ContentDeliveryAllowed"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""OemPreInstalledAppsEnabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""PreInstalledAppsEnabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""PreInstalledAppsEverEnabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SilentInstalledAppsEnabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338387Enabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338388Enabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338389Enabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-353698Enabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SystemPaneSuggestionsEnabled"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableWindowsConsumerFeatures"" -Type DWord -Value 1; ",
                    UseShellExecute = false,
                            CreateNoWindow = true,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true
                        };

                        using (var process = System.Diagnostics.Process.Start(startInfo))
                        {
                            process.WaitForExit();

                            var output = process.StandardOutput.ReadToEnd();
                            var error = process.StandardError.ReadToEnd();

                        }
                    } finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Telemetria"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 0; " +
                    @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 0; " +
                    @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 0; " +
                    @"Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\Microsoft Compatibility Appraiser""; " +
                    @"Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\ProgramDataUpdater""; " +
                    @"Disable-ScheduledTask -TaskName ""Microsoft\Windows\Autochk\Proxy""; " +
                    @"Disable-ScheduledTask -TaskName ""Microsoft\Windows\Customer Experience Improvement Program\Consolidator""; " +
                    @"Disable-ScheduledTask -TaskName ""Microsoft\Windows\Customer Experience Improvement Program\UsbCeip""; " +
                    @"Disable-ScheduledTask -TaskName ""Microsoft\Windows\DiskDiagnostic\Microsoft-Windows-DiskDiagnosticDataCollector"";",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tracking"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                             Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location"" -Name ""Value"" -Type String -Value ""Deny"";
                             Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Sensor\Overrides\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}"" -Name ""SensorPermissionState"" -Type DWord -Value 0;
                             Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\lfsvc\Service\Configuration"" -Name ""Status"" -Type DWord -Value 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Segnalazione Errori"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                             Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\Windows Error Reporting"" -Name ""Disabled"" -Type DWord -Value 1;
                             Disable-ScheduledTask -TaskName ""Microsoft\Windows\Windows Error Reporting\QueueReporting""",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tracking Diagnostica"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                             Stop-Service -Name ""DiagTrack"" -Force -ErrorAction SilentlyContinue;
                             Set-Service -Name ""DiagTrack"" -StartupType Disabled -ErrorAction SilentlyContinue",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita WAP Push Service"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Stop-Service ""dmwappushservice"" -WarningAction SilentlyContinue;
                Set-Service ""dmwappushservice"" -StartupType Disabled",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disbailita Home Group"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Stop-Service ""HomeGroupListener"" -WarningAction SilentlyContinue;
                Set-Service ""HomeGroupListener"" -StartupType Disabled;
                Stop-Service ""HomeGroupProvider"" -WarningAction SilentlyContinue;
                Set-Service ""HomeGroupProvider"" -StartupType Disabled",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Assistenza Remota"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Remote Assistance"" -Name ""fAllowToGetHelp"" -Type DWord -Value 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Storage Check"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-Item -Path \"HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\StorageSense\\Parameters\\StoragePolicy\" -Recurse -ErrorAction SilentlyContinue",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Superfetch"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Stop-Service ""SysMain"" -WarningAction SilentlyContinue;
                Set-Service ""SysMain"" -StartupType Disabled",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Ibernazione"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKLM:\System\CurrentControlSet\Control\Session Manager\Power"" -Name ""HibernateEnabled"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings"" -Name ""ShowHibernateOption"" -Type DWord -Value 0;
                powercfg /HIBERNATE OFF",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Ottimizzazione FullScreen"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_DXGIHonorFSEWindowsCompatible"" -Type DWord -Value 1;
                Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_FSEBehavior"" -Type DWord -Value 2;
                Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_FSEBehaviorMode"" -Type DWord -Value 2;
                Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_HonorUserFSEBehaviorMode"" -Type DWord -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disbailita Schedul Defrag"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Disable-ScheduledTask -TaskName \"Microsoft\\Windows\\Defrag\\ScheduledDefrag\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Xbox Features"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Get-AppxPackage ""Microsoft.XboxApp"" | Remove-AppxPackage;
             Get-AppxPackage ""Microsoft.XboxIdentityProvider"" | Remove-AppxPackage -ErrorAction SilentlyContinue;
             Get-AppxPackage ""Microsoft.XboxSpeechToTextOverlay"" | Remove-AppxPackage;
             Get-AppxPackage ""Microsoft.XboxGameOverlay"" | Remove-AppxPackage;
             Get-AppxPackage ""Microsoft.Xbox.TCUI"" | Remove-AppxPackage;
             Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -Type DWord -Value 0;
             Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\GameDVR"" -Name ""AllowGameDVR"" -Type DWord -Value 0",
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true
                        };

                  using (var process = System.Diagnostics.Process.Start(startInfo))
                  {
                    process.WaitForExit();

                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                  }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Avvio Rapido"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power\" -Name \"HiberbootEnabled\" -Type DWord -Value 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Normal Bandwidth"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Psched\" -Name \"NonBestEffortLimit\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Auto Manteinance"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\Maintenance\" -Name \"MaintenanceDisabled\" -Type dword -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                finally { }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Spazio Riservato"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-WindowsReservedStorageState -State Disabled",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tweaks Game DVR"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_DXGIHonorFSEWindowsCompatible"" -Type Hex -Value 00000000;
              Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_HonorUserFSEBehaviorMode"" -Type Hex -Value 00000000;
              Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_EFSEFeatureFlags"" -Type Hex -Value 00000000;
              Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -Type DWord -Value 00000000",
                    UseShellExecute = false,
                            CreateNoWindow = true,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true
                        };

                using (var process = System.Diagnostics.Process.Start(startInfo))
                {
                    process.WaitForExit();

                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                }
                }
                    catch (Exception ex)
                    {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    }
        }
            else if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Storia Attivita"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableActivityFeed"" -Type DWord -Value 0;
                          Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""PublishUserActivities"" -Type DWord -Value 0;
                          Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""UploadUserActivities"" -Type DWord -Value 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Opzioni Lingua"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKCU:\\Control Panel\\International\\User Profile\" -Name \"HttpAcceptLanguageOptOut\" -Type DWord -Value 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Suggerimenti App"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""ContentDeliveryAllowed"" -Type DWord -Value 1;
                      Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""OemPreInstalledAppsEnabled"" -Type DWord -Value 1;
                      Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""PreInstalledAppsEnabled"" -Type DWord -Value 1;
                      Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""PreInstalledAppsEverEnabled"" -Type DWord -Value 1;
                      Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SilentInstalledAppsEnabled"" -Type DWord -Value 1;
                      Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338388Enabled"" -Type DWord -Value 1;
                      Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338389Enabled"" -Type DWord -Value 1;
                      Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SystemPaneSuggestionsEnabled"" -Type DWord -Value 1;
                      Remove-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-338387Enabled"" -ErrorAction SilentlyContinue;
                      Remove-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" -Name ""SubscribedContent-353698Enabled"" -ErrorAction SilentlyContinue;
                      Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableWindowsConsumerFeatures"" -ErrorAction SilentlyContinue",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Telemetria"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 3;
                      Set-ItemProperty -Path ""HKLM:\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 3;
                      Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection"" -Name ""AllowTelemetry"" -Type DWord -Value 3;
                      Start-Service DiagTrack | Set-Service -StartupType Automatic;
                      Start-Service dmwappushservice | Set-Service -StartupType Automatic",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tracking"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location"" -Name ""Value"" -Type String -Value ""Allow"";
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Sensor\Overrides\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}"" -Name ""SensorPermissionState"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\lfsvc\Service\Configuration"" -Name ""Status"" -Type DWord -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Segnalazione Errori"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\Windows Error Reporting"" -Name ""Disabled"" -ErrorAction SilentlyContinue;
                     Enable-ScheduledTask -TaskName ""Microsoft\Windows\Windows Error Reporting\QueueReporting""",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tracking Diagnostica"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-Service ""DiagTrack"" -StartupType Automatic;
                     Start-Service ""DiagTrack"" -WarningAction SilentlyContinue",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita WAP Push Service"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-Service ""dmwappushservice"" -StartupType Automatic;
                     Start-Service ""dmwappushservice"" -WarningAction SilentlyContinue;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\dmwappushservice"" -Name ""DelayedAutoStart"" -Type DWord -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Home Group"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Stop-Service ""HomeGroupListener"" -WarningAction SilentlyContinue;
                     Set-Service ""HomeGroupListener"" -StartupType Manual;
                     Stop-Service ""HomeGroupProvider"" -WarningAction SilentlyContinue;
                     Set-Service ""HomeGroupProvider"" -StartupType Manual",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Assistenza Remota"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Remote Assistance\" -Name \"fAllowToGetHelp\" -Type DWord -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Storage Check"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Name ""01"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Name ""04"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Name ""08"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Name ""32"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy"" -Name ""StoragePoliciesNotified"" -Type DWord -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Superfetch"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-Service ""SysMain"" -StartupType Automatic;
                     Start-Service ""SysMain"" -WarningAction SilentlyContinue",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Ibernazione"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-ItemProperty -Path ""HKLM:\System\CurrentControlSet\Control\Session Manager\Power"" -Name ""HibernteEnabled"" -Type Dword -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings"" -Name ""ShowHibernateOption"" -Type Dword -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Ottimizzazione FullScreen"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_DXGIHonorFSEWindowsCompatible"" -Type DWord -Value 0;
                     Remove-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_FSEBehavior"" -ErrorAction SilentlyContinue;
                     Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_FSEBehaviorMode"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_HonorUserFSEBehaviorMode"" -Type DWord -Value 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Schedul Defrag"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Enable-ScheduledTask -TaskName \"Microsoft\\Windows\\Defrag\\ScheduledDefrag\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Xbox Features"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Get-AppxPackage -AllUsers ""Microsoft.XboxApp"" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register ""$($_.InstallLocation)\AppXManifest.xml""};
                     Get-AppxPackage -AllUsers ""Microsoft.XboxIdentityProvider"" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register ""$($_.InstallLocation)\AppXManifest.xml""};
                     Get-AppxPackage -AllUsers ""Microsoft.XboxSpeechToTextOverlay"" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register ""$($_.InstallLocation)\AppXManifest.xml""};
                     Get-AppxPackage -AllUsers ""Microsoft.XboxGameOverlay"" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register ""$($_.InstallLocation)\AppXManifest.xml""};
                     Get-AppxPackage -AllUsers ""Microsoft.Xbox.TCUI"" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register ""$($_.InstallLocation)\AppXManifest.xml""};
                     Set-ItemProperty -Path ""HKCU:\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -Type DWord -Value 1;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\GameDVR"" -Name ""AllowGameDVR"" -ErrorAction SilentlyContinue",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Avvio Rapido"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power\" -Name \"HiberbootEnabled\" -Type DWord -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("All Bandwidth"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"New-Item -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Psched"" -ItemType Directory -Force;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Psched"" -Name ""NonBestEffortLimit"" -Type DWord -Value 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Auto Manteinance"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\Maintenance\" -Name \"MaintenanceDisabled\" -Type dword -Value 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Spazio Riservato"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-WindowsReservedStorageState -State Enabled",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tweaks Game DVR"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Remove-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_DXGIHonorFSEWindowsCompatible"" -ErrorAction SilentlyContinue;
                      Remove-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_HonorUserFSEBehaviorMode"" -ErrorAction SilentlyContinue;
                      Remove-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_EFSEFeatureFlags"" -ErrorAction SilentlyContinue;
                      Remove-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -ErrorAction SilentlyContinue;",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tweaks Game DVR"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableActivityFeed"" -ErrorAction SilentlyContinue;
                      Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""PublishUserActivities"" -ErrorAction SilentlyContinue;
                      Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""UploadUserActivities"" -ErrorAction SilentlyContinue;",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };
                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
