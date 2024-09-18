using Microsoft.Win32;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using WinHubX.Forms.Base;

namespace WinHubX
{
    public partial class Form1 : Form
    {
        #region movable without borders
        private const int WM_NCHITTEST = 0x84;
        //private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = HT_CAPTION;
        }
        #endregion

        #region navigation panel bar

        private List<Button> bottoni = new List<Button>();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        private void swap_pnlNav(Button btn)
        {
            List<Button> swapBottoni = new List<Button>(bottoni);
            swapBottoni.Remove(btn);
            foreach (Button b in swapBottoni)
            {
                b.BackColor = Color.FromArgb(64, 60, 59);
            }
            pnlNav.Height = btn.Height;
            pnlNav.Top = btn.Top;
            pnlNav.Left = btn.Left;
            btn.BackColor = Color.FromArgb(46, 51, 73);
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            bottoni.Add(btnHome);
            bottoni.Add(btnWin);
            bottoni.Add(btnOffice);
            bottoni.Add(btnSettaggi);
            bottoni.Add(btnDebloat);
            bottoni.Add(btnCreaISO);
            bottoni.Add(btnTools);
            bottoni.Add(btnupdate);

            swap_pnlNav(btnHome);

            lblPanelTitle.Text = "Home";
            PnlFormLoader.Controls.Clear();
            FormHome formHome = new FormHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formHome.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formHome);
            formHome.Show();

        }

        public static void RemoveRegistryKeys()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\YourAppName", true);
            if (key != null)
            {
                key.DeleteSubKeyTree("SubKeyName");
                key.Close();
            }
        }

        public void btnHome_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnHome);

            lblPanelTitle.Text = "Home";
            PnlFormLoader.Controls.Clear();
            FormHome formHome = new FormHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formHome.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formHome);
            formHome.Show();
        }


        private void btnWin_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnWin);

            lblPanelTitle.Text = "Windows";
            PnlFormLoader.Controls.Clear();
            FormWin formWin = new(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formWin.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formWin);
            formWin.Show();
        }

        private void btnOffice_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnOffice);

            lblPanelTitle.Text = "Office";
            PnlFormLoader.Controls.Clear();
            FormOffice formOffice = new FormOffice(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formOffice.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formOffice);
            formOffice.Show();
        }
        private void btnOffice_Leave(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMnmz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSettaggi_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnSettaggi);

            lblPanelTitle.Text = "Settaggi";
            PnlFormLoader.Controls.Clear();
            FormSettaggi formSettaggi = new(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formSettaggi.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formSettaggi);
            formSettaggi.Show();
        }

        private void btnDebloat_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnDebloat);

            lblPanelTitle.Text = "Debloat";
            PnlFormLoader.Controls.Clear();
            FormDebloat formDebloat = new(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formDebloat.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formDebloat);
            formDebloat.Show();
        }

        private void btnCreaISO_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnCreaISO);
            string assemblyNamee = Assembly.GetExecutingAssembly().GetName().Name;
            ExtractEmbeddedResourceFolder($"{assemblyNamee}.Resources.RisorseCreaISO");
            lblPanelTitle.Text = "Crea ISO";
            PnlFormLoader.Controls.Clear();
            FormCreaISO formcreaiso = new(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formcreaiso.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formcreaiso);
            formcreaiso.Show();
        }

        public static void ExtractEmbeddedResourceFolder(string resourceFolder)
        {
            string tempFolderPath = Path.GetTempPath();
            string targetFolderPath = Path.Combine(tempFolderPath, "RisorseCreaISO");
            Directory.CreateDirectory(targetFolderPath);
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] resourceNames = assembly.GetManifestResourceNames();
            foreach (string resourceName in resourceNames)
            {
                if (resourceName.StartsWith(resourceFolder))
                {
                    string relativePath = resourceName.Substring(resourceFolder.Length + 1).Replace("Risorse.", "");
                    string path = Path.Combine(targetFolderPath, relativePath);
                    string directory = Path.GetDirectoryName(path);
                    Directory.CreateDirectory(directory);
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    using (FileStream fileStream = new FileStream(path, FileMode.Create))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnTools);

            lblPanelTitle.Text = "Tools";
            PnlFormLoader.Controls.Clear();
            FormTools formTools = new FormTools() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formTools.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formTools);
            formTools.Show();
        }


        private async void btnupdate_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnupdate);

            string updateInfoUrl = "https://aimodsitalia.store/WinHubX/update.json";
            string currentVersion = "2.4.0.3"; // Inserisci qui il numero di versione corrente dell'applicazione

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(updateInfoUrl);
                    dynamic updateInfo = JsonConvert.DeserializeObject(response);

                    string latestVersion = updateInfo.version;

                    if (latestVersion != currentVersion)
                    {
                        DialogResult result = MessageBox.Show($"Nuova versione ({latestVersion}) disponibile. Note di rilascio: {updateInfo.releaseNotes}. Vuoi aggiornare?", "Aggiornamento Disponibile", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            string updateUrl = updateInfo.updateUrl;
                            await DownloadAndUpdate(updateUrl, latestVersion);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Stai usando l'ultima versione disponibile", "Non ci sono aggiornamenti");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}", "Error");
            }
        }
        private async Task DownloadAndUpdate(string updateUrl, string version)
        {
            string updateFileName = $"WinHubX_SystemMonitorApp{version}.exe";
            string updateFilePath = Path.Combine(Path.GetTempPath(), updateFileName);

            // Mostra il form di progresso
            using (var progressForm = new ProgressForm())
            {
                progressForm.Show();
                progressForm.SetMarquee();

                try
                {
                    using (var client = new HttpClient())
                    {
                        // Scarica il file di aggiornamento
                        progressForm.SetStatus("Scaricamento file di aggiornamento...", 0);
                        await DownloadFileWithProgress(client, updateUrl, updateFilePath, progressForm);
                    }

                    // Esegui l'aggiornamento in un nuovo thread
                    Thread updateThread = new Thread(() => ExecuteUpdate(updateFilePath));
                    updateThread.Start();

                    // Chiudi la finestra principale dell'applicazione, lasciando il thread di aggiornamento in esecuzione
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore durante l'aggiornamento: {ex.Message}", "Errore");
                }
                finally
                {
                    progressForm.CompleteOperation();
                }
            }
        }

        private void ExecuteUpdate(string updateFilePath)
        {
            try
            {
                // Attendere un breve intervallo per garantire che l'applicazione principale sia chiusa
                Thread.Sleep(2000);

                // Ottieni il percorso dell'eseguibile corrente
                string currentExecutablePath = Application.ExecutablePath;
                string oldExecutablePath = Path.ChangeExtension(currentExecutablePath, ".old");

                // Rinominare l'eseguibile corrente a .old
                if (File.Exists(currentExecutablePath))
                {
                    File.Move(currentExecutablePath, oldExecutablePath);
                }

                // Sostituisci l'eseguibile con la nuova versione
                File.Move(updateFilePath, currentExecutablePath);

                // Avvia il nuovo eseguibile
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = currentExecutablePath,
                    Arguments = "/silent",
                    UseShellExecute = true,
                    Verb = "runas" // Richiede privilegi di amministratore, se necessario
                };

                Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'aggiornamento: {ex.Message}", "Errore");
            }
            finally
            {
                // Chiudi l'applicazione attuale
                Environment.Exit(0);
            }
        }

        private async Task DownloadFileWithProgress(HttpClient client, string url, string filePath, ProgressForm progressForm)
        {
            using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var totalBytes = response.Content.Headers.ContentLength.GetValueOrDefault();
                var buffer = new byte[8192];
                var bytesRead = 0L;
                using (var contentStream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, buffer.Length, true))
                {
                    int read;
                    while ((read = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, read);
                        bytesRead += read;
                        // Aggiorna la barra di avanzamento
                        var percentComplete = (int)((bytesRead * 100) / totalBytes);
                        progressForm.Invoke(new Action(() => progressForm.SetStatus("Download in corso...", percentComplete)));
                    }
                }
            }
        }
    }
}
