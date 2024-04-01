using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private void btnAvviaSelezionatiUpda_Click(object sender, EventArgs e)
        {
            if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Download Automatico Windows Update"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Set-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\" -Name \"AUOptions\" -Type DWord -Value 2",
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
            else if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Update Prodotti Microsoft"))
            {
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
            else if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Download Driver Windows Update"))
            {
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
            else if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Riavvio Automatico Windows Update"))
            {
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
            else if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Notifiche Update"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "cmd.exe",
                        Arguments = @"/c takeown /F ""%WinDIR%\System32\MusNotification.exe"" && icacls ""%WinDIR%\System32\MusNotification.exe"" /deny ""%EveryOne%:(X)"" && takeown /F ""%WinDIR%\System32\MusNotificationUx.exe"" && icacls ""%WinDIR%\System32\MusNotificationUx.exe"" /deny ""%EveryOne%:(X)""",
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
            else if (AbilitaUpdate.CheckedItems.Contains("Abilita Download Automatico Windows Update"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\" -Name \"AUOptions\" -ErrorAction SilentlyContinue",
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
            else if (AbilitaUpdate.CheckedItems.Contains("Abilita Update Prodotti Microsoft"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "(New-Object -ComObject Microsoft.Update.ServiceManager).AddService2(\"7971f918-a847-4430-9279-4a52d1efe18d\", 7, \"\")",
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
            else if (AbilitaUpdate.CheckedItems.Contains("Abilita Download Driver Windows Update"))
            {
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
            else if (AbilitaUpdate.CheckedItems.Contains("Abilita Riavvio Automatico Windows Update"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Remove-ItemProperty -Path \"HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\MusNotification.exe\" -Name \"Debugger\" -ErrorAction SilentlyContinue",
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
            else if (AbilitaUpdate.CheckedItems.Contains("Abilita Download Driver Windows Update"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "cmd.exe",
                        Arguments = @"/c takeown /F ""%WinDIR%\System32\MusNotification.exe"" && icacls ""%WinDIR%\System32\MusNotification.exe"" /allow ""%EveryOne%:(X)"" && takeown /F ""%WinDIR%\System32\MusNotificationUx.exe"" && icacls ""%WinDIR%\System32\MusNotificationUx.exe"" /allow ""%EveryOne%:(X)""",
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
