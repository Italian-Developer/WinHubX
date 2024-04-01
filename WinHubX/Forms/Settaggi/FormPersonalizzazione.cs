using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.Personalizzazione
{
    public partial class FormPersonalizzazione : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormPersonalizzazione(FormSettaggi formSettaggi, Form1 form1)
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

        private void btnAvviaSelezionatiPersonal_Click(object sender, EventArgs e)
        {
            if (tasbarsin.Checked)
            {
                string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                string valueName = "TaskbarAl";
                int valueData = 0;
                RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath, true);
                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(registryPath);
                }
                key.SetValue(valueName, valueData, RegistryValueKind.DWord);
                key.Close();
            }
            else if (taskbarcen.Checked)
            {
                string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                string valueName = "TaskbarAl";
                int valueData = 1;
                RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath, true);
                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(registryPath);
                }
                key.SetValue(valueName, valueData, RegistryValueKind.DWord);
                key.Close();
            }
            else if (orologion.Checked)
            {
                string command = "Set-ItemProperty -Path HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced -Name ShowSecondsInSystemClock -Value 0 -Force";
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "powershell.exe";
                startInfo.Arguments = command;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }
            else if (orologiom.Checked)
            {
                string command = "Set-ItemProperty -Path HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced -Name ShowSecondsInSystemClock -Value 1 -Force";
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "powershell.exe";
                startInfo.Arguments = command;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }
            else if (orologiom.Checked)
            {
                string command = "Set-ItemProperty -Path HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced -Name ShowSecondsInSystemClock -Value 1 -Force";
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "powershell.exe";
                startInfo.Arguments = command;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }
            else if (prestazioniel.Checked)
            {
                string command = "POWERCFG";
                string arguments = "/SETACTIVE SCHEME_MIN";
                ProcessStartInfo psi = new ProcessStartInfo(command, arguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                Process process = Process.Start(psi);
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                Console.WriteLine("Output:");
                Console.WriteLine(output);
                Console.WriteLine("Error:");
                Console.WriteLine(error);
            }
            else if (prestazioniec.Checked)
            {
                string command = "POWERCFG";
                string arguments = "-duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61";
                ProcessStartInfo psi = new ProcessStartInfo(command, arguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                Process process = Process.Start(psi);
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                Console.WriteLine("Output:");
                Console.WriteLine(output);
                Console.WriteLine("Error:");
                Console.WriteLine(error);
            }
            else if (prestazionimi.Checked)
            {
                string[] commands = {
                        "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters /v IRPStackSize /t REG_DWORD /d 50 /f",
                         "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters /v SizReqBuf /t REG_DWORD /d 17424 /f",
                         "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters /v DefaultTTL /t REG_DWORD /d 62 /f",
                         "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters /v TCP1323Opts /t REG_DWORD /d 1 /f",
                         "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters /v MaxFreeTcbs /t REG_DWORD /d 65536 /f",
                         "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters /v MaxUserPort /t REG_DWORD /d 65534 /f",
                         "reg add HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters /v GlobalMaxTcpWindowSize /t REG_DWORD /d 65535 /f"
                };

                foreach (string command in commands)
                {
                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c " + command)
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };
                    Process process = Process.Start(psi);
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    Console.WriteLine("Output:");
                    Console.WriteLine(output);
                    Console.WriteLine("Error:");
                    Console.WriteLine(error);
                }

                Console.ReadLine();
            }
            else if (uacdis.Checked)
            {
                string command = "cmd.exe";
                string args = "/c reg add HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v EnableLUA /t REG_DWORD /d 0 /f";

                ProcessStartInfo psi = new ProcessStartInfo(command, args)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                Process process = Process.Start(psi);
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                Console.WriteLine("Output:");
                Console.WriteLine(output);
                Console.WriteLine("Error:");
                Console.WriteLine(error);
            }
            else if (uacatti.Checked)
            {
                string command = "cmd.exe";
                string args = "/c reg add HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v EnableLUA /t REG_DWORD /d 1 /f";

                ProcessStartInfo psi = new ProcessStartInfo(command, args)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                Process process = Process.Start(psi);
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                Console.WriteLine("Output:");
                Console.WriteLine(output);
                Console.WriteLine("Error:");
                Console.WriteLine(error);
            }
            else if (destroleg2.Checked)
            {
                ProcessStartInfo info = new ProcessStartInfo("systeminfo")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process process = Process.Start(info);
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (output.Contains("Windows 10"))
                {
                    Console.WriteLine("Funzione abilitata solo per Windows 11");
                }
                else
                {
                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c \"reg add HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32 /ve /d /f\"");
                    Process.Start(psi).WaitForExit();
                    Process.Start("taskkill", "/F /IM explorer.exe").WaitForExit();
                    Process.Start("explorer.exe");
                }
            }
            else if (destrodef2.Checked)
            {
                ProcessStartInfo info = new ProcessStartInfo("systeminfo")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = Process.Start(info);
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (output.Contains("Windows 10"))
                {
                    Console.WriteLine("Funzione abilitata solo per Windows 11");
                }
                else
                {
                    Console.WriteLine("Ripristino il tasto destro del mouse");
                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c \"reg delete HKCU\\SOFTWARE\\CLASSES\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2} /f\"");
                    Process.Start(psi).WaitForExit();
                    Process.Start("taskkill", "/F /IM explorer.exe").WaitForExit();
                    Process.Start("explorer.exe");
                }
            }
        }
    }
}
