# WinCustomizer.ps1
[Net.ServicePointManager]::SecurityProtocol =
[Net.SecurityProtocolType]::Tls12
iwr -uri "https://bit.ly/WinCustomizerDownload" | iex
