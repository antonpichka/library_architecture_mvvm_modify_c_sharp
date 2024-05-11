namespace library_architecture_mvvm_modify_c_sharp;

public sealed class Result<T>
{
    public readonly T? parameter;

    public readonly ExceptionController exceptionController;

    private Result(T? parameter, ExceptionController exceptionController)
    {
        this.parameter = parameter;
        this.exceptionController = exceptionController;
    }

    private Result(ExceptionController exceptionController) 
    {
        this.exceptionController = exceptionController;
    }

    public static Result<T> Success(T parameter) 
    {
        return new Result<T>(parameter,ExceptionController.Success());
    }

    public static Result<T> Exception(BaseException exception) 
    {
        return new Result<T>(ExceptionController.Exception(exception));
    }
}
