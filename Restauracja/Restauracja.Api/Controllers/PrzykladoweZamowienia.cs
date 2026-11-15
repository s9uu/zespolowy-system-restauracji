using Restauracja.Shared;

namespace Restauracja.Api.Controllers;

// Tymczasowe dane, żeby strony /status i /kuchnia miały co pokazać, zanim zamówienia trafią do bazy.
// Gdy będzie zapis w bazie, kontrolery będą czytać z bazy, a ten plik usuniemy.
public static class PrzykladoweZamowienia
{
    public static readonly List<ZamowienieKuchniaDto> Lista = new()
    {
        new ZamowienieKuchniaDto
        {
            Kod = "K7F2QX",
            DataZlozenia = DateTime.Now.AddMinutes(-40),
            ImieKlienta = "Anna",
            SposobOdbioru = SposobOdbioru.NaMiejscu,
            Status = StatusZamowienia.Gotowe,
            Oplacone = true,
            Kwota = 48.00m,
            Pozycje = new()
            {
                new PozycjaZamowieniaDto { NazwaDania = "Żurek", CenaDania = 16.00m, Ilosc = 2 },
                new PozycjaZamowieniaDto { NazwaDania = "Kompot", CenaDania = 8.00m, Ilosc = 2 }
            }
        },
        new ZamowienieKuchniaDto
        {
            Kod = "H9ZR2C",
            DataZlozenia = DateTime.Now.AddMinutes(-5),
            ImieKlienta = "Ola",
            SposobOdbioru = SposobOdbioru.NaMiejscu,
            Status = StatusZamowienia.Nowe,
            Oplacone = false,
            Kwota = 56.00m,
            Pozycje = new()
            {
                new PozycjaZamowieniaDto { NazwaDania = "Kotlet schabowy", CenaDania = 34.00m, Ilosc = 1 },
                new PozycjaZamowieniaDto { NazwaDania = "Rosół", CenaDania = 14.00m, Ilosc = 1 },
                new PozycjaZamowieniaDto { NazwaDania = "Kompot", CenaDania = 8.00m, Ilosc = 1 }
            }
        },
        new ZamowienieKuchniaDto
        {
            Kod = "B4MN8T",
            DataZlozenia = DateTime.Now.AddMinutes(-20),
            ImieKlienta = "Tomek",
            SposobOdbioru = SposobOdbioru.NaWynos,
            Status = StatusZamowienia.WPrzygotowaniu,
            Oplacone = false,
            Kwota = 37.00m,
            Pozycje = new()
            {
                new PozycjaZamowieniaDto { NazwaDania = "Pierogi ruskie", CenaDania = 24.00m, Ilosc = 1 },
                new PozycjaZamowieniaDto { NazwaDania = "Szarlotka", CenaDania = 13.00m, Ilosc = 1 }
            }
        },
        // Wydane: strona statusu je pokazuje, a panel kuchni już nie.
        new ZamowienieKuchniaDto
        {
            Kod = "W3DPLS",
            DataZlozenia = DateTime.Now.AddMinutes(-90),
            ImieKlienta = "Marek",
            SposobOdbioru = SposobOdbioru.NaWynos,
            Status = StatusZamowienia.Wydane,
            Oplacone = true,
            Kwota = 52.00m,
            Pozycje = new()
            {
                new PozycjaZamowieniaDto { NazwaDania = "Pierogi z mięsem", CenaDania = 26.00m, Ilosc = 2 }
            }
        }
    };
}
