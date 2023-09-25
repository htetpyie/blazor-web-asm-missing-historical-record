using Microsoft.JSInterop;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.Loading;

public class LoadingService : ILoadingService
{
    private readonly IJSRuntime _jsRuntime;

    public LoadingService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public void EnableLoading()
    {
         _jsRuntime.InvokeVoidAsync("enableLoading");
    }
    public void DisableLoading()
    {
         _jsRuntime.InvokeVoidAsync("disableLoading");

    }
}