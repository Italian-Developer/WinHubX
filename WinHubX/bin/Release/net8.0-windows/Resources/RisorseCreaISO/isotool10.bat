@echo off
setlocal EnableDelayedExpansion

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

title WinHubX Debloat ISO 10

rem verifica cartelle
:cartellaISO1
cls
color 02
IF NOT EXIST "C:\ISO\WinISO" ( goto :isofolder1 )
IF EXIST "C:\ISO\WinISO" ( 
    echo "ERRORE: C\ISO\WinISO esiste gia', elimina la cartella? si,no"
    goto :domande )

:domande
set /p answer3=":"
if /i "%answer3%"=="si" ( goto :cartellaISO1 )
if /i "%answer3%"=="no" ( goto :winfolder1 )
else ( echo  ATTENZIONE! I valori accettati sono solamente 'si' e 'no'. 
goto :domande )

:isofolder1
cls 
mkdir "C:\ISO\WinISO"

:winfolder1
color 02
IF EXIST "C:\mount\mount" (
    echo "ATTENZINE! C\mount\mount esiste gia', elimina la cartella per proseguire" && timeout 04 >nul && cls && goto :winfolder1
)
mkdir "C:\mount\mount"

:iso1
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

rem copy unattended.xml
copy "Risorse\unattend10.xml" "C:\ISO\WinISO\sources\$OEM$\$$\Panther\unattend.xml"

rem check if wim or esd
IF EXIST "C:\ISO\WinISO\sources\install.wim" (
    goto :wim1
)

IF EXIST "C:\ISO\WinISO\sources\install.esd" (
    goto :esd1
)

:esd1
cls
powerShell -Command "Write-Host 'Attendi' -ForegroundColor white; exit"
dism /export-image /SourceImageFile:C:\ISO\WinISO\sources\install.esd /SourceIndex:%index% /DestinationImageFile:C:\ISO\WinISO\sources\install.wim /Compress:max /CheckIntegrity
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'Immagine esportata con successo!' -ForegroundColor Green; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile esportare l''immagine!" && pause && del "resources\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)
goto :copy_esd1

:wim1
cls
powerShell -Command "Write-Host 'Attendi' -ForegroundColor 7; exit"  
dism /Export-Image /SourceImageFile:"C:\ISO\WinISO\sources\install.wim" /SourceIndex:%index% /DestinationImageFile:"C:\ISO\WinISO\sources\install_pro.wim" /compress:max
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'Immagine esportata con successo!' -ForegroundColor 7; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile esportare l''immagine!" && pause && del "Risorse\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)

:copy_wim1
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
goto :mountwim1

rem copy the new install.esd
:copy_esd1
cls
del "C:\ISO\WinISO\sources\install.esd"
IF %errorlevel% equ 0 (
  powerShell -Command "Write-Host 'Old install.esd eliminato!' -ForegroundColor Green; exit" && timeout 04 >nul && cls
) ELSE (
  color 4 && echo "ERRORE: Impossibile eliminare old install.esd!" && pause && del "resources\unattend_edited.xml" /q && rmdir "C:\mount" /s /q && rmdir "C:\ISO" /s /q && exit /b 1
)
goto :mountwim1

rem mount the image with dism
:mountwim1
powerShell -Command "Write-Host 'Sto montando l''immagine' -ForegroundColor 7; exit"  
dism /mount-image /imagefile:"C:\ISO\WinISO\sources\install.wim" /index:1 /mountdir:"C:\mount\mount"
cls
goto :menuprincipalee1

rem menuprincipale
:menuprincipalee1
cls

rem delete edge
if "%edgeRemovalPreference%"=="RemoveEdge" (
cls
echo > C:\mount\mount\Windows\noedge.pref
copy "Risorse\OperaGXSetup.exe" "C:\mount\mount"
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

:tweaksbatt10
rem copy batch file
cls
copy "Risorse\tweaks10.bat" "C:\mount\mount\Windows"
copy "Risorse\WinCustomizerDebloat3.0.ps1" "C:\mount\mount\Windows"
copy "Risorse\WinCustomizerAttivatore.bat" "C:\mount\mount\Windows"
copy "Risorse\start10.ps1" "C:\mount\mount\Windows"
copy "Risorse\lower-ram-usage.reg" "C:\mount\mount\Windows"
copy "Risorse\WinCustomizerStartDebloat.bat" "C:\mount\mount\Windows"
copy "Risorse\unpin_start_tiles.ps1" "C:\mount\mount\Windows"

:fine1
cls
rem unmount the image
powerShell -Command "Write-Host 'Smontando l''immagine' -ForegroundColor 7; exit"  
dism /unmount-image /mountdir:"C:\mount\mount" /commit
cls 
:wimre
rem rebuild image 
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