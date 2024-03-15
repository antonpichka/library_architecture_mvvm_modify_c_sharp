namespace library_architecture_mvvm_modify_c_sharp;

public sealed class TempCacheService
{
    public static readonly TempCacheService instance = new();

    private readonly Dictionary<string, dynamic> tempCache;

    private readonly Dictionary<string, List<Action<dynamic>>> tempCacheWListAction;

    private TempCacheService() 
    {
        tempCache = [];
        tempCacheWListAction = [];
    }

    public static void ClearTempCacheParameterInstance()
    {
        var localTempCache = instance.tempCache;
        localTempCache.Clear();
    }

    public static void CloseStreamFromKeyTempCacheParameterInstance(string keyTempCache)
    {
        var localTempCacheWListAction = instance.tempCacheWListAction;
        if(!localTempCacheWListAction.TryGetValue(keyTempCache, out List<Action<dynamic>>? listAction)) 
        {
            return;
        }
        listAction.Clear();
    }

    public static void CloseStreamFromListKeyTempCacheParameterInstance(List<string> listKeyTempCache)
    {
        var localTempCacheWListAction = instance.tempCacheWListAction;
        foreach(string itemKeyTempCache in listKeyTempCache) 
        {
            if(!localTempCacheWListAction.TryGetValue(itemKeyTempCache, out List<Action<dynamic>>? listAction)) 
            {
                return;
            }
            listAction.Clear();
        }
    }

    public static void CloseStreamsParameterInstance() 
    {
        var localTempCacheWListAction = instance.tempCacheWListAction;
        foreach(List<Action<dynamic>> itemValues in localTempCacheWListAction.Values) 
        {
            itemValues.Clear();
        }
    }

    public dynamic GetFromKeyTempCacheParameterTempCache(string keyTempCache) 
    {
        if(!tempCache.TryGetValue(keyTempCache, out dynamic? value)) 
        {
            throw new LocalException(this, EnumGuilty.developer, keyTempCache, "No exists key");
        }
        return value;
    }

    public void ListenStreamFromKeyTempCacheAndCallbackParameterOne(string keyTempCache, Action<dynamic> callback)
    {
        if(!tempCacheWListAction.TryGetValue(keyTempCache, out List<Action<dynamic>>? listAction)) 
        {
            listAction = ([]);
            tempCacheWListAction[keyTempCache] = listAction;
            tempCacheWListAction[keyTempCache].Add(callback);
            return;
        }

        listAction.Add(callback);
    }

    public void UpdateFromKeyTempCacheAndValueParameterTempCache(string keyTempCache, dynamic value) 
    {
        tempCache[keyTempCache] = value;
    }

    public void UpdateWhereStreamNotificationIsPossibleFromKeyTempCacheAndValueParameterOne(string keyTempCache, dynamic value) 
    {
        UpdateFromKeyTempCacheAndValueParameterTempCache(keyTempCache,value);
        if(!tempCacheWListAction.TryGetValue(keyTempCache, out List<Action<dynamic>>? listAction)) 
        {
            return;
        }
        foreach(Action<dynamic> itemAction in listAction) 
        {
            itemAction(value);
        }
    }

    public void DeleteFromKeyTempCacheParameterTempCache(string keyTempCache) 
    {
        tempCache.Remove(keyTempCache);
    }
}