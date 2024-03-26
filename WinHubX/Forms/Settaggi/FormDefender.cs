using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinHubX.Forms.Base;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static System.Net.Mime.MediaTypeNames;

namespace WinHubX.Forms.Settaggi
{
    public partial class FormDefender : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormDefender(FormSettaggi formSettaggi, Form1 form1)
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

        private void btnAvviaSelezionatiDef_Click(object sender, EventArgs e)
        {
            if (DisabilitaDefender.CheckedItems.Contains("Disabilita Controllo Accesso Cartella"))
            {
                using (PowerShell PowerShellInstanceDisabilitaControlloAccessoCartella = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaControlloAccessoCartella.AddScript(@"Set-MpPreference -EnableControlledFolderAccess Disabled -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceDisabilitaControlloAccessoCartella.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Isolamento Core"))
            {
                using (PowerShell PowerShellInstanceDisabilitaIsolamentoCore = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaIsolamentoCore.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity"" -Name ""Enabled"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceDisabilitaIsolamentoCore.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Applicazione Defender Guard"))
            {
                using (PowerShell PowerShellInstanceDisabilitaApplicazioneDefenderGuard = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaApplicazioneDefenderGuard.AddScript(@"Disable-WindowsOptionalFeature -online -FeatureName ""Windows-Defender-ApplicationGuard"" -NoRestart -WarningAction SilentlyContinue");
                    var result = PowerShellInstanceDisabilitaApplicazioneDefenderGuard.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Protezione Account Warning"))
            {
                using (PowerShell PowerShellInstanceDisabilitaProtezioneAccountWarning = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaProtezioneAccountWarning.AddScript(@"Set-ItemProperty ""HKCU:\Software\Microsoft\Windows Security Health\State"" -Name ""AccountProtection_MicrosoftAccount_Disconnected"" -Type DWord -Value 1");
                    var result = PowerShellInstanceDisabilitaProtezioneAccountWarning.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Blocco Download Files"))
            {
                using (PowerShell PowerShellInstanceDisabilitaBloccoDownloadFiles = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaBloccoDownloadFiles.AddScript(@"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\Policies\Attachments"" -Name ""SaveZoneInformation"" -Type DWord -Value 1");
                    var result = PowerShellInstanceDisabilitaBloccoDownloadFiles.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Script Host"))
            {
                using (PowerShell PowerShellInstanceDisabilitaWindowsScriptHost = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaWindowsScriptHost.AddScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows Script Host\Settings"" -Name ""Enabled"" -Type DWord -Value 0");
                    var result = PowerShellInstanceDisabilitaWindowsScriptHost.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita .NET Strong Cryptography"))
            {
                using (PowerShell PowerShellInstanceDisabilitaNETStrongCryptography = PowerShell.Create())
                {
                    string scriptDisabilitaNETStrongCryptography = @"
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceDisabilitaNETStrongCryptography.AddScript(scriptDisabilitaNETStrongCryptography);
                    var result = PowerShellInstanceDisabilitaNETStrongCryptography.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Meltdown CVE-2017-5754"))
            {
                using (PowerShell PowerShellInstanceDisabilitaMeltdownCVE = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaMeltdownCVE.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\QualityCompat"" -Name ""cadca5fe-87d3-4b96-b7fb-a231484277cc"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceDisabilitaMeltdownCVE.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Livello Minimo UAC"))
            {
                using (PowerShell PowerShellInstanceLivelloMinimoUAC = PowerShell.Create())
                {
                    string scriptLivelloMinimoUAC = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""ConsentPromptBehaviorAdmin"" -Type DWord -Value 0
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""PromptOnSecureDesktop"" -Type DWord -Value 0";
                    PowerShellInstanceLivelloMinimoUAC.AddScript(scriptLivelloMinimoUAC);
                    var result = PowerShellInstanceLivelloMinimoUAC.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Implicit Administrative Sheres"))
            {
                using (PowerShell PowerShellInstanceDisabilitaImplicitAdministrativeSheres = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaImplicitAdministrativeSheres.AddScript(@"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters"" -Name ""AutoShareWks"" -Type DWord -Value 0");
                    var result = PowerShellInstanceDisabilitaImplicitAdministrativeSheres.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Firewall"))
            {
                using (PowerShell PowerShellInstanceDisabilitaWindowsFirewall = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaWindowsFirewall.AddScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\WindowsFirewall\StandardProfile"" -Name ""EnableFirewall"" -Type DWord -Value 0");
                    var result = PowerShellInstanceDisabilitaWindowsFirewall.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Defender"))
            {
                using (PowerShell PowerShellInstanceDisabilitaWindowsDefender = PowerShell.Create())
                {
                    string scriptLivelloDisabilitaWindowsDefender = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender"" -Name ""DisableAntiSpyware"" -Type DWord -Value 1;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"" -Name ""WindowsDefender"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"" -Name ""SecurityHealth"" -ErrorAction SilentlyContinue;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" -Name ""DisableRealtimeMonitoring"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" -Name ""DisableBehaviorMonitoring"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" -Name ""DisableOnAccessProtection"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" -Name ""DisableScanOnRealtimeEnable"" -Type DWord -Value 1";
                    PowerShellInstanceDisabilitaWindowsDefender.AddScript(scriptLivelloDisabilitaWindowsDefender);
                    var result = PowerShellInstanceDisabilitaWindowsDefender.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Defender CLoud"))
            {
                using (PowerShell PowerShellInstanceDisabilitaWindowsDefenderCLoud = PowerShell.Create())
                {
                    string scriptLivelloDisabilitaWindowsDefenderCLoud = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SpynetReporting"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SubmitSamplesConsent"" -Type DWord -Value 2";
                    PowerShellInstanceDisabilitaWindowsDefenderCLoud.AddScript(scriptLivelloDisabilitaWindowsDefenderCLoud);
                    var result = PowerShellInstanceDisabilitaWindowsDefenderCLoud.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Defender SysTray"))
            {
                using (PowerShell PowerShellInstanceDisabilitaWindowsDefenderSysTray = PowerShell.Create())
                {
                    string scriptLivelloDisabilitaWindowsDefenderSysTray = @"
                     If (!(Test-Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Systray"")) {
                     New-Item -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Systray"" -Force | Out-Null
                     }
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Systray"" -Name ""HideSystray"" -Type DWord -Value 1
                     If ([System.Environment]::OSVersion.Version.Build -eq 14393) {
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"" -Name ""WindowsDefender"" -ErrorAction SilentlyContinue
                     } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 15063) {
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"" -Name ""SecurityHealth"" -ErrorAction SilentlyContinue
                     }";
                    PowerShellInstanceDisabilitaWindowsDefenderSysTray.AddScript(scriptLivelloDisabilitaWindowsDefenderSysTray);
                    var result = PowerShellInstanceDisabilitaWindowsDefenderSysTray.Invoke();
                }
            }
            else if (DisabilitaDefender.CheckedItems.Contains("Disabilita Windows Defender Services"))
            {
                using (PowerShell PowerShellInstanceDisabilitaWindowsDefenderServices = PowerShell.Create())
                {
                    string scriptLivelloDisabilitaWindowsDefenderServices = @"
                     Takeown-Registry(""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend"");
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\WinDefend"" ""Start"" 4;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\WinDefend"" ""AutorunsDisabled"" 3;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\WdNisSvc"" ""Start"" 4;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\WdNisSvc"" ""AutorunsDisabled"" 3;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\Sense"" ""Start"" 4;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\Sense"" ""AutorunsDisabled"" 3";
                    PowerShellInstanceDisabilitaWindowsDefenderServices.AddScript(scriptLivelloDisabilitaWindowsDefenderServices);
                    var result = PowerShellInstanceDisabilitaWindowsDefenderServices.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Controllo Accesso Cartella"))
            {
                using (PowerShell PowerShellInstanceAbilitaControlloAccessoCartella = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaControlloAccessoCartella.AddScript(@"Set-MpPreference -EnableControlledFolderAccess Enabled -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaControlloAccessoCartella.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Isolamento Core"))
            {
                using (PowerShell PowerShellInstanceAbilitaIsolamentoCore = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaIsolamentoCore.AddScript(@"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity"" -Name ""Enabled"" -Type DWord -Value 1");
                    var result = PowerShellInstanceAbilitaIsolamentoCore.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Applicazione Defender Guard"))
            {
                using (PowerShell PowerShellInstanceAbilitaApplicazioneDefenderGuard = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaApplicazioneDefenderGuard.AddScript(@"Enable-WindowsOptionalFeature -online -FeatureName ""Windows-Defender-ApplicationGuard"" -NoRestart -WarningAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaApplicazioneDefenderGuard.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Protezione Account Warning"))
            {
                using (PowerShell PowerShellInstanceAbilitaProtezioneAccountWarning = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaProtezioneAccountWarning.AddScript(@"Remove-ItemProperty ""HKCU:\Software\Microsoft\Windows Security Health\State"" -Name ""AccountProtection_MicrosoftAccount_Disconnected"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaProtezioneAccountWarning.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Blocco Download Files"))
            {
                using (PowerShell PowerShellInstanceAbilitaBloccoDownloadFiles = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaBloccoDownloadFiles.AddScript(@"Remove-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\Policies\Attachments"" -Name ""SaveZoneInformation"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaBloccoDownloadFiles.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Script Host"))
            {
                using (PowerShell PowerShellInstanceAbilitaWindowsScriptHost = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaWindowsScriptHost.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows Script Host\Settings"" -Name ""Enabled"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaWindowsScriptHost.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita .NET Strong Cryptography"))
            {
                using (PowerShell PowerShellInstanceAbilitaNETStrongCryptography = PowerShell.Create())
                {
                    string scriptLivelloAbilitaNETStrongCryptography = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -Type DWord -Value 1";
                    PowerShellInstanceAbilitaNETStrongCryptography.AddScript(scriptLivelloAbilitaNETStrongCryptography);
                    var result = PowerShellInstanceAbilitaNETStrongCryptography.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Meltdown CVE-2017-5754"))
            {
                using (PowerShell PowerShellInstanceAbilitaMeltdownCVE = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaMeltdownCVE.AddScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\QualityCompat"" -Name ""cadca5fe-87d3-4b96-b7fb-a231484277cc"" -Type DWord -Value 0");
                    var result = PowerShellInstanceAbilitaMeltdownCVE.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Livello Massimo UAC"))
            {
                using (PowerShell PowerShellInstanceLivelloMassimoUAC = PowerShell.Create())
                {
                    string scriptLivelloMassimoUAC = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""ConsentPromptBehaviorAdmin"" -Type DWord -Value 5;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""PromptOnSecureDesktop"" -Type DWord -Value 1";
                    PowerShellInstanceLivelloMassimoUAC.AddScript(scriptLivelloMassimoUAC);
                    var result = PowerShellInstanceLivelloMassimoUAC.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Implicit Administrative Sheres"))
            {
                using (PowerShell PowerShellInstanceAbilitaImplicitAdministrativeSheres = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaImplicitAdministrativeSheres.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters"" -Name ""AutoShareWks"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaImplicitAdministrativeSheres.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Firewall"))
            {
                using (PowerShell PowerShellInstanceAbilitaWindowsFirewall = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaWindowsFirewall.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\WindowsFirewall\StandardProfile"" -Name ""EnableFirewall"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaWindowsFirewall.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender"))
            {
                using (PowerShell PowerShellInstanceAbilitaWindowsDefender = PowerShell.Create())
                {
                    string scriptAbilitaWindowsDefender = @"
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender"" -Name ""DisableAntiSpyware"" -ErrorAction SilentlyContinue
                     If ([System.Environment]::OSVersion.Version.Build -eq 14393) {
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"" -Name ""WindowsDefender"" -Type ExpandString -Value ""`""%ProgramFiles%\Windows Defender\MSASCuiL.exe`""""
                     } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 15063) {
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"" -Name ""SecurityHealth"" -Type ExpandString -Value ""`""%ProgramFiles%\Windows Defender\MSASCuiL.exe`""""
                     }";
                    PowerShellInstanceAbilitaWindowsDefender.AddScript(scriptAbilitaWindowsDefender);
                    var result = PowerShellInstanceAbilitaWindowsDefender.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender CLoud"))
            {
                using (PowerShell PowerShellInstanceAbilitaWindowsDefenderCLoud = PowerShell.Create())
                {
                    string scriptAbilitaWindowsDefenderCLoud = @"
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SpynetReporting"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SubmitSamplesConsent"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceAbilitaWindowsDefenderCLoud.AddScript(scriptAbilitaWindowsDefenderCLoud);
                    var result = PowerShellInstanceAbilitaWindowsDefenderCLoud.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender SysTray"))
            {
                using (PowerShell PowerShellInstanceAbilitaWindowsDefenderSysTray = PowerShell.Create())
                {
                    string scriptAbilitaWindowsDefenderSysTray = @"
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Systray"" -Name ""HideSystray"" -ErrorAction SilentlyContinue
                     If ([System.Environment]::OSVersion.Version.Build -eq 14393) {
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"" -Name ""WindowsDefender"" -Type ExpandString -Value ""`""%ProgramFiles%\Windows Defender\MSASCuiL.exe`""""
                     } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 15063 -And [System.Environment]::OSVersion.Version.Build -le 17134) {
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"" -Name ""SecurityHealth"" -Type ExpandString -Value ""%ProgramFiles%\Windows Defender\MSASCuiL.exe""
                     } ElseIf ([System.Environment]::OSVersion.Version.Build -ge 17763) {
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"" -Name ""SecurityHealth"" -Type ExpandString -Value ""%windir%\system32\SecurityHealthSystray.exe""
                     }";
                    PowerShellInstanceAbilitaWindowsDefenderSysTray.AddScript(scriptAbilitaWindowsDefenderSysTray);
                    var result = PowerShellInstanceAbilitaWindowsDefenderSysTray.Invoke();
                }
            }
            else if (AbilitaDefender.CheckedItems.Contains("Abilita Windows Defender Services"))
            {
                using (PowerShell PowerShellInstanceAbilitaWindowsDefenderServices = PowerShell.Create())
                {
                    string scriptAbilitaWindowsDefenderServices = @"
                     Takeown-Registry(""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend"");
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\WinDefend"" ""Start"" 3;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\WinDefend"" ""AutorunsDisabled"" 4;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\WdNisSvc"" ""Start"" 3;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\WdNisSvc"" ""AutorunsDisabled"" 4;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\Sense"" ""Start"" 3;
                     Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\Sense"" ""AutorunsDisabled"" 4";
                    PowerShellInstanceAbilitaWindowsDefenderServices.AddScript(scriptAbilitaWindowsDefenderServices);
                    var result = PowerShellInstanceAbilitaWindowsDefenderServices.Invoke();
                }
            }
        }

        private void btnProtezioneMinima_Click(object sender, EventArgs e)
        {
            using (PowerShell PowerShellInstanceDisabilitaControlloAccessoCartella = PowerShell.Create())
            {
                PowerShellInstanceDisabilitaControlloAccessoCartella.AddScript(@"Set-MpPreference -EnableControlledFolderAccess Disabled -ErrorAction SilentlyContinue");
                var result = PowerShellInstanceDisabilitaControlloAccessoCartella.Invoke();
            };
            using (PowerShell PowerShellInstanceDisabilitaIsolamentoCore = PowerShell.Create())
            {
                PowerShellInstanceDisabilitaIsolamentoCore.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity"" -Name ""Enabled"" -ErrorAction SilentlyContinue");
                var result = PowerShellInstanceDisabilitaIsolamentoCore.Invoke();
            };
            using (PowerShell PowerShellInstanceDisabilitaApplicazioneDefenderGuard = PowerShell.Create())
            {
                PowerShellInstanceDisabilitaApplicazioneDefenderGuard.AddScript(@"Disable-WindowsOptionalFeature -online -FeatureName ""Windows-Defender-ApplicationGuard"" -NoRestart -WarningAction SilentlyContinue");
                var result = PowerShellInstanceDisabilitaApplicazioneDefenderGuard.Invoke();
            };
            using (PowerShell PowerShellInstanceDisabilitaProtezioneAccountWarning = PowerShell.Create())
            {
                PowerShellInstanceDisabilitaProtezioneAccountWarning.AddScript(@"Set-ItemProperty ""HKCU:\Software\Microsoft\Windows Security Health\State"" -Name ""AccountProtection_MicrosoftAccount_Disconnected"" -Type DWord -Value 1");
                var result = PowerShellInstanceDisabilitaProtezioneAccountWarning.Invoke();
            };
            using (PowerShell PowerShellInstanceDisabilitaBloccoDownloadFiles = PowerShell.Create())
            {
                PowerShellInstanceDisabilitaBloccoDownloadFiles.AddScript(@"Set-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\Policies\Attachments"" -Name ""SaveZoneInformation"" -Type DWord -Value 1");
                var result = PowerShellInstanceDisabilitaBloccoDownloadFiles.Invoke();
            };
            using (PowerShell PowerShellInstanceDisabilitaWindowsScriptHost = PowerShell.Create())
            {
                PowerShellInstanceDisabilitaWindowsScriptHost.AddScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows Script Host\Settings"" -Name ""Enabled"" -Type DWord -Value 0");
                var result = PowerShellInstanceDisabilitaWindowsScriptHost.Invoke();
            };
            using (PowerShell PowerShellInstanceDisabilitaNETStrongCryptography = PowerShell.Create())
            {
                string scriptDisabilitaNETStrongCryptography = @"
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -ErrorAction SilentlyContinue
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -ErrorAction SilentlyContinue";
                PowerShellInstanceDisabilitaNETStrongCryptography.AddScript(scriptDisabilitaNETStrongCryptography);
                var result = PowerShellInstanceDisabilitaNETStrongCryptography.Invoke();
            };
            using (PowerShell PowerShellInstanceDisabilitaMeltdownCVE = PowerShell.Create())
            {
                PowerShellInstanceDisabilitaMeltdownCVE.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\QualityCompat"" -Name ""cadca5fe-87d3-4b96-b7fb-a231484277cc"" -ErrorAction SilentlyContinue");
                var result = PowerShellInstanceDisabilitaMeltdownCVE.Invoke();
            };
            using (PowerShell PowerShellInstanceLivelloMinimoUAC = PowerShell.Create())
            {
                string scriptLivelloMinimoUAC = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""ConsentPromptBehaviorAdmin"" -Type DWord -Value 0
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""PromptOnSecureDesktop"" -Type DWord -Value 0";
                PowerShellInstanceLivelloMinimoUAC.AddScript(scriptLivelloMinimoUAC);
                var result = PowerShellInstanceLivelloMinimoUAC.Invoke();
            };
            using (PowerShell PowerShellInstanceDisabilitaImplicitAdministrativeSheres = PowerShell.Create())
            {
                PowerShellInstanceDisabilitaImplicitAdministrativeSheres.AddScript(@"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters"" -Name ""AutoShareWks"" -Type DWord -Value 0");
                var result = PowerShellInstanceDisabilitaImplicitAdministrativeSheres.Invoke();
            };
            using (PowerShell PowerShellInstanceDisabilitaWindowsDefenderCLoud = PowerShell.Create())
            {
                string scriptLivelloDisabilitaWindowsDefenderCLoud = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SpynetReporting"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SubmitSamplesConsent"" -Type DWord -Value 2";
                PowerShellInstanceDisabilitaWindowsDefenderCLoud.AddScript(scriptLivelloDisabilitaWindowsDefenderCLoud);
                var result = PowerShellInstanceDisabilitaWindowsDefenderCLoud.Invoke();
            };
        }

        private void btnRipristinaDefender_Click(object sender, EventArgs e)
        {
                using (PowerShell PowerShellInstanceAbilitaControlloAccessoCartella = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaControlloAccessoCartella.AddScript(@"Set-MpPreference -EnableControlledFolderAccess Enabled -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaControlloAccessoCartella.Invoke();
                };
                using (PowerShell PowerShellInstanceAbilitaIsolamentoCore = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaIsolamentoCore.AddScript(@"Set-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity"" -Name ""Enabled"" -Type DWord -Value 1");
                    var result = PowerShellInstanceAbilitaIsolamentoCore.Invoke();
                };
                using (PowerShell PowerShellInstanceAbilitaApplicazioneDefenderGuard = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaApplicazioneDefenderGuard.AddScript(@"Enable-WindowsOptionalFeature -online -FeatureName ""Windows-Defender-ApplicationGuard"" -NoRestart -WarningAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaApplicazioneDefenderGuard.Invoke();
                };
                using (PowerShell PowerShellInstanceAbilitaProtezioneAccountWarning = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaProtezioneAccountWarning.AddScript(@"Remove-ItemProperty ""HKCU:\Software\Microsoft\Windows Security Health\State"" -Name ""AccountProtection_MicrosoftAccount_Disconnected"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaProtezioneAccountWarning.Invoke();
                };
                using (PowerShell PowerShellInstanceAbilitaBloccoDownloadFiles = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaBloccoDownloadFiles.AddScript(@"Remove-ItemProperty -Path ""HKCU:\Software\Microsoft\Windows\CurrentVersion\Policies\Attachments"" -Name ""SaveZoneInformation"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaBloccoDownloadFiles.Invoke();
                };
                using (PowerShell PowerShellInstanceAbilitaWindowsScriptHost = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaWindowsScriptHost.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows Script Host\Settings"" -Name ""Enabled"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaWindowsScriptHost.Invoke();
                };
                using (PowerShell PowerShellInstanceAbilitaNETStrongCryptography = PowerShell.Create())
                {
                    string scriptLivelloAbilitaNETStrongCryptography = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319"" -Name ""SchUseStrongCrypto"" -Type DWord -Value 1";
                    PowerShellInstanceAbilitaNETStrongCryptography.AddScript(scriptLivelloAbilitaNETStrongCryptography);
                    var result = PowerShellInstanceAbilitaNETStrongCryptography.Invoke();
                };
                using (PowerShell PowerShellInstanceAbilitaMeltdownCVE = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaMeltdownCVE.AddScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\QualityCompat"" -Name ""cadca5fe-87d3-4b96-b7fb-a231484277cc"" -Type DWord -Value 0");
                    var result = PowerShellInstanceAbilitaMeltdownCVE.Invoke();
                }
                using (PowerShell PowerShellInstanceLivelloMassimoUAC = PowerShell.Create())
                {
                    string scriptLivelloMassimoUAC = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""ConsentPromptBehaviorAdmin"" -Type DWord -Value 5;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" -Name ""PromptOnSecureDesktop"" -Type DWord -Value 1";
                    PowerShellInstanceLivelloMassimoUAC.AddScript(scriptLivelloMassimoUAC);
                    var result = PowerShellInstanceLivelloMassimoUAC.Invoke();
                };
                using (PowerShell PowerShellInstanceAbilitaImplicitAdministrativeSheres = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaImplicitAdministrativeSheres.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters"" -Name ""AutoShareWks"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaImplicitAdministrativeSheres.Invoke();
                }
                using (PowerShell PowerShellInstanceAbilitaWindowsDefenderCLoud = PowerShell.Create())
                {
                    string scriptAbilitaWindowsDefenderCLoud = @"
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SpynetReporting"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet"" -Name ""SubmitSamplesConsent"" -ErrorAction SilentlyContinue";
                     PowerShellInstanceAbilitaWindowsDefenderCLoud.AddScript(scriptAbilitaWindowsDefenderCLoud);
                     var result = PowerShellInstanceAbilitaWindowsDefenderCLoud.Invoke();
                };
        }
    }
}
