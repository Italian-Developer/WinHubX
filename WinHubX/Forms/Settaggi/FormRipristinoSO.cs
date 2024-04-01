using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinHubX.Forms.Base;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            string fileName = "mdsched";
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
            ExecuteCommand("Stop-Service", "wuauserv");
            ExecuteCommand("DISM.exe", "/Online /Cleanup-Image /StartComponentCleanup /ResetBase");
            ExecuteCommand("cleanmgr.exe", "/sagerun:1", true);
            System.Threading.Thread.Sleep(10000);
            ExecuteCommand("Remove-Item", "C:\\Windows\\SoftwareDistribution\\Download");
            ExecuteCommand("Start-Service", "wuauserv");
        }

        static void ExecuteCommand(string fileName, string arguments, bool wait = false)
        {
            ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
                if (wait)
                {
                    process.WaitForExit();
                }
            }
        }

        private void btnPuliziaCronologiaDef_Click(object sender, EventArgs e)
        {
            ExecutePowerShellCommand("Set-MpPreference -DisableRealtimeMonitoring $false");
            ExecutePowerShellCommand("Remove-MpPreference -RemoveHistory");
            ExecutePowerShellCommand("Set-MpPreference -DisableRealtimeMonitoring $true");
        }
        static void ExecutePowerShellCommand(string command)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript(command);
                ps.Invoke();
            }
        }

        private void btnResettaUpdate_Click(object sender, EventArgs e)
        {
            StopServices();
            KillProcess("wuauclt.exe");
            DeleteFiles(@"%ALLUSERSPROFILE%\Application Data\Microsoft\Network\Downloader\", "qmgr*.dat");
            DeleteFiles(@"%ALLUSERSPROFILE%\Microsoft\Network\Downloader\", "qmgr*.dat");
            string systemRoot = Environment.GetEnvironmentVariable("SYSTEMROOT");
            if (!string.IsNullOrEmpty(systemRoot))
            {
                DeleteIfExists(Path.Combine(systemRoot, "winsxs", "pending.xml.bak"));
                DeleteIfExists(Path.Combine(systemRoot, "SoftwareDistribution.bak"));
                DeleteIfExists(Path.Combine(systemRoot, "system32", "Catroot2.bak"));
                DeleteIfExists(Path.Combine(systemRoot, "WindowsUpdate.log.bak"));
                RenameIfExists(Path.Combine(systemRoot, "winsxs", "pending.xml"), "pending.xml.bak");
                RenameIfExists(Path.Combine(systemRoot, "SoftwareDistribution"), "SoftwareDistribution.bak");
                RenameIfExists(Path.Combine(systemRoot, "system32", "Catroot2"), "Catroot2.bak");
                RenameIfExists(Path.Combine(systemRoot, "WindowsUpdate.log"), "WindowsUpdate.log.bak");
                ExecuteCommand("takeown", $"/f \"{Path.Combine(systemRoot, "winsxs", "pending.xml")}\"");
                ExecuteCommand("attrib", $"-r -s -h /s /d \"{Path.Combine(systemRoot, "winsxs", "pending.xml")}\"");
                RenameIfExists(Path.Combine(systemRoot, "winsxs", "pending.xml"), "pending.xml.bak");
                ExecuteCommand("attrib", $"-r -s -h /s /d \"{Path.Combine(systemRoot, "SoftwareDistribution")}\"");
                ExecuteCommand("attrib", $"-r -s -h /s /d \"{Path.Combine(systemRoot, "system32", "Catroot2")}\"");
                ExecuteCommand("attrib", $"-r -s -h /s /d \"{Path.Combine(systemRoot, "WindowsUpdate.log")}\"");
                RenameIfExists(Path.Combine(systemRoot, "WindowsUpdate.log"), "WindowsUpdate.log.bak");
            }
            ExecuteCommand("sc.exe", "sdset wuauserv D:(A;CI;CCLCSWRPLORC;;;AU)(A;;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;BA)(A;;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;SY)S:(AU;FA;CCDCLCSWRPWPDTLOSDRCWDWO;;;WD)");
            ExecuteCommand("sc.exe", "sdset bits D:(A;CI;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;SY)(A;;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;BA)(A;;CCLCSWLOCRRC;;;IU)(A;;CCLCSWLOCRRC;;;SU)S:(AU;SAFA;WDWO;;;BA)");
            ExecuteCommand("sc.exe", "sdset cryptsvc D:(A;;CCLCSWRPWPDTLOCRRC;;;SY)(A;;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;BA)(A;;CCLCSWLOCRRC;;;IU)(A;;CCLCSWLOCRRC;;;SU)(A;;CCLCSWRPWPDTLOCRRC;;;SO)(A;;CCLCSWLORC;;;AC)(A;;CCLCSWLORC;;;S-1-15-3-1024-3203351429-2120443784-2872670797-1918958302-2829055647-4275794519-765664414-2751773334)");
            ExecuteCommand("sc.exe", "sdset trustedinstaller D:(A;CI;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;SY)(A;;CCDCLCSWRPWPDTLOCRRC;;;BA)(A;;CCLCSWLOCRRC;;;IU)(A;;CCLCSWLOCRRC;;;SU)S:(AU;SAFA;WDWO;;;BA)");
            string system32Path = Path.Combine(systemRoot, "system32");
            RegisterModules(system32Path);
            ExecuteCommand("netsh", "winsock reset");
            ConfigureServices();
            StartServices();

            Console.WriteLine("Operazioni completate con successo.");
        }

        static void StopServices()
        {
            ExecuteCommand("net", "stop bits");
            ExecuteCommand("net", "stop wuauserv");
            ExecuteCommand("net", "stop appidsvc");
            ExecuteCommand("net", "stop cryptsvc");
        }

        static void StartServices()
        {
            ExecuteCommand("net", "start bits");
            ExecuteCommand("net", "start wuauserv");
            ExecuteCommand("net", "start appidsvc");
            ExecuteCommand("net", "start cryptsvc");
        }

        static void KillProcess(string processName)
        {
            ExecuteCommand("taskkill", $"/im {processName} /f");
        }

        static void DeleteFiles(string directory, string pattern)
        {
            ExecuteCommand("del", $"/s /q /f \"{Path.Combine(directory, pattern)}\"");
        }

        static void DeleteIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        static void RenameIfExists(string filePath, string newFileName)
        {
            if (File.Exists(filePath))
            {
                File.Move(filePath, newFileName);
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
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.WriteLine(process.StandardError.ReadToEnd());
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
                    Console.WriteLine($"Cartella creata: {driverDirectory}");
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
                Console.WriteLine("Trovi la cartella in C:\\DriverPC");
                Console.WriteLine("Per ripristinare tutti i driver, salvati la cartella su USB e, con ISO installata, usa \"pnputil /add-driver 'percorsodriver\\*.inf' /subdirs /install /reboot\".");
            }
        }

        private void btnStatoBatt_Click(object sender, EventArgs e)
        {
            GenerateBatteryReport(@"C:\battery_report.html");
        }

        static void GenerateBatteryReport(string outputPath)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "powercfg";
                    process.StartInfo.Arguments = $"/batteryreport /output \"{outputPath}\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine("Report della batteria generato con successo.");
                        Console.WriteLine(output);
                    }
                    else
                    {
                        Console.WriteLine("Errore durante la generazione del report della batteria.");
                        Console.WriteLine(error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
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
                Console.WriteLine("Temp folders cleared successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing temp folders: {ex.Message}");
            }
        }

        static void RunDiskCleanup()
        {
            try
            {
                Process.Start("cleanmgr.exe", "/verylowdisk").WaitForExit();
                Console.WriteLine("Disk Cleanup completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running Disk Cleanup: {ex.Message}");
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
                    CreateNoWindow = true
                };

                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                    process.WaitForExit();
                }

                Console.WriteLine("DISM command completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running DISM command: {ex.Message}");
            }
        }
    }
}

