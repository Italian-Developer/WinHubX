@echo off
pushd "%~dp0"
set "architettura=%~1"

Resources.OfficePersonalizzato.bin.exe /configure "C:\configuration-%architettura%-complete.xml"

