# https://superuser.com/a/1442733
#Requires -RunAsAdministrator

$START_MENU_LAYOUT = @"
<LayoutModificationTemplate xmlns:defaultlayout="http://schemas.microsoft.com/Start/2014/FullDefaultLayout" xmlns:start="http://schemas.microsoft.com/Start/2014/StartLayout" Version="1" xmlns:taskbar="http://schemas.microsoft.com/Start/2014/TaskbarLayout" xmlns="http://schemas.microsoft.com/Start/2014/LayoutModification">
    <LayoutOptions StartTileGroupCellWidth="6" />
    <DefaultLayoutOverride>
        <StartLayoutCollection>
            <defaultlayout:StartLayout GroupCellWidth="6" />
        </StartLayoutCollection>
    </DefaultLayoutOverride>
</LayoutModificationTemplate>
"@

$layoutFile="C:\Windows\StartMenuLayout.xml"

#Delete layout file if it already exists
If(Test-Path $layoutFile)
{
    Remove-Item $layoutFile
}

#Creates the blank layout file
$START_MENU_LAYOUT | Out-File $layoutFile -Encoding ASCII

$regAliases = @("HKLM", "HKCU")

#Assign the start layout and force it to apply with "LockedStartLayout" at both the machine and user level
foreach ($regAlias in $regAliases){
    $basePath = $regAlias + ":\SOFTWARE\Policies\Microsoft\Windows"
    $keyPath = $basePath + "\Explorer" 
    IF(!(Test-Path -Path $keyPath)) { 
        New-Item -Path $basePath -Name "Explorer"
    }
    Set-ItemProperty -Path $keyPath -Name "LockedStartLayout" -Value 1
    Set-ItemProperty -Path $keyPath -Name "StartLayoutFile" -Value $layoutFile
}

#Restart Explorer, open the start menu (necessary to load the new layout), and give it a few seconds to process
Stop-Process -name explorer
Start-Sleep -s 5
$wshell = New-Object -ComObject wscript.shell; $wshell.SendKeys('^{ESCAPE}')
Start-Sleep -s 5

#Enable the ability to pin items again by disabling "LockedStartLayout"
foreach ($regAlias in $regAliases){
    $basePath = $regAlias + ":\SOFTWARE\Policies\Microsoft\Windows"
    $keyPath = $basePath + "\Explorer" 
    Set-ItemProperty -Path $keyPath -Name "LockedStartLayout" -Value 0
}

#Restart Explorer and delete the layout file
Stop-Process -name explorer

# Uncomment the next line to make clean start menu default for all new users
Import-StartLayout -LayoutPath $layoutFile -MountPath $env:SystemDrive\

Remove-Item $layoutFile


function Install-WinGet() {

    $progressPreference = 'silentlyContinue'

    $wc = New-Object net.webclient
    $msu_url = 'https://aka.ms/getwinget'
    $local_msu_url = "Microsoft.DesktopAppInstaller_8wekyb3d8bbwe.msixbundle"
    $wc.Downloadfile($msu_url, $local_msu_url)

    $wc = New-Object net.webclient
    $msu_url = 'https://aka.ms/Microsoft.VCLibs.x64.14.00.Desktop.appx'
    $local_msu_url = "Microsoft.VCLibs.x64.14.00.Desktop.appx"
    $wc.Downloadfile($msu_url, $local_msu_url)

    $wc = New-Object net.webclient
    $msu_url = 'https://github.com/microsoft/microsoft-ui-xaml/releases/download/v2.8.6/Microsoft.UI.Xaml.2.8.x64.appx'
    $local_msu_url = "Microsoft.UI.Xaml.2.8.x64.appx"
    $wc.Downloadfile($msu_url, $local_msu_url)

    Add-AppxPackage Microsoft.VCLibs.x64.14.00.Desktop.appx
    Add-AppxPackage Microsoft.UI.Xaml.2.8.x64.appx
    Add-AppxPackage Microsoft.DesktopAppInstaller_8wekyb3d8bbwe.msixbundle
}

if (Test-Path ~\AppData\Local\Microsoft\WindowsApps\winget.exe){
    Write-Host 'Winget Already Installed'
    }  
    else{
    Write-Host 'Installing Winget'
    Install-WinGet
}

# That's the JSON where the configs are stored
$integratedServicesPath = "C:\Windows\System32\IntegratedServicesRegionPolicySet.json"

if (Test-Path $integratedServicesPath) {

    # Get the permissions (ACL) of the original file
    $acl = Get-Acl -Path $integratedServicesPath

    # Take ownership of the file
    takeown /f $integratedServicesPath /a 

    # Grant the full control to be able to edit it
    icacls $integratedServicesPath /grant Administrators:F

    # Read the JSON
    $jsonContent = Get-Content $integratedServicesPath | ConvertFrom-Json

    # Edit the JSON to allow uninstall
    foreach ($policy in $jsonContent.policies) {
        if ($policy.'$comment' -like "*Edge*" -and $policy.'$comment' -like "*uninstall*") {
            $policy.defaultState = 'enabled'
            # Set region to all ISO 3166-1 alpha-2 country codes
            $allCountryCodes = @("AT", "BE", "BG", "CH", "CY", "CZ", "DE", "DK", "EE", "ES", "FI", "FR", "GF", "GP", "GR", "HR", "HU", "IE", "IS", "IT", "LI", "LT", "LU", "LV", "MT", "MQ", "NL", "NO", "PL", "PT", "RE", "RO", "SE", "SI", "SK", "YT", "AD", "AE", "AF", "AG", "AI", "AL", "AM", "AO", "AQ", "AR", "AS", "AU", "AW", "AX", "AZ", "BA", "BB", "BD", "BF", "BH", "BI", "BJ", "BL", "BM", "BN", "BO", "BQ", "BR", "BS", "BT", "BV", "BW", "BY", "BZ", "CA", "CC", "CD", "CF", "CG", "CI", "CK", "CL", "CM", "CN", "CO", "CR", "CU", "CV", "CW", "CX", "DJ", "DM", "DO", "DZ", "EC", "EG", "EH", "ER", "ET", "FK", "FM", "FO", "GA", "GB", "GD", "GE", "GG", "GH", "GI", "GL", "GM", "GN", "GQ", "GS", "GT", "GU", "GW", "GY", "HK", "HM", "HN", "HT", "ID", "IL", "IM", "IN", "IO", "IQ", "IR", "JE", "JM", "JO", "JP", "KE", "KG", "KH", "KI", "KM", "KN", "KP", "KR", "KW", "KY", "KZ", "LA", "LB", "LC", "LK", "LR", "LS", "LY", "MA", "MC", "MD", "ME", "MF", "MG", "MH", "MK", "ML", "MM", "MN", "MO", "MP", "MR", "MS", "MU", "MV", "MW", "MX", "MY", "MZ", "NA", "NC", "NE", "NF", "NG", "NI", "NP", "NR", "NU", "NZ", "OM", "PA", "PE", "PF", "PG", "PH", "PK", "PM", "PN", "PR", "PS", "PW", "PY", "QA", "RE", "RS", "RU", "RW", "SA", "SB", "SC", "SD", "SG", "SH", "SJ", "SL", "SM", "SN", "SO", "SR", "SS", "ST", "SV", "SX", "SY", "SZ", "TC", "TD", "TF", "TG", "TH", "TJ", "TK", "TL", "TM", "TN", "TO", "TT", "TV", "TW", "TZ", "UA", "UG", "UM", "US", "UY", "UZ", "VA", "VC", "VE", "VG", "VI", "VN", "VU", "WF", "WS", "YE", "YT", "ZA", "ZM", "ZW")
            $policy.conditions.region.enabled = $allCountryCodes
        }
    }

    # Write the JSON file to another location to avoid the 'permission denied' error
    $jsonContent | ConvertTo-Json -Depth 100 | Set-Content -Path "C:\BK_IntegratedServicesRegionPolicySet.json"

    # Move the new JSON file to C:\Windows\System32\IntegratedServicesRegionPolicySet.json
    Copy-Item C:\BK_IntegratedServicesRegionPolicySet.json C:\Windows\System32\IntegratedServicesRegionPolicySet.json

    # Set the original permissions to the new file
    Set-Acl -Path $integratedServicesPath -AclObject $acl

    # Kill edge processes
    Stop-Process -Name "MsEdge" -Force -ErrorAction SilentlyContinue | Out-Null

    # Uninstall with winget
    winget uninstall "Microsoft Edge" --accept-source-agreements --silent | out-null

    Write-Host "Done, file edited."
    Write-Host "If Edge is still present, that means you have not installed the KB that enables that feature."
    Write-Host "Please install the latest updates from Windows Update and retry."
    
    Start-Sleep 05

}
else {
    # File does not exist
    Write-Host "The file $integratedServicesPath does not exist. Install the latest updates from windows update and retry!"
    Start-Sleep 05
    exit
}