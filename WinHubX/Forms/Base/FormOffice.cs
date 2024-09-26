using System.Diagnostics;
using System.Reflection;
using WinHubX.Dialog;
using WinHubX.Forms.Personalizzazione_office;

namespace WinHubX
{
    public partial class FormOffice : Form
    {
        private Form1 form1;
        private NotifyIcon notifyIcon;
        public FormOffice(Form1 form1)
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
            this.form1 = form1;
        }

        #region Office2019

        private void btn2019Online_MouseUp(object sender, MouseEventArgs e)
        {
            string link32 = "https://devuploads.com/dd4c73vcnsk1";
            string link64 = "https://devuploads.com/8xy39zy1jaev";

            OfficeDialog officeDialog = new OfficeDialog()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            officeDialog.openDialog(lblOffice2019, link32, link64);
            officeDialog.ShowDialog();
        }

        private void btn2019Offline_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("6b50ee7f4eccd87126a0ee1aa42c814773f85cb28d0603e1afd1b56ed00bf6fc");

                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "https://devuploads.com/nqsmxo5pf47p",
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
                }
            }
        }
        #endregion

        #region Office2021

        private void btn2021Online_MouseUp(object sender, MouseEventArgs e)
        {
            string link32 = "https://devuploads.com/7n1zl4y08idi";
            string link64 = "https://devuploads.com/zz26itbug7ib";

            OfficeDialog officeDialog = new OfficeDialog()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            officeDialog.openDialog(lblOffice2021, link32, link64);
            officeDialog.ShowDialog();
        }

        private void btn2021Offline_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("1f0a36b7996840ce8022e4a98fe058cac05a5bb172dcc5d1bac6c7f386823a88");

                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "https://devuploads.com/xokgnvikk8w0",
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
                }
            }
        }
        #endregion

        #region Office365

        private void btn365Online_MouseUp(object sender, MouseEventArgs e)
        {
            string link32 = "https://devuploads.com/lbk9qknvueqf";
            string link64 = "https://devuploads.com/tr1vgi78kk57";

            OfficeDialog officeDialog = new OfficeDialog()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            officeDialog.openDialog(lblOffice365, link32, link64);
            officeDialog.ShowDialog();
        }

        private void btn365Offline_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("8c9e3d26a9af4a0fa1f1e74ec5ff197eaf2c71ab538b4ff6d9a2494167032ddc");

                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "https://devuploads.com/qrawhfz7hk6s",
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
                }
            }
        }

        #endregion

        #region Office2024


        private void btn2024Online_MouseUp(object sender, MouseEventArgs e)
        {
            string link32 = "https://devuploads.com/udxq7u2nqfgt";
            string link64 = "https://devuploads.com/q009rzo2u4z8";

            OfficeDialog officeDialog = new OfficeDialog()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            officeDialog.openDialog(lblOffice2024, link32, link64);
            officeDialog.ShowDialog();
        }

        private void btn2024Offline_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("2ef0ee897892060b27da35b1e64ccc3efc22dc7b6ed03905a33ab4a672eb851e");

                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "https://devuploads.com/cp3k76gumznb",
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
                }
            }
        }

        #endregion

        #region AttivaOffice
        private void btnAttivaOffice_Click(object sender, EventArgs e)
        {
            string fileName = "WinHubXOfficeAttivatore.cmd";
            string resourceName = "WinHubX.Resources.WinHubXOfficeAttivatore.cmd"; string tempPath = Path.GetTempPath();
            string tempFilePath = Path.Combine(tempPath, fileName);
            try
            {
                using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (resourceStream != null)
                    {
                        using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                        {
                            resourceStream.CopyTo(fileStream);
                        }
                    }
                }
                Process.Start(tempFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'avviare l'applicazione: {ex.Message}");
            }
        }
        #endregion

        private void btn2021Online_Click(object sender, EventArgs e)
        {

        }

        private void btnScrubber_Click(object sender, EventArgs e)
        {
            try
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                string resourcePath = $"{assemblyName}.Resources.WinHubXOfficeScrubber.ps1";
                byte[] exeBytes = LoadEmbeddedResource(resourcePath);
                string ps1FilePath = Path.Combine(Path.GetTempPath(), "WinHubXOfficeScrubber.ps1");

                // Scrivi il file PowerShell nella cartella temporanea
                File.WriteAllBytes(ps1FilePath, exeBytes);

                // Controlla se il file è stato scritto correttamente
                if (File.Exists(ps1FilePath))
                {
                    StartPowerShell(ps1FilePath);
                }
                else
                {
                    MessageBox.Show($"Il file {ps1FilePath} non è stato estratto correttamente.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Gestione delle eccezioni
                MessageBox.Show($"Si è verificato un errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] LoadEmbeddedResource(string resourcePath)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException($"Could not find embedded resource: {resourcePath}");
                }
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        private void StartPowerShell(string scriptFilePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptFilePath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
            }
        }

        private void btnPersonalizzaOffice_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Personalizzazione Office";
            form1.PnlFormLoader.Controls.Clear();
            PersonalizzazioneOffice formPersonalizzazioneOffice = new PersonalizzazioneOffice(form1, this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formPersonalizzazioneOffice.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formPersonalizzazioneOffice);
            formPersonalizzazioneOffice.Show();
        }


        public static void ExtractEmbeddedResourceFolder(string resourceFolder)
        {
            string tempFolderPath = Path.GetTempPath();
            string targetFolderPath = Path.Combine(tempFolderPath, "OfficePersonalizzato");
            Directory.CreateDirectory(targetFolderPath);
            Assembly assembly = Assembly.GetExecutingAssembly();
            string assemblyNamee = assembly.GetName().Name;
            string[] resourceNames = assembly.GetManifestResourceNames();

            foreach (string resourceName in resourceNames)
            {
                if (resourceName.StartsWith(resourceFolder))
                {
                    string path = Path.Combine(targetFolderPath, resourceName.Substring(assemblyNamee.Length + 1));
                    string directory = Path.GetDirectoryName(path);
                    Directory.CreateDirectory(directory);

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    using (FileStream fileStream = new FileStream(path, FileMode.Create))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }
        }

        private byte[] LoadEmbeddedResource1(string resourcePath)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException($"Could not find embedded resource: {resourcePath}");
                }
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        private void StartPowerShell1(string scriptFilePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptFilePath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
            }
        }
    }
}
