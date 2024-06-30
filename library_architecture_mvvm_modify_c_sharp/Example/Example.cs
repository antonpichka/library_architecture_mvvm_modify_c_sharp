using library_architecture_mvvm_modify_c_sharp;
using Newtonsoft.Json;

namespace Example;

public static class FactoryObjectUtility
{
    /* ModelRepository */
    public static IPAddressRepository<IPAddress,ListIPAddress<IPAddress>> GetIPAddressRepository(EnumRWTMode enumRWTMode) {
        return new IPAddressRepository<IPAddress, ListIPAddress<IPAddress>>(enumRWTMode);
    }
}

public static class ReadyDataUtility 
{
    public const string unknown = "unknown";
    public const string success = "success";
    public const string iPAPI = "https://jsonip.com/";
}

public static class KeysHttpClientServiceUtility 
{
    /* IPAddress */
    public const string iPAddressQQIp = "ip";
}

public class IPAddress(string ip) : BaseModel(ip)
{
    public readonly string ip = ip;

    public override IPAddress GetClone()
    {
        return new IPAddress(ip);
    }

    public override string ToString()
    {
        return $"IPAddress(ip: {ip})";
    }
}

public class ListIPAddress<T>(List<T> listModel) : BaseListModel<T>(listModel) where T : IPAddress
{
    public override ListIPAddress<T> GetClone()
    {
        List<T?> newListModel = [];
        foreach(T model in listModel)
        {
            newListModel.Add(model.GetClone() as T);
        }
        return new ListIPAddress<T>(newListModel!);
    }

    public override string ToString()
    {
        string strListModel = "\n";
        foreach(T model in listModel) 
        {
            strListModel += $"{model},\n";
        }
        return $"ListIPAddress(listModel: [{strListModel}])";
    }
}

public sealed class HttpClientService 
{
    public static readonly HttpClientService instance = new();

    private HttpClient? httpClient;

    private HttpClientService() {}

    public HttpClient? GetParameterHttpClient() 
    {
        if(httpClient != null) 
        {
            return httpClient;
        }
        httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(5)
        };
        return httpClient;
    }   
}

public class IPAddressRepository<T, Y> : BaseModelRepository<T, Y> where T : IPAddress where Y : ListIPAddress<T>
{
    protected readonly HttpClientService httpClientService = HttpClientService.instance;
    protected Func<Task<Result<T>>> getIPAddressParameterHttpClientServiceWReleaseCallback;
    protected Func<Task<Result<T>>> getIPAddressParameterHttpClientServiceWTestCallback;

    public IPAddressRepository(EnumRWTMode enumRWTModeFirst) : base()
    {
        enumRWTMode = enumRWTModeFirst;
        getIPAddressParameterHttpClientServiceWReleaseCallback = async () =>
        {
            try {
                var response = await httpClientService.GetParameterHttpClient()!.GetAsync(ReadyDataUtility.iPAPI);
                if(!response.IsSuccessStatusCode)
                {
                    throw NetworkException.FromKeyAndStatusCode(this,response.StatusCode.ToString(),(int)response.StatusCode);
                }
                var jsonToString = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonToString ?? "") ?? [];
                return Result<T>.Success(GetBaseModelFromMapAndListKeys(
                    json,
                    GetIPAddressParameterHttpClientServiceWListKeys()));
            } catch(NetworkException networkException)
            {
                return Result<T>.Exception(networkException);
            } catch(Exception e)
            {
                return Result<T>.Exception(new LocalException(this,EnumGuilty.device,ReadyDataUtility.unknown,e.ToString()));
            }
        };
        getIPAddressParameterHttpClientServiceWTestCallback = async () => 
        {
            await Task.Delay(1000);
            return Result<T>.Success(GetBaseModelFromMapAndListKeys(
                new Dictionary<string, dynamic>()
                {
                    {KeysHttpClientServiceUtility.iPAddressQQIp, "121.121.12.12"},
                },
                GetIPAddressParameterHttpClientServiceWListKeys()));
        };
    }

    protected override T GetBaseModelFromMapAndListKeys(Dictionary<string, dynamic> map, List<string> listKeys)
    {
        return (new IPAddress(
            GetSafeValueWhereUsedInMethodGetModelFromMapAndListKeysAndIndexAndDefaultValue(map,listKeys,0,"")) as T)!;
    }
    
    protected override Y GetBaseListModelFromListModel(List<T> listModel)
    {
        return (new ListIPAddress<T>(listModel) as Y)!;
    }

    public Task<Result<T>> GetIPAddressParameterHttpClientService() 
    {
        return GetModeCallbackFromReleaseCallbackAndTestCallbackParameterEnumRWTMode(getIPAddressParameterHttpClientServiceWReleaseCallback,getIPAddressParameterHttpClientServiceWTestCallback)();
    }

    protected List<string> GetIPAddressParameterHttpClientServiceWListKeys() {
        return [KeysHttpClientServiceUtility.iPAddressQQIp]; 
    }
}

public enum EnumDataForMainVM {
    isLoading,
    exception,
    success
}

public sealed class DataForMainVM(bool isLoading, IPAddress iPAddress) : BaseDataForNamed<EnumDataForMainVM>(isLoading)
{
    public IPAddress iPAddress = iPAddress;

    public override EnumDataForMainVM GetEnumDataForNamed()
    {
        if(isLoading) {
            return EnumDataForMainVM.isLoading;
        }
        if(exceptionController.IsWhereNotEqualsNullParameterException()) {
            return EnumDataForMainVM.exception;
        }
        return EnumDataForMainVM.success;
    }

    public override string ToString()
    {
        return $"DataForMainVM(isLoading: {isLoading}, exceptionController: {exceptionController}, iPAddress: {iPAddress})";
    }
}
    
public sealed class MainVM 
{
    // ModelRepository
    private readonly IPAddressRepository<IPAddress,ListIPAddress<IPAddress>> iPAddressRepository = FactoryObjectUtility.GetIPAddressRepository(EnumRWTMode.release);
    
    // NamedUtility
    
    // NamedStreamWState
    private readonly BaseNamedStreamWState<DataForMainVM,EnumDataForMainVM> namedStreamWState;
    
    public MainVM() 
    {
        namedStreamWState = new DefaultStreamWState<DataForMainVM,EnumDataForMainVM>(new DataForMainVM(true,new IPAddress("")));
    }

    public async Task Init() 
    {
        namedStreamWState.ListenStreamDataForNamedFromCallback((_data) =>
        {
            Build();
        });
        var firstRequest = await FirstRequest();
        Utility.DebugPrint($"MainVM: {firstRequest}");
        namedStreamWState.NotifyStreamDataForNamed();
    }

    public void Dispose() 
    {
        namedStreamWState.Dispose();
    }

    private void Build() 
    {
        var dataForNamed = namedStreamWState.GetDataForNamed();
        switch(dataForNamed.GetEnumDataForNamed()) 
        {
            case EnumDataForMainVM.isLoading:
                Utility.DebugPrint("Build: IsLoading");
                break;
            case EnumDataForMainVM.exception:
                Utility.DebugPrint($"Build: Exception({dataForNamed.exceptionController.GetKeyParameterException()})");
                break;
            case EnumDataForMainVM.success:
                Utility.DebugPrint($"Build: Success({dataForNamed.iPAddress})");
                break;
            default:
                break;            
        }
    }

    private async Task<string> FirstRequest() {
        var getIPAddressParameterHttpClientService = await iPAddressRepository.GetIPAddressParameterHttpClientService();
        if(getIPAddressParameterHttpClientService.exceptionController.IsWhereNotEqualsNullParameterException()) 
        {
            return FirstQQFirstRequestQQGetIPAddressParameterHttpClientService(getIPAddressParameterHttpClientService.exceptionController);
        }
        namedStreamWState.GetDataForNamed().isLoading = false;
        namedStreamWState.GetDataForNamed().iPAddress = getIPAddressParameterHttpClientService.parameter!.GetClone();
        return ReadyDataUtility.success;
    }
    
    private string FirstQQFirstRequestQQGetIPAddressParameterHttpClientService(ExceptionController exceptionController)
    {
        namedStreamWState.GetDataForNamed().isLoading = false;
        namedStreamWState.GetDataForNamed().exceptionController = exceptionController;
        return exceptionController.GetKeyParameterException();
    }
}

public class Example
{
    public static async Task Main()
    {
        var mainVM = new MainVM();
        await mainVM.Init();
        mainVM.Dispose();
    }
}
// EXPECTED OUTPUT:
//
// MainVM: success
// Build: Success(IPAddress(ip: ${your_ip}))

/// OR

// EXPECTED OUTPUT:
//
// ===start_to_trace_exception===
//
// WhereHappenedException(Class) --> ${WhereHappenedException(Class)}
// NameException(Class) --> ${NameException(Class)}
// ToString() --> ${ToString()}
//
// ===end_to_trace_exception===
//
// MainVM: ${getKeyParameterException}
// Build: Exception(${getKeyParameterException})