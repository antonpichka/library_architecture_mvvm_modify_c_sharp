namespace library_architecture_mvvm_modify_c_sharp;

public class ListBools<T>(List<T> listModel) : BaseListModel<T>(listModel) where T : Bools
{
    public override ListBools<T> GetClone()
    {
        List<T?> newListModel = [];
        foreach(T model in listModel)
        {
            newListModel.Add(model.GetClone() as T);
        }
        return new ListBools<T>(newListModel!);
    }

    public override string ToString()
    {
        string strListModel = "\n";
        foreach(T model in listModel) 
        {
            strListModel += $"{model},\n";
        }
        return $"ListBools(listModel: [{strListModel}])";
    }
}
