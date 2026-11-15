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
}
