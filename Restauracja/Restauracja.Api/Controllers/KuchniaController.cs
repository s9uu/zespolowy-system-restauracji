using Microsoft.AspNetCore.Mvc;
using Restauracja.Api.Baza;
using Restauracja.Shared;

namespace Restauracja.Api.Controllers;

[ApiController]
[Route("api/kuchnia/zamowienia")]
public class KuchniaController : ControllerBase
{
    private readonly RestauracjaDbContext baza;

    public KuchniaController(RestauracjaDbContext baza)
    {
        this.baza = baza;
    }

    [HttpGet]
    public List<ZamowienieKuchniaDto> PobierzAktywne()
    {
        // Wydane zamówienie znika z panelu, a najstarsze ma być na górze, żeby żadnego nie pominąć.
        return baza.Zamowienia
            .Where(z => z.Status != StatusZamowienia.Wydane)
            .OrderBy(z => z.DataZlozenia)
            .Select(z => new ZamowienieKuchniaDto
            {
                Kod = z.Kod,
                DataZlozenia = z.DataZlozenia,
                ImieKlienta = z.ImieKlienta,
                SposobOdbioru = z.SposobOdbioru,
                Status = z.Status,
                Kwota = z.Kwota,
                Oplacone = z.Oplacone,
                Pozycje = z.Pozycje
                    .Select(p => new PozycjaZamowieniaDto
                    {
                        NazwaDania = p.NazwaDania,
                        CenaDania = p.CenaDania,
                        Ilosc = p.Ilosc
                    })
                    .ToList()
            })
            .ToList();
    }

    // string, żeby zły status dał nasz komunikat po polsku
    [HttpPut("{kod}/status/{nowyStatus}")]
    public IActionResult ZmienStatus(string kod, string nowyStatus)
    {
        var kodWielkimi = kod.ToUpperInvariant();
        var zamowienie = baza.Zamowienia.FirstOrDefault(z => z.Kod == kodWielkimi);

        if (zamowienie == null)
            return NotFound("Nie ma takiego zamówienia.");

        if (!Enum.TryParse<StatusZamowienia>(nowyStatus, true, out var status) || !Enum.IsDefined(status))
            return BadRequest("Nie ma takiego statusu.");

        // tylko następny status, gdyby ktoś kliknął dwa razy
        if (status != zamowienie.Status + 1)
            return Conflict("Status zamówienia już się zmienił. Odśwież listę.");

        if (status == StatusZamowienia.Wydane && !zamowienie.Oplacone)
            return Conflict("Najpierw oznacz zamówienie jako opłacone.");

        zamowienie.Status = status;
        baza.SaveChanges();

        return NoContent();
    }

    [HttpPut("{kod}/oplacone")]
    public IActionResult OznaczOplacone(string kod)
    {
        var kodWielkimi = kod.ToUpperInvariant();
        var zamowienie = baza.Zamowienia.FirstOrDefault(z => z.Kod == kodWielkimi);

        if (zamowienie == null)
            return NotFound("Nie ma takiego zamówienia.");

        zamowienie.Oplacone = true;
        baza.SaveChanges();

        return NoContent();
    }
}
