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

namespace WinHubX.Forms.Settaggi
{
    public partial class FormUpdate : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormUpdate(FormSettaggi formSettaggi, Form1 form1)
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
        private void btnAvviaSelezionatiUpda_Click(object sender, EventArgs e)
        {
            if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Download Automatico Windows Update"))
            {
                using (PowerShell PowerShellInstanceDisabilitaDownloadAutomaticoWindowsUpdate = PowerShell.Create())
                {
                    PowerShellInstanceDisabilitaDownloadAutomaticoWindowsUpdate.AddScript(@"Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""AUOptions"" -Type DWord -Value 2");
                    var result = PowerShellInstanceDisabilitaDownloadAutomaticoWindowsUpdate.Invoke();
                }
            }
            else if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Update Prodotti Microsoft"))
            {
                using (PowerShell PowerShellInstanceDisabilitaUpdateProdottiMicrosoft = PowerShell.Create())
                {
                    string scriptDisabilitaUpdateProdottiMicrosoft = @"
                     If ((New-Object -ComObject Microsoft.Update.ServiceManager).Services | Where-Object { $_.ServiceID -eq ""7971f918-a847-4430-9279-4a52d1efe18d""}) {
                     (New-Object -ComObject Microsoft.Update.ServiceManager).RemoveService(""7971f918-a847-4430-9279-4a52d1efe18d"")
                     }";
                    PowerShellInstanceDisabilitaUpdateProdottiMicrosoft.AddScript(scriptDisabilitaUpdateProdottiMicrosoft);
                    var result = PowerShellInstanceDisabilitaUpdateProdottiMicrosoft.Invoke();
                }
            }
            else if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Download Driver Windows Update"))
            {
                using (PowerShell PowerShellInstanceDisabilitaDownloadDriverWindowsUpdate = PowerShell.Create())
                {
                    string scriptDisabilitaDownloadDriverWindowsUpdate = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\Device Metadata"" -Name ""PreventDeviceMetadataFromNetwork"" -Type DWord -Value 1;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""SearchOrderConfig"" -Type DWord -Value 0;
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"" -Name ""ExcludeWUDriversInQualityUpdate"" -Type DWord -Value 1";
                    PowerShellInstanceDisabilitaDownloadDriverWindowsUpdate.AddScript(scriptDisabilitaDownloadDriverWindowsUpdate);
                    var result = PowerShellInstanceDisabilitaDownloadDriverWindowsUpdate.Invoke();
                }
            }
            else if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Riavvio Automatico Windows Update"))
            {
                using (PowerShell PowerShellInstanceDisabilitaRiavvioAutomaticoWindowsUpdate = PowerShell.Create())
                {
                    string scriptDisabilitaRiavvioAutomaticoWindowsUpdate = @"
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""NoAutoRebootWithLoggedOnUsers"" -Type DWord -Value 1
                     Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""AUPowerManagement"" -Type DWord -Value 0";
                    PowerShellInstanceDisabilitaRiavvioAutomaticoWindowsUpdate.AddScript(scriptDisabilitaRiavvioAutomaticoWindowsUpdate);
                    var result = PowerShellInstanceDisabilitaRiavvioAutomaticoWindowsUpdate.Invoke();
                }
            }
            else if (DisabilitaUpdate.CheckedItems.Contains("Disabilita Notifiche Update"))
            {
                using (PowerShell PowerShellInstanceDisabilitaNotificheUpdate = PowerShell.Create())
                {
                    string scriptDisabilitaNotificheUpdate = @"
                     takeown /F ""$env:WinDIR\System32\MusNotification.exe""
                     icacls ""$env:WinDIR\System32\MusNotification.exe"" /deny ""$($EveryOne):(X)""
                     takeown /F ""$env:WinDIR\System32\MusNotificationUx.exe""
                     icacls ""$env:WinDIR\System32\MusNotificationUx.exe"" /deny ""$($EveryOne):(X)""";
                    PowerShellInstanceDisabilitaNotificheUpdate.AddScript(scriptDisabilitaNotificheUpdate);
                    var result = PowerShellInstanceDisabilitaNotificheUpdate.Invoke();
                }
            }
            else if (AbilitaUpdate.CheckedItems.Contains("Abilita Download Automatico Windows Update"))
            {
                using (PowerShell PowerShellInstanceAbilitaDownloadAutomaticoWindowsUpdate = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaDownloadAutomaticoWindowsUpdate.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""AUOptions"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaDownloadAutomaticoWindowsUpdate.Invoke();
                }
            }
            else if (AbilitaUpdate.CheckedItems.Contains("Abilita Update Prodotti Microsoft"))
            {
                using (PowerShell PowerShellInstanceAbilitaUpdateProdottiMicrosoft = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaUpdateProdottiMicrosoft.AddScript(@"(New-Object -ComObject Microsoft.Update.ServiceManager).AddService2(""7971f918-a847-4430-9279-4a52d1efe18d"", 7, """")");
                    var result = PowerShellInstanceAbilitaUpdateProdottiMicrosoft.Invoke();
                }
            }
            else if (AbilitaUpdate.CheckedItems.Contains("Abilita Download Driver Windows Update"))
            {
                using (PowerShell PowerShellInstanceAbilitaDownloadDriverWindowsUpdate = PowerShell.Create())
                {
                    string scriptAbilitaDownloadDriverWindowsUpdate = @"
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\Device Metadata"" -Name ""PreventDeviceMetadataFromNetwork"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""SearchOrderConfig"" -ErrorAction SilentlyContinue;
                     Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"" -Name ""ExcludeWUDriversInQualityUpdate"" -ErrorAction SilentlyContinue";
                    PowerShellInstanceAbilitaDownloadDriverWindowsUpdate.AddScript(scriptAbilitaDownloadDriverWindowsUpdate);
                    var result = PowerShellInstanceAbilitaDownloadDriverWindowsUpdate.Invoke();
                }
            }
            else if (AbilitaUpdate.CheckedItems.Contains("Abilita Riavvio Automatico Windows Update"))
            {
                using (PowerShell PowerShellInstanceAbilitaRiavvioAutomaticoWindowsUpdate = PowerShell.Create())
                {
                    PowerShellInstanceAbilitaRiavvioAutomaticoWindowsUpdate.AddScript(@"Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\MusNotification.exe"" -Name ""Debugger"" -ErrorAction SilentlyContinue");
                    var result = PowerShellInstanceAbilitaRiavvioAutomaticoWindowsUpdate.Invoke();
                }
            }
            else if (AbilitaUpdate.CheckedItems.Contains("Abilita Download Driver Windows Update"))
            {
                using (PowerShell PowerShellInstanceAbilitaDownloadDriverWindowsUpdate = PowerShell.Create())
                {
                    string scriptAbilitaDownloadDriverWindowsUpdate = @"
                     takeown /F ""$env:WinDIR\System32\MusNotification.exe""
                     icacls ""$env:WinDIR\System32\MusNotification.exe"" /allow ""$($EveryOne):(X)""
                     takeown /F ""$env:WinDIR\System32\MusNotificationUx.exe""
                     icacls ""$env:WinDIR\System32\MusNotificationUx.exe"" /allow ""$($EveryOne):(X)""";
                    PowerShellInstanceAbilitaDownloadDriverWindowsUpdate.AddScript(scriptAbilitaDownloadDriverWindowsUpdate);
                    var result = PowerShellInstanceAbilitaDownloadDriverWindowsUpdate.Invoke();
                }
            }
        }

        private void btnUpdateEssential_Click(object sender, EventArgs e)
        {
            using (PowerShell PowerShellInstanceUpdateEssential = PowerShell.Create())
            {
                string scriptUpdateEssential = @"
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\Device Metadata"" -Name ""PreventDeviceMetadataFromNetwork"" -Type DWord -Value 1
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DontPromptForWindowsUpdate"" -Type DWord -Value 1
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DontSearchWindowsUpdate"" -Type DWord -Value 1
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DriverUpdateWizardWuSearchEnabled"" -Type DWord -Value 0
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"" -Name ""ExcludeWUDriversInQualityUpdate"" -Type DWord -Value 1
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""NoAutoRebootWithLoggedOnUsers"" -Type DWord -Value 1
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""AUPowerManagement"" -Type DWord -Value 0";
                PowerShellInstanceUpdateEssential.AddScript(scriptUpdateEssential);
                var result = PowerShellInstanceUpdateEssential.Invoke();
            }
        }

        private void btnResetUpdate_Click(object sender, EventArgs e)
        {
            using (PowerShell PowerShellInstanceResetUpdate = PowerShell.Create())
            {
                string scriptResetUpdate = @"
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""NoAutoUpdate"" -Type DWord -Value 0
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""AUOptions"" -Type DWord -Value 3
                 Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\DeliveryOptimization\Config"" -Name ""DODownloadMode"" -Type DWord -Value 1
                 $services = @(
                 ""BITS""
                 ""wuauserv""
                 )
                 foreach ($service in $services) {
                 Get-Service -Name $service -ErrorAction SilentlyContinue | Set-Service -StartupType Automatic
                 }
                 Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\Device Metadata"" -Name ""PreventDeviceMetadataFromNetwork"" -ErrorAction SilentlyContinue
                 Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DontPromptForWindowsUpdate"" -ErrorAction SilentlyContinue
                 Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DontSearchWindowsUpdate"" -ErrorAction SilentlyContinue
                 Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\DriverSearching"" -Name ""DriverUpdateWizardWuSearchEnabled"" -ErrorAction SilentlyContinue
                 Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"" -Name ""ExcludeWUDriversInQualityUpdate"" -ErrorAction SilentlyContinue
                 Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""NoAutoRebootWithLoggedOnUsers"" -ErrorAction SilentlyContinue
                 Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"" -Name ""AUPowerManagement"" -ErrorAction SilentlyContinue
                 Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WindowsUpdate\UX\Settings"" -Name ""BranchReadinessLevel"" -ErrorAction SilentlyContinue
                 Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WindowsUpdate\UX\Settings"" -Name ""DeferFeatureUpdatesPeriodInDays"" -ErrorAction SilentlyContinue
                 Remove-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\WindowsUpdate\UX\Settings"" -Name ""DeferQualityUpdatesPeriodInDays"" -ErrorAction SilentlyContinue";
                PowerShellInstanceResetUpdate.AddScript(scriptResetUpdate);
                var result = PowerShellInstanceResetUpdate.Invoke();
            }
        }
    }
}
