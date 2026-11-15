using Microsoft.AspNetCore.Mvc;
using Restauracja.Shared;

namespace Restauracja.Api.Controllers;

[ApiController]
[Route("api/zamowienia")]
public class ZamowieniaController : ControllerBase
{
    [HttpGet("{kod}")]
    public ActionResult<ZamowienieDto> PobierzPoKodzie(string kod)
    {
        // Klient może wpisać kod małymi literami, a kody są zapisane wielkimi.
        var zamowienie = PrzykladoweZamowienia.Lista
            .FirstOrDefault(z => z.Kod == kod.ToUpperInvariant());

        if (zamowienie == null)
            return NotFound("Nie ma takiego zamówienia.");

        // Nowy obiekt, bo zwrócenie ZamowienieKuchniaDto wysłałoby klientowi też imię i „opłacone”.
        return new ZamowienieDto
        {
            Kod = zamowienie.Kod,
            DataZlozenia = zamowienie.DataZlozenia,
            SposobOdbioru = zamowienie.SposobOdbioru,
            Status = zamowienie.Status,
            Kwota = zamowienie.Kwota,
            Pozycje = zamowienie.Pozycje
        };
    }
}
