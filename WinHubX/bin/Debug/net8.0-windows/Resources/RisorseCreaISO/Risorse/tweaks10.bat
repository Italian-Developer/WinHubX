@echo off
setlocal EnableDelayedExpansion

rem set password never expire
wmic UserAccount set PasswordExpires=False

IF EXIST "C:\Windows\debloatapp.pref" (
powershell -command "$ErrorActionPreference = 'SilentlyContinue'; Get-AppxPackage -AllUsers | Where-Object {$_.name -notmatch 'Microsoft.VP9VideoExtensions|Microsoft.WebMediaExtensions|Microsoft.WebpImageExtension|Microsoft.Windows.ShellExperienceHost|Microsoft.VCLibs*|Microsoft.DesktopAppInstaller|Microsoft.StorePurchaseApp|Microsoft.Windows.Photos|Microsoft.WindowsStore|Microsoft.XboxIdentityProvider|Microsoft.WindowsCalculator|Microsoft.HEIFImageExtension|Microsoft.UI.Xaml*'} | Remove-AppxPackage"
)

rem Hide Meet Now icon in the taskbar
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v "HideSCAMeetNow" /t "REG_DWORD" /d 1 /f
reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v "HideSCAMeetNow" /t "REG_DWORD" /d 1 /f

rem Remove Search Icon from Windows 10 Taskbar
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Search" /v "SearchboxTaskbarMode" /t REG_DWORD /d 0 /f

rem Remove Task View from Windows 10 Taskbar
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "ShowTaskViewButton" /t REG_DWORD /d 0 /f

rem disable interest and news
reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Feeds" /v "EnableFeeds" /t "REG_DWORD" /d 0 /f
reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Feeds" /v "ShellFeedsTaskbarViewMode" /t "REG_DWORD" /d 2 /f

rem show file extensions
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "HideFileExt" /t REG_DWORD /d 0 /f

reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate /v TargetReleaseVersion /t REG_DWORD /d 1 /f
reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate /v ProductVersion /d "Windows 10" /f 
reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate /v TargetReleaseVersionInfo /d "22H2" /f 
reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate /v DisableOSUpgrade /t REG_DWORD /d 1 /f 
reg add HKLM\SOFTWARE\Policies\Microsoft\WindowsStore /v DisableOSUpgrade /t REG_DWORD /d 1 /f 
reg add HKLM\SYSTEM\Setup\UpgradeNotification /v UpgradeAvailable /t REG_DWORD /d 0 /f

rem Check the system architecture
wmic os get osarchitecture 2>NUL | find "64-bit">NUL
IF "%ERRORLEVEL%"=="0" echo "64 bit!" && goto :64bit

wmic os get osarchitecture 2>NUL | find "32-bit">NUL
IF "%ERRORLEVEL%"=="0" echo "32 bit!" && goto :32bit

:64bit
rem uninstall onedrive 64 bit
powershell -command "Get-Process OneDrive | Stop-Process -Force"
powershell -command "C:\Windows\SysWOW64\OneDriveSetup.exe /uninstall"
goto :bing

:32bit
rem uninstall onedrive 32 bit
powershell -command "Get-Process OneDrive | Stop-Process -Force"
powershell -command "C:\Windows\System32\OneDriveSetup.exe /uninstall"

:bing
rem disable bing search on start
reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Search /v BingSearchEnabled /t REG_DWORD /d 0 /f

rem enable dark theme
reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize /v AppsUseLightTheme /t REG_DWORD /d 0 /f
reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize /v SystemUsesLightTheme /t REG_DWORD /d 0 /f
reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize /v EnableTransparency /t REG_DWORD /d 1 /f
reg add "HKCU\Control Panel\Colors" /v ImmersiveApplicationForeground /t REG_SZ /d "255 255 255" /f

rem delete pinned on taskbar
del /f /s /q /a "%AppData%\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\*"
reg delete HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband /f

rem delete edge icon on desktop
del /s /q "C:\Users\%username%\Desktop\*.lnk" 

rem disable contentdelivery
reg add HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager /v OemPreInstalledAppsEnabled /t REG_DWORD /d 0 /f
reg add HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager /v PreInstalledAppsEnabled /t REG_DWORD /d 0 /f
reg add HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager /v SilentInstalledAppsEnabled /t REG_DWORD /d 0 /f
reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\CloudContent /v DisableWindowsConsumerFeatures /t REG_DWORD /d 1 /f

taskkill /F /IM SearchUI.exe
move "%windir%\SystemApps\Microsoft.Windows.Cortana_cw5n1h2txyewy" "%windir%\SystemApps\Microsoft.Windows.Cortana_cw5n1h2txyewy.bak"

rem fix indexing was turned off
sc config wsearch start=auto

regedit /s "C:\windows\lower-ram-usage.reg.reg"

rem disable telemetry
sc config DiagTrack start=disabled
sc config dmwappushservice start=disabled

rem copy Attivatore Win
copy "C:\Windows\WinCustomizerAttivatore.bat" "C:\Users\%username%\Desktop"
copy "C:\Windows\WinCustomizerStartDebloat.bat" "C:\Users\%username%\Desktop"

rem unpin from start the tiles
powerShell -ExecutionPolicy Bypass -File "C:\Windows\unpin_start_tiles.ps1"

rem disable update
IF EXIST "C:\Windows\noupdate.pref" (
reg add HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer /v NoWindowsUpdate /t REG_DWORD /d 1 /f
)

rem disable defender 
IF EXIST "C:\Windows\nodefender.pref" (
    goto :disable_def
) ELSE (
    goto :skip_disable_def
)

:disable_def
PowerRun.exe cmd.exe /c "reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender" /v "DisableAntiSpyware" /t REG_DWORD /d 1 /f"
PowerRun.exe cmd.exe /c "reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection" /v "DisableBehaviorMonitoring" /t REG_DWORD /d 1 /f"
PowerRun.exe cmd.exe /c "reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection" /v "DisableIOAVProtection" /t REG_DWORD /d 1 /f"
PowerRun.exe cmd.exe /c "reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection" /v "DisableOnAccessProtection" /t REG_DWORD /d 1 /f"
PowerRun.exe cmd.exe /c "reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection" /v "DisableRealtimeMonitoring" /t REG_DWORD /d 1 /f"
PowerRun.exe cmd.exe /c "reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SecurityHealthService" /v "Start" /t REG_DWORD /d 4 /f"
PowerRun.exe cmd.exe /c "reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend" /v "Start" /t REG_DWORD /d 4 /f"

:skip_disable_def
rem copy firefox installer to the desktop and remove edge
IF EXIST "C:\Windows\noedge.pref" (
move "C:\Windows\OperaGXSetup.exe" "C:\Users\%username%\Desktop"
goto :edge
) ELSE (
    goto :skip_edge
)

:edge
echo.
echo Killing Microsoft Edge...
echo.
taskkill /F /IM msedge.exe 2>nul

reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\EdgeUpdate" /v "DoNotUpdateToEdgeWithChromium" /t REG_DWORD /d 1 /f

PowerRun.exe cmd.exe /c "rmdir /s / q "C:\Program Files (x86)\Microsoft\Edge""
PowerRun.exe cmd.exe /c "rmdir /s / q "C:\Program Files\Microsoft\Edge""

del "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Microsoft Edge.lnk"2>nul
del "%appdata%\Microsoft\Windows\Start Menu\Programs\Microsoft Edge.lnk"2>nul

:skip_edge
IF EXIST "C:\Windows\ottimizza.pref" (
REG ADD "HKCU\SOFTWARE\Microsoft\GameBar" /v AllowAutoGameMode /t REG_DWORD /d 0 /f
REG ADD "HKCU\SOFTWARE\Microsoft\GameBar" /v AutoGameModeEnabled /t REG_DWORD /d 0 /f
schtasks /Change /TN "\Microsoft\Windows\ApplicationData\appuriverifierdaily" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\Application Experience\PcaPatchDbTask" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\Application Experience\StartupAppTask" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\ApplicationData\DsSvcCleanup" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\CloudExperienceHost\CreateObjectTask" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\Diagnosis\Scheduled" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\DiskDiagnostic\Microsoft-Windows-DiskDiagnosticDataCollector" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\DiskFootprint\Diagnostics" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\InstallService\ScanForUpdates" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\InstallService\ScanForUpdatesAsUser" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\Maintenance\WinSAT" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\MemoryDiagnostic\RunFullMemoryDiagnostic" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\PI\Sqm-Tasks" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\Power Efficiency Diagnostics\AnalyzeSystem" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\Registry\RegIdleBackup" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\Shell\FamilySafetyMonitor" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\Shell\FamilySafetyRefresh" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\Shell\IndexerAutomaticMaintenance" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\StateRepository\MaintenanceTasks" /DISABLE
schtasks /Change /TN "\Microsoft\Windows\WindowsUpdate\Scheduled Start" /DISABLE
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v ContentDeliveryAllowed /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v OemPreInstalledAppsEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v PreInstalledAppsEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v PreInstalledAppsEverEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SilentInstalledAppsEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SubscribedContentEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SubscribedContent-310093Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SubscribedContent-338393Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SubscribedContent-353694Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SubscribedContent-353696Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SubscribedContent-338387Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v RotatingLockScreenOverlayEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SubscribedContent-338388Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SystemPaneSuggestionsEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SubscribedContent-338389Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v SoftLandingEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v FeatureManagementEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager\Subscriptions" /f
PowerRun.exe cmd.exe /c reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager\SuggestedApps" /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy" /v 01 /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy" /v 1024 /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy" /v 2048 /t REG_DWORD /d 30 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy" /v 04 /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy" /v 32 /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy" /v 02 /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy" /v 128 /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy" /v 08 /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy" /v 256 /t REG_DWORD /d 30 /f
schtasks /Change /TN "\Microsoft\Windows\DiskCleanup\SilentCleanup" /Enable
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\ReserveManager" /v MiscPolicyInfo /t REG_DWORD /d 2 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\ReserveManager" /v PassedPolicy /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\ReserveManager" /v ShippedWithReserves /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Family options" /v UILockdown /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Device performance and health" /v UILockdown /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Account protection" /v UILockdown /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Search" /v BingSearchEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\SearchSettings" /v IsAADCloudSearchEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\SearchSettings" /v IsDeviceSearchHistoryEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\SearchSettings" /v IsMSACloudSearchEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\SearchSettings" /v SafeSearchMode /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Windows Search" /v ConnectedSearchUseWeb /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Windows Search" /v DisableWebSearch /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Windows Search" /v EnableDynamicContentInWSB /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Policies\Microsoft\Windows\Explorer" /v DisableSearchBoxSuggestions /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\appDiagnostics" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\appointments" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\bluetoothSync" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\broadFileSystemAccess" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\chat" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\contacts" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\documentsLibrary" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\email" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\phoneCall" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\phoneCallHistory" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\picturesLibrary" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\radios" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userAccountInformation" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userDataTasks" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userNotificationListener" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\videosLibrary" /v Value /t REG_SZ /d Deny /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\System" /v EnableActivityFeed /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v Start_TrackProgs /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\DeviceHealthAttestationService" /v EnableDeviceHealthAttestationService /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\PolicyManager\default\System" /v AllowExperimentation /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\FindMyDevice" /v AllowFindMyDevice /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\FindMyDevice" /v LocationSyncEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Personalization" /v NoLockScreenCamera /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Speech_OneCore\Settings" /v OnlineSpeechPrivacy /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\InputPersonalization" /v AllowInputPersonalization /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\AppCompat" /v AITEnable /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\AppCompat" /v AllowTelemetry /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\AppCompat" /v DisableEngine /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\AppCompat" /v DisableInventory /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\AppCompat" /v DisablePCA /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\AppCompat" /v DisableUAR /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\WDI\{9c5a40da-b965-4fc3-8781-88dd50a6299d}" /v ScenarioExecutionEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\OOBE" /v DisablePrivacyExperience /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\System" /v RSoPLogging /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Speech" /v AllowSpeechModelUpdate /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Privacy" /v TailoredExperiencesWithDiagnosticDataEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Policies\Microsoft\Windows\CloudContent" /v DisableTailoredExperiencesWithDiagnosticData /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v NoInstrumentation /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\Control Panel\International\User Profile" /v HttpAcceptLanguageOptOut /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Policies\Microsoft\Windows\Windows Error Reporting" /v Disabled /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\PCHealth\ErrorReporting" /v DoReport /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Windows Error Reporting" /v Disabled /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\DeviceInstall\Settings" /v DisableSendGenericDriverNotFoundToWER /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\DeviceInstall\Settings" /v DisableSendRequestAdditionalSoftwareToWER /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System" /v NoConnectedUser /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\System" /v UploadUserActivities /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\System" /v PublishUserActivities /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\AdvertisingInfo" /v Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v ShowSyncProviderNotifications /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\SettingSync" /v DisableSettingSync /t REG_DWORD /d 2 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\SettingSync" /v DisableSettingSyncUserOverride /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\SettingSync" /v DisableSyncOnPaidNetwork /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\SettingSync" /v DisableWindowsSettingSync /t REG_DWORD /d 2 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Personalization" /v Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\BrowserSettings" /v Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Credentials" /v Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Accessibility" /v Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Windows" /v Enabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync" /v SyncPolicy /t REG_DWORD /d 5 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\UserProfileEngagement" /v ScoobeSystemSettingEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Messaging" /v AllowMessageSync /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows NT\CurrentVersion\Software Protection Platform" /v NoGenTicket /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\AppV\CEIP" /v CEIPEnable /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\SQMClient\Windows" /v CEIPEnable /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Control\Diagnostics\Performance" /v DisableDiagnosticTracing /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\InputPersonalization" /v RestrictImplicitInkCollection /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\InputPersonalization" /v RestrictImplicitTextCollection /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\InputPersonalization\TrainedDataStore" /v HarvestContacts /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Personalization\Settings" /v AcceptedPrivacyPolicy /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\TabletPC" /v PreventHandwritingDataSharing /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\HandwritingErrorReports" /v PreventHandwritingErrorReports /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Input\Settings" /v InsightsEnabled /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Input\TIPC" /v Enabled /t REG_DWORD /d 0 /f
sc stop DiagTrack  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Diagnostics\DiagTrack" /v ShowedToastAtLevel /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection" /v AllowTelemetry /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection" /v MaxTelemetryAllowed /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\DataCollection" /v AllowTelemetry /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c del "%ProgramData%\Microsoft\Diagnosis\ETLLogs\AutoLogger\DiagTrack*" "%ProgramData%\Microsoft\Diagnosis\ETLLogs\ShutdownLogger\DiagTrack*"  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v NoStartMenuMFUprogramsList /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Explorer" /v HideRecentlyAddedApps /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Explorer" /v HideRecommendedPersonalizedSites /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\Explorer" /v ShowOrHideMostUsedApps /t REG_DWORD /d 2 /f  
setx POWERSHELL_TELEMETRY_OPTOUT 1  
ftype Microsoft.PowerShellScript.1="%windir%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoLogo -EP Unrestricted -File "%1" %*
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell" /v ExecutionPolicy /t REG_SZ /d Unrestricted /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\PolicyManager\default\Settings" /v AllowOnlineTips /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v AllowOnlineTips /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\TabletTip\1.7" /v EnableAutocorrection /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\TabletTip\1.7" /v EnableDoubleTapSpace /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\TabletTip\1.7" /v EnablePredictionSpaceInsertion /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\TabletTip\1.7" /v EnableSpellchecking /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\TabletTip\1.7" /v EnableTextPrediction /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\TabletTip\1.7" /v EnableAutoShiftEngage /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\TabletTip\1.7" /v EnableKeyAudioFeedback /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\TabletTip\1.7" /v EnableShiftLock /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsStore\WindowsUpdate" /v AutoDownload /t REG_DWORD /d 2 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\CloudContent" /v DisableSoftLanding /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\Control Panel\Cursors" /v GestureVisualization /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\Control Panel\Cursors" /v ContactVisualization /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg delete "HKCU\SOFTWARE\Microsoft\Siuf\Rules" /v PeriodInNanoSeconds /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Siuf\Rules" /v NumberOfSIUFInPeriod /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection" /v DoNotShowFeedbackNotifications /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Policies\Microsoft\Windows\CloudContent" /v DisableWindowsSpotlightFeatures /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Policies\Microsoft\Windows\CloudContent" /v DisableWindowsSpotlightWindowsWelcomeExperience /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Policies\Microsoft\Windows\CloudContent" /v DisableWindowsSpotlightOnActionCenter /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Policies\Microsoft\Windows\CloudContent" /v DisableWindowsSpotlightOnSettings /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Policies\Microsoft\Windows\CloudContent" /v DisableThirdPartySuggestions /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\Control Panel\Desktop" /v FontSmoothing /t REG_SZ /d 2 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\Control Panel\Desktop" /v UserPreferencesMask /t REG_BINARY /d 9012038010000000 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\Control Panel\Desktop" /v DragFullWindows /t REG_SZ /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\Control Panel\Desktop\WindowMetrics" /v MinAnimate /t REG_SZ /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v ListviewAlphaSelect /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v IconsOnly /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v TaskbarAnimations /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v ListviewShadow /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects" /v VisualFXSetting /t REG_DWORD /d 3 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\DWM" /v EnableAeroPeek /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\DWM" /v AlwaysHibernateThumbnails /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\OperationStatusManager" /v EnthusiastMode /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Classes\CLSID\{e88865ea-0e1c-4e20-9aa6-edcd0212c87c}" /v System.IsPinnedToNameSpaceTree /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v NoResolveSearch /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v NoResolveTrack /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCR\.ps1" /ve /t REG_SZ /d "Microsoft.PowerShellScript.1" /f  
PowerRun.exe cmd.exe /c reg add "HKCR\.ps1\ShellNew" /v NullFile /t REG_SZ /d "" /f  
PowerRun.exe cmd.exe /c reg add "HKCR\Microsoft.PowerShellScript.1" /ve /t REG_SZ /d "Windows PowerShell Script" /f  
PowerRun.exe cmd.exe /c reg add "HKCR\Microsoft.PowerShellScript.1" /v FriendlyTypeName /t REG_SZ /d "Windows PowerShell Script" /f  
PowerRun.exe cmd.exe /c reg add "HKCR\.bat\ShellNew" /v ItemName /t REG_EXPAND_SZ /d "%windir%\System32\acppage.dll,-6002" /f  
PowerRun.exe cmd.exe /c reg add "HKCR\.bat\ShellNew" /v NullFile /t REG_SZ /d "" /f  
PowerRun.exe cmd.exe /c reg delete "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Orchestrator\UScheduler\DevHomeUpdate" /f  
PowerRun.exe cmd.exe /c  "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Orchestrator\UScheduler\OutlookUpdate" /f  
PowerRun.exe cmd.exe /c  "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Orchestrator\Settings" /v STOREBIZCRITICALAPPS /f  
PowerRun.exe cmd.exe /c  "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\InstallService\State\CategoryCache" /v 48caba8a-2e62-2097-dcd8-4255c637b32dUS /f  
PowerRun.exe cmd.exe /c  "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages\Components" /v AccountsService /f  
PowerRun.exe cmd.exe /c  "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages\Components" /v BackupBanner /f  
PowerRun.exe cmd.exe /c  "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages\Components" /v DesktopSpotlight /f  
PowerRun.exe cmd.exe /c  "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages\Components" /v IrisService /f  
PowerRun.exe cmd.exe /c  "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages\Components" /v SystemSettingsExtensions /f  
PowerRun.exe cmd.exe /c  "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages\Components" /v WebExperienceHost /f  
PowerRun.exe cmd.exe /c  "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages\Components" /v WindowsBackup /f  
PowerRun.exe cmd.exe /c  "HKLM\SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\RestrictedServices\AppIso\FirewallRules" /v "{5D2C72C6-969D-4C1E-8484-41ED53782351}" /f  
PowerRun.exe cmd.exe /c  "HKLM\SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\FirewallRules" /v "{26037439-AD8B-4A56-AF2E-F6CDDB59F6BE}" /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Communications" /v ConfigureChatAutoInstall /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate" /v DeferFeatureUpdates /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate" /v DeferFeatureUpdatesPeriodInDays /t REG_DWORD /d 365 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate" /v TargetReleaseVersion /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate" /v BranchReadinessLevel /t REG_DWORD /d 20 /f  
for /f "tokens=2 delims==" %%I in ('wmic os get caption /value ^| findstr /i "caption"') do (
    if "%%I"=="11" (
        set "a=Windows 11"
    ) else (
        set "a=Windows 10"
    )
)
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate" /v ProductVersion /t REG_SZ /d "%a%" /f  
for /f "tokens=2 delims==" %%V in ('reg query "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion" /v DisplayVersion ^| findstr /i "DisplayVersion"') do (
    PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate" /v TargetReleaseVersion /t REG_SZ /d "%%V" /f  
)
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v DisallowShaking /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v NoLowDiskSpaceChecks /t REG_DWORD /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\Control Panel\Desktop" /v HungAppTimeout /t REG_SZ /d 2000 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\Control Panel\Desktop" /v WaitToKillAppTimeOut /t REG_SZ /d 2000 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Control" /v WaitToKillServiceTimeout /t REG_SZ /d 2000 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Serialize" /v StartupDelayInMSec /t REG_DWORD /d 0 /f  
PowerRun.exe cmd.exe /c reg add "HKCU\Control Panel\Desktop" /v AutoEndTasks /t REG_SZ /d 1 /f  
PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager" /v DisableWpbtExecution /t REG_DWORD /d 1 /f  
for %%a in ("CIM_NetworkAdapter", "CIM_USBController", "CIM_VideoController" "Win32_IDEController", "Win32_PnPEntity", "Win32_SoundDevice") do (
    if "%%~a" == "Win32_PnPEntity" (
        for /f "tokens=*" %%b in ('PowerShell -NoP -C "Get-WmiObject -Class Win32_PnPEntity | Where-Object {($_.PNPClass -eq 'SCSIAdapter') -or ($_.Caption -like '*High Definition Audio*')} | Where-Object { $_.PNPDeviceID -like 'PCI\VEN_*' } | Select-Object -ExpandProperty DeviceID"') do (
            PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Enum\%%b\Device Parameters\Interrupt Management\MessageSignaledInterruptProperties" /v "MSISupported" /t REG_DWORD /d "1" /f > nul
            PowerRun.exe cmd.exe /c  "HKLM\SYSTEM\CurrentControlSet\Enum\%%b\Device Parameters\Interrupt Management\Affinity Policy" /v "DevicePriority" /f  
        )
    ) else (
        for /f %%b in ('wmic path %%a get PNPDeviceID ^| findstr /l "PCI\VEN_"') do (
            PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Enum\%%b\Device Parameters\Interrupt Management\MessageSignaledInterruptProperties" /v "MSISupported" /t REG_DWORD /d "1" /f > nul
            PowerRun.exe cmd.exe /c  "HKLM\SYSTEM\CurrentControlSet\Enum\%%b\Device Parameters\Interrupt Management\Affinity Policy" /v "DevicePriority" /f  
        )
    )
)
for %%a in ("hvm", "hyper", "innotek", "kvm", "parallel", "qemu", "virtual", "xen", "vmware") do (
    wmic computersystem get manufacturer /format:value | findstr /i /c:%%~a && (
        for /f %%b in ('wmic path CIM_NetworkAdapter get PNPDeviceID ^| findstr /l "PCI\VEN_"') do (
            PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Enum\%%b\Device Parameters\Interrupt Management\Affinity Policy" /v "DevicePriority" /t REG_DWORD /d "2" /f > nul
        )
    )
)
for /f "delims=" %%a in ('reg query "HKLM\SYSTEM\CurrentControlSet\Services\NetBT\Parameters\Interfaces" /s /f "NetbiosOptions" ^| findstr "HKEY"') do (
    PowerRun.exe cmd.exe /c reg add "%%a" /v "NetbiosOptions" /t REG_DWORD /d "2" /f > nul
)
for /f %%a in ('wmic path Win32_NetworkAdapter get GUID ^| findstr "{"') do (
    PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\%%a" /v "TcpAckFrequency" /t REG_DWORD /d "1" /f > nul
    PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\%%a" /v "TcpDelAckTicks" /t REG_DWORD /d "0" /f > nul
    PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\%%a" /v "TCPNoDelay" /t REG_DWORD /d "1" /f > nul
)
for /f %%a in ('wmic path Win32_NetworkAdapter get PNPDeviceID^| findstr /L "PCI\VEN_"') do (
	for /f "tokens=3" %%b in ('reg query "HKLM\SYSTEM\CurrentControlSet\Enum\%%a" /v "Driver" 2^>nul') do (
        set "netKey=HKLM\SYSTEM\CurrentControlSet\Control\Class\%%b"
    )
)
for %%a in (
    "AdvancedEEE"
    "AlternateSemaphoreDelay"
    "ApCompatMode"
    "ARPOffloadEnable"
    "AutoDisableGigabit"
    "AutoPowerSaveModeEnabled"
    "bAdvancedLPs"
    "bLeisurePs"
    "bLowPowerEnable"
    "DeviceSleepOnDisconnect"
    "DMACoalescing"
    "EEE"
    "EEELinkAdvertisement"
    "EeePhyEnable"
    "Enable9KJFTpt"
    "EnableConnectedPowerGating"
    "EnableDynamicPowerGating"
    "EnableEDT"
    "EnableGreenEthernet"
    "EnableModernStandby"
    "EnablePME"
    "EnablePowerManagement"
    "EnableSavePowerNow"
    "EnableWakeOnLan"
    "FlowControl"
    "FlowControlCap"
    "GigaLite"
    "GPPSW"
    "GTKOffloadEnable"
    "InactivePs"
    "LargeSendOffload"
    "LargeSendOffloadJumboCombo"
    "LogLevelWarn"
    "LsoV1IPv4"
    "LsoV2IPv4"
    "LsoV2IPv6"
    "MasterSlave"
    "ModernStandbyWoLMagicPacket"
    "MPC"
    "NicAutoPowerSaver"
    "Node"
    "NSOffloadEnable"
    "PacketCoalescing"
    "PMWiFiRekeyOffload"
    "PowerDownPll"
    "PowerSaveMode"
    "PowerSavingMode"
    "PriorityVLANTag"
    "ReduceSpeedOnPowerDown"
    "S5WakeOnLan"
    "SavePowerNowEnabled"
    "SelectiveSuspend"
    "SipsEnabled"
    "uAPSDSupport"
    "ULPMode"
    "WaitAutoNegComplete"
    "WakeOnDisconnect"
    "WakeOnLink"
    "WakeOnMagicPacket"
    "WakeOnPattern"
    "WakeOnSlot"
    "WakeUpModeCap"
    "WoWLANLPSLevel"
    "WoWLANS5Support"
) do (
    rem Check without '*'
    for /f %%b in ('reg query "%netKey%" /v "%%~a" 2^>nul ^| findstr "HKEY" 2^>nul') do (
        PowerRun.exe cmd.exe /c reg add "%netKey%" /v "%%~a" /t REG_SZ /d "0" /f > nul
    )
    rem Check with '*'
    for /f %%b in ('reg query "%netKey%" /v "*%%~a" 2^>nul ^| findstr "HKEY" 2^>nul') do (
        PowerRun.exe cmd.exe /c reg add "%netKey%" /v "*%%~a" /t REG_SZ /d "0" /f > nul
    )
)
for /f %%a in ('reg query "HKLM\SYSTEM\CurrentControlSet\Services" /s /f "DmaRemappingCompatible" ^| find /i "Services\" ') do (
    PowerRun.exe cmd.exe /c reg add "%%a" /v "DmaRemappingCompatible" /t REG_DWORD /d "0" /f > nul
)

for %%a in (
    "Documents.mydocs"
    "Mail Recipient.MAPIMail"
) do (
    attrib +h "%APPDATA%\Microsoft\Windows\SendTo\%%~a" > nul
)
del /f /q "%APPDATA%\Microsoft\Windows\SendTo\Fax Recipient.lnk"  
for %%a in ("HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio\Capture", "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio\Render") do (
    for /f "delims=" %%b in ('reg query "%%a"') do (
        PowerRun.exe cmd.exe /c reg add "%%b\Properties" /v "{b3f8fa53-0004-438e-9003-51a46e139bfc},3" /t REG_DWORD /d "0" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\Properties" /v "{b3f8fa53-0004-438e-9003-51a46e139bfc},4" /t REG_DWORD /d "0" /f > nul
    )
)

for %%a in ("HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio\Capture", "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio\Render") do (
    for /f "delims=" %%b in ('reg query "%%a"') do (
        PowerRun.exe cmd.exe /c reg add "%%b\FxProperties" /v "{1da5d803-d492-4edd-8c23-e0c0ffee7f0e},5" /t REG_DWORD /d "1" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\FxProperties" /v "{1b5c2483-0839-4523-ba87-95f89d27bd8c},3" /t REG_BINARY /d "030044CD0100000000000000" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\FxProperties" /v "{73ae880e-8258-4e57-b85f-7daa6b7d5ef0},3" /t REG_BINARY /d "030044CD0100000001000000" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\FxProperties" /v "{9c00eeed-edce-4cd8-ae08-cb05e8ef57a0},3" /t REG_BINARY /d "030044CD0100000004000000" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\FxProperties" /v "{fc52a749-4be9-4510-896e-966ba6525980},3" /t REG_BINARY /d "0B0044CD0100000000000000" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\FxProperties" /v "{ae7f0b2a-96fc-493a-9247-a019f1f701e1},3" /t REG_BINARY /d "0300BC5B0100000001000000" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\FxProperties" /v "{1864a4e0-efc1-45e6-a675-5786cbf3b9f0},4" /t REG_BINARY /d "030044CD0100000000000000" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\FxProperties" /v "{61e8acb9-f04f-4f40-a65f-8f49fab3ba10},4" /t REG_BINARY /d "030044CD0100000050000000" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\Properties" /v "{e4870e26-3cc5-4cd2-ba46-ca0a9a70ed04},0" /t REG_BINARY /d "4100FE6901000000FEFF020080BB000000DC05000800200016002000030000000300000000001000800000AA00389B71" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\Properties" /v "{e4870e26-3cc5-4cd2-ba46-ca0a9a70ed04},1" /t REG_BINARY /d "41008EC901000000A086010000000000" /f > nul
        PowerRun.exe cmd.exe /c reg add "%%b\Properties" /v "{3d6e1656-2e50-4c4c-8d85-d0acae3c6c68},3" /t REG_BINARY /d "4100020001000000FEFF020080BB000000DC05000800200016002000030000000300000000001000800000AA00389B71" /f > nul
        PowerRun.exe cmd.exe /c  "%%b\Properties" /v "{624f56de-fd24-473e-814a-de40aacaed16},3" /f  
        PowerRun.exe cmd.exe /c  "%%b\Properties" /v "{3d6e1656-2e50-4c4c-8d85-d0acae3c6c68},2" /f  
    )
)

:: Detect hard drive - Solid State Drive (SSD) or Hard Disk Drive (HDD)
for /f %%a in ('PowerShell -NoP -C "(Get-PhysicalDisk -SerialNumber (Get-Disk -Number (Get-Partition -DriveLetter $env:SystemDrive.Substring(0, 1)).DiskNumber).SerialNumber.TrimStart()).MediaType"') do (
  set "diskDrive=%%a"
)

if "%diskDrive%" == "SSD" (
    rem Remove lower filters for rdyboost driver
    set "reg_path=HKLM\SYSTEM\CurrentControlSet\Control\Class\{71a27cdd-812a-11d0-bec7-08002be2092f}"
    for /f "skip=1 tokens=3*" %%a in ('reg query "!reg_path!" /v "LowerFilters"') do (set "val=%%a")
    set "val=!val:rdyboost\0=!"
    set "val=!val:\0rdyboost=!"
    set "val=!val:rdyboost=!"
    PowerRun.exe cmd.exe /c reg add "!reg_path!" /v "LowerFilters" /t REG_MULTI_SZ /d "!val!" /f > nul
    PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Services\rdyboost" /v "Start" /t REG_DWORD /d "4" /f > nul
    PowerRun.exe cmd.exe /c  "HKCR\Drive\shellex\PropertySheetHandlers\{55B3A0BD-4D28-42fe-8CFB-FA3EDFF969B8}" /f  
    PowerShell -NoP -C "Disable-MMAGent -MemoryCompression" > nul
    PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Services\SysMain" /v "Start" /t REG_DWORD /d "4" /f > nul
)

powercfg /hibernate off
powercfg /setactive scheme_current
powercfg /duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61 11111111-1111-1111-1111-111111111111 > nul
powercfg /setactive 11111111-1111-1111-1111-111111111111
powercfg /changename scheme_current "WinHubX Power Scheme" "Power scheme optimized for optimal latency and performance."
powercfg /setacvalueindex scheme_current 0012ee47-9041-4b5d-9b77-535fba8b1442 d3d55efd-c1ff-424e-9dc3-441be7833010 0
powercfg /setacvalueindex scheme_current 0012ee47-9041-4b5d-9b77-535fba8b1442 d639518a-e56d-4345-8af2-b9f32fb26109 0
powercfg /setacvalueindex scheme_current 0012ee47-9041-4b5d-9b77-535fba8b1442 fc7372b6-ab2d-43ee-8797-15e9841f2cca 0
powercfg /setacvalueindex scheme_current 0d7dbae2-4294-402a-ba8e-26777e8488cd 309dce9b-bef4-4119-9921-a851fb12f0f4 1
powercfg /setacvalueindex scheme_current 2a737441-1930-4402-8d77-b2bebba308a3 0853a681-27c8-4100-a2fd-82013e970683 0
powercfg /setacvalueindex scheme_current 2a737441-1930-4402-8d77-b2bebba308a3 48e6b7a6-50f5-4782-a5d4-53bb8f07e226 0
powercfg /setacvalueindex scheme_current 2a737441-1930-4402-8d77-b2bebba308a3 d4e98f31-5ffe-4ce1-be31-1b38b384c009 0
powercfg /setacvalueindex scheme_current 54533251-82be-4824-96c1-47b60b740d00 3b04d4fd-1cc7-4f23-ab1c-d1337819c4bb 0
powercfg /setacvalueindex scheme_current 7516b95f-f776-4464-8c53-06167f40cc99 17aaa29b-8b43-4b94-aafe-35f64daaf1ee 0
powercfg /setacvalueindex scheme_current 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 0
powercfg /setacvalueindex scheme_current 54533251-82be-4824-96c1-47b60b740d00 4d2b0152-7d5c-498b-88e2-34345392a2c5 200
powercfg /setactive scheme_current
call C:\Windows\toggleDev.cmd @("ACPI Processor Aggregator", "Microsoft Windows Management Interface for ACPI") > nul
PowerShell -NoP -C "$usb_devices = @('Win32_USBController', 'Win32_USBControllerDevice', 'Win32_USBHub'); $power_device_enable = Get-WmiObject MSPower_DeviceEnable -Namespace root\wmi; foreach ($power_device in $power_device_enable){$instance_name = $power_device.InstanceName.ToUpper(); foreach ($device in $usb_devices){foreach ($hub in Get-WmiObject $device){$pnp_id = $hub.PNPDeviceID; if ($instance_name -like \"*$pnp_id*\"){$power_device.enable = $False; $power_device.psbase.put()}}}}" > nul
for %%a in (
    "AllowIdleIrpInD3"
    "D3ColdSupported"
    "DeviceSelectiveSuspended"
    "EnableIdlePowerManagement"
    "EnableSelectiveSuspend"
    "EnhancedPowerManagementEnabled"
    "IdleInWorkingState"
    "SelectiveSuspendEnabled"
    "SelectiveSuspendOn"
    "WaitWakeEnabled"
    "WakeEnabled"
    "WdfDirectedPowerTransitionEnable"
) do (
    for /f "delims=" %%b in ('reg query "HKLM\SYSTEM\CurrentControlSet\Enum" /s /f "%%~a" ^| findstr "HKEY"') do (
        PowerRun.exe cmd.exe /c reg add "%%b" /v "%%~a" /t REG_DWORD /d "0" /f > nul
    )
)
PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Control\Storage" /v "StorageD3InModernStandby" /t REG_DWORD /d "0" /f > nul
PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Services\stornvme\Parameters\Device" /v "IdlePowerMode" /t REG_DWORD /d "0" /f > nul
PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling" /v "PowerThrottlingOff" /t REG_DWORD /d "1" /f > nul
bcdedit /set disabledynamictick yes > nul
if "%~1" == "/silent"
PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Services\LanmanWorkstation\Parameters" /v "DisableBandwidthThrottling" /t REG_DWORD /d 1 /f
netsh int tcp set supplemental Internet congestionprovider=ctcp
netsh interface Teredo set state type=enterpriseclient
netsh interface Teredo set state servername=default
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile" /v "SystemResponsiveness" /t REG_DWORD /d 10 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance" /v "MaintenanceDisabled" /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\Windows\ScheduledDiagnostics" /v "EnabledExecution" /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications" /v "GlobalUserDisabled" /t REG_DWORD /d 1 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Search" /v "BackgroundAppGlobalToggle" /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\FTH" /v "Enabled" /t REG_DWORD /d 0 /f
if "%PROCESSOR_ARCHITECTURE%"=="AMD64" (
    rundll32.exe fthsvc.dll,FthSysprepSpecialize
)
PowerRun.exe cmd.exe /c reg add "HKCU\System\GameConfigStore" /v "GameDVR_Enabled" /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR" /v "AppCaptureEnabled" /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\GameBar" /v "GamePanelStartupTipIndex" /t REG_DWORD /d 3 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\GameBar" /v "ShowStartupPanel" /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKCU\SOFTWARE\Microsoft\GameBar" /v "UseNexusForGameBarEnabled" /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\GameDVR" /v "AllowGameDVR" /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\PolicyManager\default\ApplicationManagement\AllowGameDVR" /v "value" /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SOFTWARE\Microsoft\WindowsRuntime\ActivatableClassId\Windows.Gaming.GameBar.PresenceServer.Internal.PresenceWriter" /v "ActivationType" /t REG_DWORD /d 0 /f
wevtutil.exe set-log "Microsoft-Windows-SleepStudy/Diagnostic" /e:false
wevtutil.exe set-log "Microsoft-Windows-Kernel-Processor-Power/Diagnostic" /e:false
wevtutil.exe set-log "Microsoft-Windows-UserModePowerService/Diagnostic" /e:false
bcdedit /set bootmenupolicy Legacy
powershell -Command "Get-ChildItem 'HKLM:\SYSTEM\CurrentControlSet\Services' | ? { $_.Name -notmatch 'Xbl|Xbox' } | ForEach-Object { $a = Get-ItemProperty -Path 'REGISTRY::' + $_.PSPath -ErrorAction SilentlyContinue; if ($null -ne $a.Start) { Set-ItemProperty -Path 'REGISTRY::' + $_.PSPath -Name 'SvcHostSplitDisable' -Type DWORD -Value 1 -Force -ErrorAction SilentlyContinue } }"
fsutil behavior set disablelastaccess 1
fsutil behavior set disable8dot3 1
PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Control\PriorityControl" /v "Win32PrioritySeparation" /t REG_DWORD /d 38 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Control\Remote Assistance" /v "fAllowFullControl" /t REG_DWORD /d 0 /f
PowerRun.exe cmd.exe /c reg add "HKLM\SYSTEM\CurrentControlSet\Control\Remote Assistance" /v "fAllowToGetHelp" /t REG_DWORD /d 0 /f
netsh advfirewall firewall set rule group="Remote Assistance" new enable=no
lodctr /r
lodctr /r
winmgmt /resyncperf
)
echo Configuration completed.
sc config wsearch start=auto
timeout 7
