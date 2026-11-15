namespace Restauracja.Shared;

// To widzi klient na stronie statusu, więc nie ma tu imienia.
public class ZamowienieDto
{
    public string Kod { get; set; } = "";
    public DateTime DataZlozenia { get; set; }
    public SposobOdbioru SposobOdbioru { get; set; }
    public StatusZamowienia Status { get; set; }
    public decimal Kwota { get; set; }
    public List<PozycjaZamowieniaDto> Pozycje { get; set; } = new();
}

public class PozycjaZamowieniaDto
{
    public string NazwaDania { get; set; } = "";
    public decimal CenaDania { get; set; }
    public int Ilosc { get; set; }
}
