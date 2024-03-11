namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseDataForNamed<T>(bool isLoading) where T : System.Enum
{
    public bool isLoading = isLoading;

    public abstract T GetEnumDataForNamed();
}
