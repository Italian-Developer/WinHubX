using Microsoft.Win32;
using System.Diagnostics;
using WinHubX.Forms.Base;
using WinHubX.Forms.Settaggi;


namespace WinHubX.Forms.Personalizzazione
{
    public partial class FormPersonalizzazione : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormPersonalizzazione(FormSettaggi formSettaggi, Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1 ?? throw new ArgumentNullException(nameof(form1));
            this.formSettaggi = formSettaggi ?? throw new ArgumentNullException(nameof(formSettaggi));
            LoadCheckboxStates();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (form1 == null)
            {
                MessageBox.Show("form1 is not initialized", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            tasbarsin.Checked = GetCheckboxState("tasbarsin");
            taskbarcen.Checked = GetCheckboxState("taskbarcen");
            orologion.Checked = GetCheckboxState("orologion");
            orologiom.Checked = GetCheckboxState("orologiom");
            prestazioniel.Checked = GetCheckboxState("prestazioniel");
            prestazioniec.Checked = GetCheckboxState("prestazioniec");
            prestazionimi.Checked = GetCheckboxState("prestazionimi");
            uacdis.Checked = GetCheckboxState("uacdis");
            uacatti.Checked = GetCheckboxState("uacatti");
            destroleg.Checked = GetCheckboxState("destroleg");
            destrodef.Checked = GetCheckboxState("destrodef");
        }

        private void btnAvviaSelezionatiPersonal_Click(object sender, EventArgs e)
        {
            bool changesApplied = false;

            if (form1 == null)
            {
                MessageBox.Show("Form1 non inizializzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tasbarsin.Checked)
            {
                SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl", 0, RegistryValueKind.DWord);
                SetCheckboxState("tasbarsin", true);
                SetCheckboxState("taskbarcen", false);
                changesApplied = true;
            }

            if (taskbarcen.Checked)
            {
                SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl", 1, RegistryValueKind.DWord);
                SetCheckboxState("taskbarcen", true);
                SetCheckboxState("tasbarsin", false);
                changesApplied = true;
            }

            if (orologion.Checked)
            {
                SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowSecondsInSystemClock", 0, RegistryValueKind.DWord);
                SetCheckboxState("orologion", true);
                SetCheckboxState("orologiom", false);
                changesApplied = true;
            }

            if (orologiom.Checked)
            {
                SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowSecondsInSystemClock", 1, RegistryValueKind.DWord);
                SetCheckboxState("orologiom", true);
                SetCheckboxState("orologion", false);
                changesApplied = true;
            }

            if (prestazioniel.Checked)
            {
                ExecuteCommand("POWERCFG", "/SETACTIVE SCHEME_MIN");
                SetCheckboxState("prestazioniel", true);
                SetCheckboxState("prestazioniec", false);
                changesApplied = true;
            }

            if (prestazioniec.Checked)
            {
                ExecuteCommand("POWERCFG", "-duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61");
                SetCheckboxState("prestazioniec", true);
                SetCheckboxState("prestazioniel", false);
                changesApplied = true;
            }

            if (prestazionimi.Checked)
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
                SetCheckboxState("prestazionimi", true);
                changesApplied = true;
            }

            if (uacdis.Checked)
            {
                SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", 0, RegistryValueKind.DWord);
                SetCheckboxState("uacdis", true);
                SetCheckboxState("uacatti", false);
                changesApplied = true;
            }

            if (uacatti.Checked)
            {
                SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", 1, RegistryValueKind.DWord);
                SetCheckboxState("uacatti", true);
                SetCheckboxState("uacdis", false);
                changesApplied = true;
            }

            if (destroleg.Checked)
            {
                if (IsWindows10())
                {
                    MessageBox.Show("Funzione abilitata solo per Windows 11");
                }
                else
                {
                    ExecuteCommand("cmd.exe", "/c reg add HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32 /ve /t REG_SZ /d \"\" /f");
                    RestartExplorer();
                    SetCheckboxState("destroleg", true);
                    SetCheckboxState("destrodef", false);
                    changesApplied = true;
                }
            }

            if (destrodef.Checked)
            {
                if (IsWindows10())
                {
                    MessageBox.Show("Funzione abilitata solo per Windows 11");
                }
                else
                {
                    ExecuteCommand("cmd.exe", "/c reg delete HKCU\\SOFTWARE\\CLASSES\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2} /f");
                    RestartExplorer();
                    SetCheckboxState("destrodef", true);
                    SetCheckboxState("destroleg", false);
                    changesApplied = true;
                }
            }

            if (changesApplied)
            {
                MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetRegistryValue(string path, string name, object value, RegistryValueKind kind)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true) ?? Registry.CurrentUser.CreateSubKey(path))
            {
                key.SetValue(name, value, kind);
            }
        }

        private void ExecuteCommand(string fileName, string arguments)
        {
            try
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
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                throw;
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

        private void btn_avanti_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Personalizzazione";
            form1.PnlFormLoader.Controls.Clear();
            FormPersonalizzazione2 formPersonalizzazione2 = new FormPersonalizzazione2(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formPersonalizzazione2.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formPersonalizzazione2);
            formPersonalizzazione2.Show();
        }
    }
}
