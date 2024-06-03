using library_architecture_mvvm_modify_c_sharp;

namespace TempCacheTestMain;

public class TempCacheTestMain
{
    public static async Task Main() 
    {
        var tempCacheService = TempCacheService.instance;
        var key = "key";
        tempCacheService.UpdateWhereStreamNotificationIsPossibleFromKeyTempCacheAndValueParameterOne(key, "One");
        var fromKeyTempCacheParameterTempCache = tempCacheService.GetFromKeyTempCacheParameterTempCache(key);
        Utility.DebugPrint($"FromKeyTempCacheParameterTempCache: {fromKeyTempCacheParameterTempCache}");
        tempCacheService.ListenStreamFromKeyTempCacheAndCallbackParameterOne(key,(data) => {
            Utility.DebugPrint($"Listen: {data}");
        });
        await Task.Delay(1000);
        tempCacheService.UpdateWhereStreamNotificationIsPossibleFromKeyTempCacheAndValueParameterOne(key, "Two");
        tempCacheService.ListenStreamFromKeyTempCacheAndCallbackParameterOne(key,(data) => {
            Utility.DebugPrint($"ListenTwo: {data}");
        });
        await Task.Delay(1000);
        tempCacheService.UpdateWhereStreamNotificationIsPossibleFromKeyTempCacheAndValueParameterOne(key, "Three");
        tempCacheService.ListenStreamFromKeyTempCacheAndCallbackParameterOne(key,(data) => {
            Utility.DebugPrint($"ListenThree: {data}");
        });
    }
}
// EXPECTED OUTPUT:
//
// FromKeyTempCacheParameterTempCache: One
// Listen: Two
// Listen: Three
// ListenTwo: Three