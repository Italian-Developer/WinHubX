using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Reflection;
using WinHubX.Forms.Windows;

namespace WinHubX
{
    public partial class FormWin : Form
    {
        private Form1 form1;

        public FormWin(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;

            try
            {
                string LanguageToUse;

                JObject jsonData = JObject.Parse(File.ReadAllText("data.json"));
                LanguageToUse = jsonData["SelectedLanguage"].ToString();

                JObject jsd = JObject.Parse(File.ReadAllText(LanguageToUse + ".json"));
                btnAttivaWin.Text = jsd["ActivateWindows"].ToString();
                btnCambioEdizione.Text = jsd["ChangeEdition"].ToString();
            } catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the translation file :(" + " " + ex);
            }
            


        }

        private void btnWin7_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows 7";
            form1.PnlFormLoader.Controls.Clear();
            FormWin7 formWin7 = new FormWin7(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formWin7.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formWin7);
            formWin7.Show();
        }

        private void btnWin8dot1_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows 8.1";
            form1.PnlFormLoader.Controls.Clear();
            FormWin8Dot1 formWin8Dot1 = new FormWin8Dot1(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formWin8Dot1.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formWin8Dot1);
            formWin8Dot1.Show();
        }

        private void btnWin10_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows 10";
            form1.PnlFormLoader.Controls.Clear();
            FormWin10 formWin10 = new FormWin10(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formWin10.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formWin10);
            formWin10.Show();
        }

        private void btnWin11_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows 11";
            form1.PnlFormLoader.Controls.Clear();
            FormWin11 formWin11 = new FormWin11(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formWin11.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formWin11);
            formWin11.Show();
        }

        private void btnAttivaWin_Click(object sender, EventArgs e)
        {
            string fileName = "WinHubXWindowsAttivatore.bat";
            string resourceName = "WinHubX.Resources.WinHubXWindowsAttivatore.bat"; string tempPath = Path.GetTempPath();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'avviare l'applicazione: {ex.Message}");
            }
        }

        private void btnCambioEdizione_Click(object sender, EventArgs e)
        {
            string fileName = "WinHubXCambioEdizione.bat";
            string resourceName = "WinHubX.Resources.WinHubXCambioEdizione.bat"; string tempPath = Path.GetTempPath();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'avviare l'applicazione: {ex.Message}");
            }
        }

        private void btnWinLive_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "https://devuploads.com/ucpfdcbe6bl3",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
            }
        }

        //private void btnAIO32_Click(object sender, EventArgs e)
        //{
        //    form1.lblPanelTitle.Text = "Windows All in One - 32bit";
        //    form1.PnlFormLoader.Controls.Clear();
        //    FormWinAiO_32 formWinAiO_32 = new FormWinAiO_32(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    formWinAiO_32.FormBorderStyle = FormBorderStyle.None;
        //    form1.PnlFormLoader.Controls.Add(formWinAiO_32);
        //    formWinAiO_32.Show();
        //}

        //private void btnAIO64_Click(object sender, EventArgs e)
        //{
        //    form1.lblPanelTitle.Text = "Windows All in One - 64bit";
        //    form1.PnlFormLoader.Controls.Clear();
        //    FormWinAiO_64 formWinAiO_64 = new FormWinAiO_64(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //    formWinAiO_64.FormBorderStyle = FormBorderStyle.None;
        //    form1.PnlFormLoader.Controls.Add(formWinAiO_64);
        //    formWinAiO_64.Show();
        //}
    }
}
