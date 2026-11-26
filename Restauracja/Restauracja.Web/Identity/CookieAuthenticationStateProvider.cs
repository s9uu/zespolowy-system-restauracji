using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Restauracja.Web.Identity.Models;

namespace Restauracja.Web.Identity
{
    // Na podstawie dotnet/blazor-samples
    /// <summary>
    /// Obsługuje stan uwierzytelnienia użytkownika opartego na ciasteczkach.
    /// </summary>
    public class CookieAuthenticationStateProvider(
        IHttpClientFactory httpClientFactory,
        ILogger<CookieAuthenticationStateProvider> logger)
        : AuthenticationStateProvider, IAccountManagement
    {
        private readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly HttpClient httpClient =
            httpClientFactory.CreateClient("Auth");

        private bool authenticated = false;

        private readonly ClaimsPrincipal unauthenticated =
            new(new ClaimsIdentity());

        /// <summary>
        /// Rejestruje nowego użytkownika.
        /// </summary>
        public async Task<FormResult> RegisterAsync(string email, string password)
        {
            string[] defaultDetail =
                ["Nie udało się zarejestrować konta. Spróbuj ponownie."];

            try
            {
                var result = await httpClient.PostAsJsonAsync(
                    "api/konto/rejestracja",
                    new
                    {
                        email,
                        password
                    });

                if (result.IsSuccessStatusCode)
                {
                    return new FormResult { Succeeded = true };
                }

                var details = await result.Content.ReadAsStringAsync();
                using var problemDetails = JsonDocument.Parse(details);

                var errors = new List<string>();

                if (problemDetails.RootElement.TryGetProperty(
                    "errors", out var errorList))
                {
                    foreach (var errorEntry in errorList.EnumerateObject())
                    {
                        if (errorEntry.Value.ValueKind == JsonValueKind.String)
                        {
                            errors.Add(errorEntry.Value.GetString()!);
                        }
                        else if (errorEntry.Value.ValueKind == JsonValueKind.Array)
                        {
                            errors.AddRange(
                                errorEntry.Value.EnumerateArray()
                                    .Select(e => e.GetString() ?? string.Empty)
                                    .Where(e => !string.IsNullOrEmpty(e)));
                        }
                    }
                }

                return new FormResult
                {
                    Succeeded = false,
                    ErrorList = errors.Count > 0 ? [.. errors] : defaultDetail
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Błąd podczas rejestracji użytkownika.");
            }

            return new FormResult
            {
                Succeeded = false,
                ErrorList = defaultDetail
            };
        }

        /// <summary>
        /// Loguje użytkownika.
        /// </summary>
        public async Task<FormResult> LoginAsync(string email, string password)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync(
                    "api/konto/login?useCookies=true",
                    new
                    {
                        email,
                        password
                    });

                if (result.IsSuccessStatusCode)
                {
                    NotifyAuthenticationStateChanged(
                        GetAuthenticationStateAsync());

                    return new FormResult { Succeeded = true };
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Błąd podczas logowania użytkownika.");
            }

            return new FormResult
            {
                Succeeded = false,
                ErrorList = ["Zły e-mail lub hasło."]
            };
        }

        /// <summary>
        /// Pobiera aktualny stan uwierzytelnienia.
        /// </summary>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            authenticated = false;

            var user = unauthenticated;

            try
            {
                using var userResponse =
                    await httpClient.GetAsync("api/konto/manage/info");

                userResponse.EnsureSuccessStatusCode();

                var userJson = await userResponse.Content.ReadAsStringAsync();

                var userInfo = JsonSerializer.Deserialize<UserInfo>(
                    userJson,
                    jsonSerializerOptions);

                if (userInfo != null)
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, userInfo.Email),
                        new(ClaimTypes.Email, userInfo.Email)
                    };

                    claims.AddRange(
                        userInfo.Claims
                            .Where(c => c.Key != ClaimTypes.Name &&
                                        c.Key != ClaimTypes.Email)
                            .Select(c => new Claim(c.Key, c.Value)));

                    using var rolesResponse =
                        await httpClient.GetAsync("api/konto/role");

                    rolesResponse.EnsureSuccessStatusCode();

                    var rolesJson =
                        await rolesResponse.Content.ReadAsStringAsync();

                    var roles = JsonSerializer.Deserialize<RoleClaim[]>(
                        rolesJson,
                        jsonSerializerOptions);

                    if (roles?.Length > 0)
                    {
                        foreach (var role in roles)
                        {
                            if (!string.IsNullOrEmpty(role.Type) &&
                                !string.IsNullOrEmpty(role.Value))
                            {
                                claims.Add(new Claim(
                                    role.Type,
                                    role.Value,
                                    role.ValueType ?? ClaimValueTypes.String,
                                    role.Issuer ?? ClaimsIdentity.DefaultIssuer,
                                    role.OriginalIssuer ?? ClaimsIdentity.DefaultIssuer));
                            }
                        }
                    }

                    var identity = new ClaimsIdentity(
                        claims,
                        nameof(CookieAuthenticationStateProvider));

                    user = new ClaimsPrincipal(identity);
                    authenticated = true;
                }
            }
            catch (HttpRequestException ex)
                when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Brak zalogowanego użytkownika – to normalna sytuacja.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Błąd podczas pobierania stanu uwierzytelnienia.");
            }

            return new AuthenticationState(user);
        }

        /// <summary>
        /// Wylogowuje użytkownika.
        /// </summary>
        public async Task LogoutAsync()
        {
            const string empty = "{}";
            var emptyContent = new StringContent(
                empty, Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync(
                "api/konto/wyloguj", emptyContent);

            response.EnsureSuccessStatusCode();

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        /// <summary>
        /// Sprawdza, czy użytkownik jest zalogowany.
        /// </summary>
        public async Task<bool> CheckAuthenticatedAsync()
        {
            await GetAuthenticationStateAsync();
            return authenticated;
        }
    }
}
