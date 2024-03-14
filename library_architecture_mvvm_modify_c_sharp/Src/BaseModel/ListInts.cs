namespace library_architecture_mvvm_modify_c_sharp;

public class ListInts<T>(List<T> listModel) : BaseListModel<T>(listModel) where T : Ints
{
    public override ListInts<T> GetClone()
    {
        List<T?> newListModel = [];
        foreach(T model in listModel)
        {
            newListModel.Add(model.GetClone() as T);
        }
        return new ListInts<T>(newListModel!);
    }

    public override string ToString()
    {
        return $"ListInts(listModel: {listModel}";
    }
}
