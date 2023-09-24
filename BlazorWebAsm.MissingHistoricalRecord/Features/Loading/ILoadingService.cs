namespace BlazorWebAsm.MissingHistoricalRecord.Features.Loading;

public interface ILoadingService
{
    Task EnableLoading();
    Task DisableLoading();
}