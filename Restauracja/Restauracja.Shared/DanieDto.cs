namespace Restauracja.Shared;

public class DanieDto
{
    public int Id { get; set; }
    public string Nazwa { get; set; } = "";
    public string Kategoria { get; set; } = "";
    public decimal Cena { get; set; }
    public bool Dostepne { get; set; }
    public string Opis { get; set; } = "";
    public string ZdjecieUrl { get; set; } = "";
    public string Porcja { get; set; } = "";
}
