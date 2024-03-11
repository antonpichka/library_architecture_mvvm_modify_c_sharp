using library_architecture_mvvm_modify_c_sharp;

public abstract class BaseException : Exception
{
    public readonly string key;

    public BaseException(object thisClass, string exceptionClass, string key)
    { 
        this.key = key;
        Utility.DebugPrintException("\n===start_to_trace_exception===\n");
        Utility.DebugPrintException($"WhereHappenedException(Class) --> {thisClass.GetType}\n NameException(Class) --> {exceptionClass}\n toString() --> {ToString()}");
        Utility.DebugPrintException("\n===end_to_trace_exception===\n");
    }
}