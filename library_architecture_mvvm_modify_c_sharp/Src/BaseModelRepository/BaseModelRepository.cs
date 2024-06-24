namespace library_architecture_mvvm_modify_c_sharp;

public abstract class BaseModelRepository<T,Y>(EnumRWTMode enumRWTMode) where T : BaseModel where Y : BaseListModel<T>
{
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
}