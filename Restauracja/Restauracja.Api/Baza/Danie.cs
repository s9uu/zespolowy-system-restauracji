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

    // zostaje w bazie, bo jest w starych zamówieniach
    public bool Usuniete { get; set; }

    public int KategoriaId { get; set; }

    // EF Core to uzupełni przy odczycie
    public Kategoria Kategoria { get; set; } = null!;
}
