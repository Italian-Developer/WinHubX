using Microsoft.Win32;
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
            int index = DisabilitaUtility.Items.IndexOf("Disabilita Background App");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaBackgroundApp"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Feedback");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaFeedback"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Advertising ID");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaAdvertisingID"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Filtro Smart Screen");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaFiltroSmartScreen"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Wifi Sense");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaWifiSense"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Desktop Remoto");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaDesktopRemoto"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita attivazione del Numlock in avvio");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaattivazionedelNumlockinavvio"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita News e Interessi");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaNewseInteressi"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Index File");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaIndexFile"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Edge PDF");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaEdgePDF"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Mappe");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaMappe"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita UWP apps");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaUWPapps"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Esperienze Personalizzate Microsoft");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaEsperienzePersonalizzateMicrosoft"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Esperienze Personalizzate Microsoft");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaEsperienzePersonalizzateMicrosoft"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Background App");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaBackgroundApp"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Feedback");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaFeedback"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Advertising ID");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaAdvertisingID"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Filtro Smart Screen");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaFiltroSmartScreen"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Wifi Sense");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaWifiSense"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Desktop Remoto");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaDesktopRemoto"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita attivazione del Numlock in avvio");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaattivazionedelNumlockinavvio"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita News e Interessi");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaNewseInteressi"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Risparmio Energetico Personalizzato");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaRisparmioEnergeticoPersonalizzato"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Mappe");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaMappe"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita UWP apps");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaUWPapps"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Esperienze Personalizzate Microsoft");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaEsperienzePersonalizzateMicrosoft"));
            }
        }

        private void btnAvviaSelezionatiUti_Click(object sender, EventArgs e)
        {
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Background App"))
            {
                SetCheckboxState("DisabilitaBackgroundApp", true);
                string regCommand = @"reg add HKCU\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications /v GlobalUserDisabled /t REG_DWORD /d 1 /f";

                try
                {
                    System.Diagnostics.Process.Start("cmd.exe", "/c " + regCommand).WaitForExit();
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Get-ChildItem -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications"" -Exclude ""Microsoft.Windows.Cortana*"" | ForEach {
                    Set-ItemProperty -Path $_.PsPath -Name ""Disabled"" -Type DWord -Value 1;
                    Set-ItemProperty -Path $_.PsPath -Name ""DisabledByUser"" -Type DWord -Value 1
                }
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runas"
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
                    MessageBox.Show($"Si è verificato un errore: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaBackgroundApp", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Feedback"))
            {
                SetCheckboxState("DisabilitaFeedback", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Siuf\Rules"" -Name ""NumberOfSIUFInPeriod"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection"" -Name ""DoNotShowFeedbackNotifications"" -Type DWord -Value 1;
                Disable-ScheduledTask -TaskName ""Microsoft\Windows\Feedback\Siuf\DmClient"" -ErrorAction SilentlyContinue;
                Disable-ScheduledTask -TaskName ""Microsoft\Windows\Feedback\Siuf\DmClientOnScenarioDownload"" -ErrorAction SilentlyContinue
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaFeedback", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Advertising ID"))
            {
                SetCheckboxState("DisabilitaAdvertisingID", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AdvertisingInfo\" -Name \"DisabledByGroupPolicy\" -Type DWord -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaAdvertisingID", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Filtro Smart Screen"))
            {
                SetCheckboxState("DisabilitaFiltroSmartScreen", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableSmartScreen"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter"" -Name ""EnabledV9"" -Type DWord -Value 0
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaFiltroSmartScreen", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Wifi Sense"))
            {
                SetCheckboxState("DisabilitaWifiSense", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowWiFiHotSpotReporting"" -Name ""Value"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowAutoConnectToWiFiSenseHotspots"" -Name ""Value"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config"" -Name ""AutoConnectAllowedOEM"" -Type Dword -Value 0;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config"" -Name ""WiFISenseAllowed"" -Type Dword -Value 0
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaWifiSense", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Desktop Remoto"))
            {
                SetCheckboxState("DisabilitaDesktopRemoto", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server"" -Name ""fDenyTSConnections"" -Type DWord -Value 1;
                Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp"" -Name ""UserAuthentication"" -Type DWord -Value 1
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaDesktopRemoto", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita attivazione del Numlock in avvio"))
            {
                SetCheckboxState("DisabilitaattivazionedelNumlockinavvio", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                New-PSDrive -Name ""HKU"" -PSProvider ""Registry"" -Root ""HKEY_USERS"" | Out-Null;
                Set-ItemProperty -Path ""HKU:\.DEFAULT\Control Panel\Keyboard"" -Name ""InitialKeyboardIndicators"" -Type DWord -Value 2147483648;
                Add-Type -AssemblyName System.Windows.Forms;
                if ([System.Windows.Forms.Control]::IsKeyLocked('NumLock')) {
                    $wsh = New-Object -ComObject WScript.Shell;
                    $wsh.SendKeys('{NUMLOCK}')
                }
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaattivazionedelNumlockinavvio", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita News e Interessi"))
            {
                SetCheckboxState("DisabilitaNewseInteressi", true);
                try
                {
                    var startInfo1 = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Feeds\" -Name \"EnableFeeds\" -Type DWord -Value 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runas"
                    };

                    using (var process1 = System.Diagnostics.Process.Start(startInfo1))
                    {
                        process1.WaitForExit();

                        var output1 = process1.StandardOutput.ReadToEnd();
                        var error1 = process1.StandardError.ReadToEnd();
                        if (!string.IsNullOrEmpty(error1))
                        {
                            MessageBox.Show($"Errore PowerShell: {error1}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                    var startInfo2 = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "reg.exe",
                        Arguments = "add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Feeds\" /v \"ShellFeedsTaskbarViewMode\" /t REG_DWORD /d 2 /f",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runas"
                    };

                    using (var process2 = System.Diagnostics.Process.Start(startInfo2))
                    {
                        process2.WaitForExit();

                        var output2 = process2.StandardOutput.ReadToEnd();
                        var error2 = process2.StandardError.ReadToEnd();
                        if (!string.IsNullOrEmpty(error2))
                        {
                            MessageBox.Show($"Errore reg.exe: {error2}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Si è verificato un errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SetCheckboxState("DisabilitaNewseInteressi", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Index File"))
            {
                SetCheckboxState("DisabilitaIndexFile", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                $obj = Get-WmiObject -Class Win32_Volume -Filter ""DriveLetter='$Drive'"";
                $indexing = $obj.IndexingEnabled;
                if ($indexing -eq $True) {
                    write-host ""Disabling indexing of drive $Drive"";
                    $obj | Set-WmiInstance -Arguments @{IndexingEnabled=$False} | Out-Null
                }
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaIndexFile", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Edge PDF"))
            {
                SetCheckboxState("DisabilitaEdgePDF", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                $NoPDF = ""HKCR:\.pdf"";
                $NoProgids = ""HKCR:\.pdf\OpenWithProgids"";
                $NoWithList = ""HKCR:\.pdf\OpenWithList"";
                New-ItemProperty $NoPDF NoOpenWith;
                New-ItemProperty $NoPDF NoStaticDefaultVerb;
                New-ItemProperty $NoProgids NoOpenWith;
                New-ItemProperty $NoProgids NoStaticDefaultVerb;
                New-ItemProperty $NoWithList NoOpenWith;
                New-ItemProperty $NoWithList NoStaticDefaultVerb;
                $Edge = ""HKCR:\AppXd4nrz8ff68srnhf9t5a8sbjyar1cr723_"";
                if (Test-Path $Edge) {
                    Set-Item $Edge AppXd4nrz8ff68srnhf9t5a8sbjyar1cr723_
                }
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaEdgePDF", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Mappe"))
            {
                SetCheckboxState("DisabilitaMappe", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SYSTEM\\Maps\" -Name \"AutoUpdateEnabled\" -Type DWord -Value 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaMappe", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita UWP apps"))
            {
                SetCheckboxState("DisabilitaUWPapps", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                if ([System.Environment]::OSVersion.Version.Build -ge 17763) {
                    if (!(Test-Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"")) {
                        New-Item -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Force
                    }
                    Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"" -Name ""LetAppsRunInBackground"" -Type DWord -Value 2
                } else {
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
                Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management"" -Name ""SwapfileControl"" -Type Dword -Value 0
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaUWPapps", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Esperienze Personalizzate Microsoft"))
            {
                SetCheckboxState("DisabilitaEsperienzePersonalizzateMicrosoft", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableCdp"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableMmx"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKCU:\SOFTWARE\Policies\Microsoft\Windows\CloudContent"" -Name ""DisableTailoredExperiencesWithDiagnosticData"" -Type DWord -Value 1
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("DisabilitaEsperienzePersonalizzateMicrosoft", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Background App"))
            {
                SetCheckboxState("AbilitaBackgroundApp", true);
                string regCommand = @"reg add HKCU\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications /v GlobalUserDisabled /t REG_DWORD /d 0 /f";

                try
                {
                    System.Diagnostics.Process.Start("cmd.exe", "/c " + regCommand).WaitForExit();
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Get-ChildItem -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications"" -Exclude ""Microsoft.Windows.Cortana*"" | ForEach {
                    Remove-ItemProperty -Path $_.PsPath -Name ""Disabled"" -ErrorAction SilentlyContinue
                    Remove-ItemProperty -Path $_.PsPath -Name ""DisabledByUser"" -ErrorAction SilentlyContinue
                }
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaBackgroundApp", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Feedback"))
            {
                SetCheckboxState("AbilitaFeedback", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Remove-ItemProperty -Path ""HKCU:\SOFTWARE\Microsoft\Siuf\Rules"" -Name ""NumberOfSIUFInPeriod"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection"" -Name ""DoNotShowFeedbackNotifications"" -ErrorAction SilentlyContinue;
                Enable-ScheduledTask -TaskName ""Microsoft\Windows\Feedback\Siuf\DmClient"" -ErrorAction SilentlyContinue;
                Enable-ScheduledTask -TaskName ""Microsoft\Windows\Feedback\Siuf\DmClientOnScenarioDownload"" -ErrorAction SilentlyContinue
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaFeedback", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Advertising ID"))
            {
                SetCheckboxState("AbilitaAdvertisingID", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AdvertisingInfo\" -Name \"DisabledByGroupPolicy\" -ErrorAction SilentlyContinue",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaAdvertisingID", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Filtro Smart Screen"))
            {
                SetCheckboxState("AbilitaFiltroSmartScreen", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\System"" -Name ""EnableSmartScreen"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter"" -Name ""EnabledV9"" -ErrorAction SilentlyContinue
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaFiltroSmartScreen", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Wifi Sense"))
            {
                SetCheckboxState("AbilitaWifiSense", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowWiFiHotSpotReporting"" -Name ""Value"" -Type DWord -Value 1;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowAutoConnectToWiFiSenseHotspots"" -Name ""Value"" -Type DWord -Value 1;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config"" -Name ""AutoConnectAllowedOEM"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config"" -Name ""WiFISenseAllowed"" -ErrorAction SilentlyContinue
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaWifiSense", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Desktop Remoto"))
            {
                SetCheckboxState("AbilitaDesktopRemoto", false);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server"" -Name ""fDenyTSConnections"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp"" -Name ""UserAuthentication"" -Type DWord -Value 0;
                Enable-NetFirewallRule -Name ""RemoteDesktop*""
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaDesktopRemoto", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita attivazione del Numlock in avvio"))
            {
                SetCheckboxState("AbilitaattivazionedelNumlockinavvio", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                If (!(Test-Path ""HKU:"")) {
                    New-PSDrive -Name ""HKU"" -PSProvider ""Registry"" -Root ""HKEY_USERS"" | Out-Null
                }
                Set-ItemProperty -Path ""HKU:\.DEFAULT\Control Panel\Keyboard"" -Name ""InitialKeyboardIndicators"" -Type DWord -Value 2147483650
                Add-Type -AssemblyName System.Windows.Forms
                If (!([System.Windows.Forms.Control]::IsKeyLocked('NumLock'))) {
                    $wsh = New-Object -ComObject WScript.Shell
                    $wsh.SendKeys('{NUMLOCK}')
                }
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaattivazionedelNumlockinavvio", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita News e Interessi"))
            {
                SetCheckboxState("AbilitaNewseInteressi", true);
                try
                {
                    var startInfo1 = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Feeds\" -Name \"EnableFeeds\" -Type DWord -Value 1",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runas"
                    };

                    using (var process1 = System.Diagnostics.Process.Start(startInfo1))
                    {
                        process1.WaitForExit();

                        var output1 = process1.StandardOutput.ReadToEnd();
                        var error1 = process1.StandardError.ReadToEnd();
                        if (!string.IsNullOrEmpty(error1))
                        {
                            MessageBox.Show($"Errore PowerShell: {error1}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                    var startInfo2 = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "reg.exe",
                        Arguments = "add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Feeds\" /v \"ShellFeedsTaskbarViewMode\" /t REG_DWORD /d 0 /f",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runas"
                    };

                    using (var process2 = System.Diagnostics.Process.Start(startInfo2))
                    {
                        process2.WaitForExit();

                        var output2 = process2.StandardOutput.ReadToEnd();
                        var error2 = process2.StandardError.ReadToEnd();
                        if (!string.IsNullOrEmpty(error2))
                        {
                            MessageBox.Show($"Errore reg.exe: {error2}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Si è verificato un errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SetCheckboxState("AbilitaNewseInteressi", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Risparmio Energetico Personalizzato"))
            {
                SetCheckboxState("AbilitaRisparmioEnergeticoPersonalizzato", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "cmd.exe",
                        Arguments = "/C powercfg -duplicatescheme a1841308-3541-4fab-bc81-f71556f20b4a && powercfg -duplicatescheme 381b4222-f694-41f0-9685-ff5bb260df2e && powercfg -duplicatescheme 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c && powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaRisparmioEnergeticoPersonalizzato", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Migliora uso SSD"))
            {
                SetCheckboxState("MigliorausoSSD", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "cmd.exe",
                        Arguments = "/C fsutil behavior set DisableLastAccess 1 && fsutil behavior set EncryptPagingFile 0",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("MigliorausoSSD", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Mappe"))
            {
                SetCheckboxState("AbilitaMappe", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SYSTEM\\Maps\" -Name \"AutoUpdateEnabled\" -ErrorAction SilentlyContinue",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaMappe", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita UWP apps"))
            {
                SetCheckboxState("AbilitaUWPapps", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "-Command \"Remove-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management' -Name 'SwapfileControl' -ErrorAction SilentlyContinue; " +
                        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\documentsLibrary' -Name 'Value' -Type String -Value 'Allow'; " +
                        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\picturesLibrary' -Name 'Value' -Type String -Value 'Allow'; " +
                        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\videosLibrary' -Name 'Value' -Type String -Value 'Allow'; " +
                        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\broadFileSystemAccess' -Name 'Value' -Type String -Value 'Allow'; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsGetDiagnosticInfo' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsSyncWithDevices' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsAccessRadios' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsAccessMessaging' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsAccessTasks' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsAccessEmail' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsAccessCallHistory' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsAccessPhone' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsAccessCalendar' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsAccessContacts' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsAccessAccountInfo' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsAccessNotifications' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsActivateWithVoice' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsActivateWithVoiceAboveLock' -ErrorAction SilentlyContinue; " +
                        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy' -Name 'LetAppsRunInBackground' -ErrorAction SilentlyContinue; " +
                        "Get-ChildItem -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications' | ForEach-Object { " +
                        "    Remove-ItemProperty -Path $_.PsPath -Name 'Disabled' -ErrorAction SilentlyContinue; " +
                        "    Remove-ItemProperty -Path $_.PsPath -Name 'DisabledByUser' -ErrorAction SilentlyContinue; " +
                        "}\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaUWPapps", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Esperienze Personalizzate Microsoft"))
            {
                SetCheckboxState("AbilitaEsperienzePersonalizzateMicrosoft", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKCU:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent\" -Name \"DisableTailoredExperiencesWithDiagnosticData\" -ErrorAction SilentlyContinue",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
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
            else
            {
                SetCheckboxState("AbilitaEsperienzePersonalizzateMicrosoft", false);
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
