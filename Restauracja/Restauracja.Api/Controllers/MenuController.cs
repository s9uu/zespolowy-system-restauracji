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
        new DanieDto
        {
            Id = 1,
            Nazwa = "Żurek",
            Kategoria = "Zupy",
            Cena = 16.00m,
            Dostepne = true,
            Opis = "Tradycyjny żurek na zakwasie z białą kiełbasą i jajkiem.",
            ZdjecieUrl = "images/zurek.jpg",
            Porcja = "350 ml"
        },
        new DanieDto
        {
            Id = 2,
            Nazwa = "Pierogi ruskie",
            Kategoria = "Dania główne",
            Cena = 24.00m,
            Dostepne = true,
            Opis = "Ręcznie lepione pierogi z ziemniakami, twarogiem i cebulką.",
            ZdjecieUrl = "images/pierogi.jpg",
            Porcja = "8 szt."
        },
        new DanieDto
        {
            Id = 3,
            Nazwa = "Sernik",
            Kategoria = "Desery",
            Cena = 14.00m,
            Dostepne = false,
            Opis = "Delikatny sernik na kruchym spodzie.",
            ZdjecieUrl = "images/sernik.jpg",
            Porcja = "150 g"
        }
    };
}
}
