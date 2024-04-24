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

        private void btnAvviaSelezionatiDef_Click(object sender, EventArgs e)
        {
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Controllo Accesso Cartella"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-MpPreference -EnableControlledFolderAccess Disabled -ErrorAction SilentlyContinue",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Isolamento Core"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity\" -Name \"Enabled\" -ErrorAction SilentlyContinue",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Applicazione Defender Guard"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Disable-WindowsOptionalFeature -online -FeatureName \"Windows-Defender-ApplicationGuard\" -NoRestart -WarningAction SilentlyContinue",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Protezione Account Warning"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty \"HKCU:\\Software\\Microsoft\\Windows Security Health\\State\" -Name \"AccountProtection_MicrosoftAccount_Disconnected\" -Type DWord -Value 1",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Blocco Download Files"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments\" -Name \"SaveZoneInformation\" -Type DWord -Value 1",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Script Host"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows Script Host\\Settings\" -Name \"Enabled\" -Type DWord -Value 0",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita .NET Strong Cryptography"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\.NETFramework\\v4.0.30319\" -Name \"SchUseStrongCrypto\" -ErrorAction SilentlyContinue",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita .NET Strong Cryptography"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\.NETFramework\\v4.0.30319\" -Name \"SchUseStrongCrypto\" -ErrorAction SilentlyContinue",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Meltdown CVE-2017-5754"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\QualityCompat\" -Name \"cadca5fe-87d3-4b96-b7fb-a231484277cc\" -ErrorAction SilentlyContinue",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Livello Minimo UAC"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" -Name \"ConsentPromptBehaviorAdmin\" -Type DWord -Value 0",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Livello Minimo UAC"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" -Name \"PromptOnSecureDesktop\" -Type DWord -Value 0",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Implicit Administrative Sheres"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" -Name \"AutoShareWks\" -Type DWord -Value 0",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Firewall"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\WindowsFirewall\\StandardProfile\" -Name \"EnableFirewall\" -Type DWord -Value 0",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Defender CLoud"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet\" -Name \"SpynetReporting\" -Type DWord -Value 0; Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet\" -Name \"SubmitSamplesConsent\" -Type DWord -Value 2",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Defender SysTray"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "If (!(Test-Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender Security Center\\Systray\")) { New-Item -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender Security Center\\Systray\" -Force | Out-Null } Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender Security Center\\Systray\" -Name \"HideSystray\" -Type DWord -Value 1 If ([System.Environment]::OSVersion.Version.Build -eq 14393) { Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"WindowsDefender\" -ErrorAction SilentlyContinue } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 15063) { Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"SecurityHealth\" -ErrorAction SilentlyContinue }",
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
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Defender Services"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Takeown-Registry(\"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\"); Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\" \"Start\" 4; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\" \"AutorunsDisabled\" 3; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WdNisSvc\" \"Start\" 4; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WdNisSvc\" \"AutorunsDisabled\" 3; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\Sense\" \"Start\" 4; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\Sense\" \"AutorunsDisabled\" 3",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Controllo Accesso Cartella"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-MpPreference -EnableControlledFolderAccess Enabled -ErrorAction SilentlyContinue",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Isolamento Core"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity\" -Name \"Enabled\" -Type DWord -Value 1",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Applicazione Defender Guard"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Enable-WindowsOptionalFeature -online -FeatureName \"Windows-Defender-ApplicationGuard\" -NoRestart -WarningAction SilentlyContinue",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Protezione Account Warning"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty \"HKCU:\\Software\\Microsoft\\Windows Security Health\\State\" -Name \"AccountProtection_MicrosoftAccount_Disconnected\" -ErrorAction SilentlyContinue",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Blocco Download Files"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments\" -Name \"SaveZoneInformation\" -ErrorAction SilentlyContinue",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Script Host"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows Script Host\\Settings\" -Name \"Enabled\" -ErrorAction SilentlyContinue",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita .NET Strong Cryptography"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\.NETFramework\\v4.0.30319\" -Name \"SchUseStrongCrypto\" -Type DWord -Value 1; Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\.NETFramework\\v4.0.30319\" -Name \"SchUseStrongCrypto\" -Type DWord -Value 1",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Meltdown CVE-2017-5754"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\QualityCompat\" -Name \"cadca5fe-87d3-4b96-b7fb-a231484277cc\" -Type DWord -Value 0",
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
            else if (AbilitaDefender.CheckedItems.Contains("Livello Massimo UAC"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" -Name \"ConsentPromptBehaviorAdmin\" -Type DWord -Value 5; Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" -Name \"PromptOnSecureDesktop\" -Type DWord -Value 1",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Implicit Administrative Sheres"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" -Name \"AutoShareWks\" -ErrorAction SilentlyContinue",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Firewall"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\WindowsFirewall\\StandardProfile\" -Name \"EnableFirewall\" -ErrorAction SilentlyContinue",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\" -Name \"DisableAntiSpyware\" -ErrorAction SilentlyContinue; If ([System.Environment]::OSVersion.Version.Build -eq 14393) { Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"WindowsDefender\" -Type ExpandString -Value \"`\"%ProgramFiles%\\Windows Defender\\MSASCuiL.exe`\"\" } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 15063) { Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"SecurityHealth\" -Type ExpandString -Value \"`\"%ProgramFiles%\\Windows Defender\\MSASCuiL.exe`\"\" }",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender CLoud"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet\" -Name \"SpynetReporting\" -ErrorAction SilentlyContinue; Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet\" -Name \"SubmitSamplesConsent\" -ErrorAction SilentlyContinue",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender SysTray"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender Security Center\\Systray\" -Name \"HideSystray\" -ErrorAction SilentlyContinue; If ([System.Environment]::OSVersion.Version.Build -eq 14393) { Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"WindowsDefender\" -Type ExpandString -Value \"`\"%ProgramFiles%\\Windows Defender\\MSASCuiL.exe`\"\" } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 15063 -And [System.Environment]::OSVersion.Version.Build -le 17134) { Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"SecurityHealth\" -Type ExpandString -Value \"%ProgramFiles%\\Windows Defender\\MSASCuiL.exe\" } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 17763) { Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" -Name \"SecurityHealth\" -Type ExpandString -Value \"%windir%\\system32\\SecurityHealthSystray.exe\" }",
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
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender Services"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Takeown-Registry(\"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\"); Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\" \"Start\" 3; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\" \"AutorunsDisabled\" 4; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WdNisSvc\" \"Start\" 3; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\WdNisSvc\" \"AutorunsDisabled\" 4; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\Sense\" \"Start\" 3; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\Sense\" \"AutorunsDisabled\" 4",
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
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

