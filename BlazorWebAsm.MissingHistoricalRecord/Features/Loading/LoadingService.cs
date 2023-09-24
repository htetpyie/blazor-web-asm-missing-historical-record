using Microsoft.JSInterop;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.Loading;

public class LoadingService : ILoadingService
{
    private readonly IJSRuntime _jsRuntime;

    public LoadingService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task EnableLoading()
    {
        await _jsRuntime.InvokeVoidAsync("enableLoading");
    }
    public async Task DisableLoading()
    {
        await _jsRuntime.InvokeVoidAsync("disableLoading");

    }
}