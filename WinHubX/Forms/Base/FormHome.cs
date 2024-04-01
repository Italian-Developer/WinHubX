using System.Diagnostics;
using WinHubX.Dialog;

namespace WinHubX
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void btnChangelog_Click(object sender, EventArgs e)
        {
            infoWHXChangelog(sender, e);
        }
        public static void infoWHXChangelog(object sender, EventArgs e)
        {
            #region descrizione WinHubX 

            string description = "Changelog WinHubX\n\n" +
                                    "24/02/2024 - v1.0.0.0:\n" +
                                    "- Lancio ufficiale del tool\n" +
                                    "- Creazione loghi\n" +
                                    "- Creazione sezione Home\n" +
                                    "\n" +
                                    "- Creazione sezione Windows\n" +
                                    "- Creazione sotto-sezione Windows 7 (Stock e Lite - 32bit e 64bit)\n" +
                                    "- Creazione sotto-sezione Windows 8.1 (Stock e Lite - 32bit e 64bit)\n" +
                                    "- Creazione sotto-sezione Windows 10 (Stock e Lite - ARM64, 32bit e 64bit)\n" +
                                    "- Creazione sotto-sezione Windows 11 (Stock e Lite - ARM64 e 64bit)\n" +
                                    "\n" +
                                    "- Creazione sezione Office (2019, 2021, 365, 2024)\n" +
                                    "- Creazione sotto-sezione Office 2019 Online (32bit e 64bit)\n" +
                                    "- Creazione sotto-sezione Office 2021 Online (32bit e 64bit)\n" +
                                    "- Creazione sotto-sezione Office 365 Online (32bit e 64bit)\n" +
                                    "\n" +
                                    "- Creazione sezione Tools\n" +
                                    "- Creazione sotto-sezione WinCustomizer (download)\n" +
                                    "- Creazione sotto-sezione WIMToolKit (download)\n" +
                                    "- Creazione sotto-sezione DaRT (download)\n" +
                                    "- Creazione sotto-sezione Rufus4Lite (portable)\n" +
                                    "- Creazione sotto-sezione Microsoft PC Manager (setup)\n" +
                                    "- Creazione sotto-sezione RST Driver (zip)\n" +
                                    "- Creazione sotto-sezione CheckHW (bat automatizzato)\n" +
                                    "\n" +
                                    "- Implementazione funzionalità \"Copia codice hash SHA256\"\n" +
                                    "- Implementazione funzionalità \"Visualizza Changelog\"\n" +
                                    "- Implementazione funzionalità \"Contatta i Developers\"\n" +
                                    "- Implementazione funzionalità \"Sostieni i Developers\"\n";

            #endregion

            InfoDialog infoWHXChangelog = new InfoDialog(description)
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            infoWHXChangelog.Show();
        }

        private void tgNico_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "https://telegram.me/MrNico98",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
            }
        }

        private void tgGreg_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "https://telegram.me/GregSparrow96",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
            }
        }

        private void btnKofi_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "https://ko-fi.com/winhubx",
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
