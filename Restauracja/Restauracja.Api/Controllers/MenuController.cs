using Microsoft.AspNetCore.Mvc;
using Restauracja.Api.Baza;
using Restauracja.Shared;

namespace Restauracja.Api.Controllers;

[ApiController]
[Route("api/menu")]
public class MenuController : ControllerBase
{
    private readonly RestauracjaDbContext baza;

    public MenuController(RestauracjaDbContext baza)
    {
        this.baza = baza;
    }

    [HttpGet]
    public List<DanieDto> PobierzMenu()
    {
        return baza.Dania
            .Where(d => !d.Usuniete)
            .OrderBy(d => d.KategoriaId)
            .ThenBy(d => d.Id)
            .Select(d => new DanieDto
            {
                Id = d.Id,
                Nazwa = d.Nazwa,
                Kategoria = d.Kategoria.Nazwa,
                Cena = d.Cena,
                Dostepne = d.Dostepne,
                // Web oczekuje tekstu, a w bazie te pola mogą być puste.
                Opis = d.Opis ?? "",
                ZdjecieUrl = d.ZdjecieUrl ?? "",
                Porcja = d.Porcja ?? ""
            })
            .ToList();
    }
}
