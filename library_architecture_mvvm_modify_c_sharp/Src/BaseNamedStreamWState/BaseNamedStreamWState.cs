namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseNamedStreamWState<T,Y> : IDispose where Y : Enum where T : BaseDataForNamed<Y>
{
    public virtual void Dispose() {}
    public abstract T GetDataForNamed();
    public abstract void ListenStreamDataForNamedFromCallback(Action<T> callback);
    public abstract void NotifyStreamDataForNamed();
}
