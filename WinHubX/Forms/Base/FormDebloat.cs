using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinHubX.Forms.Base
{
    public partial class FormDebloat : Form
    {
        private Form1 form1;
        public FormDebloat(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void btnAvviaSelezionatiDebloat_Click(object sender, EventArgs e)
        {
            if (Bloat1.CheckedItems.Contains("Calcolatrice"))
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
            else if (Bloat1.CheckedItems.Contains("Foto"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Windows.Photos | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Canonical"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers CanonicalGroupLimited.UbuntuonWindows | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Xbox TCUI"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Xbox.TCUI | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Xbox APP"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.XboxApp | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Xbox Overlay"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.XboxGameOverlay | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Xbox Overlay"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.XboxGameOverlay | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Xbox Speech"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.XboxSpeechToTextOverlay | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Xbox Identity"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.XboxIdentityProvider | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Sticky Notes"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.MicrosoftStickyNotes | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("MS Paint"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.MSPaint | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Windows Camera"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.WindowsCamera | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("HiFi Extension"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.HEIFImageExtension | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Cattura Schermo"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.ScreenSketch | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Estensione VP9"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.VP9VideoExtensions | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Estensione Web"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.WebMediaExtensions | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Estensione WebpImage"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.WebpImageExtension | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("WindSynthBerry"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers WindSynthBerry | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("MidiBerry"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers MIDIBerry | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Slack"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Slack | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Mixed Reality"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.MixedReality.Portal | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Mixed Reality"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.MixedReality.Portal | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("PPI Projection"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.PPIProjection | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Bing News"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.BingNews | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Get Help"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.GetHelp | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Per iniziare"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Getstarted | Remove-AppxPackage",
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
            }
            else if (Bloat1.CheckedItems.Contains("Messaggi"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Messaging | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Microsoft 3D Viewer"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Microsoft3DViewer | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Microsoft Office Hub"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.MicrosoftOfficeHub | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Solitario"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.MicrosoftSolitaireCollection | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Network Speed Test"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.NetworkSpeedTest | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Microsoft News"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.News | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Office Lens"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Office.Lens | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("One Note"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Office.OneNote | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Office Sway"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Office.Sway | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("One Connect"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.OneConnect | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Microsoft People"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.People | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Paint 3D"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Print3D | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Desktop Remoto"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.RemoteDesktop | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("App Skype"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.SkypeApp | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Office To Do"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Office.Todo.List | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Whiteboard"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Whiteboard | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Windows Alarm"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.WindowsAlarms | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Windows Comunicazione"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers microsoft.windowscommunicationsapps | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Feedback Hub"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.WindowsFeedbackHub | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Windows Maps"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.WindowsMaps | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Registratore Suoni"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.WindowsSoundRecorder | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Zune Music"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.ZuneMusic | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Zune Video"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.ZuneVideo | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Eclipse"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers EclipseManager | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Pack Lingua"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.LanguageExperiencePackit-IT | Remove-AppxPackage",
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
            }
            else if (Bloat2.CheckedItems.Contains("Adobe Express"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers AdobeSystemsIncorporated.AdobePhotoshopExpress | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Duolingo"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Duolingo-LearnLanguagesforFree | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("PandoraMedia"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers PandoraMediaInc | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Candy Crush"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers CandyCrush | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("BubbleWitch"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers BubbleWitch3Saga | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Wunderlist"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Wunderlist | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Flipboard"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Flipboard | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Twitter"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Twitter | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Facebook"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Facebook | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Dolby"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Dolby | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Advertising XAML"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Advertising.Xaml | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Portafoglio"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Wallet | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Collegamento A Telefono"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.YourPhone | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Edge"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.MicrosoftEdge.Stable | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Microsoft Store"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.WindowsStore | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Microsoft Store"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.Services.Store.Engagement | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Microsoft Store"))
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    try
                    {
                        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = "Get-AppxPackage -allusers Microsoft.StorePurchaseApp | Remove-AppxPackage",
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
            }
            else if (Bloat3.CheckedItems.Contains("Windows Defender"))
            {
                string powerRunPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "PowerRun.exe");
                RunCommand(powerRunPath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender"" /v ""DisableAntiSpyware"" /t REG_DWORD /d 1 /f""");
                RunCommand(powerRunPath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableBehaviorMonitoring"" /t REG_DWORD /d 1 /f""");
                RunCommand(powerRunPath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableIOAVProtection"" /t REG_DWORD /d 1 /f""");
                RunCommand(powerRunPath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableOnAccessProtection"" /t REG_DWORD /d 1 /f""");
                RunCommand(powerRunPath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableRealtimeMonitoring"" /t REG_DWORD /d 1 /f""");
                RunCommand(powerRunPath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SecurityHealthService"" /v ""Start"" /t REG_DWORD /d 4 /f""");
                RunCommand(powerRunPath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend"" /v ""Start"" /t REG_DWORD /d 4 /f""");

            }

            static void RunCommand(string powerRunPath, string command)
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = powerRunPath,
                    Arguments = command,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    // Optionally, read the output or errors
                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();

                    if (!string.IsNullOrEmpty(output))
                    {
                        Console.WriteLine($"Output: {output}");
                    }

                    if (!string.IsNullOrEmpty(error))
                    {
                        Console.WriteLine($"Error: {error}");
                    }
                }
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDebloatAuto_Click(object sender, EventArgs e)
        {
            string powerShellCommand = GetPowerShellCommand();
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-command \"{powerShellCommand}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (var process = Process.Start(processStartInfo))
            {
                if (process != null)
                {
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();

                    Console.WriteLine("PowerShell Output:");
                    Console.WriteLine(output);
                    if (!string.IsNullOrEmpty(errors))
                    {
                        Console.WriteLine("PowerShell Errors:");
                        Console.WriteLine(errors);
                    }
                }
            }
        }

        static string GetPowerShellCommand()
        {
            var version = Environment.OSVersion.Version.Major;
            if (version < 10)
            {
                Console.WriteLine("Unsupported version of Windows. This script is for Windows 10 or 11.");
                return null;
            }
            string commandForWindows10 = "$ErrorActionPreference = 'SilentlyContinue'; Get-AppxPackage -AllUsers | Where-Object {$_.name -notmatch 'Microsoft.VP9VideoExtensions|Microsoft.WebMediaExtensions|Microsoft.WebpImageExtension|Microsoft.Windows.ShellExperienceHost|Microsoft.VCLibs*|Microsoft.DesktopAppInstaller|Microsoft.StorePurchaseApp|Microsoft.Windows.Photos|Microsoft.WindowsStore|Microsoft.XboxIdentityProvider|Microsoft.WindowsCalculator|Microsoft.HEIFImageExtension|Microsoft.UI.Xaml*'} | Remove-AppxPackage";
            string commandForWindows11 = "$ErrorActionPreference = 'SilentlyContinue'; Get-AppxPackage -AllUsers | Where-Object {$_.name -notmatch 'Microsoft.VP9VideoExtensions|Notepad|Microsoft.WebMediaExtensions|Microsoft.WebpImageExtension|Microsoft.Windows.ShellExperienceHost|Microsoft.VCLibs*|Microsoft.DesktopAppInstaller|Microsoft.StorePurchaseApp|Microsoft.Windows.Photos|Microsoft.WindowsStore|Microsoft.XboxIdentityProvider|Microsoft.WindowsCalculator|Microsoft.HEIFImageExtension|Microsoft.UI.Xaml*'} | Remove-AppxPackage";
            return version == 10 ? commandForWindows10 : commandForWindows11;
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
