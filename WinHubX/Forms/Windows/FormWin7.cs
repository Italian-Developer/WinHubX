using System.Diagnostics;
using WinHubX.Dialog;

namespace WinHubX
{
    public partial class FormWin7 : Form
    {
        private Form1 form1;
        private FormWin formWin;
        private NotifyIcon notifyIcon;
        public FormWin7(FormWin formWin, Form1 form1)
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

        public void btnBack_Click(object sender, EventArgs e)
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

        private void infoWin7Lite_Click(object sender, EventArgs e)
        {
            infoWin7Lite(sender, e);
        }

        public static void infoWin7Lite(object sender, EventArgs e)
        {
            #region descrizione LITE

            string description = "Windows 7 Ultimate LITE\n\n" +
                                "Questa versione di Windows 7 Ultimate è stata migliorata rimuovendo una serie di driver, applicazioni, servizi e componenti, per migliorare le prestazioni del sistema e ridurre l'ingombro di spazio su disco.\n" +
                                "Questa personalizzazione porta ad un sistema operativo più snello e performante, ideale per chi cerca una versione più fluida e leggera rispetto alla versione stock.\n\n" +
                                "Di seguito l'elenco dei servizi e componenti rimossi:\n\n" +
                                "- Assistenza Remota\n" +
                                "- Auto Connection Manager di accesso remoto\n" +
                                "- Cache e file temporanei\n" +
                                "- Cartella Zip e Cab\n" +
                                "- Editor di caratteri personalizzati\n" +
                                "- Gadget\n" +
                                "- Giochi Multiplayer\n" +
                                "- Giochi Premium\n" +
                                "- Lente d'ingrandimento dello schermo\n" +
                                "- Narratore\n" +
                                "- Personalizzazione dei Temi di Windows\n" +
                                "- Puntatori del mouse (Accessibilità)\n" +
                                "- Redirector porta di Servizi Desktop remoto\n" +
                                "- Registro Remoto\n" +
                                "- RemoteFX\n" +
                                "- Servizi di integrazione Hyper-V\n" +
                                "- Servizio licenze Desktop remoto\n" +
                                "- Servizio Table Text\n" +
                                "- Suggerimenti (Informazioni di base)\n" +
                                "- Temi di base a contrasto elevato\n" +
                                "- Temi sul Market\n" +
                                "- Windows TIFF IFilter (OCR)\n" +
                                "- Accessibilità (Accessibilità)\n" +
                                "- Game Explorer\n" +
                                "- Giochi\n" +
                                "- Server Desktop remoto\n" +
                                "- Telefonia\n" +
                                "- Windows Sidebar\n";
            #endregion

            InfoDialog infoWin7Lite = new InfoDialog(description)
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            infoWin7Lite.Show();
        }

        private void btnWin7AIO32_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("fb35104043af3fcb9c87a6e8fd095ca5b2a99fa085fa2bb27eff23a09f2d173a");

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
                        FileName = "https://devuploads.com/8lj0lcz1kks8",
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

        private void btnWin7AIO64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("b78a9d0156112d93aeee7a4a0feed43bb6230b2dd173ab7d357433d0557a2a6f");

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
                        FileName = "https://devuploads.com/cx73ca63byf7",
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

        private void btnWin7Lite32_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("cc5b7b5fc182a2936b1dd8b5c4b07afa3eb180e4971ac768a79d688a7392bab1");

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
                        FileName = "https://devuploads.com/ixvzmbphwplu",
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

        private void btnWin7Lite64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("e87960fbf2913959602e510f89d23077da1068900ce4e20de683cb92f48f0185");

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
                        FileName = "https://devuploads.com/85268e6245iq",
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
