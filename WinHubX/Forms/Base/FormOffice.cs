using System.Diagnostics;
using System.Reflection;
using WinHubX.Dialog;

namespace WinHubX
{
    public partial class FormOffice : Form
    {
        private NotifyIcon notifyIcon;
        public FormOffice()
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
        }

        #region Office2019

        private void btn2019Online_MouseUp(object sender, MouseEventArgs e)
        {
            string link32 = "https://devuploads.com/j54kwwrnvp4u";
            string link64 = "https://devuploads.com/csiym2wcpt1a";

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
                        FileName = "https://devuploads.com/kpt0aq3upwna",
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
            string link32 = "https://devuploads.com/fpxdppf0h9de";
            string link64 = "https://devuploads.com/wcpw4r122iyv";

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
                        FileName = "https://devuploads.com/bqsp7cy0y1wg",
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
            string link32 = "https://devuploads.com/fy2fj55lw2fn";
            string link64 = "https://devuploads.com/1bn3rduod37y";

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
                        FileName = "https://devuploads.com/dndqpvijw15v",
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
            string link32 = "https://www.google.com";
            string link64 = "https://www.google.com";

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

                Clipboard.SetText("HASH CODE 2024");

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
                        FileName = "https://www.google.com",
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
                File.WriteAllBytes(ps1FilePath, exeBytes);
                StartPowerShell(ps1FilePath);
            }
            finally { }
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
            try
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                string resourcePath = $"{assemblyName}.Resources..OfficePersonalizzato.OfficeMaker.ps1";
                byte[] exeBytes = LoadEmbeddedResource1(resourcePath);
                string ps1FilePath = Path.Combine(Path.GetTempPath(), "OfficeMaker.ps1");
                File.WriteAllBytes(ps1FilePath, exeBytes);
                StartPowerShell1(ps1FilePath);
            }
            finally { }
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
