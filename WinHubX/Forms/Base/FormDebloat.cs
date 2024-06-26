using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using WinHubX.Forms.ReinstallaAPP;

namespace WinHubX.Forms.Base
{
    public partial class FormDebloat : Form
    {
        private Form1 form1;
        public FormDebloat(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;

            try
            {

                string LanguageToUse;

                JObject jsonData = JObject.Parse(File.ReadAllText("data.json"));
                LanguageToUse = jsonData["SelectedLanguage"].ToString();

                JObject jsd = JObject.Parse(File.ReadAllText(LanguageToUse + ".json"));
                btnAvviaSelezionatiDebloat.Text = jsd["DebloatStartSelectedBtn"].ToString();
                btnDebloatAuto.Text = jsd["DebloatAutoBtn"].ToString();
                lblInfoWin12.Text = jsd["AutoDebloatSec"].ToString();
                btnReinstallaAPP.Text = jsd["ReinstallApp"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the translation file :(" + " " + ex);
            }

        }

        private void btnAvviaSelezionatiDebloat_Click(object sender, EventArgs e)
        {
            if (Bloat1.CheckedItems.Contains("Calculator"))
            {
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "Get-AppxPackage -allusers Microsoft.WindowsCalculator | Remove-AppxPackage",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();

                        if (!string.IsNullOrEmpty(error))
                        {
                            MessageBox.Show($"Error: {error}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            if (Bloat1.CheckedItems.Contains("Photo"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Windows.Photos | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Canonical"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers CanonicalGroupLimited.UbuntuonWindows | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Xbox TCUI"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers CanonicalGroupLimited.UbuntuonWindows | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Xbox APP"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.XboxApp | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Xbox Overlay"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.XboxGameOverlay | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Xbox Overlay"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.XboxGameOverlay | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Xbox Speech"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.XboxSpeechToTextOverlay | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Xbox Identity"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.XboxIdentityProvider | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Sticky Notes"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.MicrosoftStickyNotes | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("MS Paint"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.MSPaint | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Windows Camera"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.WindowsCamera | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("HiFi Extension"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.HEIFImageExtension | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Screen Capture"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.ScreenSketch | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("VP9 Extension"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.VP9VideoExtensions | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Web Extension"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.WebMediaExtensions | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("WebpImage Extension"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.WebpImageExtension | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("WindSynthBerry"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers WindSynthBerry | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("MidiBerry"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers MIDIBerry | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Slack"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Slack | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Mixed Reality"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.MixedReality.Portal | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("PPI Projection"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.PPIProjection | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Bing News"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.BingNews | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat1.CheckedItems.Contains("Get Help"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.GetHelp | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("To Start"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Getstarted | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Messages"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Messaging | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Microsoft 3D Viewer"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Microsoft3DViewer | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Microsoft Office Hub"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.MicrosoftOfficeHub | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Solitario"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.MicrosoftSolitaireCollection | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Network Speed Test"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.NetworkSpeedTest | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Microsoft News"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.News | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Office Lens"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Office.Lens | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("One Note"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Office.OneNote | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Office Sway"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Office.Sway | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("One Connect"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.OneConnect | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Microsoft People"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.People | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Paint 3D"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Print3D | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Remote Desktop"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.RemoteDesktop | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("App Skype"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.SkypeApp | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Office To Do"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Office.Todo.List | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Whiteboard"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Whiteboard | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Windows Alarm"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.WindowsAlarms | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Comunication"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers microsoft.windowscommunicationsapps | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Feedback Hub"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.WindowsFeedbackHub | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Windows Maps"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.WindowsMaps | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Audio Recorder"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.WindowsSoundRecorder | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Zune Music"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.ZuneMusic | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Zune Video"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.ZuneVideo | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat2.CheckedItems.Contains("Eclipse"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers EclipseManager | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Language Pack"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.LanguageExperiencePackit-IT | Remove-AppxPackage" 
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Adobe Express"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers AdobeSystemsIncorporated.AdobePhotoshopExpress | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Duolingo"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Duolingo-LearnLanguagesforFree | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("PandoraMedia"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers PandoraMediaInc | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Candy Crush"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers CandyCrush | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("BubbleWitch"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers BubbleWitch3Saga | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Wunderlist"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Wunderlist | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Flipboard"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Flipboard | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Twitter"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Twitter | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Facebook"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Facebook | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Dolby"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Dolby | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Advertising XAML"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Advertising.Xaml | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Portfolio"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.Wallet | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Phone"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.YourPhone | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Edge"))
            {

                // Display a warning message
                DialogResult result = MessageBox.Show("Questa operazione richiede un riavvio del PC, Continuare?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                // Check the user's response
                if (result == DialogResult.OK)
                {
                    // User clicked OK, continue with the operation
                    RunPowerShellScript();
                }

                {
                    MessageBox.Show("Operazione Annullata");
                }

            }
            if (Bloat3.CheckedItems.Contains("Microsoft Store"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    Arguments = $"Get-AppxPackage -allusers Microsoft.WindowsStore | Remove-AppxPackage"
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }
            if (Bloat3.CheckedItems.Contains("Windows Defender"))
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                string resourcePath = $"{assemblyName}.Resources.PowerRun.exe";

                try
                {
                    byte[] exeBytes = LoadEmbeddedResource(resourcePath);
                    string tempExePath = Path.Combine(Path.GetTempPath(), "PowerRun.exe");
                    File.WriteAllBytes(tempExePath, exeBytes);
                    RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender"" /v ""DisableAntiSpyware"" /t REG_DWORD /d 1 /f""");
                    RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableBehaviorMonitoring"" /t REG_DWORD /d 1 /f""");
                    RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableIOAVProtection"" /t REG_DWORD /d 1 /f""");
                    RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableOnAccessProtection"" /t REG_DWORD /d 1 /f""");
                    RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableRealtimeMonitoring"" /t REG_DWORD /d 1 /f""");
                    RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SecurityHealthService"" /v ""Start"" /t REG_DWORD /d 4 /f""");
                    RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend"" /v ""Start"" /t REG_DWORD /d 4 /f""");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Si è verificato un errore durante il processo di debloating: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            static byte[] LoadEmbeddedResource(string resourcePath)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
                {
                    if (stream == null)
                        throw new InvalidOperationException("Impossibile trovare la risorsa: " + resourcePath);

                    // Leggi i byte dallo stream di input
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    return buffer;
                }
            }

            static void RunCommand(string fileName, string arguments)
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                }
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDebloatAuto_Click(object sender, EventArgs e)
        {
            string powerShellCommand = GetPowerShellCommand();
            if (powerShellCommand != null)
            {
                ExecutePowerShellCommand(powerShellCommand);
                MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string? GetPowerShellCommand()
        {
            int version = Environment.OSVersion.Version.Major;
            if (version < 10)
            {
                MessageBox.Show("Versione di Windows non supportata. Questo script è per Windows 10 o 11.");
                return null;
            }

            string[] commonAppsToRemove = {
        "Microsoft.VP9VideoExtensions", "Microsoft.WebMediaExtensions",
        "Microsoft.WebpImageExtension", "Microsoft.Windows.ShellExperienceHost",
        "Microsoft.VCLibs*",
        "Microsoft.WindowsStore", "Microsoft.XboxIdentityProvider", "Microsoft.HEIFImageExtension",
        "Microsoft.UI.Xaml*"
    };

            string notepad = version == 11 ? "| Notepad" : "";

            string command = $"$ErrorActionPreference = 'SilentlyContinue'; Get-AppxPackage -AllUsers | Where-Object {{$_.name -notmatch '{string.Join("|", commonAppsToRemove)}'{notepad}}} | Remove-AppxPackage";

            return command;
        }

        private void ExecutePowerShellCommand(string command)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-command \"{command}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Verb = "runas"
            };

            using (var process = Process.Start(processStartInfo))
            {
                if (process != null)
                {
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();
                }
            }
        }

        private void btnReinstallaAPP_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Reinstalla APP";
            form1.PnlFormLoader.Controls.Clear();
            FormReinstallaAPP formReinstallaAPP = new FormReinstallaAPP(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formReinstallaAPP.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formReinstallaAPP);
            formReinstallaAPP.Show();
        }

        static void RunPowerShellScript()
        {
            // Construct the PowerShell script
            StringBuilder scriptBuilder = new StringBuilder();
            scriptBuilder.AppendLine("$integratedServicesPath = 'C:\\Windows\\System32\\IntegratedServicesRegionPolicySet.json'");
            scriptBuilder.AppendLine("$acl = Get-Acl -Path $integratedServicesPath");
            scriptBuilder.AppendLine("takeown /f $integratedServicesPath /a");
            scriptBuilder.AppendLine("icacls $integratedServicesPath /grant Administrators:F");
            scriptBuilder.AppendLine("$jsonContent = Get-Content $integratedServicesPath | ConvertFrom-Json");
            scriptBuilder.AppendLine("foreach ($policy in $jsonContent.policies) {");
            scriptBuilder.AppendLine("    if ($policy.'$comment' -like '*Edge*' -and $policy.'$comment' -like '*uninstall*') {");
            scriptBuilder.AppendLine("        $policy.defaultState = 'enabled'");
            scriptBuilder.AppendLine("        $allCountryCodes = @('AT', 'BE', 'BG', 'CH', 'CY', 'CZ', 'DE', 'DK', 'EE', 'ES', 'FI', 'FR', 'GF', 'GP', 'GR', 'HR', 'HU', 'IE', 'IS', 'IT', 'LI', 'LT', 'LU', 'LV', 'MT', 'MQ', 'NL', 'NO', 'PL', 'PT', 'RE', 'RO', 'SE', 'SI', 'SK', 'YT', 'AD', 'AE', 'AF', 'AG', 'AI', 'AL', 'AM', 'AO', 'AQ', 'AR', 'AS', 'AU', 'AW', 'AX', 'AZ', 'BA', 'BB', 'BD', 'BF', 'BH', 'BI', 'BJ', 'BL', 'BM', 'BN', 'BO', 'BQ', 'BR', 'BS', 'BT', 'BV', 'BW', 'BY', 'BZ', 'CA', 'CC', 'CD', 'CF', 'CG', 'CI', 'CK', 'CL', 'CM', 'CN', 'CO', 'CR', 'CU', 'CV', 'CW', 'CX', 'DJ', 'DM', 'DO', 'DZ', 'EC', 'EG', 'EH', 'ER', 'ET', 'FK', 'FM', 'FO', 'GA', 'GB', 'GD', 'GE', 'GG', 'GH', 'GI', 'GL', 'GM', 'GN', 'GQ', 'GS', 'GT', 'GU', 'GW', 'GY', 'HK', 'HM', 'HN', 'HT', 'ID', 'IL', 'IM', 'IN', 'IO', 'IQ', 'IR', 'JE', 'JM', 'JO', 'JP', 'KE', 'KG', 'KH', 'KI', 'KM', 'KN', 'KP', 'KR', 'KW', 'KY', 'KZ', 'LA', 'LB', 'LC', 'LK', 'LR', 'LS', 'LY', 'MA', 'MC', 'MD', 'ME', 'MF', 'MG', 'MH', 'MK', 'ML', 'MM', 'MN', 'MO', 'MP', 'MR', 'MS', 'MU', 'MV', 'MW', 'MX', 'MY', 'MZ', 'NA', 'NC', 'NE', 'NF', 'NG', 'NI', 'NP', 'NR', 'NU', 'NZ', 'OM', 'PA', 'PE', 'PF', 'PG', 'PH', 'PK', 'PM', 'PN', 'PR', 'PS', 'PW', 'PY', 'QA', 'RE', 'RS', 'RU', 'RW', 'SA', 'SB', 'SC', 'SD', 'SG', 'SH', 'SJ', 'SL', 'SM', 'SN', 'SO', 'SR', 'SS', 'ST', 'SV', 'SX', 'SY', 'SZ', 'TC', 'TD', 'TF', 'TG', 'TH', 'TJ', 'TK', 'TL', 'TM', 'TN', 'TO', 'TT', 'TV', 'TW', 'TZ', 'UA', 'UG', 'UM', 'US', 'UY', 'UZ', 'VA', 'VC', 'VE', 'VG', 'VI', 'VN', 'VU', 'WF', 'WS', 'YE', 'YT', 'ZA', 'ZM', 'ZW')");
            scriptBuilder.AppendLine("        $policy.conditions.region.enabled = $allCountryCodes");
            scriptBuilder.AppendLine("    }");
            scriptBuilder.AppendLine("}");
            scriptBuilder.AppendLine("$jsonContent | ConvertTo-Json -Depth 100 | Set-Content -Path 'C:\\BK_IntegratedServicesRegionPolicySet.json'");
            scriptBuilder.AppendLine("copy C:\\BK_IntegratedServicesRegionPolicySet.json $integratedServicesPath");
            scriptBuilder.AppendLine("Set-Acl -Path $integratedServicesPath -AclObject $acl");
            scriptBuilder.AppendLine("shutdown /r /t 00");

            string powerShellScript = scriptBuilder.ToString();

            // Set up the process start info
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{powerShellScript}\"",
                UseShellExecute = true, // Must be true to use 'runas'
                Verb = "runas", // Run as administrator
                WindowStyle = ProcessWindowStyle.Hidden
            };

            try
            {
                // Start the process
                Process process = new Process
                {
                    StartInfo = psi
                };

                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void Bloat1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
