namespace Restauracja.Shared;

// Web wysyła tylko to, co klient wybrał. Ceny i kwotę Api bierze z bazy.
public class NoweZamowienieDto
{
    public string ImieKlienta { get; set; } = "";

    // null, gdy klient nie wybrał sposobu odbioru. Wtedy Api zwraca 400.
    public SposobOdbioru? SposobOdbioru { get; set; }

    public List<PozycjaKoszykaDto> Pozycje { get; set; } = new();
}

public class PozycjaKoszykaDto
{
    public int DanieId { get; set; }
    public int Ilosc { get; set; }
}
