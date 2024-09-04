using System.Diagnostics;

namespace WinHubX.Forms.Base
{
    public partial class FormCreaISO : Form
    {
        private Form1 form1;
        private string selectedFile; // Class-level variable to store selected ISO file path

        public FormCreaISO(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            groupBox7.Hide();
            groupBox6.Hide();
            pictureBox7.Hide();
            pictureBox4.Hide();
            this.FormClosing += FormCreaISO_FormClosing;
            this.ActiveControl = btn_browser;
        }

        string IsoMountLetter;
        string installwimpath;
        int windowsEdition;

        public void ExecuteCommand(string command, bool ShowMessage)
        {
            if (!ShowMessage)
            {
                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = command,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                }
            }
            else if (ShowMessage)
            {
            }
        }

        private void btn_CreaISO_Click(object sender, EventArgs e)
        {
            ExecuteCommand("Dismount-DiskImage -ImagePath " + "\"" + selectedFile + "\"", false);
            new Thread(() =>
            {
                string ComboSelected = "";
                string comboxstr = comboBox1.Text;

                int index = comboxstr.IndexOf(' ');
                ComboSelected = comboxstr.Substring(0, index);

                string windowsVersion = "";
                string edgeRemovalPreference = "";
                string defenderPreference = "";
                string Processi = "";
                string Unattend = "Bypass";
                string Architettura = "x64";
                string DebloatApp = "";

                if (Win10Rad.Checked)
                {
                    windowsVersion = "10";
                }
                else if (Win11Rad.Checked)
                {
                    windowsVersion = "11";
                }

                if (RemEdgeRad.Checked)
                {
                    edgeRemovalPreference = "RemoveEdge";
                }
                else if (NotRemEdgeRad.Checked)
                {
                    edgeRemovalPreference = "SiEdge";
                }

                if (DisWindDefRad.Checked)
                {
                    defenderPreference = "DisableWindowsDefender";
                }
                else if (NotDisWinDefRad.Checked)
                {
                    defenderPreference = "SiDefender";
                }

                if (RemProcRad.Checked)
                {
                    Processi = "RimuoviProcessi";
                }
                else if (NotRemProcRad.Checked)
                {
                    Processi = "NonRimuovereProcessi";
                }

                if (SixforArchRad.Checked)
                {
                    Architettura = "x64";
                }
                else if (ThirTwoRad.Checked)
                {
                    Architettura = "x32";
                }

                if (DebAppRad.Checked)
                {
                    DebloatApp = "Debloat";
                }
                else if (StockAppRad.Checked)
                {
                    DebloatApp = "NonDebloat";
                }

                if (Win11BypassRad.Checked)
                {
                    Unattend = "Bypass";
                }
                else if (Win11StockRad.Checked)
                {
                    Unattend = "Stock";
                }

                string argsList = $"\"{selectedFile}\" {windowsVersion} {edgeRemovalPreference} {defenderPreference} {ComboSelected} {Processi} {Unattend} {Architettura} {DebloatApp}";

                string tempPath = Path.GetTempPath();
                string batchFileName = Win10Rad.Checked ? "isotool10.bat" : "isotool11.bat";
                string batchFilePath = Path.Combine(tempPath, "RisorseCreaISO", batchFileName);

                if (!File.Exists(batchFilePath))
                {
                    MessageBox.Show($"Batch file not found: {batchFilePath}");
                    return;
                }
                var startInfo = new ProcessStartInfo()
                {
                    FileName = batchFilePath,
                    Arguments = argsList,
                    UseShellExecute = true,
                    CreateNoWindow = false, // Ensures the command prompt window is visible
                    WorkingDirectory = Path.GetDirectoryName(batchFilePath)
                };

                try
                {
                    using (var process = Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception)
                {
                }
            }).Start();
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "ISO Files (*.iso)|*.iso|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = openFileDialog.FileName;
                textBox1.Text = selectedFile;
                ExecuteCommand("Mount-DiskImage -ImagePath " + "\"" + selectedFile + "\"", false);

                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = "(Get-DiskImage -ImagePath " + selectedFile + " | Get-Volume).DriveLetter",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                    IsoMountLetter = output.Trim();
                }

                if (File.Exists(IsoMountLetter + ":\\sources\\install.wim"))
                {
                    installwimpath = IsoMountLetter + ":\\sources\\install.wim";
                }
                else if (File.Exists(IsoMountLetter + ":\\sources\\install.esd"))
                {
                    installwimpath = IsoMountLetter + ":\\sources\\install.esd";
                }
                else
                {
                    MessageBox.Show("Non trovo Install.wim / install.esd");
                    return;
                }
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;

                    var startInfoThi = new ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "dism /english /Get-WimInfo /WimFile:" + installwimpath,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = Process.Start(startInfoThi))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();

                        string input = output;

                        int indiceIndex = 0;
                        while ((indiceIndex = input.IndexOf("Index", indiceIndex)) != -1)
                        {
                            int indiceFineValore = input.IndexOfAny(new char[] { '\r', '\n' }, indiceIndex + 6);
                            if (indiceFineValore != -1)
                            {
                                string valoreind = input.Substring(indiceIndex + 6, indiceFineValore - indiceIndex - 6);
                            }

                            indiceIndex = indiceFineValore + 1;
                        }

                        int indiceNome = 1;
                        int primoind = 1;
                        while ((indiceNome = input.IndexOf("Name", indiceNome)) != -1)
                        {
                            int indiceFineValore = input.IndexOfAny(new char[] { '\r', '\n' }, indiceNome + 6);
                            if (indiceFineValore != -1)
                            {
                                string valoreNome = input.Substring(indiceNome + 6, indiceFineValore - indiceNome - 6);

                                comboBox1.Invoke(new Action(() => comboBox1.Items.Add(primoind.ToString() + " - " + valoreNome.Replace(":", ""))));
                                primoind += 1;
                            }

                            indiceNome = indiceFineValore + 1;
                        }
                    }
                }).Start();
            }
        }

        private void Win10Rad_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox6.Show();
            groupBox7.Hide();
            pictureBox7.Hide();
            pictureBox4.Show();
        }

        private void Win11Rad_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox6.Hide();
            groupBox7.Show();
            pictureBox7.Show();
            pictureBox4.Hide();
        }

        private void FormCreaISO_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Controlla se IsoMountLetter è stato assegnato
            if (!string.IsNullOrEmpty(IsoMountLetter))
            {
                ExecuteCommand("Dismount-DiskImage -ImagePath " + "\"" + selectedFile + "\"", false);
            }
        }
    }
}