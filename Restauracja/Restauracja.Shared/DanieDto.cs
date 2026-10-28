namespace Restauracja.Shared;

// Dane jednego dania, które Api wysyła do Web.
// Ta sama klasa jest w obu aplikacjach, więc obie znają te same pola.
public class DanieDto
{
    public int Id { get; set; }
    public string Nazwa { get; set; } = "";
    public string Kategoria { get; set; } = "";
    public decimal Cena { get; set; }
    public bool Dostepne { get; set; }
}
