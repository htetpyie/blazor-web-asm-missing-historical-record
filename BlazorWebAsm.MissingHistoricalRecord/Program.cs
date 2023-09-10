using BlazorWebAsm.MissingHistoricalRecord;
using BlazorWebAsm.MissingHistoricalRecord.Features.Book;
using BlazorWebAsm.MissingHistoricalRecord.Features.BookShelf;
using BlazorWebAsm.MissingHistoricalRecord.Features.Home;
using BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<SupabaseService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<BookShelfService>();
builder.Services.AddScoped<HomeService>();

await builder.Build().RunAsync();
