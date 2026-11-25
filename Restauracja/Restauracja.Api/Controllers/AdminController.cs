using Microsoft.AspNetCore.Mvc;
using Restauracja.Api.Baza;
using Restauracja.Shared;

namespace Restauracja.Api.Controllers;

// Bez [Authorize], bo blokadę dla administratora dodajemy w Sprincie 4.
[ApiController]
[Route("api/admin/dania")]
public class AdminController : ControllerBase
{
    private readonly RestauracjaDbContext baza;

    public AdminController(RestauracjaDbContext baza)
    {
        this.baza = baza;
    }

    [HttpPost]
    public ActionResult<int> DodajDanie(DanieZapisDto dane)
    {
        var blad = SprawdzDane(dane);
        if (blad != null)
            return BadRequest(blad);

        // Nowe danie jest od razu dostępne, bo zakładamy, że kuchnia może je już przygotować.
        var danie = new Danie { Dostepne = true };
        PrzepiszDane(dane, danie);

        baza.Dania.Add(danie);
        baza.SaveChanges();

        return danie.Id;
    }

    [HttpPut("{id}")]
    public IActionResult ZmienDanie(int id, DanieZapisDto dane)
    {
        var danie = ZnajdzDanie(id);
        if (danie == null)
            return NotFound("Nie ma takiego dania.");

        var blad = SprawdzDane(dane);
        if (blad != null)
            return BadRequest(blad);

        PrzepiszDane(dane, danie);
        baza.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult UkryjDanie(int id)
    {
        var danie = ZnajdzDanie(id);
        if (danie == null)
            return NotFound("Nie ma takiego dania.");

        // Danie zostaje w bazie, żeby nie zniknęło ze starych zamówień.
        danie.Usuniete = true;
        baza.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}/dostepne/{dostepne}")]
    public IActionResult UstawDostepnosc(int id, bool dostepne)
    {
        var danie = ZnajdzDanie(id);
        if (danie == null)
            return NotFound("Nie ma takiego dania.");

        // Ustawiamy podaną wartość zamiast przełączać, więc drugie "Wyłącz" nie daje błędu.
        danie.Dostepne = dostepne;
        baza.SaveChanges();

        return NoContent();
    }

    // Ukryte danie zostaje w bazie tylko dla starych zamówień, więc w panelu traktujemy je jak usunięte.
    private Danie? ZnajdzDanie(int id)
    {
        return baza.Dania.FirstOrDefault(d => d.Id == id && !d.Usuniete);
    }

    private string? SprawdzDane(DanieZapisDto dane)
    {
        // Bez Trim() nazwa z samych spacji przeszłaby jako niepusta.
        var nazwa = (dane.Nazwa ?? "").Trim();

        if (nazwa == "")
            return "Podaj nazwę dania.";

        if (nazwa.Length > 100)
            return "Nazwa może mieć najwyżej 100 znaków.";

        if (dane.Cena <= 0)
            return "Cena musi być większa od zera.";

        if (!baza.Kategorie.Any(k => k.Id == dane.KategoriaId))
            return "Nie ma takiej kategorii.";

        if ((dane.Opis ?? "").Trim().Length > 500)
            return "Opis może mieć najwyżej 500 znaków.";

        if ((dane.Porcja ?? "").Trim().Length > 30)
            return "Porcja może mieć najwyżej 30 znaków.";

        return null;
    }

    private static void PrzepiszDane(DanieZapisDto dane, Danie danie)
    {
        danie.Nazwa = (dane.Nazwa ?? "").Trim();
        danie.KategoriaId = dane.KategoriaId;
        danie.Cena = dane.Cena;
        danie.Opis = (dane.Opis ?? "").Trim();
        danie.Porcja = (dane.Porcja ?? "").Trim();
        danie.ZdjecieUrl = (dane.ZdjecieUrl ?? "").Trim();
    }
}
