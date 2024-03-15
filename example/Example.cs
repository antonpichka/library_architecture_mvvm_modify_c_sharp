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

public enum EnumDataForMainView {
    isLoading,
    exception,
    success
}

public sealed class DataForMainView(bool isLoading, IPAddress iPAddress) : BaseDataForNamed<EnumDataForMainView>(isLoading)
{
    public IPAddress iPAddress = iPAddress;

    public override EnumDataForMainView GetEnumDataForNamed()
    {
        if(isLoading) {
            return EnumDataForMainView.isLoading;
        }
        if(exceptionController.IsWhereNotEqualsNullParameterException()) {
            return EnumDataForMainView.exception;
        }
        return EnumDataForMainView.success;
    }
}

public interface IMainViewModel {
}

public sealed class TestMainViewModel : BaseNamedViewModel<DataForMainView, EnumDataForMainView, DefaultStreamWState<DataForMainView, EnumDataForMainView>>, IMainViewModel
{
    // OperationEEModel(EEWhereNamed)[EEFromNamed]EEParameterNamedService
    // NamedUtility
    
    public TestMainViewModel() : base(new DefaultStreamWState<DataForMainView, EnumDataForMainView>(new DataForMainView(true,new IPAddress(""))))
    {
    }

    public override async Task<string> Init()
    {
        // Simulation get "IPAddress"
        var iPAddress = new IPAddress("121.121.12.12");
        await Task.Delay(1);
        GetDataForNamedParameterNamedStreamWState().isLoading = false;
        GetDataForNamedParameterNamedStreamWState().iPAddress = iPAddress.GetClone();
        return KeysSuccessUtility.sUCCESS;
    }
}

public sealed class MainViewModel : BaseNamedViewModel<DataForMainView, EnumDataForMainView, DefaultStreamWState<DataForMainView, EnumDataForMainView>>, IMainViewModel
{
    // OperationEEModel(EEWhereNamed)[EEFromNamed]EEParameterNamedService
    private readonly GetEEIPAddressEEWhereJsonipAPIEEParameterHttpClientService<IPAddress,ListIPAddress<IPAddress>> getEEIPAddressEEWhereJsonipAPIEEParameterHttpClientService = new();

    // NamedUtility
    
    public MainViewModel() : base(new DefaultStreamWState<DataForMainView, EnumDataForMainView>(new DataForMainView(true,new IPAddress(""))))
    {
    }

    public override async Task<string> Init()
    {
        var getIPAddressWhereJsonipAPIParameterHttpClientService = await getEEIPAddressEEWhereJsonipAPIEEParameterHttpClientService.GetIPAddressWhereJsonipAPIParameterHttpClientService();
        if(getIPAddressWhereJsonipAPIParameterHttpClientService.exceptionController.IsWhereNotEqualsNullParameterException()) 
        {
            return FirstQQInitQQGetIPAddressWhereJsonipAPIParameterHttpClientService(getIPAddressWhereJsonipAPIParameterHttpClientService.exceptionController);
        }
        GetDataForNamedParameterNamedStreamWState().isLoading = false;
        GetDataForNamedParameterNamedStreamWState().iPAddress = getIPAddressWhereJsonipAPIParameterHttpClientService.parameter!.GetClone();
        return KeysSuccessUtility.sUCCESS;
    }

    private string FirstQQInitQQGetIPAddressWhereJsonipAPIParameterHttpClientService(ExceptionController exceptionController)
    {
        GetDataForNamedParameterNamedStreamWState().isLoading = false;
        GetDataForNamedParameterNamedStreamWState().exceptionController = exceptionController;
        return exceptionController.GetKeyParameterException();
    }
}

public sealed class MainView 
{
    /// RELEASE CODE
    private readonly MainViewModel viewModel;
    /// TEST CODE
    // private readonly TestMainViewModel viewModel;
    
    public MainView() 
    {
        /// RELEASE CODE
        viewModel = new MainViewModel();
        /// TEST CODE
        // viewModel = new TestMainViewModel();
        InitParameterViewModel();
    }
    
    public void DisposeParameterViewModel() 
    {
        viewModel.Dispose();
    }

    private async void InitParameterViewModel() 
    {
        viewModel.ListenStreamDataForNamedFromCallbackParameterNamedStreamWState((data) => {
            BuildParameterViewModel();
        });
        var result = await viewModel.Init();
        Utility.DebugPrint($"MainView: {result}");
        viewModel.NotifyStreamDataForNamedParameterNamedStreamWState();
    }

    private void BuildParameterViewModel() 
    {
        var dataForNamedParameterNamedStreamWState = viewModel.GetDataForNamedParameterNamedStreamWState();
        switch(dataForNamedParameterNamedStreamWState.GetEnumDataForNamed()) 
        {
            case EnumDataForMainView.isLoading:
                Utility.DebugPrint("Build: IsLoading");
                break;
            case EnumDataForMainView.exception:
                Utility.DebugPrint($"Build: Exception({dataForNamedParameterNamedStreamWState.exceptionController.GetKeyParameterException()})");
                break;
            case EnumDataForMainView.success:
                Utility.DebugPrint($"Build: Success({dataForNamedParameterNamedStreamWState.iPAddress})");
                break;
            default:
                break;            
        }
    }
}

public class Example
{
    public static async Task Main(string[] args)
    {
        var mainView = new MainView();
        await Task.Delay(10000);
        mainView.DisposeParameterViewModel();
        // EXPECTED OUTPUT:
        //
        // MainView: sUCCESS
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
        // MainView: ${getKeyParameterException}
        // Build: Exception(${getKeyParameterException})
    }
}