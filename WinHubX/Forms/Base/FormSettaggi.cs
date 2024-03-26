using WinHubX.Forms.Settaggi;

namespace WinHubX.Forms.Base
{
    public partial class FormSettaggi : Form
    {
        private Form1 form1;

        public FormSettaggi(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void btnPrivacy_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows Privacy";
            form1.PnlFormLoader.Controls.Clear();
            FormPrivacy formPrivacy = new FormPrivacy(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formPrivacy.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formPrivacy);
            formPrivacy.Show();
        }

        private void btnUtility_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Utility";
            form1.PnlFormLoader.Controls.Clear();
            FormUtility formUtility = new FormUtility(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formUtility.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formUtility);
            formUtility.Show();
        }

        private void btnDefender_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows Defender";
            form1.PnlFormLoader.Controls.Clear();
            FormDefender formDefender = new FormDefender(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formDefender.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formDefender);
            formDefender.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows Update";
            form1.PnlFormLoader.Controls.Clear();
            FormUpdate formUpdate = new FormUpdate(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formUpdate.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formUpdate);
            formUpdate.Show();
        }
    }
}
