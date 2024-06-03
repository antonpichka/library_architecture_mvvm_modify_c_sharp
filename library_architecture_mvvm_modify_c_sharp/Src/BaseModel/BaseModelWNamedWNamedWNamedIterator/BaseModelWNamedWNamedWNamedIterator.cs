namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseModelWNamedWNamedWNamedIterator<T> where T : BaseModel
{
    protected readonly List<T> listModelIterator;

    protected BaseModelWNamedWNamedWNamedIterator()
    {
        listModelIterator = [];
    }

    protected abstract CurrentModelWIndex<T> CurrentModelWIndex();

    public List<T> GetSortedListModelFromNewListModelParameterListModelIterator(List<T> newListModel) 
    {
        if(newListModel.Count <= 0) 
        {
            return [];
        }
        listModelIterator.AddRange(newListModel);
        List<T> newListModelFIRST = [];
        while(listModelIterator.Count > 0) 
        {
            var currentModelWIndex = CurrentModelWIndex();
            listModelIterator.RemoveAt(currentModelWIndex.index);
            newListModelFIRST.Add(currentModelWIndex.currentModel);
        }
        return newListModelFIRST;
    }
}
