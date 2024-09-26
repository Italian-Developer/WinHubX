# Define the URL for the WinHubX portable executable and the output file name
$URL = 'https://github.com/MrNico98/WinHubX/releases/download/WinHubX-v.2.4.0.2/WinHubX.portable.exe'
$FILE = 'WinHubX.portable.exe'

# Start the download process
try {
    Write-Output "Starting download from $URL..."
    Invoke-WebRequest -Uri $URL -OutFile $FILE -ErrorAction Stop
    
    # Check if the download was successful
    if (Test-Path $FILE) {
        Write-Output 'Download completed successfully.'

        # Execute the downloaded application
        Write-Output 'Launching the application...'
        $process = Start-Process -FilePath $FILE -PassThru
        
        # Wait until the process finishes
        $process.WaitForExit()

        # Clean up by removing the executable after execution
        Write-Output "Cleaning up: Removing $FILE..."
        Remove-Item -Path $FILE -Force
        Write-Output 'Operation completed successfully.'
    }
    else {
        Write-Output 'Error: The downloaded file was not found.'
    }
}
catch {
    # Handle any errors that occur during the download or execution
    Write-Output "An error occurred: $_"
    if (Test-Path $FILE) {
        Write-Output "Attempting to clean up: Removing $FILE..."
        Remove-Item -Path $FILE -Force
    }
    Write-Output 'Download or execution failed. Please check the URL or your network connection.'
}
