# Instalacja

Żeby pracować nad naszym projektem, instalujemy Visual Studio Community 2022 (razem z nim instaluje się .NET 9) i Git.

## Visual Studio Community 2022

https://aka.ms/vs/17/release/vs_community.exe

Używamy Visual Studio 2022, a nie 2026: ten link pobiera instalator wersji 2022, a przy instalacji zaznaczamy pakiet „ASP.NET i tworzenie aplikacji internetowych”.

Jeśli Visual Studio pokaże żółty pasek o aktualizacji, klikamy „Update 17.14”, a nie „Install Visual Studio 2026”.

## .NET 9 SDK

https://dotnet.microsoft.com/download/dotnet/9.0

Używamy .NET 9: Visual Studio 2022 instaluje go razem z pakietem ASP.NET, a sprawdzisz to w Widok → Terminal poleceniem `dotnet --version` (wynik ma się zaczynać od 9).

## Git

https://git-scm.com/downloads

Git zapamiętuje kolejne wersje naszych plików i wysyła je na GitHuba, a przy instalacji wystarczy zostawić domyślne ustawienia i klikać „Next”.

## SQLite

SQLite nie instalujemy osobno, bo baza to jeden plik, a jej obsługę dodajemy do projektu jako pakiet NuGet razem z Entity Framework Core.

## Uruchomienie

1. W Visual Studio kliknij Git → Klonuj repozytorium i wklej adres https://github.com/s9uu/zespolowy-system-restauracji.
2. Otwórz plik Restauracja.sln z folderu Restauracja.
3. U góry, na lewo od zielonej strzałki, jest lista z napisem „Restauracja.Api” – wybierz z niej profil „Api + Web”, który uruchamia Api i Web naraz, i naciśnij F5. Jeśli tego profilu nie ma, ustaw go w Projekt → Konfiguruj projekty startowe (Api i Web: Uruchom, https).
4. Przy pierwszym uruchomieniu mogą pojawić się dwa okna z pytaniem o certyfikat – w obu klikamy „Tak”.
5. W przeglądarce kliknij Menu w bocznym pasku – powinna się pokazać tabela z trzema daniami.
6. Czarnych okien konsoli nie zamykamy, bo to działające Api i Web. Aplikację zatrzymujemy w Visual Studio klawiszami Shift+F5.

Jeśli przy projektach jest dopisek „(zwolniony)”, kliknij je prawym przyciskiem i wybierz „Załaduj ponownie projekt”.

## Przed pierwszym commitem

W Visual Studio kliknij Git → Ustawienia → Ustawienia globalne Git i wpisz nazwę użytkownika z GitHuba oraz adres e-mail noreply ze strony https://github.com/settings/emails (wygląda tak: 12345678+login@users.noreply.github.com). Dzięki temu commity od razu liczą się na Twoje konto, a prywatny e-mail nie jest widoczny w repozytorium.
