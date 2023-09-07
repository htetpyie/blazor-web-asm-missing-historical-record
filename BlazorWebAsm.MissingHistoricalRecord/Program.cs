using BlazorWebAsm.MissingHistoricalRecord;
using BlazorWebAsm.MissingHistoricalRecord.Services.Book;
using BlazorWebAsm.MissingHistoricalRecord.Services.SupabaseModule;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<SupabaseService>();
builder.Services.AddScoped<BookService>();

await builder.Build().RunAsync();
