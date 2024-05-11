namespace library_architecture_mvvm_modify_c_sharp;

public sealed class RWTMode(EnumRWTMode enumRWTMode,List<NamedCallback> listNamedCallbackWRelease,List<NamedCallback> listNamedCallbackWTest)
{
    private readonly EnumRWTMode enumRWTMode = enumRWTMode;

    private readonly Dictionary<string,NamedCallback> dictionaryStringWNamedCallbackWRelease = GetDictionaryStringWNamedCallbackFromListNamedCallback(listNamedCallbackWRelease);

    private readonly Dictionary<string,NamedCallback> dictionaryStringWNamedCallbackWTest = GetDictionaryStringWNamedCallbackFromListNamedCallback(listNamedCallbackWTest);

    private static Dictionary<string,NamedCallback> GetDictionaryStringWNamedCallbackFromListNamedCallback(List<NamedCallback> listNamedCallback)
    {
        var dictionaryStringWNamedCallback = new Dictionary<string,NamedCallback>();
        foreach(NamedCallback itemNamedCallback in listNamedCallback) {
            dictionaryStringWNamedCallback[itemNamedCallback.name] = itemNamedCallback;
        }
        return dictionaryStringWNamedCallback;
    }

    public NamedCallback GetNamedCallbackFromName(string name)
    {
        var dictionaryStringWNamedCallbackWhereSelectModParametersThree = GetDictionaryStringWNamedCallbackWhereSelectModParametersThree();
        if(!dictionaryStringWNamedCallbackWhereSelectModParametersThree.TryGetValue(name, out NamedCallback? namedCallback)) 
        {
            throw new LocalException(this, EnumGuilty.developer, "RWTModeQQGetNamedCallbackFromName", $"no exists key: {name}");
        }
        return namedCallback;
    }

    private Dictionary<string,NamedCallback> GetDictionaryStringWNamedCallbackWhereSelectModParametersThree()
    {
        if(enumRWTMode == EnumRWTMode.release) {
            return dictionaryStringWNamedCallbackWRelease;
        }
        return dictionaryStringWNamedCallbackWTest;
    }
}