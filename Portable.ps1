$URL = "https://github.com/MrNico98/WinHubX/releases/download/WinHubX-v.2.4.0.2/WinHubX.portable.exe"
$FILE = "WinHubX.portable.exe"
Invoke-WebRequest -Uri $URL -OutFile $FILE

# Controlla se il download è riuscito
if (Test-Path $FILE) {
    Write-Output "Download completato."

    # Esegui l'applicazione
    Write-Output "Avviando l'applicazione..."
    $process = Start-Process -FilePath $FILE -PassThru
    
    # Attendi fino a quando il processo non è terminato
    $process.WaitForExit()

    Write-Output "Eliminando $FILE..."
    Remove-Item -Path $FILE
    Write-Output "Operazione completata."
} else {
    Write-Output "Il download non è riuscito."
}


