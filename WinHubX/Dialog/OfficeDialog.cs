using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WinHubX.Dialog
{
    public partial class OfficeDialog : Form
    {
        private readonly NotifyIcon notifyIcon;
        private string? dlLink32;
        private string? dlLink64;

        public OfficeDialog()
        {
            InitializeComponent();
            notifyIcon = NotifyIconFactory.CreateInformationIcon();
            InitializeCloseButton();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawBorder(e.Graphics);
        }

        private void InitializeCloseButton()
        {
            var closeButton = ButtonFactory.CreateCloseButton();
            closeButton.Click += (sender, e) => Close();
            Controls.Add(closeButton);
        }

        private void DrawBorder(Graphics graphics)
        {
            int borderWidth = 2;
            Color borderColor = Color.Coral;
            using (var pen = new Pen(borderColor, borderWidth))
            {
                var borderRectangle = new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
                graphics.DrawRectangle(pen, borderRectangle);
            }
        }

        public void OpenDialog(Label lblOffice, string link32, string link64)
        {
            var infoLabel = LabelFactory.CreateInfoLabel(lblOffice);
            dlLink32 = link32;
            dlLink64 = link64;
            Controls.Add(infoLabel);
            infoLabel.BringToFront();
        }

        private void BtnOfficeOnline32_MouseUp(object sender, MouseEventArgs e)
        {
            HandleMouseUp(e, dlLink32);
        }

        private void BtnOfficeOnline64_MouseUp(object sender, MouseEventArgs e)
        {
            HandleMouseUp(e, dlLink64);
        }

        private void HandleMouseUp(MouseEventArgs e, string? link)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowNotifyIconBalloonTip("Nessun codice hash da copiare!", "Il codice hash è disponibile solo per le versioni offline.");
            }
            else if (e.Button == MouseButtons.Left)
            {
                TryOpenUrl(link);
            }
        }

        private void ShowNotifyIconBalloonTip(string title, string text)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = text;
            notifyIcon.ShowBalloonTip(1000);
        }

        private void TryOpenUrl(string? url)
        {
            if (url == null) return;

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = url,
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

    internal static class NotifyIconFactory
    {
        public static NotifyIcon CreateInformationIcon()
        {
            return new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
        }
    }

    internal static class ButtonFactory
    {
        public static Button CreateCloseButton()
        {
            return new Button
            {
                Text = "Chiudi",
                Dock = DockStyle.Bottom,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = Color.Coral,
                ForeColor = Color.Black,
                Font = new Font("Product Sans", 15f),
                Cursor = Cursors.Hand
            };
        }
    }

    internal static class LabelFactory
    {
        public static Label CreateInfoLabel(Label lblOffice)
        {
            return new Label
            {
                Image = lblOffice.Image,
                Text = lblOffice.Text,
                Font = lblOffice.Font,
                Size = new Size(211, 110),
                Location = new Point(50, 70),
                ForeColor = lblOffice.ForeColor,
                BackColor = lblOffice.BackColor,
                TextAlign = ContentAlignment.MiddleRight,
                ImageAlign = ContentAlignment.MiddleLeft
            };
        }
    }
}
