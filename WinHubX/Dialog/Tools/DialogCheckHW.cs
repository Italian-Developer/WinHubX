using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WinHubX.Dialog.Tools
{
    public partial class DialogCheckHW : Form
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

        public DialogCheckHW()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string NameByLang="";

            try
            {
                string LanguageToUse;

                JObject jsonData = JObject.Parse(File.ReadAllText("data.json"));
                LanguageToUse = jsonData["SelectedLanguage"].ToString();
                
                if (LanguageToUse.Contains("it"))
                {
                    NameByLang = "CheckHW.bat";
                }else
                {
                    NameByLang = "CheckHW_eng.bat";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading language " + ex);
            }


            string fileName = NameByLang;
            string resourceName = "WinHubX.Resources." + NameByLang;
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

                Process.Start(tempFilePath);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'avviare l'applicazione: {ex.Message}");
            }
        }
    }
}
