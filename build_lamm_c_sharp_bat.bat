@echo off

set "project=library_architecture_mvvm_modify_c_sharp"
rd /s /q build
rd /s /q intermediate_output
rd /s /q output
robocopy %project% build /S
cd build
rd /s /q Example
rd /s /q Src\NamedTestMain
dotnet build
PAUSE