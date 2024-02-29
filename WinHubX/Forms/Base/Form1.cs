using System.Runtime.InteropServices;

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
                m.Result = (IntPtr)(HT_CAPTION);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMnmz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
