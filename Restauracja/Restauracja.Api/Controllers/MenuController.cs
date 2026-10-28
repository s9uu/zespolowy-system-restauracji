using Microsoft.AspNetCore.Mvc;
using Restauracja.Shared;

namespace Restauracja.Api.Controllers;

// Kontroler menu: odpowiada pod adresem /api/menu.
[ApiController]
[Route("api/menu")]
public class MenuController : ControllerBase
{
    // GET /api/menu: zwraca listę dań.
    // Na razie dania są wpisane w kodzie.
    // W Sprincie 1 przyjdą z bazy SQLite.
    [HttpGet]
    public List<DanieDto> PobierzMenu()
    {
        return new List<DanieDto>
        {
            new DanieDto { Id = 1, Nazwa = "Żurek",
                Kategoria = "Zupy", Cena = 16.00m, Dostepne = true },
            new DanieDto { Id = 2, Nazwa = "Pierogi ruskie",
                Kategoria = "Dania główne", Cena = 24.00m, Dostepne = true },
            new DanieDto { Id = 3, Nazwa = "Sernik",
                Kategoria = "Desery", Cena = 14.00m, Dostepne = false }
        };
    }
}
