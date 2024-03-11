@echo off
set "source=build\"
for /f "delims=" %%i in ('dir %source% /ad /b') do (
    rmdir /s /q %source%"%%i"
)