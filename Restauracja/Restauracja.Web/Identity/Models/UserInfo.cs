// Na podstawie dotnet/blazor-samples

namespace Restauracja.Web.Identity.Models
{
    /// <summary>
    /// Informacje o zalogowanym użytkowniku.
    /// </summary>
    public class UserInfo
    {
        public string Email { get; set; } = string.Empty;

        public bool IsEmailConfirmed { get; set; }

        public Dictionary<string, string> Claims { get; set; } = [];
    }
}
