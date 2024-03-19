<p align="center">
<img src="https://raw.githubusercontent.com/antonpichka/library_architecture_mvvm_modify/main/assets/logo_lamm.png" alt="Logo LAMM"/>
</p>

--- 

| Package                                                                                                               | Nuget                                                                                                                                            |
|-----------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| [library_architecture_mvvm_modify_c_sharp](https://github.com/antonpichka/library_architecture_mvvm_modify_c_sharp/tree/main/library_architecture_mvvm_modify_c_sharp) | [NuGet](https://www.nuget.org/packages/library_architecture_mvvm_modify_c_sharp) |

## Windows

### Build "library_architecture_mvvm_modify_c_sharp"

- Commands cmd:
- - start /min build_lamm_c_sharp_bat.bat
- - taskkill /f /im dotnet.exe
- - taskkill /f /im cmd.exe
- Commands PowerShell:
- - Start-Process -FilePath "build_lamm_c_sharp_bat.bat"
- - taskkill /f /im dotnet.exe
- - taskkill /f /im cmd.exe
- Commands cmd/PowerShell (Only For NuGet):
- - dotnet pack

### Build/Run "example"

- Commands cmd\PowerShell:
- - cd example
- - dotnet build
- - dotnet run