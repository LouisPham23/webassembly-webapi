using Data;
using FrontEnd;
using FrontEnd.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IBookService, FrontEnd.Services.BookService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7295/");
});
builder.Services.AddHttpClient<IGenreService, FrontEnd.Services.GenreService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7295/");
});
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
