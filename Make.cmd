@echo off

if [%APPVEYOR%] NEQ [] path C:\Program Files (x86)\Windows Kits\10\bin\10.0.14393.0\x64;C:\Program Files (x86)\Inno Setup 5;%PATH%

cd "%~dp0"

rem Call all the make files from subdirectories
FOR /d %%i IN (*) DO (
    IF EXIST %%i\Make.cmd (
        call %%i\Make.cmd
    )
)
if [%APPVEYOR%] EQ [] pause