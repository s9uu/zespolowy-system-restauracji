# Instalacja

Żeby pracować nad naszym projektem, instalujemy dwa darmowe programy: Visual Studio Community i Git.

## Visual Studio Community

https://visualstudio.microsoft.com/vs/community/

To darmowy program do pisania i uruchamiania kodu w C#, a przy instalacji zaznaczamy pakiet „ASP.NET i tworzenie aplikacji internetowych”, dzięki któremu .NET SDK instaluje się razem z nim.

## .NET SDK

https://dotnet.microsoft.com/download

Kto używa innego edytora niż Visual Studio, instaluje .NET SDK osobno z tej strony.

## Git

https://git-scm.com/downloads

Git zapamiętuje kolejne wersje naszych plików i wysyła je na GitHuba, a przy instalacji wystarczy zostawić domyślne ustawienia i klikać „Next”.

## SQLite

SQLite nie instalujemy osobno, bo baza to jeden plik, a jej obsługę dodajemy do projektu jako pakiet NuGet razem z Entity Framework Core.
