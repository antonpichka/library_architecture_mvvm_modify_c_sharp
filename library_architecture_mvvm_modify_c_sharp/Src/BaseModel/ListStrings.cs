namespace library_architecture_mvvm_modify_c_sharp;

public class ListStrings<T>(List<T> listModel) : BaseListModel<T>(listModel) where T : Strings
{
    public override ListStrings<T> GetClone()
    {
        List<T?> newListModel = [];
        foreach(T model in listModel)
        {
            newListModel.Add(model.GetClone() as T);
        }
        return new ListStrings<T>(newListModel!);
    }

    public override string ToString()
    {
        string strListModel = "\n";
        foreach(T model in listModel) 
        {
            strListModel += $"{model},\n";
        }
        return $"ListStrings(listModel: [{strListModel}])";
    }
}
