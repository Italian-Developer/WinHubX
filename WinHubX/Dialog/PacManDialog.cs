using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinHubX.Dialog
{
    public partial class PacManDialog : Form
    {
        private string dlLink32;
        private string dlLink64;
        private NotifyIcon notifyIcon;

        public PacManDialog()
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };

            Button closeButton = new Button
            {
                Text = "Chiudi",
                Dock = DockStyle.Bottom,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.Coral,
                ForeColor = System.Drawing.Color.Black,
                Font = new System.Drawing.Font("Product Sans", 15f),
                Cursor = Cursors.Hand
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (sender, e) => this.Close();

            this.Controls.Add(closeButton);
        }

        public void openDialog(Label lblPacMan, string link32, string link64)
        {
            Label infoLabel = new Label
            {
                Image = lblPacMan.Image,
                Text = lblPacMan.Text,
                Font = lblPacMan.Font,
                Size = new System.Drawing.Size(211, 110),
                Location = new System.Drawing.Point(50, 70),
                ForeColor = lblPacMan.ForeColor,
                BackColor = lblPacMan.BackColor,
                TextAlign = ContentAlignment.MiddleRight,
                ImageAlign = ContentAlignment.MiddleLeft
            };

            this.dlLink32 = link32;
            this.dlLink64 = link64;

            this.Controls.Add(infoLabel);
            infoLabel.BringToFront();
        }

        private async void btnInstallaPacMan_Click(object sender, EventArgs e)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string zipFilePath = Path.Combine(desktopPath, "pacman-main.zip");
                string extractPath = desktopPath;
                string sourceDirectory = Path.Combine(desktopPath, "pacman-main", "WSA-pacman-v1.5.0-portable");
                string destinationDirectory = Path.Combine(desktopPath, "PacManWSA");

                if (!Directory.Exists(destinationDirectory))
                {
                    // Usa HttpClient per scaricare il file
                    await DownloadFileAsync("https://github.com/MrNico98/pacman/archive/refs/heads/main.zip", zipFilePath);

                    // Estrai e sposta la directory
                    ZipFile.ExtractToDirectory(zipFilePath, extractPath, true);
                    Directory.Move(sourceDirectory, destinationDirectory);

                    // Pulisci i file temporanei
                    Directory.Delete(Path.Combine(desktopPath, "pacman-main"), true);
                    File.Delete(zipFilePath);

                    // Avvia il programma PacMan
                    Process.Start(Path.Combine(destinationDirectory, "WSA-pacman.exe"));
                }
                else
                {
                    MessageBox.Show("PacMan è già presente sul Desktop.");
                    Process.Start(Path.Combine(destinationDirectory, "WSA-pacman.exe"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un errore: " + ex.Message);
            }
        }

        // Funzione di download con HttpClient
        private static async Task DownloadFileAsync(string url, string destinationFilePath)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using (FileStream fs = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await response.Content.CopyToAsync(fs);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int borderWidth = 2;
            System.Drawing.Color borderColor = System.Drawing.Color.Coral;

            using (System.Drawing.Pen pen = new System.Drawing.Pen(borderColor, borderWidth))
            {
                System.Drawing.Rectangle borderRectangle = new System.Drawing.Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, borderRectangle);
            }
        }
    }
}
