// Na podstawie dotnet/blazor-samples

namespace Restauracja.Web.Identity.Models
{
    /// <summary>
    /// Wynik logowania lub rejestracji.
    /// </summary>
    public class FormResult
    {
        public bool Succeeded { get; set; }

        public string[] ErrorList { get; set; } = [];
    }
}
