# Scarica il file
$URL = "https://github.com/MrNico98/WinHubX/releases/download/WinHubX-v.2.4.0.2/WinHubX.portable.exe"
$FILE = "WinHubX.portable.exe"
Invoke-WebRequest -Uri $URL -OutFile $FILE

# Controlla se il download è riuscito
if (Test-Path $FILE) {
    Write-Output "Download completato."

    # Esegui l'applicazione
    Write-Output "Avviando l'applicazione..."
    Start-Process -FilePath $FILE
    
    while (Get-Process | Where-Object { $_.Name -eq "WinHubX.portable" }) {
        # Se il processo è ancora in esecuzione, attendi 5 secondi e riprova
        Start-Sleep -Seconds 2
    }

    Write-Output "Eliminando $FILE..."
    Remove-Item -Path $FILE
    Write-Output "Operazione completata."
}
