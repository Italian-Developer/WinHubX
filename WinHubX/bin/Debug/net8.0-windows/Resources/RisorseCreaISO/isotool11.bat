@echo off

rem Extracting arguments
set "selectedFile=%~1"
set "windowsVersion=%~2"
set "edgeRemovalPreference=%~3"
set "defenderPreference=%~4"
set "windowsEdition=%~5"
set "Processi=%~6"
set "Unattend=%~7"
set "OttimizzaSO=%~8"
set "DebloatApp=%~9"

for %%I in ("%selectedFile%") do set "dest_path=%%~dpI"

rem export windows edition
if "%windowsEdition%"=="Home" (
    set "index=1"
) else (
    set "index=5"
)

title WinHubX Debloat ISO 11

rem verifica cartelle
:cartellaISO
cls
color 02
IF NOT EXIST "C:\ISO\WinISO" ( goto :isofolder )
IF EXIST "C:\ISO\WinISO" ( 
    echo "ERRORE: C\ISO\WinISO esiste gia', elimina la cartella? si,no"
    goto :domande )

:domande
SET /P answer=":" 
IF /I '%answer%'=='si' GOTO :eliminacartella
IF /I '%answer%'=='no' GOTO :winfolder

:eliminacartella
echo Elimino la cartella, attendi...
dism /unmount-image /mountdir:C:\mount\mount /discard >NUL
rmdir "C:\ISO\WinISO" /s /q
goto :cartellaISO

:isofolder
cls 
mkdir "C:\ISO\WinISO"

:winfolder
color 02
IF EXIST "C:\mount\mount" (
    dism /unmount-image /mountdir:C:\mount\mount /discard >NUL
    rmdir "C:\mount\mount" /s /q
)
mkdir "C:\mount\mount"

:iso
cls
rem estraggo iso
powerShell -Command "Write-Host 'Sto estraendo la iso in C:\ISO\WinISO... Attendi!' -ForegroundColor Green; exit"  
Risorse\7z.exe x -y -o"C:\ISO\WinISO" "%selectedFile%" > nul
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'Estrazione della ISO completata!' -ForegroundColor Green; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Estrazione fallita!" && pause && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)

IF NOT EXIST "C:\ISO\WinISO\sources\$OEM$\$$\Panther" (
    mkdir "C:\ISO\WinISO\sources\$OEM$\$$\Panther"
)

:checkesdwim
cls
rem check if wim or esd
IF EXIST "C:\ISO\WinISO\sources\install.wim" (
    goto :wim
)

IF EXIST "C:\ISO\WinISO\sources\install.esd" (
    goto :esd
)

:esd
cls
powerShell -Command "Write-Host 'Attendi' -ForegroundColor white; exit"
dism /export-image /SourceImageFile:C:\ISO\WinISO\sources\install.esd /SourceIndex:%index% /DestinationImageFile:C:\ISO\WinISO\sources\install.wim /Compress:max /CheckIntegrity
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'Immagine esportata con successo!' -ForegroundColor Green; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile esportare l''immagine!" && pause && del "resources\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)
goto :copy_esd

:wim
cls
rem export windows edition
powerShell -Command "Write-Host 'Attendi' -ForegroundColor 7; exit"  
dism /Export-Image /SourceImageFile:"C:\ISO\WinISO\sources\install.wim" /SourceIndex:%index% /DestinationImageFile:"C:\ISO\WinISO\sources\install_pro.wim" /compress:max
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'Immagine esportata con successo!' -ForegroundColor 7; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile esportare l''immagine!" && pause && del "Risorse\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)

:copy_wim
cls
rem copy the new install.wim
del "C:\ISO\WinISO\sources\install.wim"
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'Old install.wim eliminato!' -ForegroundColor 7; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile eliminare old install.wim!" && pause && del "Risorse\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)

move "C:\ISO\WinISO\sources\install_pro.wim" "C:\ISO\WinISO\sources\install.wim"
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'Il nuovo install.wim e'' stato spostato con successo!' -ForegroundColor 7; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile spostare il nuovo install.wim!" && pause && del "Risorse\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)
goto :mountwim

rem copy the new install.esd
:copy_esd
cls
del "C:\ISO\WinISO\sources\install.esd"
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'Old install.esd eliminato!' -ForegroundColor Green; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile eliminare old install.esd!" && pause && del "resources\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)
goto :mountwim

:mountwim
rem mount the image with dism
powerShell -Command "Write-Host 'Sto montando l''immagine' -ForegroundColor 7; exit"  
dism /mount-image /imagefile:"C:\ISO\WinISO\sources\install.wim" /index:1 /mountdir:"C:\mount\mount"
cls

rem ISO bypass
:selectunattend
if "%Unattend%"=="Stock" ( goto :stock )
else if "%Unattend%"=="Bypass" ( goto :bypass )

:bypass
rem copy unattended.xml
copy "Risorse\unattend.xml" "C:\ISO\WinISO\sources\$OEM$\$$\Panther\unattend.xml"
reg load HKLM\TK_COMPONENTS "C:\mount\mount\Windows\System32\config\COMPONENTS"
reg load HKLM\TK_DEFAULT "C:\mount\mount\Windows\System32\config\default" 
reg load HKLM\TK_NTUSER "C:\mount\mount\Users\Default\ntuser.dat"
reg load HKLM\TK_SOFTWARE "C:\mount\mount\Windows\System32\config\SOFTWARE" 
reg load HKLM\TK_SYSTEM "C:\mount\mount\Windows\System32\config\SYSTEM" 
			Reg add "HKLM\TK_DEFAULT\Control Panel\UnsupportedHardwareNotificationCache" /v "SV1" /t REG_DWORD /d "0" /f
			Reg add "HKLM\TK_DEFAULT\Control Panel\UnsupportedHardwareNotificationCache" /v "SV2" /t REG_DWORD /d "0" /f 
			Reg add "HKLM\TK_NTUSER\Control Panel\UnsupportedHardwareNotificationCache" /v "SV1" /t REG_DWORD /d "0" /f 
			Reg add "HKLM\TK_NTUSER\Control Panel\UnsupportedHardwareNotificationCache" /v "SV2" /t REG_DWORD /d "0" /f 
			Reg add "HKLM\TK_SYSTEM\Setup\LabConfig" /v "BypassCPUCheck" /t REG_DWORD /d "1" /f
			Reg add "HKLM\TK_SYSTEM\Setup\LabConfig" /v "BypassRAMCheck" /t REG_DWORD /d "1" /f 
			Reg add "HKLM\TK_SYSTEM\Setup\LabConfig" /v "BypassSecureBootCheck" /t REG_DWORD /d "1" /f 
			Reg add "HKLM\TK_SYSTEM\Setup\LabConfig" /v "BypassStorageCheck" /t REG_DWORD /d "1" /f 
			Reg add "HKLM\TK_SYSTEM\Setup\LabConfig" /v "BypassTPMCheck" /t REG_DWORD /d "1" /f 
			Reg add "HKLM\TK_SYSTEM\Setup\MoSetup" /v "AllowUpgradesWithUnsupportedTPMOrCPU" /t REG_DWORD /d "1" /f
reg unload HKLM\TK_COMPONENTS 
reg unload HKLM\TK_DEFAULT 
reg unload HKLM\TK_DRIVERS 
reg unload HKLM\TK_NTUSER 
reg unload HKLM\TK_SCHEMA 
reg unload HKLM\TK_SOFTWARE 
reg unload HKLM\TK_SYSTEM 

mkdir "C:\mount\boot"
dism /mount-image /imagefile:"C:\ISO\WinISO\sources\boot.wim" /index:2 /mountdir:"C:\mount\boot"
	Reg load "HKLM\TK_BOOT_SYSTEM" "C:\mount\boot\Windows\System32\Config\SYSTEM" 
	Reg add "HKLM\TK_BOOT_SYSTEM\Setup\LabConfig" /v "BypassCPUCheck" /t REG_DWORD /d "1" /f 
	Reg add "HKLM\TK_BOOT_SYSTEM\Setup\LabConfig" /v "BypassRAMCheck" /t REG_DWORD /d "1" /f 
	Reg add "HKLM\TK_BOOT_SYSTEM\Setup\LabConfig" /v "BypassSecureBootCheck" /t REG_DWORD /d "1" /f 
	Reg add "HKLM\TK_BOOT_SYSTEM\Setup\LabConfig" /v "BypassStorageCheck" /t REG_DWORD /d "1" /f 
	Reg add "HKLM\TK_BOOT_SYSTEM\Setup\LabConfig" /v "BypassTPMCheck" /t REG_DWORD /d "1" /f 
	Reg unload "HKLM\TK_BOOT_SYSTEM" 
  move "C:\ISO\WinISO\sources\appraiserres.dll" "C:\ISO\WinISO\sources\appraiserres.dll.bak"
  dism /unmount-image /mountdir:"C:\mount\boot" /commit
cls
goto :menuprincipale

:stock
cls
rem copy unattended.xml
copy "Risorse\unattendstock.xml" "C:\ISO\WinISO\sources\$OEM$\$$\Panther\unattend.xml"
goto :menuprincipale

cls
rem menuprincipale
:menuprincipale
cls

rem delete edge
:edge
cls
if "%edgeRemovalPreference%"=="RemoveEdge" (
echo > C:\mount\mount\Windows\noedge.pref
copy "Risorse\OperaGXSetup.exe" "C:\mount\mount\Windows"
copy "Risorse\PowerRun.exe" "C:\mount\mount\Windows"
)

if "%OttimizzaSO%"=="Ottimizza" (
  echo > C:\mount\mount\Windows\ottimizza.pref
)

if "%DebloatApp%"=="Debloat" (
  echo > C:\mount\mount\Windows\debloatapp.pref
)

rem disable defender
cls
if "%defenderPreference%"=="DisableWindowsDefender" (
echo > C:\mount\mount\Windows\nodefender.pref
copy "Risorse\PowerRun.exe" "C:\mount\mount\Windows"
)

if "%Processi%"=="RimuoviProcessi" (
powerShell -Command "Write-Host 'Iniziamo la rimozione...' -ForegroundColor Green; exit"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-InternetExplorer-Optional-Package*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-Kernel-LA57-FoD*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-Handwriting*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-OCR*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-Speech*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-TextToSpeech*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-MediaPlayer-Package*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-TabletPCMath-Package*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powershell -Command "Get-WindowsPackage -Path 'C:\mount\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-Wallpaper-Content-Extended-FoD*'} | ForEach-Object {dism /image:C:\mount\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}"
powerShell -Command "Write-Host 'Completato' -ForegroundColor Green; exit"
)

rem copy 
copy "Risorse\tweaks.bat" "C:\mount\mount\Windows"
copy "Risorse\WinCustomizerDebloat3.0.ps1" "C:\mount\mount\Windows"
copy "Risorse\lower-ram-usage.reg" "C:\mount\mount\Windows"
copy "Risorse\start.ps1" "C:\mount\mount\Windows"
copy "Risorse\WinCustomizerAttivatore.bat" "C:\mount\mount\Windows"
copy "Risorse\WinCustomizerStartDebloat.bat" "C:\mount\mount\Windows"



:fine
cls
rem unmount the image
powerShell -Command "Write-Host 'Smontando l''immagine' -ForegroundColor 7; exit" 
dism /unmount-image /mountdir:"C:\mount\mount" /commit

:wimre
cls
powerShell -Command "Write-Host 'Creando la ISO' -ForegroundColor 7; exit"  
Risorse\oscdimg -m -o -u2 -bootdata:2#p0,e,bC:\ISO\WinISO\boot\etfsboot.com#pEF,e,bC:\ISO\WinISO\efi\microsoft\boot\efisys.bin C:\ISO\WinISO C:\ISO\WindowsISO_edited.iso
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'ISO creata con successo!' -ForegroundColor 7; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile creare la ISO!" && pause && del "Risorse\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)

rem copy the iso and clean
cls
copy "C:\ISO\WindowsISO_edited.iso" "C:\"
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'ISO copiata con successo!' -ForegroundColor 7; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile copiare la ISO in C!" && pause && del "Risorse\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)

rmdir "C:\ISO" /s /q
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'La directory1 usata per la creazione della ISO e'' stata eliminata con successo!' -ForegroundColor 7; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile eliminare la directory1 usata per la creazione della ISO!" && pause && del "Risorsenattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)

rmdir "C:\mount" /s /q
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'La directory2 usata per la creazione della ISO e'' stata eliminata con successo!' -ForegroundColor 7; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile eliminare la directory2 usatq per la creazione della ISO!" && pause && del "Risorse\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)

powerShell -Command "Write-Host 'Processo completato troverari la tua ISO in C:! -ForegroundColor Green; exit"
timeout 7
endlocal
exit
::##################################################################################################################################################
