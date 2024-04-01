using System.Diagnostics;
using System.Reflection;

namespace WinHubX.Dialog.Tools
{
    public partial class DialogWinCustomizer : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int borderWidth = 2;

            Color borderColor = Color.Coral;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle borderRectangle = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);

                e.Graphics.DrawRectangle(pen, borderRectangle);
            }
        }

        private NotifyIcon notifyIcon;
        public DialogWinCustomizer()
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            notifyIcon.BalloonTipTitle = "Download di WinCustomizer!";
            notifyIcon.BalloonTipText = "WinCustomizer verrà scaricato e aperto, attendi.";
            notifyIcon.ShowBalloonTip(1000);

            string fileName = "WinCustomizer.ps1";
            string resourceName = "WinHubX.Resources.WinCustomizer.ps1";
            string tempPath = Path.GetTempPath();
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

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"-ExecutionPolicy Bypass -File \"{tempFilePath}\""
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'avviare l'applicazione: {ex.Message}");
            }
        }
    }
}
