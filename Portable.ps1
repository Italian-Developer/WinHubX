# URL dell'applicazione da scaricare
$URL = "https://github.com/MrNico98/WinHubX/releases/download/WinHubX-v.2.4.0.2/WinHubX.portable.exe"

# Nome del file scaricato
$FILE = "WinHubX.portable.exe"

# Scarica il file
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

Pause
