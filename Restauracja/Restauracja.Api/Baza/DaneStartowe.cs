namespace Restauracja.Api.Baza;

// Id są wpisane ręcznie, bo HasData ich wymaga.
// Po zmianie tych danych trzeba dodać nową migrację.
public static class DaneStartowe
{
    public static readonly Kategoria[] Kategorie =
    {
        new Kategoria { Id = 1, Nazwa = "Zupy" },
        new Kategoria { Id = 2, Nazwa = "Dania główne" },
        new Kategoria { Id = 3, Nazwa = "Pierogi" },
        new Kategoria { Id = 4, Nazwa = "Desery" },
        new Kategoria { Id = 5, Nazwa = "Napoje" }
    };

    public static readonly Danie[] Dania =
    {
        new Danie
        {
            Id = 1,
            Nazwa = "Żurek",
            Opis = "Tradycyjny żurek na zakwasie z białą kiełbasą i jajkiem.",
            Cena = 16.00m,
            Porcja = "350 ml",
            ZdjecieUrl = "images/zurek.jpg",
            Dostepne = true,
            KategoriaId = 1
        },
        new Danie
        {
            Id = 2,
            Nazwa = "Pierogi ruskie",
            Opis = "Ręcznie lepione pierogi z ziemniakami, twarogiem i cebulką.",
            Cena = 24.00m,
            Porcja = "8 szt.",
            ZdjecieUrl = "images/pierogi.jpg",
            Dostepne = true,
            KategoriaId = 3
        },
        // Niedostępny, żeby w menu było widać wyłączony przycisk „Dodaj do koszyka”.
        new Danie
        {
            Id = 3,
            Nazwa = "Sernik",
            Opis = "Delikatny sernik na kruchym spodzie.",
            Cena = 14.00m,
            Porcja = "150 g",
            ZdjecieUrl = "images/sernik.jpg",
            Dostepne = false,
            KategoriaId = 4
        },
        new Danie
        {
            Id = 4,
            Nazwa = "Rosół",
            Opis = "Domowy rosół z makaronem i natką pietruszki.",
            Cena = 14.00m,
            Porcja = "350 ml",
            Dostepne = true,
            KategoriaId = 1
        },
        new Danie
        {
            Id = 5,
            Nazwa = "Kotlet schabowy",
            Opis = "Kotlet schabowy z ziemniakami i kapustą zasmażaną.",
            Cena = 34.00m,
            Porcja = "400 g",
            Dostepne = true,
            KategoriaId = 2
        },
        new Danie
        {
            Id = 6,
            Nazwa = "Pierogi z mięsem",
            Opis = "Ręcznie lepione pierogi z mięsem, podawane ze skwarkami.",
            Cena = 26.00m,
            Porcja = "8 szt.",
            Dostepne = true,
            KategoriaId = 3
        },
        new Danie
        {
            Id = 7,
            Nazwa = "Szarlotka",
            Opis = "Ciepła szarlotka z cynamonem.",
            Cena = 13.00m,
            Porcja = "150 g",
            Dostepne = true,
            KategoriaId = 4
        },
        new Danie
        {
            Id = 8,
            Nazwa = "Kompot",
            Opis = "Domowy kompot z owoców sezonowych.",
            Cena = 8.00m,
            Porcja = "300 ml",
            Dostepne = true,
            KategoriaId = 5
        }
    };
}
