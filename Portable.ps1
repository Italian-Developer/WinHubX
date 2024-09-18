# URL dell'API di GitHub per ottenere l'ultima release di WinHubX
$apiUrl = "https://api.github.com/repos/MrNico98/WinHubX/releases/latest"
$headers = @{ "User-Agent" = "PowerShell" }

# Funzione per scaricare l'ultima versione
function Get-LatestRelease {
    param (
        [string]$apiUrl
    )
    
    try {
        # Richiede informazioni sull'ultima release
        $response = Invoke-RestMethod -Uri $apiUrl -Headers $headers -ErrorAction Stop
        return $response.assets[0].browser_download_url
    } catch {
        Write-Error "Errore nel recuperare l'ultima versione: $_"
        return $null
    }
}

# Recupera l'URL per il download dell'ultima versione
$downloadUrl = Get-LatestRelease -apiUrl $apiUrl
$filename = "WinHubX.portable.exe"

if ($downloadUrl) {
    # Funzione per la gestione del download
    function Download-File {
        param (
            [string]$url,
            [string]$file
        )
        
        try {
            Invoke-WebRequest -Uri $url -OutFile $file -ErrorAction Stop
            return $true
        } catch {
            Write-Error "Errore durante il download del file: $_"
            return $false
        }
    }

    # Avvia il download
    if (Download-File -url $downloadUrl -file $filename) {
        Write-Output "Download completato correttamente."

        # Controlla se il file è stato scaricato correttamente
        if (Test-Path $filename) {
            Write-Output "Avviando l'applicazione..."
            
            try {
                # Avvia l'applicazione e attende la sua chiusura
                $process = Start-Process -FilePath $filename -PassThru -ErrorAction Stop
                $process.WaitForExit()

                Write-Output "L'applicazione è stata eseguita correttamente."
            } catch {
                Write-Error "Errore durante l'esecuzione dell'applicazione: $_"
            }

            # Elimina il file eseguibile scaricato
            try {
                Write-Output "Eliminando $filename..."
                Remove-Item -Path $filename -ErrorAction Stop
                Write-Output "File eliminato con successo."
            } catch {
                Write-Error "Errore durante l'eliminazione del file: $_"
            }
        } else {
            Write-Error "Il file scaricato non esiste o non è stato creato correttamente."
        }
    } else {
        Write-Error "Il download non è riuscito."
    }
} else {
    Write-Error "Non è stato possibile ottenere l'URL dell'ultima versione."
}
