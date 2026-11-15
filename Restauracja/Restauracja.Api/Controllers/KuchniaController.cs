using Microsoft.AspNetCore.Mvc;
using Restauracja.Shared;

namespace Restauracja.Api.Controllers;

[ApiController]
[Route("api/kuchnia/zamowienia")]
public class KuchniaController : ControllerBase
{
    [HttpGet]
    public List<ZamowienieKuchniaDto> PobierzAktywne()
    {
        // Wydane zamówienie znika z panelu, a najstarsze ma być na górze, żeby żadnego nie pominąć.
        return PrzykladoweZamowienia.Lista
            .Where(z => z.Status != StatusZamowienia.Wydane)
            .OrderBy(z => z.DataZlozenia)
            .ToList();
    }
}
