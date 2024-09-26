@echo off
title WinHubX Debloat ISO 11
set "selectedFile=%~1"
set "windowsVersion=%~2"
set "edgeRemovalPreference=%~3"
set "defenderPreference=%~4"
set "ComboSelected=%~5"
set "Processi=%~6"
set "Unattend=%~7"
set "Architettura=%~8"
set "DebloatApp=%~9"

for %%I in ("%selectedFile%") do set "dest_path=%%~dpI"
for /f "tokens=2" %%A in ("%ComboSelected%") do set "index=%%A"

set "index=%ComboSelected%"

dism /cleanup-wim 

:cartellaISO
        if not exist "C:\ISO\WinISO" (
            goto :isofolder
        ) else (
            dism /unmount-image /mountdir:C:\mount\mount /discard >nul 2>&1
            rmdir "C:\ISO\WinISO" /s /q >nul
        )

        :isofolder
        mkdir "C:\ISO\WinISO" >nul
        :winfolder
        if exist "C:\mount\mount" (
            dism /unmount-image /mountdir:C:\mount\mount /discard >nul 2>&1
            rmdir "C:\mount\mount" /s /q >nul
        )
        mkdir "C:\mount\mount" >nul 2>&1
        mkdir "C:\mount\boot" >nul 2>&1


%TEMP%\RisorseCreaISO\7z.exe x -y -o"C:\ISO\WinISO" "%selectedFile%" >nul



IF NOT EXIST "C:\ISO\WinISO\sources\$OEM$\$$\Panther" (
    mkdir "C:\ISO\WinISO\sources\$OEM$\$$\Panther"
)

:checkesdwim
rem check if wim or esd
IF EXIST "C:\ISO\WinISO\sources\install.wim" (
    goto :wim
)

IF EXIST "C:\ISO\WinISO\sources\install.esd" (
    goto :esd
)

:esd
dism /export-image /SourceImageFile:C:\ISO\WinISO\sources\install.esd /SourceIndex:%index% /DestinationImageFile:C:\ISO\WinISO\sources\install.wim /Compress:max /CheckIntegrity 
goto :copy_esd

:wim
dism /Export-Image /SourceImageFile:"C:\ISO\WinISO\sources\install.wim" /SourceIndex:%index% /DestinationImageFile:"C:\ISO\WinISO\sources\install_pro.wim" /compress:max 


:copy_wim

del "C:\ISO\WinISO\sources\install.wim" 


move "C:\ISO\WinISO\sources\install_pro.wim" "C:\ISO\WinISO\sources\install.wim" 
goto :mountwim

:copy_esd

del "C:\ISO\WinISO\sources\install.esd" 

goto :mountwim

:mountwim
dism /mount-image /imagefile:"C:\ISO\WinISO\sources\install.wim" /index:1 /mountdir:"C:\mount\mount" 


:selectunattend
if "%Unattend%"=="Stock" ( goto :stock )
if "%Unattend%"=="Bypass" ( goto :bypass )

:bypass
copy "%TEMP%\RisorseCreaISO\unattend.xml" "C:\ISO\WinISO\sources\$OEM$\$$\Panther\unattend.xml" >nul 2>&1
reg load HKLM\TK_COMPONENTS "C:\mount\mount\Windows\System32\config\COMPONENTS" >nul 2>&1
reg load HKLM\TK_DEFAULT "C:\mount\mount\Windows\System32\config\default" >nul 2>&1
reg load HKLM\TK_NTUSER "C:\mount\mount\Users\Default\ntuser.dat" >nul 2>&1
reg load HKLM\TK_SOFTWARE "C:\mount\mount\Windows\System32\config\SOFTWARE" 
reg load HKLM\TK_SYSTEM "C:\mount\mount\Windows\System32\config\SYSTEM" >nul 2>&1

reg add "HKLM\TK_SOFTWARE\Microsoft\Windows\CurrentVersion\Communications" /v "ConfigureChatAutoInstall" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "OemPreInstalledAppsEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "PreInstalledAppsEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SilentInstalledAppsEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_SOFTWARE\Policies\Microsoft\Windows\CloudContent /v DisableWindowsConsumerFeature" /t REG_DWORD /d 1 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "ContentDeliveryAllowed" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_SOFTWARE\Microsoft\PolicyManager\current\device\Start" /v "ConfigureStartPins" /t REG_SZ /d "{\"pinnedList\": [{}]}" /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "ContentDeliveryAllowed" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "ContentDeliveryAllowed" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "FeatureManagementEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "OemPreInstalledAppsEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "PreInstalledAppsEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "PreInstalledAppsEverEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SilentInstalledAppsEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SoftLandingEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SubscribedContentEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SubscribedContent-310093Enabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SubscribedContent-338388Enabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SubscribedContent-338389Enabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SubscribedContent-338393Enabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SubscribedContent-353694Enabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SubscribedContent-353696Enabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SubscribedContentEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SystemPaneSuggestionsEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_SOFTWARE\Policies\Microsoft\PushToInstall" /v "DisablePushToInstall" /t REG_DWORD /d 1 /f >nul 2>&1
reg add "HKLM\TK_SOFTWARE\Policies\Microsoft\MRT" /v "DontOfferThroughWUAU" /t REG_DWORD /d 1 /f >nul 2>&1
reg delete "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager\Subscriptions" /f >nul 2>&1
reg delete "HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager\SuggestedApps" /f >nul 2>&1
reg add "HKLM\TK_SOFTWARE\Policies\Microsoft\Windows\CloudContent" /v "DisableConsumerAccountStateContent" /t REG_DWORD /d 1 /f >nul 2>&1
reg add "HKLM\TK_SOFTWARE\Policies\Microsoft\Windows\CloudContent" /v "DisableCloudOptimizedContent" /t REG_DWORD /d 1 /f >nul 2>&1
reg add "HKLM\TK_SOFTWARE\Microsoft\Windows\CurrentVersion\ReserveManager" /v "ShippedWithReserves" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKLM\TK_SOFTWARE\Policies\Microsoft\Windows\Windows Chat" /v "ChatIcon" /t REG_DWORD /d 3 /f >nul 2>&1
reg add "HKLM\TK_NTUSER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "TaskbarMn" /t REG_DWORD /d 0 /f >nul 2>&1
Reg add "HKLM\TK_DEFAULT\Control Panel\UnsupportedHardwareNotificationCache" /v "SV1" /t REG_DWORD /d "0" /f >nul 2>&1
Reg add "HKLM\TK_DEFAULT\Control Panel\UnsupportedHardwareNotificationCache" /v "SV2" /t REG_DWORD /d "0" /f >nul 2>&1
Reg add "HKLM\TK_NTUSER\Control Panel\UnsupportedHardwareNotificationCache" /v "SV1" /t REG_DWORD /d "0" /f  >nul 2>&1
Reg add "HKLM\TK_NTUSER\Control Panel\UnsupportedHardwareNotificationCache" /v "SV2" /t REG_DWORD /d "0" /f  >nul 2>&1
Reg add "HKLM\TK_SYSTEM\Setup\LabConfig" /v "BypassCPUCheck" /t REG_DWORD /d "1" /f >nul 2>&1
Reg add "HKLM\TK_SYSTEM\Setup\LabConfig" /v "BypassRAMCheck" /t REG_DWORD /d "1" /f  >nul 2>&1
Reg add "HKLM\TK_SYSTEM\Setup\LabConfig" /v "BypassSecureBootCheck" /t REG_DWORD /d "1" /f  >nul 2>&1
Reg add "HKLM\TK_SYSTEM\Setup\LabConfig" /v "BypassStorageCheck" /t REG_DWORD /d "1" /f  >nul 2>&1
Reg add "HKLM\TK_SYSTEM\Setup\LabConfig" /v "BypassTPMCheck" /t REG_DWORD /d "1" /f  >nul 2>&1
Reg add "HKLM\TK_SYSTEM\Setup\MoSetup" /v "AllowUpgradesWithUnsupportedTPMOrCPU" /t REG_DWORD /d "1" /f >nul 2>&1
Reg add "HKLM\TK_SOFTWARE\Microsoft\Windows\CurrentVersion\OOBE" /v "BypassNRO" /t REG_DWORD /d "1" /f >nul 2>&1
reg unload HKLM\TK_COMPONENTS >nul 2>&1
reg unload HKLM\TK_DEFAULT >nul 2>&1
reg unload HKLM\TK_DRIVERS >nul 2>&1
reg unload HKLM\TK_NTUSER >nul 2>&1
reg unload HKLM\TK_SCHEMA >nul 2>&1
reg unload HKLM\TK_SOFTWARE >nul 2>&1
reg unload HKLM\TK_SYSTEM >nul 2>&1
dism /mount-image /imagefile:"C:\ISO\WinISO\sources\boot.wim" /index:2 /mountdir:"C:\mount\boot" >nul 2>&1
	Reg load "HKLM\TK_BOOT_SYSTEM" "C:\mount\boot\Windows\System32\Config\SYSTEM" >nul 2>&1
	Reg add "HKLM\TK_BOOT_SYSTEM\Setup\LabConfig" /v "BypassCPUCheck" /t REG_DWORD /d "1" /f >nul 2>&1
	Reg add "HKLM\TK_BOOT_SYSTEM\Setup\LabConfig" /v "BypassRAMCheck" /t REG_DWORD /d "1" /f >nul 2>&1
	Reg add "HKLM\TK_BOOT_SYSTEM\Setup\LabConfig" /v "BypassSecureBootCheck" /t REG_DWORD /d "1" /f >nul 2>&1
	Reg add "HKLM\TK_BOOT_SYSTEM\Setup\LabConfig" /v "BypassStorageCheck" /t REG_DWORD /d "1" /f >nul 2>&1
	Reg add "HKLM\TK_BOOT_SYSTEM\Setup\LabConfig" /v "BypassTPMCheck" /t REG_DWORD /d "1" /f >nul 2>&1
	Reg unload "HKLM\TK_BOOT_SYSTEM" >nul 2>&1
  move "C:\ISO\WinISO\sources\appraiserres.dll" "C:\ISO\WinISO\sources\appraiserres.dll.bak" >nul 2>&1
  dism /unmount-image /mountdir:"C:\mount\boot" /commit
goto :menuprincipale

:stock
copy "%TEMP%\RisorseCreaISO\unattendstock.xml" "C:\ISO\WinISO\sources\$OEM$\$$\Panther\unattend.xml"
goto :menuprincipale


:menuprincipale
:edge
if "%edgeRemovalPreference%"=="RemoveEdge" (
echo > C:\mount\mount\Windows\noedge.pref
copy "%TEMP%\RisorseCreaISO\OperaGXSetup.exe" "C:\mount\mount\Windows"
copy "%TEMP%\RisorseCreaISO\PowerRun.exe" "C:\mount\mount\Windows"
)

if "%DebloatApp%"=="Debloat" (
  echo > C:\mount\mount\Windows\debloatapp.pref
)


if "%defenderPreference%"=="DisableWindowsDefender" (
echo > C:\mount\mount\Windows\nodefender.pref
copy "%TEMP%\RisorseCreaISO\PowerRun.exe" "C:\mount\mount\Windows"
)

if "%Processi%"=="RimuoviProcessi" (
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-InternetExplorer-Optional-Package*'} | ForEach-Object {dism /English /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-Kernel-LA57-FoD*'} | ForEach-Object {dism /English /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-Handwriting*'} | ForEach-Object {dism /English /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-OCR*'} | ForEach-Object {dism /English /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-Speech*'} | ForEach-Object {dism /English /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-TextToSpeech*'} | ForEach-Object {dism /English /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-MediaPlayer-Package*'} | ForEach-Object {dism /English /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-TabletPCMath-Package*'} | ForEach-Object {dism /English /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-Wallpaper-Content-Extended-FoD*'} | ForEach-Object {dism /English /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
)

copy "%TEMP%\RisorseCreaISO\tweaks.bat" "C:\mount\mount\Windows"
copy "%TEMP%\RisorseCreaISO\lower-ram-usage.reg" "C:\mount\mount\Windows"
copy "%TEMP%\RisorseCreaISO\start.ps1" "C:\mount\mount\Windows"
copy "%TEMP%\RisorseCreaISO\PowerRun.exe" "C:\mount\mount\Windows"

dism /unmount-image /mountdir:"C:\mount\mount" /commit




:wimre
%TEMP%\RisorseCreaISO\oscdimg -m -o -u2 -bootdata:2#p0,e,bC:\ISO\WinISO\boot\etfsboot.com#pEF,e,bC:\ISO\WinISO\efi\microsoft\boot\efisys.bin C:\ISO\WinISO C:\ISO\WindowsISO_edited.iso >nul 2>&1
copy "C:\ISO\WindowsISO_edited.iso" "C:\"
rmdir "C:\ISO" /s /q 
rmdir "C:\mount" /s /q 

powerShell -Command "Write-Host 'Processo completato troverai la tua ISO in C: chimata WindowsISO_edited!' -ForegroundColor Green; exit"
timeout 7
endlocal
exit
::##################################################################################################################################################