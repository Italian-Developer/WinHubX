﻿using System.Diagnostics;
using WinHubX.Dialog;

namespace WinHubX.Forms.Windows
{
    public partial class FormWin10 : Form
    {
        private Form1 form1;
        private FormWin formWin;
        private NotifyIcon notifyIcon;
        public FormWin10(FormWin formWin, Form1 form1)
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
        private void btnInfoWin10Lite_Click(object sender, EventArgs e)
        {
            infoWin10Lite(sender, e);
        }

        public static void infoWin10Lite(object sender, EventArgs e)
        {
            #region descrizione LITE

            string description = "Windows 10 LITE\n\n" +
                     "Questa versione di Windows 10 è stata ottimizzata rimuovendo una serie di driver, applicazioni, servizi e componenti, per migliorare le prestazioni del sistema e ridurre l'ingombro di spazio su disco.\n" +
                     "Questa personalizzazione porta ad un sistema operativo più snello e performante, ideale per chi cerca una versione più fluida e leggera rispetto alla versione standard.\n\n" +
                     "Di seguito l'elenco dei servizi e componenti rimossi:\n\n" +
                        "- Anteprima codice a barre Windows\n" +
                        "- App di blocco con accesso assegnato\n" +
                        "- Assistente vocale\n" +
                        "- Chiama\n" +
                        "- Configurazione di Windows Hello\n" +
                        "- Controllo ottico\n" +
                        "- Cortana\n" +
                        "- Feedback Hub\n" +
                        "- Funzionalità per la famiglia di account Microsoft\n" +
                        "- Gestore distribuzione contenuti\n" +
                        "- Get Help\n" +
                        "- Groove Music\n" +
                        "- Mail and Calendar\n" +
                        "- Microsoft Advertising SDK for XAML\n" +
                        "- Microsoft Edge DevTools Client\n" +
                        "- Microsoft Pay\n" +
                        "- Microsoft People\n" +
                        "- Microsoft Photos\n" +
                        "- Microsoft Solitaire Collection\n" +
                        "- Microsoft Sticky Notes\n" +
                        "- Mixed Reality Portal\n" +
                        "- Movies & TV\n" +
                        "- MSN Weather\n" +
                        "- Office\n" +
                        "- OneNote\n" +
                        "- Paint 3D\n" +
                        "- Rimozione sicura del dispositivo\n" +
                        "- Schermata di blocco predefinita di Windows\n" +
                        "- Skype\n" +
                        "- Suggerimenti (Informazioni di base)\n" +
                        "- Test ed esami\n" +
                        "- Visualizzatore 3D\n" +
                        "- Web Media Extensions\n" +
                        "- Windows Alarms & Clock\n" +
                        "- Windows Maps\n" +
                        "- Windows Voice Recorder\n" +
                        "- Xbox Game Bar Plugin\n" +
                        "- Xbox Game Bar\n" +
                        "- Xbox Game Speech Window\n" +
                        "- Xbox Game UI\n" +
                        "- Xbox TCUI\n" +
                        "- Xbox\n" +
                        "- Your Phone\n" +
                        "- Accessibilità (Accessibilità)\n" +
                        "- Device Experience\n" +
                        "- File Offline\n" +
                        "- Input Method Editor (IME) - Consigliato\n" +
                        "- Internet Explorer\n" +
                        "- Pagamenti\n" +
                        "- Server Desktop remoto\n" +
                        "- Telefonia\n";

            #endregion 

            InfoDialog infoWin10Lite = new InfoDialog(description)
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            infoWin10Lite.Show();
        }

        private void btnWin10ARM64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("7f9c63e48578451cbc92c009f9819816a28f5605ba9b1578e9f91a49834d10ac");

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
                        FileName = "https://devuploads.com/uygo2n5ytiul",
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

        private void btnWin10AIO32_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("fde189da1265dc3eb1d3e26b560876a37c44a447afdd493ed73d53d33d766cf0");

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
                        FileName = "https://devuploads.com/cpv4k191sy00",
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

        private void btnWin10AIO64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("ae84df01bdd0a038d0ed60b2af3dba08bfefa0fd8e4297bddb3f90e16b6fa4d6");

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
                        FileName = "https://devuploads.com/0up8pc2rl5qp",
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

        private void btnWin10Lite32_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("60d47df775b0f4445f69e2313844fa2516ae7efb007fd2db3bf781b93f2fac82");

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
                        FileName = "https://devuploads.com/l8czyal3q98c",
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

        private void btnWin10Lite64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("8a5e5e1feaf6e85a7afec162357d22673d11f7190f5d37d20936c44f8301ac42");

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
                        FileName = "https://devuploads.com/2nyv53dz1izk",
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

        private void btnWin10AIO32_Click(object sender, EventArgs e)
        {

        }

        private void btnWin10AIO64_Click(object sender, EventArgs e)
        {

        }
    }
}
