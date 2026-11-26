using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace Restauracja.Web.Identity
{
    // Na podstawie dotnet/blazor-samples
    /// <summary>
    /// Handler automatycznie dołączający ciasteczka do zapytań API.
    /// </summary>
    public class CookieHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // Dołączanie ciasteczek uwierzytelniających.
            request.SetBrowserRequestCredentials(
                BrowserRequestCredentials.Include);

            request.Headers.Add("X-Requested-With", "XMLHttpRequest");

            return base.SendAsync(request, cancellationToken);
        }
    }
}
