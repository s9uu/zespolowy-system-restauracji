
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Restauracja.Web;
using Restauracja.Web.Services;
using Restauracja.Web.Identity;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Handler obs³uguj¹cy cookies dla wszystkich zapytañ do API.
builder.Services.AddTransient<CookieHandler>();

// Wspólny klient HTTP z obs³ug¹ cookies.
builder.Services.AddHttpClient("Auth", client =>
{
    client.BaseAddress = new Uri("https://localhost:7097/");
})
.AddHttpMessageHandler<CookieHandler>();

// Domyœlny HttpClient równie¿ korzysta z tego samego handlera.
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Auth"));

builder.Services.AddScoped<CartService>();

// Obs³uga stanu uwierzytelnienia.
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<CookieAuthenticationStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(sp =>
    sp.GetRequiredService<CookieAuthenticationStateProvider>());

builder.Services.AddScoped<IAccountManagement>(sp =>
    sp.GetRequiredService<CookieAuthenticationStateProvider>());

await builder.Build().RunAsync();
