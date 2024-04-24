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
            bottoni.Add(btnMonitoraggio);
            bottoni.Add(btnTools);

            swap_pnlNav(btnHome);

            lblPanelTitle.Text = "Home";
            PnlFormLoader.Controls.Clear();
            FormHome formHome = new FormHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formHome.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formHome);
            formHome.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
        private void btnHome_Leave(object sender, EventArgs e)
        {
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
        private void btnWin_Leave(object sender, EventArgs e)
        {
        }

        private void btnOffice_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnOffice);

            lblPanelTitle.Text = "Office";
            PnlFormLoader.Controls.Clear();
            FormOffice formOffice = new FormOffice() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
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
        private void btnSettaggi_Leave(object sender, EventArgs e)
        {
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
        private void btnDebloat_Leave(object sender, EventArgs e)
        {
        }

        private void btnCreaISO_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnCreaISO);
            string assemblyNamee = Assembly.GetExecutingAssembly().GetName().Name;
            ExtractEmbeddedResourceFolder($"{assemblyNamee}.Resources.RisorseCreaISO");
            try
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                string resourcePath = $"{assemblyName}.Resources.RisorseCreaISO.ISOMaker.ps1";
                byte[] exeBytes = LoadEmbeddedResource(resourcePath);
                string ps1FilePath = Path.Combine(Path.GetTempPath(), "ISOMaker.ps1");
                File.WriteAllBytes(ps1FilePath, exeBytes);

                // Start the process
                StartPowerShell(ps1FilePath);
            }
            finally { }
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
                    // This will strip out the resourceFolder prefix and the "Risorse." part from the file name
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


        private byte[] LoadEmbeddedResource(string resourcePath)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException($"Could not find embedded resource: {resourcePath}");
                }
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        private void StartPowerShell(string scriptFilePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptFilePath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
            }
        }
        private void btnCreaISO_Leave(object sender, EventArgs e)
        {
        }

        private void btnMonitoraggio_Click(object sender, EventArgs e)
        {
            swap_pnlNav(btnMonitoraggio);
            lblPanelTitle.Text = "Monitoraggio";
            PnlFormLoader.Controls.Clear();
            FormMonitoraggio formMonitoraggio = new(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formMonitoraggio.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formMonitoraggio);
            formMonitoraggio.Show();
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
        private void btnTools_Leave(object sender, EventArgs e)
        {
        }
    }
}
