# System zamówień online dla restauracji

Aplikacja internetowa dla małej restauracji. Klient zamawia jedzenie przez stronę i płaci przy odbiorze. Kuchnia widzi zamówienia i zmienia ich status. Właściciel zarządza menu.

Projekt zespołowy systemu informatycznego, Politechnika Opolska, Wydział Informatyki, semestr zimowy 2026/27, grupa 6.

## Wizja

Restauracja przyjmuje wszystkie zamówienia w jednym miejscu, bez kartek i telefonów. Klient zamawia w kilka minut, kuchnia gotuje z jednej listy, a właściciel sam dba o aktualne menu.

## Propozycja wartości

Co zyskuje każdy użytkownik:

- **Klient:** szybko widzi menu z cenami i zamawia bez dzwonienia. Płaci dopiero przy odbiorze. Wie, kiedy jedzenie jest gotowe, więc nie czeka w kolejce.
- **Kuchnia:** ma jedną czytelną listę zamówień w kolejności złożenia. Status zmienia jednym kliknięciem.
- **Właściciel:** sam zmienia menu, ceny i dostępność dań. Klienci nie zamawiają dań, których zabrakło.

## Wymagania biznesowe

1. **WB1.** Wszystkie zamówienia trafiają do jednego systemu, a nie na kartki i do arkusza.
2. **WB2.** Jest mniej pomyłek, bo klient sam wybiera dania z aktualnego menu i widzi łączną kwotę.
3. **WB3.** Klient wie, kiedy odebrać jedzenie, więc nie czeka i nie dostaje zimnego jedzenia.
4. **WB4.** Klient chętnie wraca, bo ma konto i widzi swoje wcześniejsze zamówienia.
5. **WB5.** Właściciel sam zmienia menu, ceny i dostępność dań, bez pomocy informatyka.
6. **WB6.** Restauracja wie, które zamówienia są już opłacone.
7. **WB7.** Tylko uprawnione osoby mogą zmieniać zamówienia i menu.

## Wymagania funkcjonalne

1. **Menu.** Klient widzi dania w kategoriach, z ceną, opisem i zdjęciem. Dania niedostępne są oznaczone.
2. **Koszyk.** Klient dodaje dania do koszyka i zmienia ich ilość. System liczy łączną kwotę.
3. **Składanie zamówienia.** Klient wybiera: na miejscu albo na wynos. Płaci przy odbiorze. System sprawdza, czy dania są nadal dostępne.
4. **Status zamówienia.** Zamówienie ma status, np. nowe, w przygotowaniu, gotowe, wydane. Klient widzi aktualny status.
5. **Panel kuchni.** Pracownik widzi aktywne zamówienia od najstarszego. Zmienia status jednym kliknięciem. Przy wydaniu oznacza zamówienie jako opłacone.
6. **Panel administratora.** Właściciel dodaje, edytuje i usuwa dania. Oznacza dania jako dostępne albo niedostępne.
7. **Konta i logowanie.** Każde konto ma rolę: klient, pracownik albo administrator. Klient widzi listę swoich zamówień.

## Wymagania niefunkcjonalne

1. **Szybkość.** Strona odpowiada w mniej niż 2 sekundy, gdy korzysta z niej kilkanaście osób naraz.
2. **Telefon i komputer.** Strona działa w popularnych przeglądarkach (Chrome, Firefox, Edge, Safari) i dobrze wygląda na telefonie.
3. **Prosta obsługa.** Nowy pracownik uczy się obsługi panelu kuchni w 10 minut.
4. **Bezpieczne hasła.** Hasła jako hash z solą, połączenie przez HTTPS.
5. **Dostęp według ról.** Panel kuchni widzi tylko pracownik i administrator. Panel administratora widzi tylko administrator.
6. **Dane osobowe.** System zbiera tylko dane potrzebne do zamówienia: imię, adres e-mail i hasło. Działamy zgodnie z RODO.

## User stories

| Nr | User story | WB | Sprint |
|---|---|---|---|
| US1 | Jako klient chcę przeglądać menu z podziałem na kategorie i cenami, aby szybko wybrać danie. | WB2 | 1 |
| US2 | Jako klient chcę dodawać dania do koszyka i zmieniać ich ilość, aby przed zamówieniem znać łączną kwotę. | WB2 | 1 |
| US3 | Jako klient chcę złożyć zamówienie na miejscu albo na wynos i zapłacić przy odbiorze, aby nie podawać danych płatniczych w internecie. | WB1 | 2 |
| US4 | Jako klient chcę sprawdzać status zamówienia, aby przyjść po nie, gdy będzie gotowe. | WB3 | 2 |
| US5 | Jako klient chcę założyć konto i się logować, aby widzieć historię swoich zamówień. | WB4 | 3 |
| US6 | Jako pracownik kuchni chcę widzieć aktywne zamówienia w kolejności złożenia, aby żadnego nie pominąć. | WB1 | 2 |
| US7 | Jako pracownik kuchni chcę jednym kliknięciem zmieniać status zamówienia, a przy wydaniu oznaczać je jako opłacone, aby klient wiedział, na jakim etapie jest jego jedzenie, a restauracja wiedziała, które zamówienia są rozliczone. | WB3, WB6 | 2 |
| US8 | Jako właściciel chcę dodawać, edytować i usuwać dania oraz oznaczać je jako niedostępne, aby menu zgadzało się z tym, co kuchnia może przygotować. | WB5 | 3 |
| US9 | Jako właściciel chcę, aby panele kuchni i administratora były dostępne tylko dla kont z odpowiednią rolą, aby klient nie mógł zmieniać zamówień ani menu. | WB7 | 3 |

## MVP

Gotowe MVP pokażemy **11.12.2026**.

W MVP są:

- menu z kategoriami, cenami i oznaczeniem dań niedostępnych,
- koszyk i złożenie zamówienia (na miejscu albo na wynos) z płatnością przy odbiorze,
- podgląd statusu zamówienia przez klienta,
- panel kuchni: lista zamówień, zmiana statusu, oznaczenie „opłacone”,
- panel administratora: zarządzanie menu i dostępnością dań,
- logowanie z rolami: klient, pracownik, administrator,
- konto klienta z listą jego zamówień.

**Rozszerzenia**, jeśli starczy czasu: płatność online przez Stripe (tryb testowy), raport sprzedaży.

**Poza zakresem:** dostawa do domu, kody SMS przy logowaniu.

## Harmonogram

Scrum, sprinty po 2 tygodnie, przegląd na koniec każdego sprintu.

| Faza | Termin | Co powstaje | Przegląd |
|---|---|---|---|
| Sprint 0 | 16.10–29.10.2026 | opis produktu, lista user stories, repozytorium, makiety ekranów | 30.10.2026 |
| Sprint 1 | 30.10–12.11.2026 | baza danych, menu, koszyk | 13.11.2026 |
| Sprint 2 | 13.11–26.11.2026 | składanie zamówienia, panel kuchni | 27.11.2026 |
| Sprint 3 | 27.11–10.12.2026 | logowanie i role, panel administratora | 11.12.2026 (gotowe MVP) |
| Sprint 4 | 11.12.2026–07.01.2027 | płatność online przez Stripe (tryb testowy) i testy; przerwa świąteczna 23.12–06.01 | 08.01.2027 |
| Sprint 5 | 08.01–21.01.2027 | poprawki, dokumentacja, prezentacja | 22.01.2027 (oddanie) |

Kamienie milowe: **16.10.2026** plan projektu, **11.12.2026** gotowe MVP, **22.01.2027** oddanie systemu.

### Wykres Gantta

```mermaid
gantt
    title Harmonogram projektu
    dateFormat YYYY-MM-DD
    axisFormat %d.%m

    section Sprinty
    Sprint 0           : s0, 2026-10-16, 14d
    Sprint 1           : s1, 2026-10-30, 14d
    Sprint 2           : s2, 2026-11-13, 14d
    Sprint 3           : s3, 2026-11-27, 14d
    Sprint 4           : s4, 2026-12-11, 28d
    Sprint 5           : s5, 2027-01-08, 14d

    section Przerwa
    Przerwa świąteczna : 2026-12-23, 15d

    section Kamienie milowe
    Plan projektu      : milestone, 2026-10-16, 0d
    Gotowe MVP         : milestone, 2026-12-11, 0d
    Oddanie systemu    : milestone, 2027-01-22, 0d
```

## Zadania

Tablica zadań w GitHub Projects: (https://github.com/users/s9uu/projects/2), zatytułowana **Backlog**

Tablica jest publiczna. Ma kolumny: Do zrobienia, W trakcie i Zrobione. Taski zostały podzielone na kategorie, odpowiednio zaetykietowane i opisane.

## Wykorzystanie AI

Zgodnie z zasadami kursu oznaczamy, gdzie korzystamy z narzędzi AI.

- **Narzędzia:** Claude (Anthropic), ChatGPT (OpenAI).
- **Do czego:** pomoc przy planowaniu i porządkowaniu dokumentacji (opis produktu, user stories, harmonogram) oraz wsparcie przy pisaniu i sprawdzaniu kodu.
- **Co robimy sami:** decyzje projektowe, podział pracy i ostateczną treść.

Listę uzupełniamy, gdy AI pomaga w nowym obszarze.

## Zespół i role

| Osoba | Rola w Scrumie | Część techniczna |
|---|---|---|
| Maciej Poczkajski | Product Owner, Developer | backend: baza danych, statusy zamówień, logowanie i role |
| Mariia Merenkova | Scrum Master, Developer | frontend: wygląd aplikacji, panel kuchni, panel administratora; harmonogram |
| Krzysztof Kozielski | Developer | backend: menu, koszyk, zamówienia, zarządzanie menu |
| Fabian Puchała | Developer | frontend: strony dla klienta (menu, koszyk, zamówienie, status, konto); repozytorium i tablica zadań |

## Technologia

- backend: ASP.NET Core Web API
- frontend: Blazor WebAssembly
- baza danych: SQLite przez Entity Framework Core
- wszystko w C#, dwie osobne aplikacje w jednym rozwiązaniu
- instrukcja instalacji i uruchomienia: [instalacja.md](instalacja.md)
- model danych z diagramem ERD: [model-danych.md](model-danych.md)
