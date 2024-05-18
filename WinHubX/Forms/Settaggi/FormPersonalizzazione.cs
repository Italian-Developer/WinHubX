using Microsoft.Win32;
using System.Diagnostics;
using WinHubX.Forms.Base;


namespace WinHubX.Forms.Personalizzazione
{
    public partial class FormPersonalizzazione : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormPersonalizzazione(FormSettaggi formSettaggi, Form1 form1)
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

        private void btnAvviaSelezionatiPersonal_Click(object sender, EventArgs e)
        {
            if (tasbarsin.Checked)
            {
                SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl", 0, RegistryValueKind.DWord);
            }
            else if (taskbarcen.Checked)
            {
                SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl", 1, RegistryValueKind.DWord);
            }
            else if (orologion.Checked)
            {
                ExecutePowerShellCommand("Set-ItemProperty -Path HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced -Name ShowSecondsInSystemClock -Value 0 -Force");
            }
            else if (orologiom.Checked)
            {
                ExecutePowerShellCommand("Set-ItemProperty -Path HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced -Name ShowSecondsInSystemClock -Value 1 -Force");
            }
            else if (prestazioniel.Checked)
            {
                ExecuteCommand("POWERCFG", "/SETACTIVE SCHEME_MIN");
            }
            else if (prestazioniec.Checked)
            {
                ExecuteCommand("POWERCFG", "-duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61");
            }
            else if (prestazionimi.Checked)
            {
                string[] commands = {
            "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters /v IRPStackSize /t REG_DWORD /d 50 /f",
            "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters /v SizReqBuf /t REG_DWORD /d 17424 /f",
            "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters /v DefaultTTL /t REG_DWORD /d 62 /f",
            "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters /v TCP1323Opts /t REG_DWORD /d 1 /f",
            "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters /v MaxFreeTcbs /t REG_DWORD /d 65536 /f",
            "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters /v MaxUserPort /t REG_DWORD /d 65534 /f",
            "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters /v GlobalMaxTcpWindowSize /t REG_DWORD /d 65535 /f"
        };

                foreach (string command in commands)
                {
                    ExecuteCommand("cmd.exe", "/c " + command);
                }
            }
            else if (uacdis.Checked)
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", 0, RegistryValueKind.DWord);
            }
            else if (uacatti.Checked)
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", 1, RegistryValueKind.DWord);
            }
            else if (destroleg.Checked)
            {
                if (IsWindows10())
                {
                    MessageBox.Show("Funzione abilitata solo per Windows 11");
                }
                else
                {
                    ExecuteCommand("cmd.exe", "/c reg add HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32 /ve /d /f /t REG_SZ /f");
                    RestartExplorer();
                }
            }
            else if (destrodef.Checked)
            {
                if (IsWindows10())
                {
                    MessageBox.Show("Funzione abilitata solo per Windows 11");
                }
                else
                {
                    ExecuteCommand("cmd.exe", "/c reg delete HKCU\\SOFTWARE\\CLASSES\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2} /f");
                    RestartExplorer();
                }
            }

            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetRegistryValue(string path, string name, object value, RegistryValueKind kind)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true) ?? Registry.CurrentUser.CreateSubKey(path))
            {
                key.SetValue(name, value, kind);
            }
        }

        private void ExecutePowerShellCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = command,
                Verb = "runas",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
            }
        }

        private void ExecuteCommand(string fileName, string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments)
            {
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
            }
        }

        private bool IsWindows10()
        {
            ProcessStartInfo info = new ProcessStartInfo("systeminfo")
            {
                Verb = "runas",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (Process process = Process.Start(info))
            {
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return output.Contains("Windows 10");
            }
        }

        private void RestartExplorer()
        {
            ExecuteCommand("taskkill", "/F /IM explorer.exe");
            Process.Start("explorer.exe");
        }
    }
}
