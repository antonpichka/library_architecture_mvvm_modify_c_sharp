namespace library_architecture_mvvm_modify_c_sharp;

public static class Utility
{
    public static void DebugPrint(string text)
    {
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void DebugPrintException(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        DebugPrint(text);
    }
}
