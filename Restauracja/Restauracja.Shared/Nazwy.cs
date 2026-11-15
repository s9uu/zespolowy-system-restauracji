namespace Restauracja.Shared;

// Jedno miejsce z polskimi nazwami, żeby strona statusu i panel kuchni pisały to samo.
public static class Nazwy
{
    public static string PoPolsku(StatusZamowienia status)
    {
        return status switch
        {
            StatusZamowienia.Nowe => "Nowe",
            StatusZamowienia.WPrzygotowaniu => "W przygotowaniu",
            StatusZamowienia.Gotowe => "Gotowe",
            StatusZamowienia.Wydane => "Wydane",
            _ => status.ToString()
        };
    }

    public static string PoPolsku(SposobOdbioru sposob)
    {
        return sposob switch
        {
            SposobOdbioru.NaMiejscu => "Na miejscu",
            SposobOdbioru.NaWynos => "Na wynos",
            _ => sposob.ToString()
        };
    }
}
