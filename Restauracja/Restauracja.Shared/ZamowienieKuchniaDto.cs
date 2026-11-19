namespace Restauracja.Shared;

// Kuchnia widzi wszystko to, co klient, a do tego imię i "opłacone".
public class ZamowienieKuchniaDto : ZamowienieDto
{
    public string ImieKlienta { get; set; } = "";
    public bool Oplacone { get; set; }
}
