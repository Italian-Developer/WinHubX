@echo off
title WinHubX Debloat ISO 10

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

:cartellaISO1
        if not exist "C:\ISO\WinISO" (
            goto :isofolder
        ) else (
            dism /unmount-image /mountdir:C:\mount\mount /discard >nul 2>&1
            rmdir "C:\ISO\WinISO" /s /q >nul
        )

        :isofolder
        mkdir "C:\ISO\WinISO" 

        :winfolder
        if exist "C:\mount\mount" (
            dism /unmount-image /mountdir:C:\mount\mount /discard >nul 2>&1
            rmdir "C:\mount\mount" /s /q >nul
        )
        mkdir "C:\mount\mount" 

:iso1
 %TEMP%\RisorseCreaISO\7z.exe x -y -o"C:\ISO\WinISO" "%selectedFile%" > nul


IF NOT EXIST "C:\ISO\WinISO\sources\$OEM$\$$\Panther" (
    mkdir "C:\ISO\WinISO\sources\$OEM$\$$\Panther"
)

rem copy unattended.xml
if "%Architettura%"=="x64" (
 copy "%TEMP%\RisorseCreaISO\unattend10.xml" "C:\ISO\WinISO\sources\$OEM$\$$\Panther\unattend.xml" 
) else (
 copy "%TEMP%\RisorseCreaISO\unattendx32.xml" "C:\ISO\WinISO\sources\$OEM$\$$\Panther\unattend.xml" 
)

rem check if wim or esd
IF EXIST "C:\ISO\WinISO\sources\install.wim" (
goto :wim1
)

IF EXIST "C:\ISO\WinISO\sources\install.esd" (
goto :esd1
)

:esd1
dism /export-image /SourceImageFile:C:\ISO\WinISO\sources\install.esd /SourceIndex:%index% /DestinationImageFile:C:\ISO\WinISO\sources\install.wim /Compress:max /CheckIntegrity 
goto :copy_esd1

:wim1
dism /Export-Image /SourceImageFile:"C:\ISO\WinISO\sources\install.wim" /SourceIndex:%index% /DestinationImageFile:"C:\ISO\WinISO\sources\install_pro.wim" /compress:max 


:copy_wim1
del "C:\ISO\WinISO\sources\install.wim"  


move "C:\ISO\WinISO\sources\install_pro.wim" "C:\ISO\WinISO\sources\install.wim" 
goto :mountwim1


:copy_esd1
del "C:\ISO\WinISO\sources\install.esd" 
goto :mountwim1

:mountwim1
dism /mount-image /imagefile:"C:\ISO\WinISO\sources\install.wim" /index:1 /mountdir:"C:\mount\mount"

goto :menuprincipalee1

:menuprincipalee1
reg load HKLM\TK_SOFTWARE "C:\mount\mount\Windows\System32\config\SOFTWARE"  
Reg add "HKLM\TK_SOFTWARE\Microsoft\Windows\CurrentVersion\OOBE" /v "BypassNRO" /t REG_DWORD /d "1" /f 
reg unload HKLM\TK_SOFTWARE 


if "%edgeRemovalPreference%"=="RemoveEdge" (
echo > C:\mount\mount\Windows\noedge.pref
copy "%TEMP%\RisorseCreaISO\OperaGXSetup.exe" "C:\mount\mount" 
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

:tweaksbatt10
copy "%TEMP%\RisorseCreaISO\tweaks10.bat" "C:\mount\mount\Windows"
copy "%TEMP%\RisorseCreaISO\start10.ps1" "C:\mount\mount\Windows" 
copy "%TEMP%\RisorseCreaISO\lower-ram-usage.reg" "C:\mount\mount\Windows"
copy "%TEMP%\RisorseCreaISO\unpin_start_tiles.ps1" "C:\mount\mount\Windows"
copy "%TEMP%\RisorseCreaISO\PowerRun.exe" "C:\mount\mount\Windows"

dism /unmount-image /mountdir:"C:\mount\mount" /commit


:wimre
%TEMP%\RisorseCreaISO\oscdimg -m -o -u2 -bootdata:2#p0,e,bC:\ISO\WinISO\boot\etfsboot.com#pEF,e,bC:\ISO\WinISO\efi\microsoft\boot\efisys.bin C:\ISO\WinISO C:\ISO\WindowsISO_edited.iso 
copy "C:\ISO\WindowsISO_edited.iso" "C:\" 
rmdir "C:\ISO" /s /q 
rmdir "C:\mount" /s /q 

powerShell -Command "Write-Host 'Processo completato troverai la tua ISO in C: chimata WindowsISO_edited!' -ForegroundColor Green; exit"
timeout 7
endlocal
exit
::##################################################################################################################################################
