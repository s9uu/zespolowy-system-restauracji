using System.ComponentModel.DataAnnotations;

namespace Restauracja.Api.Baza;

public class Danie
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Nazwa { get; set; } = "";

    [MaxLength(500)]
    public string? Opis { get; set; }

    public decimal Cena { get; set; }

    [MaxLength(30)]
    public string? Porcja { get; set; }

    public string? ZdjecieUrl { get; set; }

    public bool Dostepne { get; set; }

    // usunięte zostaje w bazie, bo może być w starych zamówieniach
    public bool Usuniete { get; set; }

    public int KategoriaId { get; set; }

    // null!, bo wypełnia to EF Core przy odczycie
    public Kategoria Kategoria { get; set; } = null!;
}
