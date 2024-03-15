namespace library_architecture_mvvm_modify_c_sharp;

public class ListDatesTimes<T>(List<T> listModel) : BaseListModel<T>(listModel) where T : DatesTimes
{
    public override ListDatesTimes<T> GetClone()
    {
        List<T?> newListModel = [];
        foreach(T model in listModel)
        {
            newListModel.Add(model.GetClone() as T);
        }
        return new ListDatesTimes<T>(newListModel!);
    }

    public override string ToString()
    {
        string strListModel = "\n";
        foreach(T model in listModel) 
        {
            strListModel += $"{model},\n";
        }
        return $"ListDatesTimes(listModel: [{strListModel}])";
    }
}
