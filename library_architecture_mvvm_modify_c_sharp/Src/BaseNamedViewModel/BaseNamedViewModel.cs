namespace library_architecture_mvvm_modify_c_sharp;

// OperationEEModel(EEWhereNamed)[EEFromNamed]EEParameterNamedService
// NamedUtility

public abstract class BaseNamedViewModel<T, Y, U>(U namedStreamWState) : IDispose where Y : Enum where T : BaseDataForNamed<Y> where U : BaseNamedStreamWState<T, Y>
{
    protected readonly U namedStreamWState = namedStreamWState;

    public abstract Task<string> Init();

    public virtual void Dispose()
    {
        namedStreamWState.Dispose();
    }

    public T GetDataForNamedParameterNamedStreamWState()
    {
        return namedStreamWState.GetDataForNamed();
    }

    public void ListenStreamDataForNamedFromCallbackParameterNamedStreamWState(Action<T> callback) 
    {
        namedStreamWState.ListenStreamDataForNamedFromCallback(callback);
    }

    public void NotifyStreamDataForNamedParameterNamedStreamWState()
    {
        namedStreamWState.NotifyStreamDataForNamed();
    }
}
