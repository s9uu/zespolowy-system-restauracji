using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Restauracja.Shared;

namespace Restauracja.Api.Baza;

// Pole UzytkownikId dojdzie w Sprincie 3, razem z kontami.
[Index(nameof(Kod), IsUnique = true)]
public class Zamowienie
{
    public int Id { get; set; }

    [MaxLength(6)]
    public string Kod { get; set; } = "";

    public DateTime DataZlozenia { get; set; }

    [MaxLength(50)]
    public string ImieKlienta { get; set; } = "";

    public SposobOdbioru SposobOdbioru { get; set; }

    public StatusZamowienia Status { get; set; }

    public decimal Kwota { get; set; }

    public bool Oplacone { get; set; }

    public List<PozycjaZamowienia> Pozycje { get; set; } = new();
}
