using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restauracja.Api.Baza;
using Restauracja.Shared;

namespace Restauracja.Api.Controllers;

[ApiController]
[Route("api/zamowienia")]
public class ZamowieniaController : ControllerBase
{
    // Bez 0, O, 1 i I, żeby klient nie pomylił znaków, gdy przepisuje kod.
    private const string ZnakiKodu = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

    private readonly RestauracjaDbContext baza;

    public ZamowieniaController(RestauracjaDbContext baza)
    {
        this.baza = baza;
    }

    [HttpPost]
    public ActionResult<ZamowienieDto> ZlozZamowienie(NoweZamowienieDto nowe)
    {
        var imie = (nowe.ImieKlienta ?? "").Trim();

        if (imie == "")
            return BadRequest("Podaj imię.");

        if (imie.Length > 50)
            return BadRequest("Imię może mieć najwyżej 50 znaków.");

        if (nowe.SposobOdbioru == null || !Enum.IsDefined(nowe.SposobOdbioru.Value))
            return BadRequest("Wybierz: na miejscu albo na wynos.");

        if (nowe.Pozycje == null || nowe.Pozycje.Count == 0)
            return BadRequest("Koszyk jest pusty.");

        // Najpierw sprawdzamy każdą ilość, a dopiero potem łączymy to samo danie w jedną pozycję.
        if (nowe.Pozycje.Any(p => p.Ilosc < 1))
            return BadRequest("Ilość każdego dania musi wynosić co najmniej 1.");

        var ilosci = new Dictionary<int, int>();
        foreach (var pozycja in nowe.Pozycje)
            ilosci[pozycja.DanieId] = ilosci.GetValueOrDefault(pozycja.DanieId) + pozycja.Ilosc;

        var idDan = ilosci.Keys.ToList();
        var dania = baza.Dania.Where(d => idDan.Contains(d.Id)).ToList();

        var zamowienie = new Zamowienie
        {
            Kod = NowyKod(),
            DataZlozenia = DateTime.Now,
            ImieKlienta = imie,
            SposobOdbioru = nowe.SposobOdbioru.Value,
            Status = StatusZamowienia.Nowe,
            Oplacone = false
        };

        foreach (var (danieId, ilosc) in ilosci)
        {
            var danie = dania.FirstOrDefault(d => d.Id == danieId);

            if (danie == null || danie.Usuniete)
                return BadRequest("Jednego z dań nie ma już w menu. Odśwież menu i sprawdź koszyk.");

            if (!danie.Dostepne)
                return BadRequest($"Danie „{danie.Nazwa}” jest chwilowo niedostępne. Usuń je z koszyka.");

            // Cenę bierzemy z bazy, a nie od klienta, i kopiujemy ją, żeby późniejsza zmiana menu nie zmieniła zamówienia.
            zamowienie.Pozycje.Add(new PozycjaZamowienia
            {
                DanieId = danie.Id,
                NazwaDania = danie.Nazwa,
                CenaDania = danie.Cena,
                Ilosc = ilosc
            });
        }

        zamowienie.Kwota = zamowienie.Pozycje.Sum(p => p.CenaDania * p.Ilosc);

        baza.Zamowienia.Add(zamowienie);
        baza.SaveChanges();

        return CreatedAtAction(nameof(PobierzPoKodzie), new { kod = zamowienie.Kod }, NaDto(zamowienie));
    }

    [HttpGet("{kod}")]
    public ActionResult<ZamowienieDto> PobierzPoKodzie(string kod)
    {
        // Klient może wpisać kod małymi literami, a kody są zapisane wielkimi.
        var kodWielkimi = kod.ToUpperInvariant();

        var zamowienie = baza.Zamowienia
            .Include(z => z.Pozycje)
            .FirstOrDefault(z => z.Kod == kodWielkimi);

        if (zamowienie == null)
            return NotFound("Nie ma takiego zamówienia.");

        return NaDto(zamowienie);
    }

    // Losujemy, dopóki nie trafimy na kod, którego jeszcze nie ma w bazie.
    // RandomNumberGenerator, żeby nie dało się przewidzieć cudzego kodu.
    private string NowyKod()
    {
        string kod;
        do
        {
            kod = "";
            for (int i = 0; i < 6; i++)
                kod += ZnakiKodu[RandomNumberGenerator.GetInt32(ZnakiKodu.Length)];
        }
        while (baza.Zamowienia.Any(z => z.Kod == kod));

        return kod;
    }

    // Bez imienia i pola „opłacone”, bo to widzi klient.
    private static ZamowienieDto NaDto(Zamowienie zamowienie)
    {
        return new ZamowienieDto
        {
            Kod = zamowienie.Kod,
            DataZlozenia = zamowienie.DataZlozenia,
            SposobOdbioru = zamowienie.SposobOdbioru,
            Status = zamowienie.Status,
            Kwota = zamowienie.Kwota,
            Pozycje = zamowienie.Pozycje
                .Select(p => new PozycjaZamowieniaDto
                {
                    NazwaDania = p.NazwaDania,
                    CenaDania = p.CenaDania,
                    Ilosc = p.Ilosc
                })
                .ToList()
        };
    }
}
