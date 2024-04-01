using System.Diagnostics;
using WinHubX.Dialog;

namespace WinHubX.Forms.Windows
{
    public partial class FormWin8Dot1 : Form
    {
        private Form1 form1;
        private FormWin formWin;
        private NotifyIcon notifyIcon;
        public FormWin8Dot1(FormWin formWin, Form1 form1)
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

        private void btnInfoWin8dot1Lite_Click(object sender, EventArgs e)
        {
            infoWin8dot1Lite(sender, e);
        }

        public static void infoWin8dot1Lite(object sender, EventArgs e)
        {
            #region descrizione LITE

            string description = "Windows 8.1 Enterprise LITE\n\n" +
                     "Questa versione di Windows 8.1 Enterprise è stata ottimizzata rimuovendo una serie di driver, applicazioni, servizi e componenti, per migliorare le prestazioni del sistema e ridurre l'ingombro di spazio su disco.\n" +
                     "Questa personalizzazione porta ad un sistema operativo più snello e performante, ideale per chi cerca una versione più fluida e leggera rispetto alla versione standard.\n\n" +
                     "Di seguito l'elenco dei servizi e componenti rimossi:\n\n" +
                     "- Adobe Flash per Internet Explorer - 32 bit\n" +
                     "- Aggiunta all'area di lavoro\n" +
                     "- Briefcase\n" +
                     "- Controllo genitori\n" +
                     "- File system resiliente (ReFS)\n" +
                     "- Floppy disk\n" +
                     "- Localizzatore Remote Procedure Call (RPC)\n" +
                     "- Notifiche cloud\n" +
                     "- Pannello Share Media Control\n" +
                     "- Registratore di suoni\n" +
                     "- Registrazione azioni utente\n" +
                     "- Registro Remoto\n" +
                     "- Remote Differential Compression (RDC)\n" +
                     "- RemoteFX\n" +
                     "- Screensaver\n" +
                     "- Servizi di integrazione Hyper-V\n" +
                     "- Servizio di Localizzazione\n" +
                     "- Servizio licenze Desktop remoto\n" +
                     "- Servizio Table Text\n" +
                     "- Sfondi schermata di sblocco\n" +
                     "- Sticky Notes\n" +
                     "- Suggerimenti (Informazioni di base)\n" +
                     "- Telefonia\n" +
                     "- Windows TIFF IFilter (OCR)\n" +
                     "- Check Point VPN\n" +
                     "- F5 VPN\n" +
                     "- Fotocamera\n" +
                     "- Games\n" +
                     "- Juniper Networks Junos Pulse\n" +
                     "- Mail, Calendar, and People\n" +
                     "- Maps\n" +
                     "- Microsoft PlayReady\n" +
                     "- MSN Food & Drink\n" +
                     "- MSN Health & Fitness\n" +
                     "- MSN Money\n" +
                     "- MSN News\n" +
                     "- MSN Sports\n" +
                     "- MSN Travel\n" +
                     "- MSN Weather\n" +
                     "- Music\n" +
                     "- OneNote\n" +
                     "- Reader\n" +
                     "- Skype\n" +
                     "- SonicWALL Mobile Connect\n" +
                     "- Video\n" +
                     "- Windows Alarms\n" +
                     "- Windows Help+Tips\n" +
                     "- Windows Reading List\n" +
                     "- Windows Sound Recorder\n";

            #endregion

            InfoDialog infoWin8dot1Lite = new InfoDialog(description)
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            infoWin8dot1Lite.Show();
        }

        private void btnWin8dot1AIO32_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("dfa6d6149fbe3a5247695305a466623a4a8c37cc622006c90cd414c2cfc71513");

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
                        FileName = "https://devuploads.com/kwo0ujca5v3n",
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

        private void btnWin8dot1AIO64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("6c8739b6f9941e32604c79dea362fe8628ab8dae76f9fed36038b9cfb49abc23");

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
                        FileName = "https://devuploads.com/a2qjbwjazwlz",
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

        private void btnWin8dot1Lite32_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("19565cd2acf239a5abe7a947867b3d6a0e18390519cbefd313e8b2ebb8bf83bf");

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
                        FileName = "https://devuploads.com/bsa3bhugnhjt",
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

        private void btnWin8dot1Lite64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("b8493b86ebd1a11f952e1545c4bd9393212eade22ad3d0e09dee582d5bd29dea");

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
                        FileName = "https://devuploads.com/6qk33fwtxn7v",
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
