using System.Diagnostics;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.Settaggi
{
    public partial class FormRipristinoSO : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormRipristinoSO(FormSettaggi formSettaggi, Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formSettaggi = formSettaggi;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Settaggi";
            form1.PnlFormLoader.Controls.Clear();
            formSettaggi = new FormSettaggi(form1)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            form1.PnlFormLoader.Controls.Add(formSettaggi);
            formSettaggi.Show();
        }

        private void btnSFC_Click(object sender, EventArgs e)
        {
            string fileName = "sfc.exe";
            string arguments = "/scannow";
            ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardError = false;
            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
            }
        }

        private void btnDISM_Click(object sender, EventArgs e)
        {
            RunDismCommand("/online /cleanup-image /checkhealth");
            RunDismCommand("/online /cleanup-image /scanhealth");
            RunDismCommand("/online /cleanup-image /RestoreHealth");
        }

        static void RunDismCommand(string arguments)
        {
            string fileName = "dism.exe";

            ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = false,
                RedirectStandardOutput = false,
                RedirectStandardError = false
            };
            Process process = new Process();
            process.StartInfo = psi;
            process.Start();
        }

        private void btnEliminaDeallocati_Click(object sender, EventArgs e)
        {
            {
                string fileName = "cipher.exe";
                string arguments = "/w:c";
                ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);
                psi.UseShellExecute = false;
                psi.CreateNoWindow = false;
                psi.RedirectStandardOutput = false;
                psi.RedirectStandardError = false;
                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                }
            }
        }

        private void btnStatoDisco_Click(object sender, EventArgs e)
        {
            string fileName = "chkdsk.exe";
            string arguments = "/x /r /f";
            ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardError = false;
            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
            }
        }

        private void btnBios_Click(object sender, EventArgs e)
        {
            string fileName = "shutdown.exe";
            string arguments = "/t 0 /r /fw";
            ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardError = false;
            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
            }
        }

        private void btnVerificaRam_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Windows\System32\mdsched.exe";
            ProcessStartInfo psi = new ProcessStartInfo(fileName);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
            }
        }

        private void btnPuliziaUpdate_Click(object sender, EventArgs e)
        {
            ExecutePowerShellCommand("Stop-Service", "wuauserv", true);
            ExecutePowerShellCommand("DISM.exe", "/Online /Cleanup-Image /StartComponentCleanup /ResetBase", true);
            ExecutePowerShellCommand("cleanmgr.exe", "/sagerun:1", true);
            System.Threading.Thread.Sleep(10000);
            ExecutePowerShellCommand("Remove-Item", "C:\\Windows\\SoftwareDistribution\\Download", true);
            ExecutePowerShellCommand("Start-Service", "wuauserv", true);
        }


        private void btnPuliziaCronologiaDef_Click(object sender, EventArgs e)
        {
            ExecutePowerShellCommand("Set-MpPreference", "-DisableRealtimeMonitoring $false", true);
            ExecutePowerShellCommand("Remove-MpPreference", "-RemoveHistory", true);
            ExecutePowerShellCommand("Set-MpPreference", "-DisableRealtimeMonitoring $true", true);
        }

        private void ExecutePowerShellCommand(string command, string arguments, bool waitForExit = false)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-Command \"{command} {arguments}\"",
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                MessageBox.Show("Output:");
                MessageBox.Show(output);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Error:");
                    MessageBox.Show(error);
                }
            }
        }


        static void ExecuteCommand(string command, string arguments)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (Process process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
                MessageBox.Show(process.StandardOutput.ReadToEnd());
                MessageBox.Show(process.StandardError.ReadToEnd());
            }
        }

        static void RegisterModules(string directory)
        {
            string[] modules = new string[]
            {
            "atl.dll", "urlmon.dll", "mshtml.dll", "shdocvw.dll", "browseui.dll", "jscript.dll", "vbscript.dll",
            "scrrun.dll", "msxml.dll", "msxml3.dll", "msxml6.dll", "actxprxy.dll", "softpub.dll", "wintrust.dll",
            "dssenh.dll", "rsaenh.dll", "gpkcsp.dll", "sccbase.dll", "slbcsp.dll", "cryptdlg.dll", "oleaut32.dll",
            "ole32.dll", "shell32.dll", "initpki.dll", "wuapi.dll", "wuaueng.dll", "wuaueng1.dll", "wucltui.dll",
            "wups.dll", "wups2.dll", "wuweb.dll", "qmgr.dll", "qmgrprxy.dll", "wucltux.dll", "muweb.dll", "wuwebv.dll"
            };

            foreach (string module in modules)
            {
                ExecuteCommand("regsvr32.exe", $"/s \"{Path.Combine(directory, module)}\"");
            }
        }

        static void ConfigureServices()
        {
            ExecuteCommand("sc.exe", "config wuauserv start= auto");
            ExecuteCommand("sc.exe", "config bits start= delayed-auto");
            ExecuteCommand("sc.exe", "config cryptsvc start= auto");
            ExecuteCommand("sc.exe", "config TrustedInstaller start= demand");
            ExecuteCommand("sc.exe", "config DcomLaunch start= auto");
        }

        private void btnSalvaDriver_Click(object sender, EventArgs e)
        {
            try
            {
                string driverDirectory = @"C:\DriverPC";
                if (!Directory.Exists(driverDirectory))
                {
                    Directory.CreateDirectory(driverDirectory);
                    MessageBox.Show($"Cartella creata: {driverDirectory}");
                }
                var dismProcess = Process.Start(new ProcessStartInfo
                {
                    FileName = "dism.exe",
                    Arguments = $"/online /export-driver /destination:{driverDirectory}",
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    CreateNoWindow = false
                });
                string outputPath = Path.Combine(driverDirectory, "driver.txt");
                using (var commandProcess = new Process())
                {
                    commandProcess.StartInfo.FileName = "cmd.exe";
                    commandProcess.StartInfo.Arguments = $"/c driverquery > \"{outputPath}\"";
                    commandProcess.StartInfo.UseShellExecute = false;
                    commandProcess.StartInfo.CreateNoWindow = true;
                    commandProcess.Start();
                    commandProcess.WaitForExit();
                }
            }
            finally
            {
                MessageBox.Show("Trovi la cartella in C:\\DriverPC");
                MessageBox.Show("Per ripristinare tutti i driver, salvati la cartella su USB e, con ISO installata, usa \"pnputil /add-driver 'percorsodriver\\*.inf' /subdirs /install /reboot\".");
            }
        }

        private void btnStatoBatt_Click(object sender, EventArgs e)
        {
            GenerateBatteryReport(@"C:\battery_report.html");
        }

        private void GenerateBatteryReport(string filePath)
        {
            string command = "powercfg /batteryreport /output " + filePath;

            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
                process.StandardInput.WriteLine(command);
                process.StandardInput.Flush();
                process.StandardInput.Close();

                process.WaitForExit();
            }
            if (File.Exists(filePath))
            {
                MessageBox.Show("Battery report generated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to generate battery report.");
            }
        }

        private void btnEliminaTempor_Click(object sender, EventArgs e)
        {
            ClearTempFolders();
            RunDiskCleanup();
        }

        static void ClearTempFolders()
        {
            try
            {
                Process.Start("cmd.exe", "/c del /s /f /q \"%TEMP%\\*.*\"");
                Process.Start("cmd.exe", "/c del /s /f /q \"%SYSTEMROOT%\\Temp\\*.*\"");
                MessageBox.Show("Temp folders cleared successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing temp folders: {ex.Message}");
            }
        }

        static void RunDiskCleanup()
        {
            try
            {
                Process.Start("cleanmgr.exe", "/verylowdisk").WaitForExit();
                MessageBox.Show("Disk Cleanup completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running Disk Cleanup: {ex.Message}");
            }
        }

        private void btnResetWinSxS_Click(object sender, EventArgs e)
        {
            RunDISMCommand();
        }

        static void RunDISMCommand()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "DISM.exe",
                    Arguments = "/Online /Cleanup-Image /StartComponentCleanup",
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                    process.WaitForExit();
                }

                MessageBox.Show("DISM command completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running DISM command: {ex.Message}");
            }
        }
    }
}

