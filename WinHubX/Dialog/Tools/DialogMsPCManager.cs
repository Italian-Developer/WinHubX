
using System.Diagnostics;
using System.Reflection;

namespace WinHubX.Dialog.Tools
{
    public partial class DialogMsPCManager : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int borderWidth = 2;

            Color borderColor = Color.Coral;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle borderRectangle = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);

                e.Graphics.DrawRectangle(pen, borderRectangle);
            }
        }

        public DialogMsPCManager()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string fileName = "MSPCManagerSetup.msixbundle";
            string resourceName = "WinHubX.Resources.MSPCManagerSetup.msixbundle";
            string tempPath = Path.GetTempPath();
            string tempFilePath = Path.Combine(tempPath, fileName);

            try
            {
                using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (resourceStream != null)
                    {
                        using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                        {
                            resourceStream.CopyTo(fileStream);
                        }
                    }
                }

                // Use explorer.exe to handle the msixbundle installation
                Process.Start("explorer.exe", tempFilePath);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'avviare l'applicazione: {ex.Message}");
            }
        }

    }
}
