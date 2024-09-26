using System.Diagnostics;
using System.Net;
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
                                    "17/09/2024 - v2.4.0.9:\n" +
                                    "- Fix link lite\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "17/09/2024 - v2.4.0.8:\n" +
                                    "- Correzione crazione ISO windows10 e 11\n" +
                                    "- Modifica visualizzazione creazione iso\n" +
                                    "- Aggiornamento iso Lite 10x64 e 11\n" +
                                    "- Modificata logica update app\n" +
                                    "- Aggiunte informazioni driver sui bottoni\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "07/09/2024 - v2.4.0.7:\n" +
                                    "- Aggiornato PC Manager\n" +
                                    "- Fix ScrubberOffice\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "07/09/2024 - v2.4.0.6:\n" +
                                    "- Fix isotool11\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "07/09/2024 - v2.4.0.5:\n" +
                                    "- Fix Personalizzazione office\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "05/09/2024 - v2.4.0.4:\n" +
                                    "- Fix Vari\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "04/09/2024 - v2.4.0.3:\n" +
                                    "- Eliminato personalizzazioni\n" +
                                    "- Eliminato monitoraggio\n" +
                                    "- Aggiornato WSA\n" +
                                    "- Aggiornato codici creazione iso\n" +
                                    "- Aggiunto WinHubX-SystemTray\n" +
                                    "- Aggiunto update\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "10/07/2024 - v2.4.0.2:\n" +
                                    "- Aggiunta icona publisher per office personalizzato\n" +
                                    "- Nuova schermata CreaISO\n" +
                                    "- Fix personalizzazione privacy\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "24/06/2024 - v2.4.0.1:\n" +
                                    "- Minor Fix\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "22/06/2024 - v2.4.0.0:\n" +
                                    "- Modifica codice settaggi personalizzazione\n" +
                                    "- Aggiunto un 2 menù personalizzazione\n" +
                                    "- Aggiunto modifiche win11-10 preset\n" +
                                    "- Riscrittura codice debloat app\n" +
                                    "- Riscrittura codice ripristina app\n" +
                                    "- Fix Crea ISO win 10 (non settava corettamente l'unattend se x32 o x64)\n" +
                                    "- Adattamento codice crea iso di win11 24h2\n" +
                                    "- Adeguamento codice crea iso con le utlime versione di win10\n" +
                                    "- Adeguamento codice tweaks win10-11\n" +
                                    "- Aggiunto nuova personalizzazione office\n" +
                                    "- Aggiornato WSA per win11x64, win11arm64 e win10x64\n" +
                                    "- Miglioramento codice e stabiltà\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "11/06/2024 - v2.3.0.2:\n" +
                                    "- Patch settaggi personalizzazione\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "04/06/2024 - v2.3.0.1:\n" +
                                    "- Fix settaggi personalizzazione\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "27/05/2024 - v2.3.0.0:\n" +
                                    "- Settaggi vengono salvati\n" +
                                    "- Preparazione Windows 11 per 24H2\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "21/05/2024 - v2.2.1.3:\n" +
                                    "- Fix unattend Crea ISO\n" +
                                    "- Fix unattend su iso 10Lite\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "17/05/2024 - v2.2.0.2:\n" +
                                    "- Fix Codice Personalizzazione\n" +
                                    "- Fix Codice Crea ISO (Super ottimizzato e ora supporta le iso di win11 24h2 e fixato crash app e crea iso win10)\n" +
                                    "- Fix Codice Personalizzazione Office (durante l'apertura se veniva cliccato qualcosa nell'app crashava)\n" +
                                    "- Aggiornate ISO Lite Win11 e Win10\n" +
                                    "- Aggiornato il WSA alla LTS\n" +
                                    "- Ottimizzioni varie al codice\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "17/05/2024 - v2.2.0.1:\n" +
                                    "- Rilascio versione autoaggiornante\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "23/04/2024 - v2.2.0.0:\n" +
                                    "- Fix Codice (Personalizzazione Office)\n" +
                                    "- Nuove iso Win11/10 (stock e lite)\n" +
                                    "- Aggiunto Monitoraggio\n" +
                                    "- Fix individuazione antivirus\n" +
                                    "- Fix codice Debloat (Defender)\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "15/04/2024 - v2.1.0.0:\n" +
                                    "- Fix Codice (Crea ISO, Personalizzazione)\n" +
                                    "- Aggiunto PacMan per WSA\n" +
                                    "- Aggiunto Rimozione Edge nativa\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
                                    "08/04/2024 - v2.0.0.0:\n" +
                                    "- Creazione nuovi loghi\n" +
                                    "- Rimozione chat telegram\n" +
                                    "- Aggiunto BOT Telegram WinHubX\n" +
                                    "\n" +
                                    "- Aggiornamento sezione Windows\n" +
                                    "- Nuove iso Windows 11 MOMENT5 (Stock e Lite - ARM64 e 64bit)\n" +
                                    "- Aggiunto Windows Live\n" +
                                    "- Aggiunto pulsante attivazione Windows\n" +
                                    "- Aggiunto pulsante cambio Edizione Windows\n" +
                                    "\n" +
                                    "- Aggiunto pulsante attivazione Office\n" +
                                    "- Aggiunto pulsante disinstallazione Office\n" +
                                    "- Aggiunto pulsante personalizzazione Office\n" +
                                    "\n" +
                                    "- Creazione sezione Tools\n" +
                                    "- Rimozione Tool WinCustomizer (download)\n" +
                                    "- Aggiunta ISO Kaspersky Live (download)\n" +
                                    "- Creazione sotto-sezione WIMToolKit (download)\n" +
                                    "- Aggiornamento Rufus4Lite (portable)\n" +
                                    "\n" +
                                    "- Creazione sezione Settaggi\n" +
                                    "- Creazione sotto-sezione Defender (Gestisci Windows Defender)\n" +
                                    "- Creazione sotto-sezione Privacy (Gestisci la Privacy di Windows)\n" +
                                    "- Creazione sotto-sezione Update (Gestisci impostazioni Windows Update)\n" +
                                    "- Creazione sotto-sezione Utility (Settaggi Vari)\n" +
                                    "- Creazione sotto-sezione RipristinoSO (Vari comandi per verificare Windows)\n" +
                                    "- Creazione sotto-sezione Personalizzazione (Modifica alcuni settaggi di Windows)\n" +
                                    "\n" +
                                    "- Creazione sezione Debloat\n" +
                                    "- Creazione sotto-sezione Ripristina APP (Permette di reinstallare alcune APP)\n" +
                                    "- Creazione sezione CreaISO\n" +
                                    "\n" +
                                    "\n" +
                                    "\n" +
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

        private void tgWinHubX_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "https://telegram.me/WinHubXbot",
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

        private void btn_winhubxmonitor_Click(object sender, EventArgs e)
        {
            // Definisci l'URL del file da scaricare
            string fileUrl = "https://github.com/MrNico98/WinHubX-Resources/releases/download/WinHubX_SystemMonitorApp/WinHubX_SystemMonitorApp.exe";

            // Configura il dialogo per il salvataggio del file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "WinHubX_SystemMonitorApp.exe";
            saveFileDialog.Filter = "Executable Files|*.exe";
            saveFileDialog.Title = "Scegli dove salvare il file";

            // Mostra il dialogo e controlla se l'utente ha selezionato un percorso valido
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Usa WebClient per scaricare il file dal link specificato
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.DownloadFile(fileUrl, filePath);
                        MessageBox.Show("Download completato!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Errore durante il download: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
