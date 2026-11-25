namespace Restauracja.Shared;

public class DanieZapisDto
{
    public string Nazwa { get; set; } = "";
    public int KategoriaId { get; set; }
    public decimal Cena { get; set; }
    public string Opis { get; set; } = "";
    public string Porcja { get; set; } = "";
    public string ZdjecieUrl { get; set; } = "";
}
