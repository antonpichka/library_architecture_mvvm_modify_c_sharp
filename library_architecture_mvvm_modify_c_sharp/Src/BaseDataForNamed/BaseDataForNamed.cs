namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseDataForNamed<T>(bool isLoading) where T : Enum
{
    public bool isLoading = isLoading;

    public ExceptionController exceptionController = ExceptionController.Success();

    public abstract T GetEnumDataForNamed();
}
