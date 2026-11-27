using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Restauracja.Web;
using Restauracja.Web.Services;
using Restauracja.Web.Identity;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Handler obsługujący cookies dla wszystkich zapytań do API.
builder.Services.AddTransient<CookieHandler>();

// Wspólny klient HTTP z obsługą cookies.
builder.Services.AddHttpClient("Auth", client =>
{
    client.BaseAddress = new Uri("https://localhost:7097/");
})
.AddHttpMessageHandler<CookieHandler>();

// Domyślny HttpClient również korzysta z tego samego handlera.
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Auth"));

builder.Services.AddScoped<CartService>();

// Obsługa stanu uwierzytelnienia.
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<CookieAuthenticationStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(sp =>
    sp.GetRequiredService<CookieAuthenticationStateProvider>());

builder.Services.AddScoped<IAccountManagement>(sp =>
    sp.GetRequiredService<CookieAuthenticationStateProvider>());

await builder.Build().RunAsync();
