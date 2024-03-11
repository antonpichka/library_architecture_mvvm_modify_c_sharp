@echo off

rem ONLY EDIT THIS ROW (Name of your catalog)
set "project=library_architecture_mvvm_modify_c_sharp"
rem ONLY EDIT THIS ROW (Name of your catalog)

rd /s /q build
rd /s /q %systemdrive%\$Recycle.bin
Xcopy %project%\* build\ /S /E
start /b named_bat_utility\copy_all_files_w_all_folders_to_one_folder_bat_utility.bat
start /b named_bat_utility\remove_unnecessary_files_w_folders_w_the_build_bat_utility.bat
start /b named_bat_utility\dotnet_bat_utility.bat