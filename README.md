## Windows

### Build "library_architecture_mvvm_modify_c_sharp"

- Commands cmd:
- - start /min build_lamm_c_sharp_bat.bat
- - taskkill /f /im dotnet.exe
- - taskkill /f /im cmd.exe
- Commands PowerShell:
- - Start-Process -FilePath "build_lamm_c_sharp_bat.bat" -WindowStyle Hidden
- - taskkill /f /im dotnet.exe
- - taskkill /f /im cmd.exe

### Build/Run "example"

- Commands cmd\PowerShell:
- - cd example
- - dotnet build
- - dotnet run