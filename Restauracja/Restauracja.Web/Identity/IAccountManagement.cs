using Restauracja.Web.Identity.Models;

namespace Restauracja.Web.Identity
{
    // Na podstawie dotnet/blazor-samples
    /// <summary>
    /// Interfejs do zarządzania kontem użytkownika.
    /// </summary>
    public interface IAccountManagement
    {
        /// <summary>
        /// Logowanie użytkownika.
        /// </summary>
        Task<FormResult> LoginAsync(string email, string password);

        /// <summary>
        /// Wylogowanie użytkownika.
        /// </summary>
        Task LogoutAsync();

        /// <summary>
        /// Rejestracja nowego użytkownika.
        /// </summary>
        Task<FormResult> RegisterAsync(string email, string password);

        /// <summary>
        /// Sprawdzenie, czy użytkownik jest zalogowany.
        /// </summary>
        Task<bool> CheckAuthenticatedAsync();
    }
}
