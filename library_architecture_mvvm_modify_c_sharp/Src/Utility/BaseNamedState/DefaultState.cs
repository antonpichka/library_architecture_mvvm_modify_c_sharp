namespace library_architecture_mvvm_modify_c_sharp;

public class DefaultState<T,Y>(T dataForNamed) : BaseNamedState<T,Y> where Y : Enum where T : BaseDataForNamed<Y>
{
    private readonly T dataForNamed = dataForNamed;
    private bool isDispose = false;

    public override void Dispose()
    {
        if(isDispose) 
        {
            return;
        }
        isDispose = true;
    }
    
    public override T GetDataForNamed()
    {
        return dataForNamed;
    }
}
