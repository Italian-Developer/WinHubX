using System.Diagnostics;

namespace WinHubX.Forms.Windows
{
    public partial class FormWinAiO_64 : Form
    {
        private Form1 form1;
        private FormWin formWin;
        private NotifyIcon notifyIcon;
        public FormWinAiO_64(FormWin formWin, Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formWin = formWin;
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
        }

        private void FormWinAiO_64_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows";
            form1.PnlFormLoader.Controls.Clear();
            formWin = new FormWin(form1)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            form1.PnlFormLoader.Controls.Add(formWin);
            formWin.Show();
        }

        private void btnInfoWin7Lite_Click(object sender, EventArgs e)
        {
            FormWin7.infoWin7Lite(sender, e);
        }

        private void btnInfoWin8dot1Lite_Click(object sender, EventArgs e)
        {
            FormWin8Dot1.infoWin8dot1Lite(sender, e);
        }

        private void btnInfoWin10Lite_Click(object sender, EventArgs e)
        {
            FormWin10.infoWin10Lite(sender, e);
        }

        private void btnInfoWin11Lite_Click(object sender, EventArgs e)
        {
            FormWin11.infoWin11Lite(sender, e);
        }

        private void btnWinAIO64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("HASH CODE AIO64");

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
    }
}
