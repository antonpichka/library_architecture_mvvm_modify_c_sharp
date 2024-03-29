namespace library_architecture_mvvm_modify_c_sharp;

public sealed class DefaultStreamWState<T,Y>(T dataForNamed) : BaseNamedStreamWState<T,Y> where Y : Enum where T : BaseDataForNamed<Y>
{
    private readonly T dataForNamed = dataForNamed;
    private bool isDispose = false;
    private Action<T>? callback;

    public override void Dispose()
    {
        if(isDispose) 
        {
            return;
        }
        isDispose = true;
        callback = null;
    }
    
    public override T GetDataForNamed()
    {
        return dataForNamed;
    }

    public override void ListenStreamDataForNamedFromCallback(Action<T> callback)
    {
        if(isDispose) 
        {
            throw new LocalException(this,EnumGuilty.developer,"DefaultStreamWStateQQListenStreamDataForNamedFromCallback","Already disposed of");
        }
        if(this.callback != null) 
        {
            throw new LocalException(this,EnumGuilty.developer,"DefaultStreamWStateQQListenStreamDataForNamedFromCallback","Duplicate");
        }
        this.callback = callback;
    }

    public override void NotifyStreamDataForNamed()
    {
        if(isDispose) 
        {
            throw new LocalException(this,EnumGuilty.developer,"DefaultStreamWStateQQNotifyStreamDataForNamed","Already disposed of");
        }
        if(callback == null) 
        {
            throw new LocalException(this,EnumGuilty.developer,"DefaultStreamWStateQQNotifyStreamDataForNamed","Stream has no listener");
        }
        callback(dataForNamed);
    }
}
