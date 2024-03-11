@echo off

set "project=library_architecture_mvvm_modify_c_sharp"
rd /s /q build
rd /s /q %systemdrive%\$Recycle.bin
Xcopy %project%\* build\ /S /E
set "source=build\."
set "destination=build\."
for /r "%source%" %%F in (*) do (
    copy "%%F" "%destination%"
)
rd /s /q build\Src
cd build
dotnet build
