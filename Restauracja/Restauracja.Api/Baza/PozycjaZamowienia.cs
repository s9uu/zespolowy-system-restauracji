using Microsoft.EntityFrameworkCore;

namespace Restauracja.Api.Baza;

public class PozycjaZamowienia
{
    public int Id { get; set; }

    public int ZamowienieId { get; set; }

    public int DanieId { get; set; }

    // zapisujemy nazwę i cenę, bo menu może się zmienić
    public string NazwaDania { get; set; } = "";
    public decimal CenaDania { get; set; }

    public int Ilosc { get; set; }

    // usunięcie dania nie może skasować starych zamówień
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Danie Danie { get; set; } = null!;
}
