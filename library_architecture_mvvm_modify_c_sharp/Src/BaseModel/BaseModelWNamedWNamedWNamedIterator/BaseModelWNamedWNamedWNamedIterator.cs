namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseModelWNamedWNamedWNamedIterator<T> : IIterator<T> where T : BaseModel
{
    protected readonly List<T> listModelIterator;

    protected BaseModelWNamedWNamedWNamedIterator()
    {
        listModelIterator = [];
    }

    public List<T> GetSortedListModelFromNewListModelParameterListModelIterator(List<T> newListModel) 
    {
        if(newListModel.Count <= 0) 
        {
            return [];
        }
        listModelIterator.AddRange(newListModel);
        List<T> newListModelFIRST = [];
        while(MoveNext()) 
        {
            var newModel = Current();
            newListModelFIRST.Add(newModel);
        }
        return newListModelFIRST;
    }

    public bool MoveNext()
    {
        return listModelIterator.Count > 0;
    }

    public virtual T Current()
    {
        throw new NotImplementedException();
    }
}
