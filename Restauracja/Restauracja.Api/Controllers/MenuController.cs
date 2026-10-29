using Microsoft.AspNetCore.Mvc;
using Restauracja.Shared;

namespace Restauracja.Api.Controllers;

[ApiController]
[Route("api/menu")]
public class MenuController : ControllerBase
{
    // Na razie dania są wpisane w kodzie, w Sprincie 1 przyjdą z bazy.
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
