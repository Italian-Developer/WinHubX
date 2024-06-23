using Microsoft.Win32;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.Settaggi
{
    public partial class FormUpdate : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormUpdate(FormSettaggi formSettaggi, Form1 form1)
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
            int index = DisabilitaUpdate.Items.IndexOf("Disabilita Download Automatico Windows Update");
            if (index != -1)
            {
                DisabilitaUpdate.SetItemChecked(index, GetCheckboxState("DisabilitaDownloadAutomaticoWindowsUpdate"));
            }
            index = DisabilitaUpdate.Items.IndexOf("Disabilita Update Prodotti Microsoft");
            if (index != -1)
            {
                DisabilitaUpdate.SetItemChecked(index, GetCheckboxState("DisabilitaUpdateProdottiMicrosoft"));
            }
            index = DisabilitaUpdate.Items.IndexOf("Disabilita Download Driver Windows Update");
            if (index != -1)
            {
                DisabilitaUpdate.SetItemChecked(index, GetCheckboxState("DisabilitaDownloadDriverWindowsUpdate"));
            }
            index = DisabilitaUpdate.Items.IndexOf("Disabilita Riavvio Automatico Windows Update");
            if (index != -1)
            {
                DisabilitaUpdate.SetItemChecked(index, GetCheckboxState("DisabilitaRiavvioAutomaticoWindowsUpdate"));
            }
            index = DisabilitaUpdate.Items.IndexOf("Disabilita Notifiche Update");
            if (index != -1)
            {
                DisabilitaUpdate.SetItemChecked(index, GetCheckboxState("DisabilitaNotificheUpdate"));
            }
            index = AbilitaUpdate.Items.IndexOf("Abilita Download Automatico Windows Update");
            if (index != -1)
            {
                AbilitaUpdate.SetItemChecked(index, GetCheckboxState("AbilitaDownloadAutomaticoWindowsUpdate"));
            }
            index = AbilitaUpdate.Items.IndexOf("Abilita Update Prodotti Microsoft");
            if (index != -1)
            {
                AbilitaUpdate.SetItemChecked(index, GetCheckboxState("AbilitaUpdateProdottiMicrosoft"));
            }
            index = AbilitaUpdate.Items.IndexOf("Abilita Download Driver Windows Update");
            if (index != -1)
            {
                AbilitaUpdate.SetItemChecked(index, GetCheckboxState("AbilitaDownloadDriverWindowsUpdate"));
            }
            index = AbilitaUpdate.Items.IndexOf("Abilita Riavvio Automatico Windows Update");
            if (index != -1)
            {
                AbilitaUpdate.SetItemChecked(index, GetCheckboxState("AbilitaRiavvioAutomaticoWindowsUpdate"));
            }
            index = AbilitaUpdate.Items.IndexOf("Abilita Notifiche Update");
            if (index != -1)
            {
                AbilitaUpdate.SetItemChecked(index, GetCheckboxState("AbilitaNotificheUpdate"));
            }
        }

        private void btnAvviaSelezionatiUpda_Click(object sender, EventArgs e)
        {
            if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Download Automatico Windows Update"))
            {
                SetCheckboxState("DisabilitaDownloadAutomaticoWindowsUpdate", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\" -Name \"AUOptions\" -Type DWord -Value 2",
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
                SetCheckboxState("DisabilitaDownloadAutomaticoWindowsUpdate", false);
            }
            if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Update Prodotti Microsoft"))
            {
                SetCheckboxState("DisabilitaUpdateProdottiMicrosoft", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                         If ((New-Object -ComObject Microsoft.Update.ServiceManager).Services | Where-Object { $_.ServiceID -eq ""7971f918-a847-4430-9279-4a52d1efe18d""}) {
                         (New-Object -ComObject Microsoft.Update.ServiceManager).RemoveService(""7971f918-a847-4430-9279-4a52d1efe18d"")
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
                SetCheckboxState("DisabilitaUpdateProdottiMicrosoft", false);
            }
            if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Download Driver Windows Update"))
            {
                SetCheckboxState("DisabilitaDownloadDriverWindowsUpdate", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\Device Metadata"" -Name ""PreventDeviceMetadataFromNetwork"" -Type DWord -Value 1;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""SearchOrderConfig"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"" -Name ""ExcludeWUDriversInQualityUpdate"" -Type DWord -Value 1
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
                SetCheckboxState("DisabilitaDownloadDriverWindowsUpdate", false);
            }
            if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Riavvio Automatico Windows Update"))
            {
                SetCheckboxState("DisabilitaRiavvioAutomaticoWindowsUpdate", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""NoAutoRebootWithLoggedOnUsers"" -Type DWord -Value 1;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""AUPowerManagement"" -Type DWord -Value 0
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
                SetCheckboxState("DisabilitaRiavvioAutomaticoWindowsUpdate", false);
            }
            if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Notifiche Update"))
            {
                SetCheckboxState("DisabilitaNotificheUpdate", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "cmd.exe",
                        Arguments = @"/c takeown /F ""%WinDIR%\System32\MusNotification.exe"" && icacls ""%WinDIR%\System32\MusNotification.exe"" /deny ""%EveryOne%:(X)"" && takeown /F ""%WinDIR%\System32\MusNotificationUx.exe"" && icacls ""%WinDIR%\System32\MusNotificationUx.exe"" /deny ""%EveryOne%:(X)""",
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
                SetCheckboxState("DisabilitaNotificheUpdate", false);
            }
            if (AbilitaUpdate.CheckedItems.Contains("Abilita Download Automatico Windows Update"))
            {
                SetCheckboxState("AbilitaDownloadAutomaticoWindowsUpdate", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\" -Name \"AUOptions\" -ErrorAction SilentlyContinue",
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
                SetCheckboxState("AbilitaDownloadAutomaticoWindowsUpdate", false);
            }
            if (AbilitaUpdate.CheckedItems.Contains("Abilita Update Prodotti Microsoft"))
            {
                SetCheckboxState("AbilitaUpdateProdottiMicrosoft", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "(New-Object -ComObject Microsoft.Update.ServiceManager).AddService2(\"7971f918-a847-4430-9279-4a52d1efe18d\", 7, \"\")",
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
                SetCheckboxState("AbilitaUpdateProdottiMicrosoft", false);
            }
            if (AbilitaUpdate.CheckedItems.Contains("Abilita Download Driver Windows Update"))
            {
                SetCheckboxState("AbilitaDownloadDriverWindowsUpdate", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\Device Metadata"" -Name ""PreventDeviceMetadataFromNetwork"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""SearchOrderConfig"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"" -Name ""ExcludeWUDriversInQualityUpdate"" -ErrorAction SilentlyContinue
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
                SetCheckboxState("AbilitaDownloadDriverWindowsUpdate", false);
            }
            if (AbilitaUpdate.CheckedItems.Contains("Abilita Riavvio Automatico Windows Update"))
            {
                SetCheckboxState("AbilitaRiavvioAutomaticoWindowsUpdate", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\MusNotification.exe\" -Name \"Debugger\" -ErrorAction SilentlyContinue",
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
                SetCheckboxState("AbilitaRiavvioAutomaticoWindowsUpdate", false);
            }
            if (AbilitaUpdate.CheckedItems.Contains("Abilita Notifiche Update"))
            {
                SetCheckboxState("AbilitaNotificheUpdate", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "cmd.exe",
                        Arguments = @"/c takeown /F ""%WinDIR%\System32\MusNotification.exe"" && icacls ""%WinDIR%\System32\MusNotification.exe"" /allow ""%EveryOne%:(X)"" && takeown /F ""%WinDIR%\System32\MusNotificationUx.exe"" && icacls ""%WinDIR%\System32\MusNotificationUx.exe"" /allow ""%EveryOne%:(X)""",
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
                SetCheckboxState("AbilitaNotificheUpdate", false);
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdateEssential_Click(object sender, EventArgs e)
        {
            try
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = @"
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\Device Metadata"" -Name ""PreventDeviceMetadataFromNetwork"" -Type DWord -Value 1;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DontPromptForWindowsUpdate"" -Type DWord -Value 1;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DontSearchWindowsUpdate"" -Type DWord -Value 1;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DriverUpdateWizardWuSearchEnabled"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"" -Name ""ExcludeWUDriversInQualityUpdate"" -Type DWord -Value 1;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""NoAutoRebootWithLoggedOnUsers"" -Type DWord -Value 1;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""AUPowerManagement"" -Type DWord -Value 0
            ",
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

        private void btnResetUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = @"
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""NoAutoUpdate"" -Type DWord -Value 0;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""AUOptions"" -Type DWord -Value 3;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\DeliveryOptimization\Config"" -Name ""DODownloadMode"" -Type DWord -Value 1;
                $services = @(
                    ""BITS"",
                    ""wuauserv""
                );
                foreach ($service in $services) {
                    Get-Service -Name $service -ErrorAction SilentlyContinue | Set-Service -StartupType Automatic;
                }
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\Device Metadata"" -Name ""PreventDeviceMetadataFromNetwork"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DontPromptForWindowsUpdate"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DontSearchWindowsUpdate"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DriverUpdateWizardWuSearchEnabled"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"" -Name ""ExcludeWUDriversInQualityUpdate"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""NoAutoRebootWithLoggedOnUsers"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""AUPowerManagement"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WindowsUpdate\UX\Settings"" -Name ""BranchReadinessLevel"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WindowsUpdate\UX\Settings"" -Name ""DeferFeatureUpdatesPeriodInDays"" -ErrorAction SilentlyContinue;
                Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WindowsUpdate\UX\Settings"" -Name ""DeferQualityUpdatesPeriodInDays"" -ErrorAction SilentlyContinue
            ",
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
