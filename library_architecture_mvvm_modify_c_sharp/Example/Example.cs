using library_architecture_mvvm_modify_c_sharp;
using Newtonsoft.Json;

namespace Example;

public static class KeysHttpClientServiceUtility 
{
    /* IPAddress */
    public const string iPAddressQQIp = "ip";
}

public static class KeysExceptionUtility 
{
    /* UNKNOWN */
    public const string uNKNOWN = "uNKNOWN";
}

public static class KeysSuccessUtility 
{
    /* SUCCESS */
    public const string sUCCESS = "sUCCESS";
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
            Timeout = TimeSpan.FromSeconds(10)
        };
        return httpClient;
    }   
}

public class GetEEIPAddressEEWhereJsonipAPIEEParameterHttpClientService<T,Y> where T: IPAddress where Y: ListIPAddress<T> 
{
    protected readonly HttpClientService httpClientService = HttpClientService.instance;

    public async Task<Result<T>> GetIPAddressWhereJsonipAPIParameterHttpClientService() 
    {
        try 
        {
            var response = await httpClientService.GetParameterHttpClient()!.GetAsync("https://jsonip.com/");
            if(!response.IsSuccessStatusCode)
            {
                throw NetworkException.FromKeyAndStatusCode(this,response.StatusCode.ToString(),(int)response.StatusCode);
            }
            var jsonToString = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonToString ?? "") ?? [];
            var iPAddress = new IPAddress(json[KeysHttpClientServiceUtility.iPAddressQQIp] ?? "") as T;
            return Result<T>.Success(iPAddress!);
        } catch(NetworkException networkException)
        {
            return Result<T>.Exception(networkException);
        } catch(Exception e)
        {
            return Result<T>.Exception(new LocalException(this,EnumGuilty.device,KeysExceptionUtility.uNKNOWN,e.ToString()));
        }
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
}

public sealed class MainVM 
{
    // OperationEEModel(EEWhereNamed)[EEFromNamed]EEParameterNamedService
    private readonly GetEEIPAddressEEWhereJsonipAPIEEParameterHttpClientService<IPAddress,ListIPAddress<IPAddress>> getEEIPAddressEEWhereJsonipAPIEEParameterHttpClientService = new();
    // NamedUtility
    
    // Main objects
    private readonly BaseNamedStreamWState<DataForMainVM,EnumDataForMainVM> namedStreamWState;
    private readonly RWTMode rwtMode;
    
    public MainVM() 
    {
        namedStreamWState = new DefaultStreamWState<DataForMainVM,EnumDataForMainVM>(new DataForMainVM(true,new IPAddress("")));
        rwtMode = new RWTMode(
            EnumRWTMode.release,
            [
                new NamedCallback("init", (Func<Task<string>>)(async () =>
                {
                    var getIPAddressWhereJsonipAPIParameterHttpClientService = await getEEIPAddressEEWhereJsonipAPIEEParameterHttpClientService.GetIPAddressWhereJsonipAPIParameterHttpClientService();
                    if(getIPAddressWhereJsonipAPIParameterHttpClientService.exceptionController.IsWhereNotEqualsNullParameterException()) 
                    {
                        return FirstQQInitQQGetIPAddressWhereJsonipAPIParameterHttpClientService(getIPAddressWhereJsonipAPIParameterHttpClientService.exceptionController);
                    }
                    namedStreamWState.GetDataForNamed().isLoading = false;
                    namedStreamWState.GetDataForNamed().iPAddress = getIPAddressWhereJsonipAPIParameterHttpClientService.parameter!.GetClone();
                    return KeysSuccessUtility.sUCCESS;
                })),
            ],
            [
                new NamedCallback("init", (Func<Task<string>>)(async () =>
                {
                    // Simulation get "IPAddress"
                    var iPAddress = new IPAddress("121.121.12.12");
                    await Task.Delay(1000);
                    namedStreamWState.GetDataForNamed().isLoading = false;
                    namedStreamWState.GetDataForNamed().iPAddress = iPAddress.GetClone();
                    return KeysSuccessUtility.sUCCESS;
                })),
            ]
        );
        Init();
    }

    // Override
    public void OnClosed() 
    {
        namedStreamWState.Dispose();
    }

    private async void Init() 
    {
        namedStreamWState.ListenStreamDataForNamedFromCallback((data) =>
        {
            Build();
        });
        var result = await rwtMode.GetNamedCallbackFromName("init").callback();
        Utility.DebugPrint($"MainVM: {result}");
        namedStreamWState.NotifyStreamDataForNamed();
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

    private string FirstQQInitQQGetIPAddressWhereJsonipAPIParameterHttpClientService(ExceptionController exceptionController)
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
        await Task.Delay(10000);
        mainVM.OnClosed();
    }
}
// EXPECTED OUTPUT:
//
// MainVM: sUCCESS
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