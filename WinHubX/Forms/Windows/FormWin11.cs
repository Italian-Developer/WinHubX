using System.Diagnostics;
using WinHubX.Dialog;

namespace WinHubX.Forms.Windows
{
    public partial class FormWin11 : Form
    {
        private Form1 form1;
        private FormWin formWin;
        private NotifyIcon notifyIcon;
        public FormWin11(FormWin formWin, Form1 form1)
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

        private void btnInfoWin11Lite_Click(object sender, EventArgs e)
        {
            infoWin11Lite(sender, e);
        }

        public static void infoWin11Lite(object sender, EventArgs e)
        {
            #region descrizione LITE

            string description = "Windows 11 LITE\n\n" +
                     "Questa versione di Windows 11 è stata ottimizzata rimuovendo una serie di driver, applicazioni, servizi e componenti, per migliorare le prestazioni del sistema e ridurre l'ingombro di spazio su disco.\n" +
                     "Questa personalizzazione porta ad un sistema operativo più snello e performante, ideale per chi cerca una versione più fluida e leggera rispetto alla versione standard.\n\n" +
                     "Di seguito l'elenco dei servizi e componenti rimossi:\n\n" +
                     "- Anteprima codice a barre Windows\n" +
                     "- App Xbox\n" +
                     "- Assistente vocale\n" +
                     "- Assistenza rapida\n" +
                     "- Chiama\n" +
                     "- Clipchamp\n" +
                     "- Configurazione di Windows Hello\n" +
                     "- Controllo ottico\n" +
                     "- Cortana\n" +
                     "- Dev Home\n" +
                     "- Esperienza shell di Windows\n" +
                     "- Estensioni video HEVC del produttore del dispositivo\n" +
                     "- Feedback Hub\n" +
                     "- Funzionalità per la famiglia di account Microsoft\n" +
                     "- Get Help\n" +
                     "- HEIF Image Extensions\n" +
                     "- Mail and Calendar\n" +
                     "- Microsoft Edge DevTools Client\n" +
                     "- Microsoft Engagement Framework\n" +
                     "- Microsoft Family\n" +
                     "- Microsoft News\n" +
                     "- Microsoft People\n" +
                     "- Microsoft Photos\n" +
                     "- Microsoft Solitaire Collection\n" +
                     "- Microsoft Sticky Notes\n" +
                     "- Microsoft Teams\n" +
                     "- Microsoft To Do\n" +
                     "- Movies & TV\n" +
                     "- MSN Weather\n" +
                     "- Office\n" +
                     "- Outlook for Windows\n" +
                     "- Pacchetto Esperienza Web Windows\n" +
                     "- Power Automate\n" +
                     "- Raw Image Extension\n" +
                     "- Rimozione sicura del dispositivo\n" +
                     "- Schermata di blocco predefinita di Windows\n" +
                     "- Suggerimenti (Informazioni di base)\n" +
                     "- Test ed esami\n" +
                     "- Web Media Extensions\n" +
                     "- Windows Maps\n" +
                     "- Windows Media Player\n" +
                     "- Windows Voice Recorder\n" +
                     "- Xbox Game Bar Plugin\n" +
                     "- Xbox Game Bar\n" +
                     "- Xbox Game Speech Window\n" +
                     "- Xbox Game UI\n" +
                     "- Xbox TCUI\n" +
                     "- Your Phone\n" +
                     "- Accessibilità (Accessibilità)\n" +
                     "- File Offline\n" +
                     "- Gestione quote\n" +
                     "- Input Method Editor (IME) - Consigliato\n" +
                     "- Internet Explorer\n" +
                     "- Pagamenti\n" +
                     "- Server Desktop remoto\n" +
                     "- Telefonia\n" +
                     "- Pulizia voci rimanenti\n" +
                     "- Pulizia cartelle vuote\n";

            #endregion 

            InfoDialog infoWin11Lite = new InfoDialog(description)
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            infoWin11Lite.Show();
        }

        private void btnWin11AIO64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("fb09fb0acb96c13d93e75f978a1f4ebf240ae8948c5205aef8a278969cf055be");

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
                        FileName = "https://devuploads.com/0m4q4ahlf3ya",
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

        private void btnWin11Lite64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("5852ee1779da524a03b83329e81b8b08da66d363a5cc1027c78e553809656a60");

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
                        FileName = "https://devuploads.com/67a2lix9pwsy",
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

        private void btnWin11ARM64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("5416c7aa0c04f1613e51926997d75b1f7be3b30640e3bfdf822f547a96a4123f");

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
                        FileName = "https://devuploads.com/6qg4t95jndjx",
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
