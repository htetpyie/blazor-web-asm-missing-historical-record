using BlazorWebAsm.MissingHistoricalRecord;
using BlazorWebAsm.MissingHistoricalRecord.Features.Book;
using BlazorWebAsm.MissingHistoricalRecord.Features.BookContent;
using BlazorWebAsm.MissingHistoricalRecord.Features.Bookmark;
using BlazorWebAsm.MissingHistoricalRecord.Features.BookShelf;
using BlazorWebAsm.MissingHistoricalRecord.Features.Home;
using BlazorWebAsm.MissingHistoricalRecord.Features.Loading;
using BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule;
using BlazorWebAsm.MissingHistoricalRecord.Features.WishedBook;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddSingleton<ILoadingService,LoadingService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<SupabaseService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<BookShelfService>();
builder.Services.AddScoped<BookContentService>();
builder.Services.AddScoped<BookmarkService>();
builder.Services.AddScoped<WishedBookService>();
builder.Services.AddScoped<HomeService>();
builder.Services.AddScoped<BookmarkState>();
builder.Services.AddScoped<WishedBookState>();

await builder.Build().RunAsync();
