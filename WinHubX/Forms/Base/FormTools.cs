using WinHubX.Dialog;
using WinHubX.Dialog.Tools;

namespace WinHubX
{
    public partial class FormTools : Form
    {
        public FormTools()
        {
            InitializeComponent();
        }

        private void btnWinC_Click(object sender, EventArgs e)
        {
            DialogWinCustomizer dialogWinC = new DialogWinCustomizer()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            dialogWinC.ShowDialog();
        }

        private void btnWimTK_Click(object sender, EventArgs e)
        {
            DialogWIMToolKit dialogWIMTK = new DialogWIMToolKit()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            dialogWIMTK.ShowDialog();
        }

        private void btnDaRT_Click(object sender, EventArgs e)
        {
            DialogDaRT dialogDaRT = new DialogDaRT()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            dialogDaRT.ShowDialog();
        }

        private void btnRufus_Click(object sender, EventArgs e)
        {
            DialogRufus4Lite dialogRufus4Lite = new DialogRufus4Lite()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            dialogRufus4Lite.ShowDialog();
        }

        private void btnMPM_Click(object sender, EventArgs e)
        {
            DialogMsPCManager dialogMsPCManager = new DialogMsPCManager()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            dialogMsPCManager.ShowDialog();
        }

        private void btnRSTDriver_Click(object sender, EventArgs e)
        {
            DialogRSTDriver dialogRSTDriver = new DialogRSTDriver()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            dialogRSTDriver.ShowDialog();
        }

        private void btnCheckHW_Click(object sender, EventArgs e)
        {
            DialogCheckHW dialogCheckHW = new DialogCheckHW()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            dialogCheckHW.ShowDialog();
        }
    }
}
