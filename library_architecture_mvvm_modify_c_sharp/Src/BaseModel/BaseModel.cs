namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseModel(string uniqueId)
{
    public readonly string uniqueId = uniqueId;

    public abstract BaseModel GetClone();
}
