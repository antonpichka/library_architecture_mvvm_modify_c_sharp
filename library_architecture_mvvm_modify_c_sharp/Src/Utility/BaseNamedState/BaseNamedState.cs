namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseNamedState<T,Y> : IDispose where Y : Enum where T : BaseDataForNamed<Y>
{
    public virtual void Dispose() {}
    public abstract T GetDataForNamed();
}
