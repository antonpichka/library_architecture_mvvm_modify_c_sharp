namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseNamedViewModelCutDown<T, Y, U>(U namedState) : IDispose where Y : Enum where T : BaseDataForNamed<Y> where U : BaseNamedState<T, Y>
{
    protected readonly U namedState = namedState;

    public virtual void Dispose()
    {
        namedState.Dispose();
    }

    public T GetDataForNamedParameterNamedState()
    {
        return namedState.GetDataForNamed();
    }
}
