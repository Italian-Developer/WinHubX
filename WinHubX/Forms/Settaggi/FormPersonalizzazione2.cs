using Microsoft.Win32;
using System.Diagnostics;
using System.Text;
using WinHubX.Forms.Personalizzazione;

namespace WinHubX.Forms.Settaggi
{
    public partial class FormPersonalizzazione2 : Form
    {
        private Form1 form1;
        private FormPersonalizzazione formPersonalizzazione;

        public FormPersonalizzazione2(FormPersonalizzazione formPersonalizzazione, Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1 ?? throw new ArgumentNullException(nameof(form1));
            this.formPersonalizzazione = formPersonalizzazione ?? throw new ArgumentNullException(nameof(formPersonalizzazione));
            LoadCheckboxStates();
        }

        private void SetCheckboxState(string itemName, bool isChecked)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\WinHubX"))
            {
                key.SetValue(itemName, isChecked ? 1 : 0, RegistryValueKind.DWord);
            }
        }

        private bool GetCheckboxState(string itemName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinHubX"))
            {
                if (key != null)
                {
                    object value = key.GetValue(itemName);
                    if (value != null)
                    {
                        return (int)value == 1;
                    }
                }
            }
            return false;
        }

        private void LoadCheckboxStates()
        {
            disabilitasuggeriti.Checked = GetCheckboxState("disabilitasuggeriti");
            abilitasuggeriti.Checked = GetCheckboxState("abilitasuggeriti");
            velocizzaricerca.Checked = GetCheckboxState("velocizzaricerca");
            win11preset.Checked = GetCheckboxState("win11preset");
            win10preset.Checked = GetCheckboxState("win10preset");
            disabilcopilot.Checked = GetCheckboxState("disabilcopilot");
            abilcopilot.Checked = GetCheckboxState("abilcopilot");
            abilitacmd.Checked = GetCheckboxState("abilitacmd");
            disabilitacmd.Checked = GetCheckboxState("disabilitacmd");
            abilps.Checked = GetCheckboxState("abilps");
            disabilps.Checked = GetCheckboxState("disabilps");
            ripristinafx.Checked = GetCheckboxState("ripristinafx");
            performancefx.Checked = GetCheckboxState("ripristinafx");
        }




        private void avviawin11preset(object sender, EventArgs e)
        {
            string[] packages = new string[]
            {
            "CanonicalGroupLimited.UbuntuonWindows",
            "Microsoft.Xbox.TCUI",
            "Microsoft.XboxApp",
            "Microsoft.XboxGameOverlay",
            "Microsoft.XboxGamingOverlay",
            "Microsoft.XboxSpeechToTextOverlay",
            "Microsoft.MicrosoftStickyNotes",
            "Microsoft.HEIFImageExtension",
            "Microsoft.VP9VideoExtensions",
            "Microsoft.WebMediaExtensions",
            "Microsoft.WebpImageExtension",
            "WindSynthBerry",
            "MIDIBerry",
            "Slack",
            "Microsoft.MixedReality.Portal",
            "Microsoft.PPIProjection",
            "Microsoft.BingNews",
            "Microsoft.GetHelp",
            "Microsoft.Getstarted",
            "Microsoft.Messaging",
            "Microsoft.Microsoft3DViewer",
            "Microsoft.MicrosoftOfficeHub",
            "Microsoft.MicrosoftSolitaireCollection",
            "Microsoft.NetworkSpeedTest",
            "Microsoft.News",
            "Microsoft.Office.Lens",
            "Microsoft.Office.OneNote",
            "Microsoft.Office.Sway",
            "Microsoft.OneConnect",
            "Microsoft.People",
            "Microsoft.Print3D",
            "Microsoft.RemoteDesktop",
            "Microsoft.SkypeApp",
            "Microsoft.Office.Todo.List",
            "Microsoft.Whiteboard",
            "Microsoft.WindowsAlarms",
            "microsoft.windowscommunicationsapps",
            "Microsoft.WindowsFeedbackHub",
            "Microsoft.WindowsMaps",
            "Microsoft.WindowsSoundRecorder",
            "Microsoft.ZuneMusic",
            "Microsoft.ZuneVideo",
            "EclipseManager",
            "ActiproSoftwareLLC",
            "AdobeSystemsIncorporated.AdobePhotoshopExpress",
            "Duolingo-LearnLanguagesforFree",
            "PandoraMediaInc",
            "CandyCrush",
            "BubbleWitch3Saga",
            "Wunderlist",
            "Flipboard",
            "Twitter",
            "Facebook",
            "Spotify",
            "Minecraft",
            "Royal Revolt",
            "Sway",
            "Microsoft.Advertising.Xaml",
            "Microsoft.Wallet",
            "Microsoft.YourPhone",
            "MicrosoftCorporationII.QuickAssist",
            "MicrosoftWindows.Client.WebExperience",
            "Clipchamp.Clipchamp",
            "Microsoft.RawImageExtension",
            "Microsoft.Todos",
            "Microsoft.PowerAutomateDesktop",
            "Microsoft.549981C3F5F10",
            "Microsoft.BingWeather"
            };

            StringBuilder log = new StringBuilder();
            foreach (var package in packages)
            {
                log.AppendLine(RemoveAppxPackage(package));
            }
            RunPowerShellScript();
        }

        private string RemoveAppxPackage(string packageName)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-Command \"Get-AppxPackage -allusers {packageName} | Remove-AppxPackage -Force\"",
                Verb = "runas",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                StringBuilder result = new StringBuilder();
                result.AppendLine($"Risultato per {packageName}:");
                if (!string.IsNullOrEmpty(output))
                {
                    result.AppendLine($"Output: {output}");
                }
                if (!string.IsNullOrEmpty(error))
                {
                    result.AppendLine($"Errore: {error}");
                }
                result.AppendLine();
                return result.ToString();
            }
        }

        private void RunPowerShellScript()
        {
            string[] powerShellCommands = new string[]
            {
                "Set-ItemProperty -Path 'HKCU:\\Control Panel\\International\\User Profile' -Name 'HttpAcceptLanguageOptOut' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent' -Name 'DisableThirdPartySuggestions' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent' -Name 'DisableWindowsConsumerFeatures' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Device Metadata' -Name 'PreventDeviceMetadataFromNetwork' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\MRT' -Name 'DontOfferThroughWUAU' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\SQMClient\\Windows' -Name 'CEIPEnable' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat' -Name 'AITEnable' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat' -Name 'DisableUAR' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\WMI\\AutoLogger\\AutoLogger-Diagtrack-Listener' -Name 'Start' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\WMI\\AutoLogger\\SQMLogger' -Name 'Start' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SilentInstalledAppsEnabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SystemPaneSuggestionsEnabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SoftLandingEnabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-310093Enabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-314559Enabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-338393Enabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-353694Enabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-353698Enabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'ContentDeliveryAllowed' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'OemPreInstalledAppsEnabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'PreInstalledAppsEnabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'PreInstalledAppsEverEnabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SilentInstalledAppsEnabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-338387Enabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-338388Enabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-338389Enabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-353698Enabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SystemPaneSuggestionsEnabled' -Type DWord -Value 0",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent' -Force | Out-Null }",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent' -Name 'DisableWindowsConsumerFeatures' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection' -Name 'AllowTelemetry' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection' -Name 'AllowTelemetry' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection' -Name 'AllowTelemetry' -Type DWord -Value 0",
                "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Application Experience\\Microsoft Compatibility Appraiser' | Out-Null",
                "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Application Experience\\ProgramDataUpdater' | Out-Null",
                "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Autochk\\Proxy' | Out-Null",
                "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Customer Experience Improvement Program\\Consolidator' | Out-Null",
                "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Customer Experience Improvement Program\\UsbCeip' | Out-Null",
                "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\DiskDiagnostic\\Microsoft-Windows-DiskDiagnosticDataCollector' | Out-Null",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'EnableActivityFeed' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'PublishUserActivities' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'UploadUserActivities' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Search' -Name 'BingSearchEnabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Search' -Name 'CortanaConsent' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Name 'DisableWebSearch' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Name 'ConnectedSearchUseWeb' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Name 'ConnectedSearchUseWebOverMeteredConnections' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Personalization' -Name 'NoLockScreen' -Type DWord -Value 1",
                "Remove-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync' -Force -Recurse",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Input\\Tip\\TouchPrediction' -Name 'Enabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\TimeZoneInformation' -Name 'RealTimeIsUniversal' -Type DWord -Value 1",
                "powercfg -duplicatescheme a1841308-3541-4fab-bc81-f71556f20b4a",
                "powercfg -duplicatescheme 381b4222-f694-41f0-9685-ff5bb260df2e",
                "powercfg -duplicatescheme 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c",
                "powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61",
                "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters' -Name 'IRPStackSize' -Type DWord -Value 20",
                "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control' -Name 'SvcHostSplitThresholdInKB' -Type DWord -Value 4194304",
                "fsutil behavior set DisableLastAccess 1",
                "fsutil behavior set EncryptPagingFile 0",
                "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server' -Name 'fDenyTSConnections' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server\\WinStations\\RDP-Tcp' -Name 'UserAuthentication' -Type DWord -Value 1",
                "Disable-NetFirewallRule -Name 'RemoteDesktop*'",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Feeds' -Name 'EnableFeeds' -Type DWord -Value 0",
                "If (!(Test-Path 'HKU:')) { New-PSDrive -Name 'HKU' -PSProvider 'Registry' -Root 'HKEY_USERS' | Out-Null }",
                "Set-ItemProperty -Path 'HKU:\\.DEFAULT\\Control Panel\\Keyboard' -Name 'InitialKeyboardIndicators' -Type DWord -Value 2147483650",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'UploadUserActivities' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Search' -Name 'BingSearchEnabled' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Search' -Name 'CortanaConsent' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Name 'DisableWebSearch' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Name 'ConnectedSearchUseWeb' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Name 'ConnectedSearchUseWebOverMeteredConnections' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Personalization' -Name 'NoLockScreen' -Type DWord -Value 1",
                "Remove-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync' -Force -Recurse",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Input\\Tip\\TouchPrediction' -Name 'Enabled' -Type DWord -Value 0",
                "Remove-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity' -Name 'Enabled' -ErrorAction SilentlyContinue",
                "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows Security Health\\State')) { New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows Security Health\\State' -Force | Out-Null }",
                "Set-ItemProperty 'HKCU:\\Software\\Microsoft\\Windows Security Health\\State' -Name 'AccountProtection_MicrosoftAccount_Disconnected' -Type DWord -Value 1",
                "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments')) { New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments' | Out-Null }",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments' -Name 'SaveZoneInformation' -Type DWord -Value 1",
                "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\.NETFramework\\v4.0.30319' -Name 'SchUseStrongCrypto' -ErrorAction SilentlyContinue",
                "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\.NETFramework\\v4.0.30319' -Name 'SchUseStrongCrypto' -ErrorAction SilentlyContinue",
                "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System' -Name 'EnableLinkedConnections' -ErrorAction SilentlyContinue",
                "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters' -Name 'AutoShareWks' -Type DWord -Value 0",
                "Set-NetConnectionProfile -NetworkCategory Private",
                "bcdedit /set `{current`} bootmenupolicy Legacy | Out-Null",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Force | Out-Null",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Name 'AUPowerManagement' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\Maintenance' -Name 'WakeUp' -Type DWord -Value 0",
                "If ([System.Environment]::OSVersion.Version.Build -eq 10240) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Config' | Out-Null",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Config' -Name 'DODownloadMode' -Type DWord -Value 1",
                "} ElseIf ([System.Environment]::OSVersion.Version.Build -le 14393) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization' | Out-Null",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization' -Name 'DODownloadMode' -Type DWord -Value 1",
                "} Else {",
                "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization' -Name 'DODownloadMode' -ErrorAction SilentlyContinue",
                "}",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\MusNotification.exe')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\MusNotification.exe' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\MusNotification.exe' -Name 'Debugger' -Type String -Value 'cmd.exe'",
                "takeown /F \"$env:WinDIR\\System32\\MusNotification.exe\"",
                "icacls \"$env:WinDIR\\System32\\MusNotification.exe\" /deny \"($EveryOne):(X)\"",
                "takeown /F \"$env:WinDIR\\System32\\MusNotificationUx.exe\"",
                "icacls \"$env:WinDIR\\System32\\MusNotificationUx.exe\" /deny \"($EveryOne):(X)\"",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Device Metadata' -Force | Out-Null",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Device Metadata' -Name 'PreventDeviceMetadataFromNetwork' -Type DWord -Value 1",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Name 'DontPromptForWindowsUpdate' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Name 'DontSearchWindowsUpdate' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Name 'DriverUpdateWizardWuSearchEnabled' -Type DWord -Value 0",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate' -Name 'ExcludeWUDriversInQualityUpdate' -Type DWord -Value 1",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Name 'NoAutoRebootWithLoggedOnUsers' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Name 'AUPowerManagement' -Type DWord -Value 0",
                "Disable-WindowsOptionalFeature -Online -FeatureName 'WorkFolders-Client' -NoRestart -WarningAction SilentlyContinue | Out-Null",
                "If ((Get-WmiObject -Class 'Win32_OperatingSystem').Caption -like '*Server*') {",
                "Uninstall-WindowsFeature -Name 'Hyper-V' -IncludeManagementTools -WarningAction SilentlyContinue | Out-Null",
                "} Else {",
                "Disable-WindowsOptionalFeature -Online -FeatureName 'Microsoft-Hyper-V-All' -NoRestart -WarningAction SilentlyContinue | Out-Null",
                "}",
                "Disable-WindowsOptionalFeature -Online -FeatureName 'Printing-PrintToPDFServices-Features' -NoRestart -WarningAction SilentlyContinue | Out-Null",
                "Remove-Printer -Name 'Fax' -ErrorAction SilentlyContinue",
                "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock' -Name 'AllowDevelopmentWithoutDevLicense' -ErrorAction SilentlyContinue",
                "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock' -Name 'AllowAllTrustedApps' -ErrorAction SilentlyContinue",
                "Get-WindowsCapability -Online | Where-Object { $_.Name -like 'MathRecognizer*' } | Remove-WindowsCapability -Online | Out-Null",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync' -Name 'BackupPolicy' -Type DWord -Value 0x3c",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync' -Name 'DeviceMetadataUploaded' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync' -Name 'PriorLogons' -Type DWord -Value 1",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\Common\\ClientTelemetry' -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\ClientTelemetry' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\Common\\ClientTelemetry' -Name 'DisableTelemetry' -Type DWORD -Value 1 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\ClientTelemetry' -Name 'DisableTelemetry' -Type DWORD -Value 1 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\Common\\ClientTelemetry' -Name 'VerboseLogging' -Type DWORD -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\ClientTelemetry' -Name 'VerboseLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Mail' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Mail' -Name 'EnableLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Mail' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Mail' -Name 'EnableLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Calendar' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Calendar' -Name 'EnableCalendarLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Calendar' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Calendar' -Name 'EnableCalendarLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Word\\Options' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Word\\Options' -Name 'EnableLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Word\\Options' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Word\\Options' -Name 'EnableLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\15.0\\OSM' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\15.0\\OSM' -Name 'EnableLogging' -Type DWORD -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\15.0\\OSM' -Name 'EnableUpload' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\16.0\\OSM' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\16.0\\OSM' -Name 'EnableLogging' -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\16.0\\OSM' -Name 'EnableUpload' -Type DWORD -Value 0 -Force",
                "schtasks /change /TN 'Microsoft\\Office\\OfficeTelemetryAgentFallBack' /DISABLE",
                "schtasks /change /TN 'Microsoft\\Office\\OfficeTelemetryAgentFallBack2016' /DISABLE",
                "schtasks /change /TN 'Microsoft\\Office\\OfficeTelemetryAgentLogOn' /DISABLE",
                "schtasks /change /TN 'Microsoft\\Office\\OfficeTelemetryAgentLogOn2016' /DISABLE",
                "schtasks /change /TN 'Microsoft\\Office\\Office 15 Subscription Heartbeat' /DISABLE",
                "schtasks /change /TN 'Microsoft\\Office\\Office 16 Subscription Heartbeat' /DISABLE",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Common\\Feedback' -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\Feedback' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Common\\Feedback' -Name 'Enabled' -Type DWORD -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\Feedback' -Name 'Enabled' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Common' -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Common' -Name 'QMEnable' -Type DWORD -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common' -Name 'QMEnable' -Type DWORD -Value 0 -Force",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Device Metadata' -Name 'PreventDeviceMetadataFromNetwork' -Type DWord -Value 1",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Name 'DontPromptForWindowsUpdate' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Name 'DontSearchWindowsUpdate' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Name 'DriverUpdateWizardWuSearchEnabled' -Type DWord -Value 0",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate' -Name 'ExcludeWUDriversInQualityUpdate' -Type DWord -Value 1",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Name 'NoAutoRebootWithLoggedOnUsers' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Name 'AUPowerManagement' -Type DWord -Value 0",
                "Disable-WindowsOptionalFeature -Online -FeatureName 'WorkFolders-Client' -NoRestart -WarningAction SilentlyContinue | Out-Null",
                "If ((Get-WmiObject -Class 'Win32_OperatingSystem').Caption -like '*Server*') {",
                "Uninstall-WindowsFeature -Name 'Hyper-V' -IncludeManagementTools -WarningAction SilentlyContinue | Out-Null",
                "} Else {",
                "Disable-WindowsOptionalFeature -Online -FeatureName 'Microsoft-Hyper-V-All' -NoRestart -WarningAction SilentlyContinue | Out-Null",
                "}",
                "Disable-WindowsOptionalFeature -Online -FeatureName 'Printing-PrintToPDFServices-Features' -NoRestart -WarningAction SilentlyContinue | Out-Null",
                "Remove-Printer -Name 'Fax' -ErrorAction SilentlyContinue",
                "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock' -Name 'AllowDevelopmentWithoutDevLicense' -ErrorAction SilentlyContinue",
                "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock' -Name 'AllowAllTrustedApps' -ErrorAction SilentlyContinue",
                "Get-WindowsCapability -Online | Where-Object { $_.Name -like 'MathRecognizer*' } | Remove-WindowsCapability -Online | Out-Null",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync' -Name 'BackupPolicy' -Type DWord -Value 0x3c",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync' -Name 'DeviceMetadataUploaded' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync' -Name 'PriorLogons' -Type DWord -Value 1",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\Common\\ClientTelemetry' -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\ClientTelemetry' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\Common\\ClientTelemetry' -Name 'DisableTelemetry' -Type DWORD -Value 1 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\ClientTelemetry' -Name 'DisableTelemetry' -Type DWORD -Value 1 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\Common\\ClientTelemetry' -Name 'VerboseLogging' -Type DWORD -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\ClientTelemetry' -Name 'VerboseLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Mail' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Mail' -Name 'EnableLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Mail' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Mail' -Name 'EnableLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Calendar' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Calendar' -Name 'EnableCalendarLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Calendar' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Calendar' -Name 'EnableCalendarLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Word\\Options' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Word\\Options' -Name 'EnableLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Word\\Options' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Word\\Options' -Name 'EnableLogging' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\15.0\\OSM' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\15.0\\OSM' -Name 'EnableLogging' -Type DWORD -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\15.0\\OSM' -Name 'EnableUpload' -Type DWORD -Value 0 -Force",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\16.0\\OSM' -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\16.0\\OSM' -Name 'EnableLogging' -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\16.0\\OSM' -Name 'EnableUpload' -Type DWORD",
                "Get-ScheduledTask -TaskName 'GoogleUpdateTaskMachineCore' | Disable-ScheduledTask",
                "Get-ScheduledTask -TaskName 'GoogleUpdateTaskMachineUA' | Disable-ScheduledTask",
                "New-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Google\\Chrome' -Name 'ChromeCleanupEnabled' -Type 'String' -Value '0' -Force",
                "New-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Google\\Chrome' -Name 'ChromeCleanupReportingEnabled' -Type 'String' -Value '0' -Force",
                "New-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Google\\Chrome' -Name 'MetricsReportingEnabled' -Type 'String' -Value '0' -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' -Name 'DisallowRun' -Type 'DWORD' -Value 1 -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowRun' -Name '1' -Type 'String' -Value 'software_reporter_tool.exe' -Force",
                "Set-ItemProperty -Path 'HKLM:\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\software_reporter_tool.exe' -Name 'Debugger' -Type 'String' -Value '%windir%\\System32\\taskkill.exe' -Force",
                "Set-ItemProperty -Path 'HKLM:\\Software\\Policies\\Google\\Chrome' -Name 'ChromeCleanupEnabled' -Type 'String' -Value '0' -Force",
                "Set-ItemProperty -Path 'HKLM:\\Software\\Policies\\Google\\Chrome' -Name 'ChromeCleanupReportingEnabled' -Type 'String' -Value '0' -Force",
                "Set-ItemProperty -Path 'HKLM:\\Software\\Policies\\Google\\Chrome' -Name 'MetricsReportingEnabled' -Type 'String' -Value '0' -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'HideFileExt' -Type 'DWord' -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'HideMergeConflicts' -Type 'DWord' -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'PersistBrowsers' -Type 'DWord' -Value 1 -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'ShowSyncProviderNotifications' -Type 'DWord' -Value 1 -Force",
                "Remove-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\ClassicStartMenu' -Name '{645FF040-5081-101B-9F08-00AA002F954E}' -ErrorAction SilentlyContinue",
                "Remove-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel' -Name '{645FF040-5081-101B-9F08-00AA002F954E}' -ErrorAction SilentlyContinue",
                "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\ClassicStartMenu')) {",
                "New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\ClassicStartMenu' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\ClassicStartMenu' -Name '{20D04FE0-3AEA-1069-A2D8-08002B30309D}' -Type 'DWord' -Value 0 -Force",
                "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel')) {",
                "New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel' -Name '{20D04FE0-3AEA-1069-A2D8-08002B30309D}' -Type 'DWord' -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'SharingWizardOn' -Type 'DWord' -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'AutoCheckSelect' -Type 'DWord' -Value 0 -Force",
                "If (!(Test-Path 'HKCR:')) {",
                "New-PSDrive -Name 'HKCR' -PSProvider 'Registry' -Root 'HKEY_CLASSES_ROOT' | Out-Null",
                "}",
                "Remove-Item -Path 'HKCR:\\Folder\\ShellEx\\ContextMenuHandlers\\Library Location' -ErrorAction SilentlyContinue",
                "Remove-ItemProperty -Path 'HKCU:\\Software\\Classes\\CLSID\\{031E4825-7B94-4dc3-B131-E946B44C8DD5}' -Name 'System.IsPinnedToNameSpaceTree' -ErrorAction SilentlyContinue",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer' -Name 'HideRecentlyAddedApps' -Type 'DWord' -Value 1 -Force",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' -Name 'NoStartMenuMFUprogramsList' -Type 'DWord' -Value 1 -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Feeds' -Name 'ShellFeedsTaskbarViewMode' -Type 'DWord' -Value 2 -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' -Name 'HideSCAMeetNow' -Type 'DWord' -Value 1 -ErrorAction SilentlyContinue",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' -Name 'HideSCAMeetNow' -Type 'DWord' -Value 1 -Force",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'ShowCortanaButton' -Type 'DWord' -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search' -Name 'BingSearchEnabled' -Type 'DWord' -Value 0 -Force",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search' -Name 'CortanaConsent' -Type 'DWord' -Value 0",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Name 'DisableWebSearch' -Type DWord -Value 1",
                "Stop-Service 'WSearch' -WarningAction SilentlyContinue",
                "Set-Service 'WSearch' -StartupType Disabled",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search' -Name 'SearchboxTaskbarMode' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'ShowTaskViewButton' -Type DWord -Value 0",
                "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\People')) {",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\People' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\People' -Name 'PeopleBand' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'UseOLEDTaskbarTransparency' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\Dwm' -Name 'ForceEffectMode' -Type DWord -Value 1",
                "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\OperationStatusManager')) {",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\OperationStatusManager' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\OperationStatusManager' -Name 'EnthusiastMode' -Type DWord -Value 1",
                "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel')) {",
                "New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel' -Name 'StartupPage' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel' -Name 'AllItemsIconView' -Type DWord -Value 0",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer' -Name 'NoUseStoreOpenWith' -Type DWord -Value 1",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' -Name 'NoRecentDocsHistory' -Type DWord -Value 1",
                "Remove-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}' -Recurse -ErrorAction SilentlyContinue",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag' -Name 'ThisPCPolicy' -Type String -Value 'Hide'",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag' -Name 'ThisPCPolicy' -Type String -Value 'Hide'",
                "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\Personalization\\Settings')) {",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Personalization\\Settings' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Personalization\\Settings' -Name 'AcceptedPrivacyPolicy' -Type DWord -Value 0",
                "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization')) {",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization' -Name 'RestrictImplicitTextCollection' -Type DWord -Value 1",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization' -Name 'RestrictImplicitInkCollection' -Type DWord -Value 1",
                "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization\\TrainedDataStore')) {",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization\\TrainedDataStore' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization\\TrainedDataStore' -Name 'HarvestContacts' -Type DWord -Value 0",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Name 'AllowCortana' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name 'AppsUseLightTheme' -Type DWord -Value 0",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Feeds' -Name 'ShellFeedsTaskbarViewMode' -Value 2",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Chat')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Chat' -Force | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Chat'",
                "If (!(Test-Path 'HKCU:\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32')) {",
                "New-Item -Path 'HKCU:\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32' -Name '(Default)' -Type Dword -Value ''",
                "Stop-Process -Name explorer -Force",
                "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement')) {",
                "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement' -Name 'ScoobeSystemSettingEnabled' -Value 0 -Type DWord",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-310093Enabled' -Value 0 -Type DWord",
                "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-338389Enabled' -Value 0 -Type DWord",
                "Write-Host 'Disabled Welcome Experience'",
                "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications')) {",
                "New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications' | Out-Null",
                "}",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FlyoutMenuSettings' -Name 'GlobalUserDisabled' -Type Dword -Value 1",
                "$ErrorActionPreference = 'SilentlyContinue'",
                "$Bandwidth = 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Psched'",
                "New-Item -Path $Bandwidth -ItemType Directory -Force",
                "Set-ItemProperty -Path $Bandwidth -Name 'NonBestEffortLimit' -Type DWord -Value 0",
                "$CloudStore = 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\CloudStore'",
                "If (Test-Path $CloudStore) {",
                "Stop-Process Explorer.exe -Force",
                "Remove-Item $CloudStore -Recurse -Force",
                "Start-Process Explorer.exe -Wait",
                "}",
                "Add-Type -AssemblyName System.Windows.Forms",
                "If (!([System.Windows.Forms.Control]::IsKeyLocked('NumLock'))) {",
                "$wsh = New-Object -ComObject WScript.Shell",
                "$wsh.SendKeys('{NUMLOCK}')",
                "}",
                "$groups = @(",
                "'Accessibility'",
                "'AppSync'",
                "'BrowserSettings'",
                "'Credentials'",
                "'DesktopTheme'",
                "'Language'",
                "'PackageState'",
                "'Personalization'",
                "'StartLayout'",
                "'Windows'",
                ")",
                "foreach ($group in $groups) {",
                "New-FolderForced -Path \"HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\$group\"",
                "Set-ItemProperty -Path \"HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\$group\" -Name 'Enabled' -Value 0",
                "}",
                "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer')) {",
                "New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' | Out-Null",
                "}",
                "$Paint3Dstuff = @(",
                "'HKCR:\\SystemFileAssociations\\.3mf\\Shell\\3D Edit'",
                "'HKCR:\\SystemFileAssociations\\.bmp\\Shell\\3D Edit'",
                "'HKCR:\\SystemFileAssociations\\.fbx\\Shell\\3D Edit'",
                "'HKCR:\\SystemFileAssociations\\.gif\\Shell\\3D Edit'",
                "'HKCR:\\SystemFileAssociations\\.jfif\\Shell\\3D Edit'",
                "'HKCR:\\SystemFileAssociations\\.jpe\\Shell\\3D Edit'",
                "'HKCR:\\SystemFileAssociations\\.jpeg\\Shell\\3D Edit'",
                "'HKCR:\\SystemFileAssociations\\.jpg\\Shell\\3D Edit'",
                "'HKCR:\\SystemFileAssociations\\.png\\Shell\\3D Edit'",
                "'HKCR:\\SystemFileAssociations\\.tif\\Shell\\3D Edit'",
                "'HKCR:\\SystemFileAssociations\\.tiff\\Shell\\3D Edit'",
                ")",
                "foreach ($Paint3D in $Paint3Dstuff) {",
                "If (Test-Path $Paint3D) {",
                "$rmPaint3D = $Paint3D + '_'",
                "Set-Item $Paint3D $rmPaint3D",
               "}",
               "}",
            };

            foreach (string command in powerShellCommands)
            {
                RunPowerShellCommand(command);
            }
        }

        private void RunPowerShellCommand(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = command,
                Verb = "runas", // Esegui con privilegi di amministratore
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Personalizzazione";
            form1.PnlFormLoader.Controls.Clear();
            form1.PnlFormLoader.Controls.Add(formPersonalizzazione);
            formPersonalizzazione.Show();
            this.Close();
        }

        private void btnAvviaSelezionatiPersonal_Click(object sender, EventArgs e)
        {
            bool changesApplied = false;

            if (form1 == null)
            {
                MessageBox.Show("Form1 non inizializzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (abilitasuggeriti.Checked)
            {
                SetRegistryValue(@"SOFTWARE\Policies\Microsoft\Windows\Explorer", "DisableSearchBoxSuggestions", "1", RegistryValueKind.String);
                SetCheckboxState("abilitasuggeriti", true);
                SetCheckboxState("disabilitasuggeriti", false);
                changesApplied = true;
            }

            if (disabilitasuggeriti.Checked)
            {
                DeleteRegistryKey(@"SOFTWARE\Policies\Microsoft\Windows\Explorer", "DisableSearchBoxSuggestions");
                SetCheckboxState("disabilitasuggeriti", true);
                SetCheckboxState("abilitasuggeriti", false);
                changesApplied = true;
            }

            if (velocizzaricerca.Checked)
            {
                SetRegistryValue(@"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\Shell\Bags\AllFolders\Shell", "FolderType", "NotSpecified", RegistryValueKind.String);
                SetCheckboxState("velocizzaricerca", true);
                changesApplied = true;
            }

            if (win11preset.Checked)
            {
                DialogResult result = MessageBox.Show("Non è stato previsto il reset delle impostazioni continuare?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    DialogResult resultt = MessageBox.Show("L'operazione può richiedere diverso tempo, si consiglia di avviarla qaundo non devi usare il pc nel breve periodo", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (resultt == DialogResult.OK)
                    {
                        avviawin11preset(this, e);
                        SetCheckboxState("win11preset", true);
                        SetCheckboxState("win10preset", false);
                        changesApplied = true;
                    }
                }
                MessageBox.Show("Operazione Annullata");
                {
                    MessageBox.Show("Operazione Annullata");
                }
            }
            if (win10preset.Checked)
            {
                DialogResult result = MessageBox.Show("Non è stato previsto il reset delle impostazioni continuare?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    DialogResult resulttt = MessageBox.Show("L'operazione può richiedere diverso tempo, si consiglia di avviarla qaundo non devi usare il pc nel breve periodo", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (resulttt == DialogResult.OK)
                    {
                        avviawin10preset(this, e);
                        SetCheckboxState("win10preset", true);
                        SetCheckboxState("win11preset", false);
                        changesApplied = true;
                    }
                }
                    MessageBox.Show("Operazione Annullata");
                {
                    MessageBox.Show("Operazione Annullata");
                }
            }
            if (disabilcopilot.Checked)
            {
                SetRegistryValue(@"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\WindowsCopilot", "TurnOffWindowsCopilot", 0, RegistryValueKind.DWord);
                SetCheckboxState("disabilcopilot", true);
                SetCheckboxState("abilcopilot", false);
                changesApplied = true;
            }
            if (abilcopilot.Checked)
            {
                SetRegistryValue(@"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\WindowsCopilot", "TurnOffWindowsCopilot", 1, RegistryValueKind.DWord);
                SetCheckboxState("abilcopilot", true);
                SetCheckboxState("disabilcopilot", false);
                changesApplied = true;
            }
            if (abilitacmd.Checked)
            {
                try
                {
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt", "Icon", "imageres.dll,-5323");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt", "MUIVerb", "Command Prompt");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt", "Extended", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt", "SubCommands", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt\shell\cmd1", "", "@shell32.dll,-8506");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt\shell\cmd1", "MUIVerb", "Open here");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt\shell\cmd1", "Icon", "imageres.dll,-5323");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt\shell\cmd1", "NoWorkingDirectory", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt\shell\cmd1\command", "", "cmd.exe /s /k pushd \"%V\"");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt\shell\cmd2", "", "Open here as administrator");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt\shell\cmd2", "HasLUAShield", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt\shell\cmd2", "Icon", "imageres.dll,-5324");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\DesktopBackground\shell\CommandPrompt\shell\cmd2\command", "", "cmd /c echo|set/p=\"%V\"|powershell -NoP -W 1 -NonI -NoL \"SaPs 'cmd' -Args '/c \"\"\"cd /d',$([char]34+$Input+[char]34),'^&^& start /b cmd.exe\"\"\"' -Verb RunAs\"");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt", "Icon", "imageres.dll,-5323");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt", "MUIVerb", "Command Prompt");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt", "Extended", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt", "SubCommands", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt\shell\cmd1", "", "@shell32.dll,-8506");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt\shell\cmd1", "MUIVerb", "Open here");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt\shell\cmd1", "Icon", "imageres.dll,-5323");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt\shell\cmd1", "NoWorkingDirectory", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt\shell\cmd1\command", "", "cmd.exe /s /k pushd \"%V\"");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt\shell\cmd2", "", "Open here as administrator");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt\shell\cmd2", "HasLUAShield", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt\shell\cmd2", "Icon", "imageres.dll,-5324");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\CommandPrompt\shell\cmd2\command", "", "cmd /c echo|set/p=\"%L\"|powershell -NoP -W 1 -NonI -NoL \"SaPs 'cmd' -Args '/c \"\"\"cd /d',$([char]34+$Input+[char]34),'^&^& start /b cmd.exe\"\"\"' -Verb RunAs\"");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt", "Icon", "imageres.dll,-5323");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt", "MUIVerb", "Command Prompt");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt", "Extended", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt", "SubCommands", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt\shell\cmd1", "", "@shell32.dll,-8506");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt\shell\cmd1", "MUIVerb", "Open here");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt\shell\cmd1", "Icon", "imageres.dll,-5323");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt\shell\cmd1", "NoWorkingDirectory", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt\shell\cmd1\command", "", "cmd.exe /s /k pushd \"%V\"");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt\shell\cmd2", "", "Open here as administrator");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt\shell\cmd2", "HasLUAShield", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt\shell\cmd2", "Icon", "imageres.dll,-5324");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\CommandPrompt\shell\cmd2\command", "", "cmd /c echo|set/p=\"%V\"|powershell -NoP -W 1 -NonI -NoL \"SaPs 'cmd' -Args '/c \"\"\"cd /d',$([char]34+$Input+[char]34),'^&^& start /b cmd.exe\"\"\"' -Verb RunAs\"");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt", "Icon", "imageres.dll,-5323");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt", "MUIVerb", "Command Prompt");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt", "Extended", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt", "SubCommands", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt\shell\cmd1", "", "@shell32.dll,-8506");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt\shell\cmd1", "MUIVerb", "Open here");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt\shell\cmd1", "Icon", "imageres.dll,-5323");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt\shell\cmd1", "NoWorkingDirectory", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt\shell\cmd1\command", "", "cmd.exe /s /k pushd \"%V\"");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt\shell\cmd2", "", "Open here as administrator");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt\shell\cmd2", "HasLUAShield", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt\shell\cmd2", "Icon", "imageres.dll,-5324");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\CommandPrompt\shell\cmd2\command", "", "cmd /c echo|set/p=\"%L\"|powershell -NoP -W 1 -NonI -NoL \"SaPs 'cmd' -Args '/c \"\"\"cd /d',$([char]34+$Input+[char]34),'^&^& start /b cmd.exe\"\"\"' -Verb RunAs\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Si è verificato un errore durante l'aggiunta delle voci del Registro:\n" + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SetCheckboxState("abilitacmd", true);
                SetCheckboxState("disabilitacmd", false);
                changesApplied = true;
            }
            if (disabilitacmd.Checked)
            {
                try
                {
                    Registry.ClassesRoot.DeleteSubKeyTree(@"DesktopBackground\shell\CommandPrompt", false);
                    Registry.ClassesRoot.DeleteSubKeyTree(@"Directory\shell\CommandPrompt", false);
                    Registry.ClassesRoot.DeleteSubKeyTree(@"Directory\Background\shell\CommandPrompt", false);
                    Registry.ClassesRoot.DeleteSubKeyTree(@"Drive\shell\CommandPrompt", false);
                    Registry.ClassesRoot.DeleteSubKeyTree(@"LibraryFolder\Background\shell\CommandPrompt", false);

                    MessageBox.Show("Le voci del Registro sono state rimosse correttamente.", "Completato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Si è verificato un errore durante la rimozione delle voci del Registro:\n" + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SetCheckboxState("disabilitacmd", true);
                SetCheckboxState("abilita", false);
                changesApplied = true;
            }
            if (abilps.Checked)
            {
                try
                {
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\OpenElevatedPS", "", "Open PowerShell here as administrator");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\OpenElevatedPS", "Icon", "powershell.exe");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\OpenElevatedPS", "HasLUAShield", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\OpenElevatedPS\command", "", @"PowerShell -windowstyle hidden -Command ""Start-Process cmd.exe -ArgumentList '/s,/c,pushd %V && powershell' -Verb RunAs""");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\OpenElevatedPS", "", "Open PowerShell here as administrator");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\OpenElevatedPS", "Icon", "powershell.exe");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\OpenElevatedPS", "HasLUAShield", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\OpenElevatedPS\command", "", @"PowerShell -windowstyle hidden -Command ""Start-Process cmd.exe -ArgumentList '/s,/c,pushd %V && powershell' -Verb RunAs""");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\OpenElevatedPS", "", "Open PowerShell here as administrator");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\OpenElevatedPS", "Icon", "powershell.exe");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\OpenElevatedPS", "HasLUAShield", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\OpenElevatedPS\command", "", @"PowerShell -windowstyle hidden -Command ""Start-Process cmd.exe -ArgumentList '/s,/c,pushd %V && powershell' -Verb RunAs""");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\LibraryFolder\background\shell\OpenElevatedPS", "", "Open PowerShell here as administrator");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\LibraryFolder\background\shell\OpenElevatedPS", "Icon", "powershell.exe");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\LibraryFolder\background\shell\OpenElevatedPS", "HasLUAShield", "");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\LibraryFolder\background\shell\OpenElevatedPS\command", "", @"PowerShell -windowstyle hidden -Command ""Start-Process cmd.exe -ArgumentList '/s,/c,pushd %V && powershell' -Verb RunAs""");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Si è verificato un errore durante l'aggiunta delle voci del Registro:\n" + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SetCheckboxState("abilps", true);
                SetCheckboxState("disabilps", false);
                changesApplied = true;
            }
            if (disabilps.Checked)
            {
                try
                {
                    Registry.ClassesRoot.DeleteSubKeyTree(@"Directory\shell\OpenElevatedPS");
                    Registry.ClassesRoot.DeleteSubKeyTree(@"Directory\Background\shell\OpenElevatedPS");
                    Registry.ClassesRoot.DeleteSubKeyTree(@"Drive\shell\OpenElevatedPS");
                    Registry.ClassesRoot.DeleteSubKeyTree(@"LibraryFolder\background\shell\OpenElevatedPS");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Si è verificato un errore durante la rimozione delle voci del Registro:\n" + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SetCheckboxState("disabilps", true);
                SetCheckboxState("abilps", false);
                changesApplied = true;
            }
            if (ripristinafx.Checked)
            {
                try
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "DragFullWindows", "1");
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay", "400");
                    byte[] binaryValue = new byte[] { 158, 30, 7, 128, 18, 0, 0, 0 };
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "UserPreferencesMask", binaryValue, RegistryValueKind.Binary);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics", "MinAnimate", "1");
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Keyboard", "KeyboardDelay", 1, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewAlphaSelect", 1, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewShadow", 1, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAnimations", 1, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", 3, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableAeroPeek", 1, RegistryValueKind.DWord);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Si è verificato un errore durante l'aggiunta delle voci del Registro:\n" + ex.Message);
                }
                SetCheckboxState("ripristinafx", true);
                SetCheckboxState("performancefx", false);
                changesApplied = true;
            }
            if (performancefx.Checked)
            {
                try
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "DragFullWindows", "0");
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay", "0");
                    byte[] binaryValue = new byte[] { 144, 18, 3, 128, 16, 0, 0, 0 };
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "UserPreferencesMask", binaryValue, RegistryValueKind.Binary);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics", "MinAnimate", "0");
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Keyboard", "KeyboardDelay", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewAlphaSelect", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewShadow", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAnimations", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", 3, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableAeroPeek", 0, RegistryValueKind.DWord);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Si è verificato un errore durante l'aggiunta delle voci del Registro:\n" + ex.Message);
                }
            }
            if (changesApplied)
            {
                MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SetCheckboxState("performancefx", true);
            SetCheckboxState("ripristinafx", false);
            changesApplied = true;
        }

        private void DeleteRegistryKey(string path, string name)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true))
            {
                key?.DeleteValue(name, false);
            }
        }

        private void SetRegistryValue(string path, string name, object value, RegistryValueKind kind)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true) ?? Registry.CurrentUser.CreateSubKey(path))
            {
                key.SetValue(name, value, kind);
            }
        }

        private void avviawin10preset(object sender, EventArgs e)
        {
            string[] packages = new string[]
            {
        "CanonicalGroupLimited.UbuntuonWindows",
        "Microsoft.Xbox.TCUI",
        "Microsoft.XboxApp",
        "Microsoft.XboxGameOverlay",
        "Microsoft.XboxGamingOverlay",
        "Microsoft.XboxSpeechToTextOverlay",
        "Microsoft.MicrosoftStickyNotes",
        "Microsoft.HEIFImageExtension",
        "Microsoft.VP9VideoExtensions",
        "Microsoft.WebMediaExtensions",
        "Microsoft.WebpImageExtension",
        "WindSynthBerry",
        "MIDIBerry",
        "Slack",
        "Microsoft.MixedReality.Portal",
        "Microsoft.PPIProjection",
        "Microsoft.BingNews",
        "Microsoft.GetHelp",
        "Microsoft.Getstarted",
        "Microsoft.Messaging",
        "Microsoft.Microsoft3DViewer",
        "Microsoft.MicrosoftOfficeHub",
        "Microsoft.MicrosoftSolitaireCollection",
        "Microsoft.NetworkSpeedTest",
        "Microsoft.News",
        "Microsoft.Office.Lens",
        "Microsoft.Office.OneNote",
        "Microsoft.Office.Sway",
        "Microsoft.OneConnect",
        "Microsoft.People",
        "Microsoft.Print3D",
        "Microsoft.RemoteDesktop",
        "Microsoft.SkypeApp",
        "Microsoft.Office.Todo.List",
        "Microsoft.Whiteboard",
        "Microsoft.WindowsAlarms",
        "microsoft.windowscommunicationsapps",
        "Microsoft.WindowsFeedbackHub",
        "Microsoft.WindowsMaps",
        "Microsoft.WindowsSoundRecorder",
        "Microsoft.Xbox.TCUI",
        "Microsoft.XboxApp",
        "Microsoft.XboxGameOverlay",
        "Microsoft.XboxGamingOverlay",
        "Microsoft.XboxSpeechToTextOverlay",
        "Microsoft.ZuneMusic",
        "Microsoft.ZuneVideo",
        "EclipseManager",
        "ActiproSoftwareLLC",
        "AdobeSystemsIncorporated.AdobePhotoshopExpress",
        "Duolingo-LearnLanguagesforFree",
        "PandoraMediaInc",
        "CandyCrush",
        "BubbleWitch3Saga",
        "Wunderlist",
        "Flipboard",
        "Twitter",
        "Facebook",
        "Spotify",
        "Minecraft",
        "Royal Revolt",
        "Sway",
        "Microsoft.Advertising.Xaml",
        "Microsoft.Wallet",
        "Microsoft.YourPhone",
        "MicrosoftCorporationII.QuickAssist",
        "MicrosoftWindows.Client.WebExperience",
        "Clipchamp.Clipchamp",
        "Microsoft.RawImageExtension",
        "Microsoft.Todos",
        "Microsoft.PowerAutomateDesktop",
        "Microsoft.549981C3F5F10",
        "Microsoft.BingWeather"
            };

            foreach (var package in packages)
            {
                RemoveAppxPackageee(package);
            }
            RunPowerShellScripttt();
        }

        private void RemoveAppxPackageee(string packageName)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"Get-AppxPackage -allusers {packageName} | Remove-AppxPackage",
                Verb = "runas",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine($"Output for {packageName}: {output}");
                Console.WriteLine($"Error for {packageName}: {error}");
            }
        }

        private void RunPowerShellScripttt()
        {
            string[] powerShellCommands = new string[]
    {
        "Set-ItemProperty -Path 'HKCU:\\Control Panel\\International\\User Profile' -Name 'HttpAcceptLanguageOptOut' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent' -Name 'DisableThirdPartySuggestions' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent' -Name 'DisableWindowsConsumerFeatures' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Device Metadata' -Name 'PreventDeviceMetadataFromNetwork' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\MRT' -Name 'DontOfferThroughWUAU' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\SQMClient\\Windows' -Name 'CEIPEnable' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat' -Name 'AITEnable' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat' -Name 'DisableUAR' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\WMI\\AutoLogger\\AutoLogger-Diagtrack-Listener' -Name 'Start' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\WMI\\AutoLogger\\SQMLogger' -Name 'Start' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SilentInstalledAppsEnabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SystemPaneSuggestionsEnabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SoftLandingEnabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-310093Enabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-314559Enabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-338393Enabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-353694Enabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-353698Enabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SystemPaneSuggestionsEnabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'ContentDeliveryAllowed' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'OemPreInstalledAppsEnabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'PreInstalledAppsEnabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'PreInstalledAppsEverEnabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SilentInstalledAppsEnabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-338387Enabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-338388Enabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-338389Enabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SubscribedContent-353698Enabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager' -Name 'SystemPaneSuggestionsEnabled' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent' -Name 'DisableWindowsConsumerFeatures' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection' -Name 'AllowTelemetry' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection' -Name 'AllowTelemetry' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection' -Name 'AllowTelemetry' -Type DWord -Value 0",
        "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Application Experience\\Microsoft Compatibility Appraiser' | Out-Null",
        "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Application Experience\\ProgramDataUpdater' | Out-Null",
        "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Autochk\\Proxy' | Out-Null",
        "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Customer Experience Improvement Program\\Consolidator' | Out-Null",
        "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Customer Experience Improvement Program\\UsbCeip' | Out-Null",
        "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\DiskDiagnostic\\Microsoft-Windows-DiskDiagnosticDataCollector' | Out-Null",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'EnableActivityFeed' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'PublishUserActivities' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'UploadUserActivities' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\location')) { New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\location' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\location' -Name 'Value' -Type String -Value 'Deny'",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Sensor\\Overrides\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}' -Name 'SensorPermissionState' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Services\\lfsvc\\Service\\Configuration' -Name 'Status' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\Windows Error Reporting' -Name 'Disabled' -Type DWord -Value 1",
        "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Windows Error Reporting\\QueueReporting' | Out-Null",
        "Stop-Service 'DiagTrack' -WarningAction SilentlyContinue",
        "Set-Service 'DiagTrack' -StartupType Disabled",
        "Stop-Service 'dmwappushservice' -WarningAction SilentlyContinue",
        "Set-Service 'dmwappushservice' -StartupType Disabled",
        "Stop-Service 'HomeGroupListener' -WarningAction SilentlyContinue",
        "Set-Service 'HomeGroupListener' -StartupType Disabled",
        "Stop-Service 'HomeGroupProvider' -WarningAction SilentlyContinue",
        "Set-Service 'HomeGroupProvider' -StartupType Disabled",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Remote Assistance' -Name 'fAllowToGetHelp' -Type DWord -Value 0",
        "Remove-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\StorageSense\\Parameters\\StoragePolicy' -Recurse -ErrorAction SilentlyContinue",
        "Stop-Service 'SysMain' -WarningAction SilentlyContinue",
        "Set-Service 'SysMain' -StartupType Disabled",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\Maintenance' -Name 'MaintenanceDisabled' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ReserveManager' -Name 'ShippedWithReserves' -Type DWord -Value 0",
        "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Defrag\\ScheduledDefrag' | Out-Null",
        "Set-ItemProperty -Path 'HKLM:\\System\\GameConfigStore' -Name 'GameDVR_DXGIHonorFSEWindowsCompatible' -Type Hex -Value 00000000",
        "Set-ItemProperty -Path 'HKLM:\\System\\GameConfigStore' -Name 'GameDVR_HonorUserFSEBehaviorMode' -Type Hex -Value 00000000",
        "Set-ItemProperty -Path 'HKLM:\\System\\GameConfigStore' -Name 'GameDVR_EFSEFeatureFlags' -Type Hex -Value 00000000",
        "Set-ItemProperty -Path 'HKLM:\\System\\GameConfigStore' -Name 'GameDVR_Enabled' -Type DWord -Value 00000000",
        "Set-ItemProperty -Path 'HKCU:\\System\\GameConfigStore' -Name 'GameDVR_DXGIHonorFSEWindowsCompatible' -Type DWord -Value 0",
        "Remove-ItemProperty -Path 'HKCU:\\System\\GameConfigStore' -Name 'GameDVR_FSEBehavior' -ErrorAction SilentlyContinue",
        "Set-ItemProperty -Path 'HKCU:\\System\\GameConfigStore' -Name 'GameDVR_FSEBehaviorMode' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\System\\GameConfigStore' -Name 'GameDVR_HonorUserFSEBehaviorMode' -Type DWord -Value 0",
        "Get-ChildItem -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications' -Exclude 'Microsoft.Windows.Cortana*' | ForEach {",
        "Set-ItemProperty -Path $_.PsPath -Name 'Disabled' -Type DWord -Value 1",
        "Set-ItemProperty -Path $_.PsPath -Name 'DisabledByUser' -Type DWord -Value 1",
        "}",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\Maps' -Name 'AutoUpdateEnabled' -Type DWord -Value 0",
        "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\Siuf\\Rules')) { New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Siuf\\Rules' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Siuf\\Rules' -Name 'NumberOfSIUFInPeriod' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection' -Name 'DoNotShowFeedbackNotifications' -Type DWord -Value 1",
        "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Feedback\\Siuf\\DmClient' -ErrorAction SilentlyContinue | Out-Null",
        "Disable-ScheduledTask -TaskName 'Microsoft\\Windows\\Feedback\\Siuf\\DmClientOnScenarioDownload' -ErrorAction SilentlyContinue | Out-Null",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'EnableCdp' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'EnableMmx' -Type DWord -Value 0",
        "If (!(Test-Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent')) { New-Item -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent' -Name 'DisableTailoredExperiencesWithDiagnosticData' -Type DWord -Value 1",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AdvertisingInfo')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AdvertisingInfo' | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\AdvertisingInfo' -Name 'DisabledByGroupPolicy' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'EnableSmartScreen' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\MicrosoftEdge\\PhishingFilter')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\MicrosoftEdge\\PhishingFilter' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\MicrosoftEdge\\PhishingFilter' -Name 'EnabledV9' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\PolicyManager\\default\\WiFi\\AllowWiFiHotSpotReporting')) { New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\PolicyManager\\default\\WiFi\\AllowWiFiHotSpotReporting' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\PolicyManager\\default\\WiFi\\AllowWiFiHotSpotReporting' -Name 'Value' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\PolicyManager\\default\\WiFi\\AllowAutoConnectToWiFiSenseHotspots' -Name 'Value' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\WcmSvc\\wifinetworkmanager\\config')) { New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\WcmSvc\\wifinetworkmanager\\config' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\WcmSvc\\wifinetworkmanager\\config' -Name 'AutoConnectAllowedOEM' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Internet Explorer')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Internet Explorer' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Internet Explorer' -Name 'DisableFlashInIE' -Type DWord -Value 1",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\MicrosoftEdge\\Addons')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\MicrosoftEdge\\Addons' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\MicrosoftEdge\\Addons' -Name 'FlashPlayerEnabled' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Internet Explorer\\Main')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Internet Explorer\\Main' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Internet Explorer\\Main' -Name 'DisableFirstRunCustomize' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\FileSystem' -Name 'LongPathsEnabled' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\TimeZoneInformation' -Name 'RealTimeIsUniversal' -Type DWord -Value 1",
        "powercfg -duplicatescheme a1841308-3541-4fab-bc81-f71556f20b4a",
        "powercfg -duplicatescheme 381b4222-f694-41f0-9685-ff5bb260df2e",
        "powercfg -duplicatescheme 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c",
        "powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61",
        "Write-host 'Custom Powerplan Installed'",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters' -Name 'IRPStackSize' -Type DWord -Value 20",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control' -Name 'SvcHostSplitThresholdInKB' -Type DWord -Value 4194304",
        "fsutil behavior set DisableLastAccess 1",
        "fsutil behavior set EncryptPagingFile 0",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server' -Name 'fDenyTSConnections' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server\\WinStations\\RDP-Tcp' -Name 'UserAuthentication' -Type DWord -Value 1",
        "Disable-NetFirewallRule -Name 'RemoteDesktop*'",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Feeds' -Name 'EnableFeeds' -Type DWord -Value 0",
        "If (!(Test-Path 'HKU:')) { New-PSDrive -Name 'HKU' -PSProvider 'Registry' -Root 'HKEY_USERS' | Out-Null }",
        "Set-ItemProperty -Path 'HKU:\\.DEFAULT\\Control Panel\\Keyboard' -Name 'InitialKeyboardIndicators' -Type DWord -Value 2147483650",
        "Add-Type -AssemblyName System.Windows.Forms",
        "If (!([System.Windows.Forms.Control]::IsKeyLocked('NumLock'))) { $wsh = New-Object -ComObject WScript.Shell; $wsh.SendKeys('{NUMLOCK}') }",
        "Remove-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity' -Name 'Enabled' -ErrorAction SilentlyContinue",
        "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows Security Health\\State')) { New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows Security Health\\State' -Force | Out-Null }",
        "Set-ItemProperty 'HKCU:\\Software\\Microsoft\\Windows Security Health\\State' -Name 'AccountProtection_MicrosoftAccount_Disconnected' -Type DWord -Value 1",
        "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments')) { New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments' | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments' -Name 'SaveZoneInformation' -Type DWord -Value 1",
        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\.NETFramework\\v4.0.30319' -Name 'SchUseStrongCrypto' -ErrorAction SilentlyContinue",
        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\.NETFramework\\v4.0.30319' -Name 'SchUseStrongCrypto' -ErrorAction SilentlyContinue",
        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System' -Name 'EnableLinkedConnections' -ErrorAction SilentlyContinue",
        "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters' -Name 'AutoShareWks' -Type DWord -Value 0",
        "Set-NetConnectionProfile -NetworkCategory Private",
        "bcdedit /set `{current`} bootmenupolicy Legacy | Out-Null",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Name 'AUPowerManagement' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\Maintenance' -Name 'WakeUp' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Force | Out-Null; Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Name 'AUOptions' -Type DWord -Value 2 }",

        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\MusNotification.exe')) {",
        "New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\MusNotification.exe' -Force | Out-Null",
        "}",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\MusNotification.exe' -Name 'Debugger' -Type String -Value 'cmd.exe'",
        "takeown /F '$env:WinDIR\\System32\\MusNotification.exe'",
        "icacls '$env:WinDIR\\System32\\MusNotification.exe' /deny '$($EveryOne):(X)'",
        "takeown /F '$env:WinDIR\\System32\\MusNotificationUx.exe'",
        "icacls '$env:WinDIR\\System32\\MusNotificationUx.exe' /deny '$($EveryOne):(X)'",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Device Metadata')) {",
        "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Device Metadata' -Force | Out-Null",
        "}",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Device Metadata' -Name 'PreventDeviceMetadataFromNetwork' -Type DWord -Value 1",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching')) {",
        "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Force | Out-Null",
        "}",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Name 'DontPromptForWindowsUpdate' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Name 'DontSearchWindowsUpdate' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching' -Name 'DriverUpdateWizardWuSearchEnabled' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate')) {",
        "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate' | Out-Null",
        "}",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate' -Name 'ExcludeWUDriversInQualityUpdate' -Type DWord -Value 1",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU')) {",
        "New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Force | Out-Null",
        "}",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Name 'NoAutoRebootWithLoggedOnUsers' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU' -Name 'AUPowerManagement' -Type DWord -Value 0",
        "Disable-WindowsOptionalFeature -Online -FeatureName 'WindowsMediaPlayer' -NoRestart -WarningAction SilentlyContinue | Out-Null",
        "Disable-WindowsOptionalFeature -Online -FeatureName 'WorkFolders-Client' -NoRestart -WarningAction SilentlyContinue | Out-Null",
        "If ((Get-WmiObject -Class 'Win32_OperatingSystem').Caption -like '*Server*') {",
        "Uninstall-WindowsFeature -Name 'Hyper-V' -IncludeManagementTools -WarningAction SilentlyContinue | Out-Null",
        "} Else {",
        "Disable-WindowsOptionalFeature -Online -FeatureName 'Microsoft-Hyper-V-All' -NoRestart -WarningAction SilentlyContinue | Out-Null",
        "}",
        "Disable-WindowsOptionalFeature -Online -FeatureName 'Printing-XPSServices-Features' -NoRestart -WarningAction SilentlyContinue | Out-Null",
        "Remove-Printer -Name 'Fax' -ErrorAction SilentlyContinue",
        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock' -Name 'AllowDevelopmentWithoutDevLicense' -ErrorAction SilentlyContinue",
        "Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock' -Name 'AllowAllTrustedApps' -ErrorAction SilentlyContinue",
        "Get-WindowsCapability -Online | Where-Object { $_.Name -like 'MathRecognizer*' } | Remove-WindowsCapability -Online | Out-Null",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync' -Name 'BackupPolicy' -Type DWord -Value 0x3c",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync' -Name 'DeviceMetadataUploaded' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync' -Name 'PriorLogons' -Type DWord -Value 1",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\Common\\ClientTelemetry' -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\ClientTelemetry' -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\Common\\ClientTelemetry' -Name 'DisableTelemetry' -Type 'DWORD' -Value 1 -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\ClientTelemetry' -Name 'DisableTelemetry' -Type 'DWORD' -Value 1 -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\Common\\ClientTelemetry' -Name 'VerboseLogging' -Type 'DWORD' -Value 0 -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\ClientTelemetry' -Name 'VerboseLogging' -Type 'DWORD' -Value 0 -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Mail' -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Mail' -Name 'EnableLogging' -Type 'DWORD' -Value 0 -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Mail' -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Mail' -Name 'EnableLogging' -Type 'DWORD' -Value 0 -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Calendar' -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Outlook\\Options\\Calendar' -Name 'EnableCalendarLogging' -Type 'DWORD' -Value 0 -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Calendar' -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Outlook\\Options\\Calendar' -Name 'EnableCalendarLogging' -Type 'DWORD' -Value 0 -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Word\\Options' -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Word\\Options' -Name 'EnableLogging' -Type 'DWORD' -Value 0 -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Word\\Options' -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Word\\Options' -Name 'EnableLogging' -Type 'DWORD' -Value 0 -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\15.0\\OSM' -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\15.0\\OSM' -Name 'EnableLogging' -Type 'DWORD' -Value 0 -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\15.0\\OSM' -Name 'EnableUpload' -Type 'DWORD' -Value 0 -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\16.0\\OSM' -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\16.0\\OSM' -Name 'EnableLogging' -Type 'DWORD' -Value 0 -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Policies\\Microsoft\\Office\\16.0\\OSM' -Name 'EnableUpload' -Type 'DWORD' -Value 0 -Force",
        "schtasks /change /TN 'Microsoft\\Office\\OfficeTelemetryAgentFallBack' /DISABLE",
        "schtasks /change /TN 'Microsoft\\Office\\OfficeTelemetryAgentFallBack2016' /DISABLE",
        "schtasks /change /TN 'Microsoft\\Office\\OfficeTelemetryAgentLogOn' /DISABLE",
        "schtasks /change /TN 'Microsoft\\Office\\OfficeTelemetryAgentLogOn2016' /DISABLE",
        "schtasks /change /TN 'Microsoft\\Office\\Office 15 Subscription Heartbeat' /DISABLE",
        "schtasks /change /TN 'Microsoft\\Office\\Office 16 Subscription Heartbeat' /DISABLE",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Common\\Feedback' -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\Feedback' -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Common\\Feedback' -Name 'Enabled' -Type 'DWORD' -Value 0 -Force",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\16.0\\Common\\Feedback' -Name 'Enabled' -Type 'DWORD' -Value 0 -Force",
        "New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Office\\15.0\\Common' -Force",
        "New-Item -Path 'HKCU\\SOFTWARE\\Microsoft\\Office\\16.0\\Common' -Force",
        "Set-ItemProperty -Path 'HKCU\\SOFTWARE\\Microsoft\\Office\\15.0\\Common' -Name 'QMEnable' -Type 'DWORD' -Value 0 -Force",
        "Set-ItemProperty -Path 'HKCU\\SOFTWARE\\Microsoft\\Office\\16.0\\Common' -Name 'QMEnable' -Type 'DWORD' -Value 0 -Force",
        "Get-ScheduledTask -TaskName 'GoogleUpdateTaskMachineCore' | Disable-ScheduledTask",
        "Get-ScheduledTask -TaskName 'GoogleUpdateTaskMachineUA' | Disable-ScheduledTask",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'HideFileExt' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'Hidden' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'HideMergeConflicts' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'PersistBrowsers' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'ShowSyncProviderNotifications' -Type DWord -Value 1",
        "Remove-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\ClassicStartMenu' -Name '{645FF040-5081-101B-9F08-00AA002F954E}' -ErrorAction SilentlyContinue",
        "Remove-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel' -Name '{645FF040-5081-101B-9F08-00AA002F954E}' -ErrorAction SilentlyContinue",
        "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\ClassicStartMenu')) { New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\ClassicStartMenu' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\ClassicStartMenu' -Name '{20D04FE0-3AEA-1069-A2D8-08002B30309D}' -Type DWord -Value 0",
        "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel')) { New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel' -Name '{20D04FE0-3AEA-1069-A2D8-08002B30309D}' -Type DWord -Value 0",
        "Remove-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'NavPaneExpandToCurrentFolder' -ErrorAction SilentlyContinue",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'SharingWizardOn' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'AutoCheckSelect' -Type DWord -Value 0",
        "If (!(Test-Path 'HKCR:')) { New-PSDrive -Name 'HKCR' -PSProvider 'Registry' -Root 'HKEY_CLASSES_ROOT' | Out-Null }",
        "Remove-Item -Path 'HKCR:\\Folder\\ShellEx\\ContextMenuHandlers\\Library Location' -ErrorAction SilentlyContinue",
        "If (!(Test-Path 'HKCR:')) { New-PSDrive -Name 'HKCR' -PSProvider 'Registry' -Root 'HKEY_CLASSES_ROOT' | Out-Null }",
        "Remove-Item -LiteralPath 'HKCR:\\*\\shellex\\ContextMenuHandlers\\Sharing' -ErrorAction SilentlyContinue",
        "Remove-Item -Path 'HKCR:\\Directory\\Background\\shellex\\ContextMenuHandlers\\Sharing' -ErrorAction SilentlyContinue",
        "Remove-Item -Path 'HKCR:\\Directory\\shellex\\ContextMenuHandlers\\Sharing' -ErrorAction SilentlyContinue",
        "Remove-Item -Path 'HKCR:\\Drive\\shellex\\ContextMenuHandlers\\Sharing' -ErrorAction SilentlyContinue",
        "If (!(Test-Path 'HKCR:')) { New-PSDrive -Name 'HKCR' -PSProvider 'Registry' -Root 'HKEY_CLASSES_ROOT' | Out-Null }",
        "Remove-Item -LiteralPath 'HKCR:\\*\\shellex\\ContextMenuHandlers\\ModernSharing' -ErrorAction SilentlyContinue",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'HideIcons' -Value 0",
        "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CabinetState')) { New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CabinetState' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CabinetState' -Name 'FullPath' -Type DWord -Value 1",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer' | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer' -Name 'HideRecentlyAddedApps' -Type DWord -Value 1",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer')) { New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' -Name 'NoStartMenuMFUprogramsList' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Feeds' -Name 'ShellFeedsTaskbarViewMode' -Type DWord -Value 2",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' -Name 'HideSCAMeetNow' -Type DWord -Value 1 -ErrorAction SilentlyContinue",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' -Name 'HideSCAMeetNow' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'ShowCortanaButton' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search' -Name 'BingSearchEnabled' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search' -Name 'CortanaConsent' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Name 'DisableWebSearch' -Type DWord -Value 1",
        "Stop-Service 'WSearch' -WarningAction SilentlyContinue",
        "Set-Service 'WSearch' -StartupType Disabled",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search' -Name 'SearchboxTaskbarMode' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'ShowTaskViewButton' -Type DWord -Value 0",
        "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\People')) { New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\People' | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\People' -Name 'PeopleBand' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name 'UseOLEDTaskbarTransparency' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\Dwm' -Name 'ForceEffectMode' -Type DWord -Value 1",
        "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\Personalization\\Settings')) { New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Personalization\\Settings' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Personalization\\Settings' -Name 'AcceptedPrivacyPolicy' -Type DWord -Value 0",
        "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization')) { New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization' -Name 'RestrictImplicitTextCollection' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization' -Name 'RestrictImplicitInkCollection' -Type DWord -Value 1",
        "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization\\TrainedDataStore')) { New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization\\TrainedDataStore' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\InputPersonalization\\TrainedDataStore' -Name 'HarvestContacts' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Force | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search' -Name 'AllowCortana' -Type DWord -Value 0",
        "$taskmgr = Start-Process -WindowStyle Hidden -FilePath taskmgr.exe -PassThru",
        "Do {",
        "    Start-Sleep -Milliseconds 100",
        "    $preferences = Get-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\TaskManager' -Name 'Preferences' -ErrorAction SilentlyContinue",
        "} Until ($preferences)",
        "Stop-Process $taskmgr",
        "$preferences.Preferences[28] = 0",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\TaskManager' -Name 'Preferences' -Type Binary -Value $preferences.Preferences",
        "If (!(Test-Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\OperationStatusManager')) { New-Item -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\OperationStatusManager' | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\OperationStatusManager' -Name 'EnthusiastMode' -Type DWord -Value 1",
        "If (!(Test-Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel')) { New-Item -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel' | Out-Null }",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel' -Name 'StartupPage' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel' -Name 'AllItemsIconView' -Type DWord -Value 0",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer')) { New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' | Out-Null }",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer' -Name 'NoRecentDocsHistory' -Type DWord -Value 1",
        "Set-ItemProperty -Path 'HKCU:\\Control Panel\\Accessibility\\StickyKeys' -Name 'Flags' -Type String -Value '506'",
        "$CloudStore = 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\CloudStore'",
        "If (Test-Path $CloudStore) {",
        "    Stop-Process Explorer.exe -Force",
        "    Remove-Item $CloudStore -Recurse -Force",
        "    Start-Process Explorer.exe -Wait",
        "}",
        "If ([System.Environment]::OSVersion.Version.Build -eq 10240) {",
        "    If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Config')) { New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Config' | Out-Null }",
        "    Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Config' -Name 'DODownloadMode' -Type DWord -Value 1",
        "} ElseIf ([System.Environment]::OSVersion.Version.Build -le 14393) {",
        "    If (!(Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization')) { New-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization' | Out-Null }",
        "    Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization' -Name 'DODownloadMode' -Type DWord -Value 1",
        "} Else {",
        "    Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization' -Name 'DODownloadMode' -ErrorAction SilentlyContinue",
        "}",
        "$groups = @(",
        "    'Accessibility'",
        "    'AppSync'",
        "    'BrowserSettings'",
        "    'Credentials'",
        "    'DesktopTheme'",
        "    'Language'",
        "    'PackageState'",
        "    'Personalization'",
        "    'StartLayout'",
        "    'Windows'",
        ")",
        "foreach ($group in $groups) {",
        "    New-FolderForced -Path \"HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\$group\"",
        "    Set-ItemProperty -Path \"HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\$group\" -Name 'Enabled' -Value 0",
        "}",
        "$Paint3Dstuff = @(",
        "    'HKCR:\\SystemFileAssociations\\.3mf\\Shell\\3D Edit'",
        "    'HKCR:\\SystemFileAssociations\\.bmp\\Shell\\3D Edit'",
        "    'HKCR:\\SystemFileAssociations\\.fbx\\Shell\\3D Edit'",
        "    'HKCR:\\SystemFileAssociations\\.gif\\Shell\\3D Edit'",
        "    'HKCR:\\SystemFileAssociations\\.jfif\\Shell\\3D Edit'",
        "    'HKCR:\\SystemFileAssociations\\.jpe\\Shell\\3D Edit'",
        "    'HKCR:\\SystemFileAssociations\\.jpeg\\Shell\\3D Edit'",
        "    'HKCR:\\SystemFileAssociations\\.jpg\\Shell\\3D Edit'",
        "    'HKCR:\\SystemFileAssociations\\.png\\Shell\\3D Edit'",
        "    'HKCR:\\SystemFileAssociations\\.tif\\Shell\\3D Edit'",
        "    'HKCR:\\SystemFileAssociations\\.tiff\\Shell\\3D Edit'",
        ")",
        "foreach ($Paint3D in $Paint3Dstuff) {",
        "    If (Test-Path $Paint3D) {",
        "        $rmPaint3D = $Paint3D + '_'",
        "        Set-Item $Paint3D $rmPaint3D",
        "    }",
        "}",
        "Remove-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}' -Recurse -ErrorAction SilentlyContinue",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag')) {",
        "    New-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag' -Force | Out-Null",
        "}",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag' -Name 'ThisPCPolicy' -Type String -Value 'Hide'",
        "If (!(Test-Path 'HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag')) {",
        "    New-Item -Path 'HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag' -Force | Out-Null",
        "}",
        "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions\\{31C0DD25-9439-4F12-BF41-7FF4EDA38722}\\PropertyBag' -Name 'ThisPCPolicy' -Type String -Value 'Hide'",
        "Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name 'AppsUseLightTheme' -Type DWord -Value 0",
        "Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Feeds' -Name 'ShellFeedsTaskbarViewMode' -Value 2"
    };

            foreach (string command in powerShellCommands)
            {
                RunPowerShellCommanddd(command);
            }
        }

        private void RunPowerShellCommanddd(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = command,
                Verb = "runas", // Esegui con privilegi di amministratore
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
        }
    }
}
