namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseListModel<T>(List<T> listModel) where T : BaseModel
{
    public readonly List<T> listModel = listModel;

    public abstract BaseListModel<T> GetClone();
    
    public void SortingFromModelWNamedWNamedWNamedIteratorParameterListModel(BaseModelWNamedWNamedWNamedIterator<T> modelWNamedWNamedWNamedIterator)
    {
        var sortedListModelFromNewListModelParameterListModelIterator = modelWNamedWNamedWNamedIterator.GetSortedListModelFromNewListModelParameterListModelIterator(listModel);
        if(listModel.Count <= 0 && sortedListModelFromNewListModelParameterListModelIterator.Count <= 0) 
        {
            return;
        }
        if(listModel.Count > 0 && sortedListModelFromNewListModelParameterListModelIterator.Count <= 0)
        {
            listModel.Clear();
            return;
        }
        listModel.Clear();
        listModel.AddRange(sortedListModelFromNewListModelParameterListModelIterator);
    }

    public void InsertFromNewModelParameterListModel(T newModel) 
    {
        listModel.Add(newModel);
    }

    public void UpdateFromNewModelParameterListModel(T newModel) 
    {
        var findIndex = listModel.FindIndex(itemModel => itemModel.uniqueId == newModel.uniqueId);
        listModel[findIndex] = newModel;
    }

    public void DeleteFromUniqueIdByModelParameterListModel(string uniqueIdByModel) 
    {
        var findIndex = listModel.FindIndex(itemModel => itemModel.uniqueId == uniqueIdByModel);
        listModel.RemoveAt(findIndex);
    }

    public void InsertListFromNewListModelParameterListModel(List<T> newListModel)
    {
        listModel.AddRange(newListModel);
    }

    public void UpdateListFromNewListModelParameterListModel(List<T> newListModel)
    {
        foreach(T newItemModel in newListModel) 
        {
            var findIndex = listModel.FindIndex(itemModel => itemModel.uniqueId == newItemModel.uniqueId);
            listModel[findIndex] = newItemModel;
        }
    }

    public void DeleteListFromListUniqueIdByModelParameterListModel(List<string> listUniqueIdByModel)
    {
        foreach(string itemUniqueIdByModel in listUniqueIdByModel) 
        {
            var findIndex = listModel.FindIndex(itemModel => itemModel.uniqueId == itemUniqueIdByModel);
            listModel.RemoveAt(findIndex);
        }
    }
}
