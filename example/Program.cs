using System;
using library_architecture_mvvm_modify_c_sharp;

namespace Program;

public enum EnumDataForProgram {
    IsLoading,
    Exception,
    Success
}

public class DataForProgram(bool isLoading) : BaseDataForNamed<EnumDataForProgram>(isLoading)
{
    public override EnumDataForProgram GetEnumDataForNamed()
    {
        if(isLoading) {
            return EnumDataForProgram.IsLoading;
        }
        if(exceptionController.IsWhereNotEqualsNullParameterException()) {
            return EnumDataForProgram.Exception;
        }
        return EnumDataForProgram.Success;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var defaultStreamWState = new DefaultStreamWState<DataForProgram,EnumDataForProgram>(new DataForProgram(true));
        switch(defaultStreamWState.GetDataForNamed().GetEnumDataForNamed()) {
            case EnumDataForProgram.IsLoading:
                Utility.DebugPrint("IsLoading");
                break;
            case EnumDataForProgram.Exception:
                Utility.DebugPrint("Exception");
                break;
            case EnumDataForProgram.Success:
                Utility.DebugPrint("Success");
                break;
            default:
                break;    
        }
        defaultStreamWState.ListenStreamDataForNamedFromCallback((DataForProgram dataForProgram) => {
            Utility.DebugPrint($"Event: {dataForProgram.isLoading}");
        });
        defaultStreamWState.GetDataForNamed().isLoading = false;
        defaultStreamWState.NotifyStreamDataForNamed();
    }
}
