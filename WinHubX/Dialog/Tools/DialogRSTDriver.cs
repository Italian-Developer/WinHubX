using System.Reflection;

namespace WinHubX.Dialog.Tools
{
    public partial class DialogRSTDriver : Form
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

        private SaveFileDialog saveFileDialog;

        public DialogRSTDriver()
        {
            InitializeComponent();

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Zip Files (*.zip)|*.zip";
            saveFileDialog.Title = "Salva Driver RST";
            saveFileDialog.FileName = "DriverRST.zip";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string resourceName = "WinHubX.Resources.DriverRST.zip";
                string destPath = saveFileDialog.FileName;

                try
                {
                    using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                    {
                        if (resourceStream != null)
                        {
                            using (FileStream fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                            {
                                resourceStream.CopyTo(fileStream);
                            }
                        }
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore durante il salvataggio del file: {ex.Message}");
                }
            }
        }
    }
}
