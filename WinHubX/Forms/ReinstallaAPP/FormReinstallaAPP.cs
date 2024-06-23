using System.Diagnostics;
using System.Reflection;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.ReinstallaAPP
{
    public partial class FormReinstallaAPP : Form
    {
        private Form1 form1;
        private FormDebloat formDebloat;

        public FormReinstallaAPP(FormDebloat formDebloat, Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formDebloat = formDebloat;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Debloat";
            form1.PnlFormLoader.Controls.Clear();
            formDebloat = new FormDebloat(form1)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            form1.PnlFormLoader.Controls.Add(formDebloat);
            formDebloat.Show();
        }

        static void RegisterAppxPackage(string packageName)
        {
            // Comando PowerShell per ottenere il percorso del manifest del pacchetto AppX
            string getManifestPathCommand = $"Get-AppxPackage -AllUsers '{packageName}' | Select -ExpandProperty InstallLocation";

            string manifestPath = ExecutePowerShellCommand(getManifestPathCommand);

            if (!string.IsNullOrEmpty(manifestPath))
            {
                // Comando PowerShell per registrare il pacchetto AppX utilizzando il percorso del manifest
                string registerCommand = $"Add-AppxPackage -DisableDevelopmentMode -Register '{manifestPath}\\AppXManifest.xml'";

                ExecutePowerShellCommand(registerCommand);
            }
        }

        static string ExecutePowerShellCommand(string command)
        {
            string output = "";

            using (Process powerShellProcess = new Process())
            {
                powerShellProcess.StartInfo.FileName = "powershell.exe";
                powerShellProcess.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy unrestricted -Command \"{command}\"";
                powerShellProcess.StartInfo.UseShellExecute = false;
                powerShellProcess.StartInfo.CreateNoWindow = true;
                powerShellProcess.StartInfo.RedirectStandardOutput = true;
                powerShellProcess.StartInfo.RedirectStandardError = true;

                powerShellProcess.Start();

                output = powerShellProcess.StandardOutput.ReadToEnd();
                string error = powerShellProcess.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show($"Errore di PowerShell:\n{error}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                powerShellProcess.WaitForExit();
            }

            return output.Trim();
        }

        private void btnAvviaSelezionatiApp_Click(object sender, EventArgs e)
        {
            if (App1.CheckedItems.Contains("Microsoft Store"))
            {
                RegisterAppxPackage("Microsoft.DesktopAppInstaller");
                RegisterAppxPackage("Microsoft.WindowsStore");
            }

            if (App1.CheckedItems.Contains("Microsoft Edge"))
            {
                RunPowerShellCommand1("winget install Microsoft.Edge");

                MessageBox.Show("Premi un tasto per uscire...");
                Console.ReadKey();
            }
            if (App1.CheckedItems.Contains("Windows Defender"))
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                string resourcePath = $"{assemblyName}.Resources.PowerRun.exe";

                try
                {
                    byte[] exeBytes = LoadEmbeddedResource(resourcePath);
                    string tempExePath = Path.Combine(Path.GetTempPath(), "PowerRun.exe");

                    File.WriteAllBytes(tempExePath, exeBytes);
                    RunCommandd(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender"" /v ""DisableAntiSpyware"" /t REG_DWORD /d 0 /f""");
                    RunCommandd(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableBehaviorMonitoring"" /t REG_DWORD /d 0 /f""");
                    RunCommandd(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableIOAVProtection"" /t REG_DWORD /d 0 /f""");
                    RunCommandd(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableOnAccessProtection"" /t REG_DWORD /d 0 /f""");
                    RunCommandd(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableRealtimeMonitoring"" /t REG_DWORD /d 0 /f""");
                    RunCommandd(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SecurityHealthService"" /v ""Start"" /t REG_DWORD /d 2 /f""");
                    RunCommandd(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend"" /v ""Start"" /t REG_DWORD /d 2 /f""");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Si è verificato un errore durante il ripristino Defender {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            static byte[] LoadEmbeddedResource(string resourcePath)
            {

                Assembly assembly = Assembly.GetExecutingAssembly();


                using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
                {
                    if (stream == null)
                        throw new InvalidOperationException("Impossibile trovare la risorsa: " + resourcePath);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    return buffer;
                }
            }

            static void RunCommandd(string fileName, string arguments)
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

                    if (!string.IsNullOrEmpty(output))
                    {
                        MessageBox.Show($"Output: {output}");
                    }

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Error: {error}");
                    }
                }
            }

            static void RunPowerShellCommand1(string command)
            {
                try
                {
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };
                    using (var process = Process.Start(startInfo))
                    {
                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                        if (!string.IsNullOrEmpty(error))
                        {
                            MessageBox.Show($"Errore: {error}");
                        }
                        if (!string.IsNullOrEmpty(output))
                        {
                            MessageBox.Show($"Output: {output}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Si è verificata un'eccezione: {ex.Message}");
                }
            }

            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
