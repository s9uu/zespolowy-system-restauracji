using Microsoft.EntityFrameworkCore;

namespace Restauracja.Api.Baza;

public class PozycjaZamowienia
{
    public int Id { get; set; }

    public int ZamowienieId { get; set; }

    public int DanieId { get; set; }

    // kopia z chwili zamówienia, zmiana dania nie rusza starych zamówień
    public string NazwaDania { get; set; } = "";
    public decimal CenaDania { get; set; }

    public int Ilosc { get; set; }

    // bez tego skasowanie dania skasuje pozycje w starych zamówieniach
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Danie Danie { get; set; } = null!;
}
