namespace library_architecture_mvvm_modify_c_sharp;

public class ListDoubles<T>(List<T> listModel) : BaseListModel<T>(listModel) where T : Doubles
{
    public override ListDoubles<T> GetClone()
    {
        List<T?> newListModel = [];
        foreach(T model in listModel)
        {
            newListModel.Add(model.GetClone() as T);
        }
        return new ListDoubles<T>(newListModel!);
    }

    public override string ToString()
    {
        return $"ListDoubles(listModel: {listModel}";
    }
}
