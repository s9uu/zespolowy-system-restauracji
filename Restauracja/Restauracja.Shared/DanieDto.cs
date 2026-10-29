namespace Restauracja.Shared;

public class DanieDto
{
    public int Id { get; set; }
    public string Nazwa { get; set; } = "";
    public string Kategoria { get; set; } = "";
    public decimal Cena { get; set; }
    public bool Dostepne { get; set; }
}
