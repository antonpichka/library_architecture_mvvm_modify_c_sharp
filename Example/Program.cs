using System;
using library_architecture_mvvm_modify_c_sharp;

class Program
{
    static void Main(string[] args)
    {
        Utility.DebugPrint("Hello suka World");
        Utility.DebugPrintException("Hello suka World");
        Utility.DebugPrint("Hello suka World");
        Utility.DebugPrint($"{EnumGuilty.Device}");
    }
}
