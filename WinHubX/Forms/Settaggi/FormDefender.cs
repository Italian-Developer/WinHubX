using Microsoft.Win32;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.Settaggi
{
    public partial class FormDefender : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormDefender(FormSettaggi formSettaggi, Form1 form1)
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
            int index = DisabilitaDefender.Items.IndexOf("Disabilita Controllo Accesso Cartella");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaControlloAccessoCartella"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Isolamento Core");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaIsolamentoCore"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Applicazione Defender Guard");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaApplicazioneDefenderGuard"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Protezione Account Warning");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaProtezioneAccountWarning"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Blocco Download Files");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaBloccoDownloadFiles"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Windows Script Host");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaWindowsScriptHost"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita .NET Strong Cryptography");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaNETStrongCryptography"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Meltdown CVE-2017-5754");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaMeltdownCVE-2017-5754"));
            }
            index = DisabilitaDefender.Items.IndexOf("Livello Minimo UAC");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("LivelloMinimoUAC"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Implicit Administrative Sheres");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaImplicitAdministrativeSheres"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Windows Firewall");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaWindowsFirewall"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Windows Defender CLoud");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaWindowsDefenderCLoud"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Windows Defender SysTray");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaWindowsDefenderSysTray"));
            }
            index = DisabilitaDefender.Items.IndexOf("Disabilita Windows Defender Services");
            if (index != -1)
            {
                DisabilitaDefender.SetItemChecked(index, GetCheckboxState("DisabilitaWindowsDefenderServices"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Controllo Accesso Cartella");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaControlloAccessoCartella"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Isolamento Core");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaIsolamentoCore"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Applicazione Defender Guard");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaApplicazioneDefenderGuard"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Protezione Account Warning");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaProtezioneAccountWarning"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Blocco Download Files");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaBloccoDownloadFiles"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Windows Script Host");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaWindowsScriptHost"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita .NET Strong Cryptography");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaNETStrongCryptography"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Meltdown CVE-2017-5754");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaMeltdownCVE-2017-5754"));
            }
            index = AbilitaDefender.Items.IndexOf("Livello Massimo UAC");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("LivelloMassimoUAC"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Implicit Administrative Sheres");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaImplicitAdministrativeSheres"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Windows Firewall");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaWindowsFirewall"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Windows Defender CLoud");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaWindowsDefenderCLoud"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Windows Defender SysTray");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaWindowsDefenderSysTray"));
            }
            index = AbilitaDefender.Items.IndexOf("Abilita Windows Defender Services");
            if (index != -1)
            {
                AbilitaDefender.SetItemChecked(index, GetCheckboxState("AbilitaWindowsDefenderServices"));
            }
        }

        private void btnAvviaSelezionatiDef_Click(object sender, EventArgs e)
        {
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Controllo Accesso Cartella"))
            {
                SetCheckboxState("DisabilitaControlloAccessoCartella", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-MpPreference -EnableControlledFolderAccess Disabled -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaControlloAccessoCartella", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Isolamento Core"))
            {
                SetCheckboxState("DisabilitaIsolamentoCore", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity\" -Name \"Enabled\" -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaIsolamentoCore", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Applicazione Defender Guard"))
            {
                SetCheckboxState("DisabilitaApplicazioneDefernderGuard", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Disable-WindowsOptionalFeature -online -FeatureName \"Windows-Defender-ApplicationGuard\" -NoRestart -WarningAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaApplicazioneDefernderGuard", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Protezione Account Warning"))
            {
                SetCheckboxState("DisabilitaProtezioneAccountWarning", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty \"HKCU:\\Software\\Microsoft\\Windows Security Health\\State\" -Name \"AccountProtection_MicrosoftAccount_Disconnected\" -Type DWord -Value 1",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaProtezioneAccountWarning", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Blocco Download Files"))
            {
                SetCheckboxState("DisabilitaBloccoDownloadFiles", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments\" -Name \"SaveZoneInformation\" -Type DWord -Value 1",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaBloccoDownloadFiles", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Script Host"))
            {
                SetCheckboxState("DisabilitaWindowsScriptHost", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows Script Host\\Settings\" -Name \"Enabled\" -Type DWord -Value 0",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaWindowsScriptHost", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita .NET Strong Cryptography"))
            {
                SetCheckboxState("DisabilitaNETStrongCryptography", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\.NETFramework\\v4.0.30319\" -Name \"SchUseStrongCrypto\" -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaNETStrongCryptography", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Meltdown CVE-2017-5754"))
            {
                SetCheckboxState("DisabilitaMeltdownCVE-2017-5754", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\QualityCompat\" -Name \"cadca5fe-87d3-4b96-b7fb-a231484277cc\" -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaMeltdownCVE-2017-5754", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Livello Minimo UAC"))
            {
                SetCheckboxState("LivelloMinimoUAC", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" -Name \"ConsentPromptBehaviorAdmin\" -Type DWord -Value 0",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("LivelloMinimoUAC", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Implicit Administrative Sheres"))
            {
                SetCheckboxState("DisabilitaImplicitAdministrativeSheres", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" -Name \"AutoShareWks\" -Type DWord -Value 0",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaImplicitAdministrativeSheres", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Firewall"))
            {
                SetCheckboxState("DisabilitaWindowsFirewall", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\WindowsFirewall\\StandardProfile\" -Name \"EnableFirewall\" -Type DWord -Value 0",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaWindowsFirewall", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Defender CLoud"))
            {
                SetCheckboxState("DisabilitaWindowsDefenderCLoud", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet\" -Name \"SpynetReporting\" -Type DWord -Value 0; Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet\" -Name \"SubmitSamplesConsent\" -Type DWord -Value 2",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaWindowsDefenderCLoud", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Defender SysTray"))
            {
                SetCheckboxState("DisabilitaWindowsDefenderSysTray", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "If (!(Test-Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender Security Center\\Systray\")) { New-Item -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender Security Center\\Systray\" -Force | Out-Null } Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender Security Center\\Systray\" -Name \"HideSystray\" -Type DWord -Value 1 If ([System.Environment]::OSVersion.Version.Build -eq 14393) { Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"WindowsDefender\" -ErrorAction SilentlyContinue } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 15063) { Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"SecurityHealth\" -ErrorAction SilentlyContinue }",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaWindowsDefenderSysTray", false);
            }
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Defender Services"))
            {
                SetCheckboxState("DisabilitaWindowsDefenderServices", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Takeown-Registry(\"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\"); Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\" \"Start\" 4; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\" \"AutorunsDisabled\" 3; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WdNisSvc\" \"Start\" 4; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WdNisSvc\" \"AutorunsDisabled\" 3; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\Sense\" \"Start\" 4; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\Sense\" \"AutorunsDisabled\" 3",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("DisabilitaWindowsDefenderServices", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Controllo Accesso Cartella"))
            {
                SetCheckboxState("AbilitaControlloAccessoCartella", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-MpPreference -EnableControlledFolderAccess Enabled -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaControlloAccessoCartella", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Isolamento Core"))
            {
                SetCheckboxState("AbilitaIsolamentoCore", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity\" -Name \"Enabled\" -Type DWord -Value 1",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaIsolamentoCore", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Applicazione Defender Guard"))
            {
                SetCheckboxState("AbilitaApplicazioneDefenderGuard", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Enable-WindowsOptionalFeature -online -FeatureName \"Windows-Defender-ApplicationGuard\" -NoRestart -WarningAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaApplicazioneDefenderGuard", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Protezione Account Warning"))
            {
                SetCheckboxState("AbilitaProtezioneAccountWarning", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty \"HKCU:\\Software\\Microsoft\\Windows Security Health\\State\" -Name \"AccountProtection_MicrosoftAccount_Disconnected\" -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaProtezioneAccountWarning", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Blocco Download Files"))
            {
                SetCheckboxState("AbilitaBloccoDownloadFiles", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments\" -Name \"SaveZoneInformation\" -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaBloccoDownloadFiles", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Script Host"))
            {
                SetCheckboxState("AbilitaWindowsScriptHost", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows Script Host\\Settings\" -Name \"Enabled\" -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaWindowsScriptHost", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita .NET Strong Cryptography"))
            {
                SetCheckboxState("AbilitaNETStrongCryptography", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\.NETFramework\\v4.0.30319\" -Name \"SchUseStrongCrypto\" -Type DWord -Value 1; Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\.NETFramework\\v4.0.30319\" -Name \"SchUseStrongCrypto\" -Type DWord -Value 1",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaNETStrongCryptography", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Meltdown CVE-2017-5754"))
            {
                SetCheckboxState("AbilitaMeltdownCVE-2017-5754", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\QualityCompat\" -Name \"cadca5fe-87d3-4b96-b7fb-a231484277cc\" -Type DWord -Value 0",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaMeltdownCVE-2017-5754", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Livello Massimo UAC"))
            {
                SetCheckboxState("LivelloMassimoUAC", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" -Name \"ConsentPromptBehaviorAdmin\" -Type DWord -Value 5; Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" -Name \"PromptOnSecureDesktop\" -Type DWord -Value 1",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("LivelloMassimoUAC", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Implicit Administrative Sheres"))
            {
                SetCheckboxState("AbilitaImplicitAdministrativeSheres", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" -Name \"AutoShareWks\" -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaImplicitAdministrativeSheres", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Firewall"))
            {
                SetCheckboxState("AbilitaWindowsFirewall", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\WindowsFirewall\\StandardProfile\" -Name \"EnableFirewall\" -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaWindowsFirewall", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender CLoud"))
            {
                SetCheckboxState("AbilitaWindowsDefenderCLoud", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet\" -Name \"SpynetReporting\" -ErrorAction SilentlyContinue; Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet\" -Name \"SubmitSamplesConsent\" -ErrorAction SilentlyContinue",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaWindowsDefenderCLoud", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender SysTray"))
            {
                SetCheckboxState("AbilitaWindowsDefenderSysTray", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender Security Center\\Systray\" -Name \"HideSystray\" -ErrorAction SilentlyContinue; If ([System.Environment]::OSVersion.Version.Build -eq 14393) { Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"WindowsDefender\" -Type ExpandString -Value \"`\"%ProgramFiles%\\Windows Defender\\MSASCuiL.exe`\"\" } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 15063 -And [System.Environment]::OSVersion.Version.Build -le 17134) { Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"SecurityHealth\" -Type ExpandString -Value \"%ProgramFiles%\\Windows Defender\\MSASCuiL.exe\" } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 17763) { Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"SecurityHealth\" -Type ExpandString -Value \"%windir%\\system32\\SecurityHealthSystray.exe\" }",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaWindowsDefenderSysTray", false);
            }
            if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender Services"))
            {
                SetCheckboxState("AbilitaWindowsDefenderServices", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Takeown-Registry(\"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\"); Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\" \"Start\" 3; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\" \"AutorunsDisabled\" 4; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WdNisSvc\" \"Start\" 3; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WdNisSvc\" \"AutorunsDisabled\" 4; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\Sense\" \"Start\" 3; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\Sense\" \"AutorunsDisabled\" 4",
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                SetCheckboxState("AbilitaWindowsDefenderServices", false);
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProtezioneMinima_Click(object sender, EventArgs e)
        {
            try
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = @"Set-MpPreference -EnableControlledFolderAccess Disabled -ErrorAction SilentlyContinue; " +
            @"Remove-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity"" -Name ""Enabled"" -ErrorAction SilentlyContinue; " +
            @"Disable-WindowsOptionalFeature -online -FeatureName ""Windows-Defender-ApplicationGuard"" -NoRestart -WarningAction SilentlyContinue; " +
            @"Set-ItemProperty ""HKCU:\Software\Microsoft\Windows Security Health\State"" -Name ""AccountProtection_MicrosoftAccount_Disconnected"" -Type DWord -Value 1; " +
            @"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\Policies\Attachments"" -Name ""SaveZoneInformation"" -Type DWord -Value 1; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows Script Host\Settings"" -Name ""Enabled"" -Type DWord -Value 0; " +
            @"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -ErrorAction SilentlyContinue; " +
            @"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -ErrorAction SilentlyContinue; " +
            @"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\QualityCompat"" -Name ""cadca5fe-87d3-4b96-b7fb-a231484277cc"" -ErrorAction SilentlyContinue; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""ConsentPromptBehaviorAdmin"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""PromptOnSecureDesktop"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters"" -Name ""AutoShareWks"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SpynetReporting"" -Type DWord -Value 0; " +
            @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SubmitSamplesConsent"" -Type DWord -Value 2",

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
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRipristinaDefender_Click(object sender, EventArgs e)
        {
            try
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = @"Set-MpPreference -EnableControlledFolderAccess Enabled -ErrorAction SilentlyContinue; " +
                        @"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity"" -Name ""Enabled"" -Type DWord -Value 1; " +
                        @"Enable-WindowsOptionalFeature -online -FeatureName ""Windows-Defender-ApplicationGuard"" -NoRestart -WarningAction SilentlyContinue; " +
                        @"Remove-ItemProperty ""HKCU:\Software\Microsoft\Windows Security Health\State"" -Name ""AccountProtection_MicrosoftAccount_Disconnected"" -ErrorAction SilentlyContinue; " +
                        @"Remove-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\Policies\Attachments"" -Name ""SaveZoneInformation"" -ErrorAction SilentlyContinue; " +
                        @"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows Script Host\Settings"" -Name ""Enabled"" -ErrorAction SilentlyContinue; " +
                        @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -Type DWord -Value 1; " +
                        @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -Type DWord -Value 1; " +
                        @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\QualityCompat"" -Name ""cadca5fe-87d3-4b96-b7fb-a231484277cc"" -Type DWord -Value 0; " +
                        @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""ConsentPromptBehaviorAdmin"" -Type DWord -Value 5; " +
                        @"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""PromptOnSecureDesktop"" -Type DWord -Value 1; " +
                        @"Remove-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters"" -Name ""AutoShareWks"" -ErrorAction SilentlyContinue; " +
                        @"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SpynetReporting"" -ErrorAction SilentlyContinue; " +
                        @"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SubmitSamplesConsent"" -ErrorAction SilentlyContinue;",
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
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

