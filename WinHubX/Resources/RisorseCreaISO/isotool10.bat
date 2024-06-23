@echo off
title WinHubX Debloat ISO 10

set "selectedFile=%~1"
set "windowsVersion=%~2"
set "edgeRemovalPreference=%~3"
set "defenderPreference=%~4"
set "windowsEdition=%~5"
set "Processi=%~6"
set "Unattend=%~7"
set "Architettura=%~8"
set "DebloatApp=%~9"

for %%I in ("%selectedFile%") do set "dest_path=%%~dpI"

for /f "tokens=2" %%A in ("%windowsEdition%") do set "index=%%A"



:cartellaISO1
call :initProgressBar 
for /l %%f in (0, 1, 100) do (
    call :drawProgressBar %%f "Preparazione in corso"
        if not exist "C:\ISO\WinISO" (
            goto :isofolder
        ) else (
            dism /unmount-image /mountdir:C:\mount\mount /discard /Quiet >nul 2>&1 
            rmdir "C:\ISO\WinISO" /s /q >nul
        )

        :isofolder
        mkdir "C:\ISO\WinISO" >nul 2>&1

        :winfolder
        if exist "C:\mount\mount" (
            dism /unmount-image /mountdir:C:\mount\mount /discard /Quiet >nul 2>&1 
            rmdir "C:\mount\mount" /s /q >nul 2>&1
        )
        mkdir "C:\mount\mount" >nul 2>&1
)

:iso1
for /l %%f in (0, 1, 100) do (
call :drawProgressBar %%f "Preparo la iso"
%TEMP%\RisorseCreaISO\7z.exe x -y -o"C:\ISO\WinISO" "%selectedFile%" > nul
)

IF NOT EXIST "C:\ISO\WinISO\sources\$OEM$\$$\Panther" (
    mkdir "C:\ISO\WinISO\sources\$OEM$\$$\Panther"
)

rem copy unattended.xml
if "%Architettura%"=="x64" (
 copy "%TEMP%\RisorseCreaISO\unattend10.xml" "C:\ISO\WinISO\sources\$OEM$\$$\Panther\unattend.xml" >nul 2>&1
) else (
 copy "%TEMP%\RisorseCreaISO\unattendx32.xml" "C:\ISO\WinISO\sources\$OEM$\$$\Panther\unattend.xml" >nul 2>&1
)

rem check if wim or esd
IF EXIST "C:\ISO\WinISO\sources\install.wim" (
    goto :wim1
)

IF EXIST "C:\ISO\WinISO\sources\install.esd" (
    goto :esd1
)

:esd1
for /l %%f in (0, 1, 100) do (
call :drawProgressBar %%f "Converto l'install.esd"
dism /export-image /SourceImageFile:C:\ISO\WinISO\sources\install.esd /SourceIndex:%index% /DestinationImageFile:C:\ISO\WinISO\sources\install.wim /Compress:max /CheckIntegrity /Quiet >nul 2>&1
)
goto :copy_esd1

:wim1

for /l %%f in (0 1 100) do (
  call :drawProgressBar %%f "Estraggo l'indice"
dism /Export-Image /SourceImageFile:"C:\ISO\WinISO\sources\install.wim" /SourceIndex:%index% /DestinationImageFile:"C:\ISO\WinISO\sources\install_pro.wim" /compress:max /Quiet >nul 2>&1
)

:copy_wim1
del "C:\ISO\WinISO\sources\install.wim" >nul 2>&1 


move "C:\ISO\WinISO\sources\install_pro.wim" "C:\ISO\WinISO\sources\install.wim" >nul 2>&1
goto :mountwim1


:copy_esd1
del "C:\ISO\WinISO\sources\install.esd" >nul 2>&1
goto :mountwim1

:mountwim1
for /l %%f in (0 1 100) do (
  call :drawProgressBar %%f "Monto la iso"
dism /mount-image /imagefile:"C:\ISO\WinISO\sources\install.wim" /index:1 /mountdir:"C:\mount\mount" /Quiet >nul 2>&1
)
goto :menuprincipalee1

rem menuprincipale
:menuprincipalee1
for /l %%f in (0 1 100) do (
  call :drawProgressBar %%f "Abilito l'account locale"
reg load HKLM\TK_SOFTWARE "C:\mount\mount\Windows\System32\config\SOFTWARE"  >nul 2>&1
Reg add "HKLM\TK_SOFTWARE\Microsoft\Windows\CurrentVersion\OOBE" /v "BypassNRO" /t REG_DWORD /d "1" /f >nul 2>&1
reg unload HKLM\TK_SOFTWARE >nul 2>&1
)

for /l %%f in (0 1 100) do (
  call :drawProgressBar %%f "Inizio modifiche"
if "%edgeRemovalPreference%"=="RemoveEdge" (
echo > C:\mount\mount\Windows\noedge.pref
copy "%TEMP%\RisorseCreaISO\OperaGXSetup.exe" "C:\mount\mount" >nul 2>&1
copy "%TEMP%\RisorseCreaISO\PowerRun.exe" "C:\mount\mount\Windows" >nul 2>&1
)

if "%DebloatApp%"=="Debloat" (
  echo > C:\mount\mount\Windows\debloatapp.pref
)



if "%defenderPreference%"=="DisableWindowsDefender" (
echo > C:\mount\mount\Windows\nodefender.pref 
copy "%TEMP%\RisorseCreaISO\PowerRun.exe" "C:\mount\mount\Windows" >nul 2>&1
)

if "%Processi%"=="RimuoviProcessi" (
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-InternetExplorer-Optional-Package*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-Kernel-LA57-FoD*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-Handwriting*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-OCR*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-Speech*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-TextToSpeech*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-MediaPlayer-Package*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-TabletPCMath-Package*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-Wallpaper-Content-Extended-FoD*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"

)

:tweaksbatt10
copy "%TEMP%\RisorseCreaISO\tweaks10.bat" "C:\mount\mount\Windows" >nul 2>&1
copy "%TEMP%\RisorseCreaISO\start10.ps1" "C:\mount\mount\Windows" >nul 2>&1
copy "%TEMP%\RisorseCreaISO\lower-ram-usage.reg" "C:\mount\mount\Windows" >nul 2>&1
copy "%TEMP%\RisorseCreaISO\WinHubX.exe" "C:\mount\mount\Windows" >nul 2>&1
copy "%TEMP%\RisorseCreaISO\unpin_start_tiles.ps1" "C:\mount\mount\Windows" >nul 2>&1
copy "%TEMP%\RisorseCreaISO\PowerRun.exe" "C:\mount\mount\Windows" >nul 2>&1
copy "%TEMP%\RisorseCreaISO\[AIMODS]-Store.exe" "C:\mount\mount\Windows" >nul 2>&1
)
:fine1

for /l %%f in (0 1 100) do (
  call :drawProgressBar %%f "Salvataggio ISO"
dism /unmount-image /mountdir:"C:\mount\mount" /commit /Quiet >nul 2>&1
)

:wimre
for /l %%f in (0 1 100) do (
  call :drawProgressBar %%f "Ricreo la iso"
%TEMP%\RisorseCreaISO\oscdimg -m -o -u2 -bootdata:2#p0,e,bC:\ISO\WinISO\boot\etfsboot.com#pEF,e,bC:\ISO\WinISO\efi\microsoft\boot\efisys.bin C:\ISO\WinISO C:\ISO\WindowsISO_edited.iso >nul 2>&1
copy "C:\ISO\WindowsISO_edited.iso" "C:\" >nul 2>&1
rmdir "C:\ISO" /s /q >nul 2>&1
rmdir "C:\mount" /s /q >nul 2>&1
)
call :finalizeProgressBar 1

powerShell -Command "Write-Host 'Processo completato troverai la tua ISO in C: chimata WindowsISO_edited!' -ForegroundColor Green; exit"
timeout 7
endlocal
exit
::##################################################################################################################################################
:drawProgressBar
    if "%~1"=="" goto :eof
    if not defined pb.barArea call :initProgressBar
    setlocal enableextensions enabledelayedexpansion
    set /a "pb.value=%~1 %% 101", "pb.filled=pb.value*pb.barArea/100", "pb.dotted=pb.barArea-pb.filled", "pb.pct=1000+pb.value"
    set "pb.pct=%pb.pct:~-3%"
    if "%~2"=="" ( set "pb.text=" ) else ( 
        set "pb.text=%~2%pb.back%" 
        set "pb.text=!pb.text:~0,%pb.textArea%!"
    )
    <nul set /p "pb.prompt=[!pb.fill:~0,%pb.filled%!!pb.dots:~0,%pb.dotted%!][ %pb.pct% ] %pb.text%!pb.cr!"
    endlocal
    goto :eof

:initProgressBar
    if defined pb.cr call :finalizeProgressBar
    for /f %%a in ('copy "%~f0" nul /z') do set "pb.cr=%%a"
    if "%~1"=="" ( set "pb.fillChar=#" ) else ( set "pb.fillChar=%~1" )
    if "%~2"=="" ( set "pb.dotChar=." ) else ( set "pb.dotChar=%~2" )
    set "pb.console.columns="
    for /f "tokens=2 skip=4" %%f in ('mode con') do if not defined pb.console.columns set "pb.console.columns=%%f"
    set /a "pb.barArea=pb.console.columns/2-2", "pb.textArea=pb.barArea-9"
    set "pb.fill="
    setlocal enableextensions enabledelayedexpansion
    for /l %%p in (1 1 %pb.barArea%) do set "pb.fill=!pb.fill!%pb.fillChar%"
    set "pb.fill=!pb.fill:~0,%pb.barArea%!"
    set "pb.dots=!pb.fill:%pb.fillChar%=%pb.dotChar%!"
    set "pb.back=!pb.fill:~0,%pb.textArea%!
    set "pb.back=!pb.back:%pb.fillChar%= !"
    endlocal & set "pb.fill=%pb.fill%" & set "pb.dots=%pb.dots%" & set "pb.back=%pb.back%"
    goto :eof

:finalizeProgressBar
    if defined pb.cr (
        if not "%~1"=="" (
            setlocal enabledelayedexpansion
            set "pb.back="
            for /l %%p in (1 1 %pb.console.columns%) do set "pb.back=!pb.back! "
            <nul set /p "pb.prompt=!pb.cr!!pb.back:~1!!pb.cr!"
            endlocal
        )
    )
    for /f "tokens=1 delims==" %%v in ('set pb.') do set "%%v="
    goto :eof