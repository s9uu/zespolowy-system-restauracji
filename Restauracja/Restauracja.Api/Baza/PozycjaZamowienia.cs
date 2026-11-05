using Microsoft.EntityFrameworkCore;

namespace Restauracja.Api.Baza;

public class PozycjaZamowienia
{
    public int Id { get; set; }

    public int ZamowienieId { get; set; }

    public int DanieId { get; set; }

    // Kopia z chwili zamówienia, żeby późniejsza zmiana dania nie zmieniała starych zamówień.
    public string NazwaDania { get; set; } = "";
    public decimal CenaDania { get; set; }

    public int Ilosc { get; set; }

    // Domyślnie skasowanie dania skasowałoby też jego pozycje w starych zamówieniach.
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Danie Danie { get; set; } = null!;
}
