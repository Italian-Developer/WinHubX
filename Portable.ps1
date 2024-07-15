# Verifica se PowerShell è stato avviato con -WindowStyle Hidden
if ($env:__PSLockdownPolicy -ne "4") {
    Write-Output "Mi riavvio con -WindowStyle Hidden..."
    # Riavvia PowerShell con -WindowStyle Hidden e esegui il comando per scaricare e eseguire lo script
    Start-Process powershell.exe -ArgumentList "-WindowStyle Hidden -Command 'irm -uri ''https://bit.ly/winhubx'' | iex'"
    break  # Termina lo script corrente
}

Add-Type @"
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
public static class NativeMethods {
    [DllImport("user32.dll")]
    public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
    [DllImport("user32.dll")]
    public static extern bool UnhookWindowsHookEx(IntPtr hhk);
    [DllImport("user32.dll")]
    public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);
    public const int WH_KEYBOARD_LL = 13;
    public const int VK_F4 = 0x73;
    public const int WM_KEYDOWN = 0x0100;
}
"@

$proc = [NativeMethods+LowLevelKeyboardProc] {
    param($nCode, $wParam, $lParam)
    if ($nCode -ge 0 -and $wParam -eq [NativeMethods]::WM_KEYDOWN) {
        $vkCode = [System.Runtime.InteropServices.Marshal]::ReadInt32($lParam)
        if ($vkCode -eq [NativeMethods]::VK_F4) {
            return [IntPtr]::Zero
        }
    }
    return [NativeMethods]::CallNextHookEx($null, $nCode, $wParam, $lParam)
}

# Ottieni l'handle del modulo corrente
$hMod = [NativeMethods]::GetModuleHandle([Diagnostics.Process]::GetCurrentProcess().ProcessName)

# Imposta l'hook
$hook = [NativeMethods]::SetWindowsHookEx([NativeMethods]::WH_KEYBOARD_LL, $proc, $hMod, 0)

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
        # Se il processo è ancora in esecuzione, attendi 2 secondi e riprova
        Start-Sleep -Seconds 2
    }

    Write-Output "Eliminando $FILE..."
    Remove-Item -Path $FILE
    Write-Output "Operazione completata."
}

# Rimuovi l'hook quando il lavoro è terminato
[NativeMethods]::UnhookWindowsHookEx($hook)

Pause
