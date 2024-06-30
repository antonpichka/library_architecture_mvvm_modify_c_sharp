namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseModelRepository<T,Y> where T : BaseModel where Y : BaseListModel<T>
{
    public static EnumRWTMode enumRWTMode = EnumRWTMode.test;

    protected abstract T GetBaseModelFromMapAndListKeys(Dictionary<string, dynamic> map, List<string> listKeys);

    protected abstract Y GetBaseListModelFromListModel(List<T> listModel);

    protected dynamic GetModeCallbackFromReleaseCallbackAndTestCallbackParameterEnumRWTMode(dynamic releaseCallback, dynamic testCallback)
    {
        return enumRWTMode switch
        {
            EnumRWTMode.release => releaseCallback,
            EnumRWTMode.test => testCallback,
            _ => releaseCallback,
        };
    }

    protected dynamic GetSafeValueWhereUsedInMethodGetModelFromMapAndListKeysAndIndexAndDefaultValue(Dictionary<string, dynamic> map, List<string> listKeys, int index, dynamic defaultValue) 
    {
        try 
        {
            return map.TryGetValue(listKeys[index], out dynamic? value) ? value : "";
        } catch (Exception)
        {
            return defaultValue;
        }
    }
}