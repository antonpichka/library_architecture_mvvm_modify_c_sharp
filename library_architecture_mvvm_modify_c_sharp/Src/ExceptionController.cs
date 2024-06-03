namespace library_architecture_mvvm_modify_c_sharp;

public sealed class ExceptionController
{
    private readonly BaseException? exception;

    private ExceptionController(BaseException? exception) 
    {
        this.exception = exception;
    }

    public static ExceptionController Success() 
    {
        return new ExceptionController(null);
    }

    public static ExceptionController Exception(BaseException exception) 
    {
        return new ExceptionController(exception);
    }

    public override string ToString() {
        if(exception == null) {
            return "ExceptionController(exception: null)";
        }
        return "ExceptionController(exception: " + exception + ")";
    }

    public string GetKeyParameterException()
    {
        return exception?.key ?? "";
    }

    public bool IsWhereNotEqualsNullParameterException() {
        return exception != null;
    }
}