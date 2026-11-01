# Słowniczek zasad SOLID

Skróty z komentarzy `// PROBLEM:` w kodzie i z materiałów szkolenia.

## SOLID

| Litera | Skrót | Nazwa angielska | Nazwa polska | Co oznacza | Objaw naruszenia | Przykład z laboratorium |
|---|---|---|---|---|---|---|
| S | **SRP** | Single Responsibility Principle | Zasada pojedynczej odpowiedzialności | Klasa ma jeden powód do zmiany | Zmiana w jednym obszarze wymaga edycji klasy, która zajmuje się też czymś innym | Formularz wyników liczy też zakres referencyjny, więc reguły nie da się sprawdzić bez okna |
| O | **OCP** | Open/Closed Principle | Zasada otwarte-zamknięte | Nowe zachowanie dodajemy nowym kodem, bez zmiany działającego | Każdy nowy wariant to kolejny `if` lub `case` w tej samej metodzie | Nowy format pliku z analizatora wymaga zmiany metody importu |
| L | **LSP** | Liskov Substitution Principle | Zasada podstawienia Liskov | Klasa pochodna działa wszędzie tam, gdzie klasa bazowa, bez niespodzianek | Klasa pochodna zgłasza `NotSupportedException` lub kod sprawdza typ przez `is` | Wydruk raportu zgłasza wyjątek dla jednego rodzaju badania, choć interfejs obiecuje wydruk każdego |
| I | **ISP** | Interface Segregation Principle | Zasada segregacji interfejsów | Klient zależy tylko od metod, których używa | Klasa implementuje metody, których nie potrzebuje, często puste | Okno podglądu korzysta z interfejsu, który wymaga też zatwierdzania i wysyłki wyniku |
| D | **DIP** | Dependency Inversion Principle | Zasada odwrócenia zależności | Logika zależy od abstrakcji, a nie od konkretnych klas | Klasa sama tworzy zależności przez `new` albo korzysta ze stanu statycznego | Serwis wyników sam tworzy połączenie z bazą i czyta `DateTime.Now`, więc test wymaga bazy i zależy od zegara |

## Inny skrót używany w materiałach

`DRY` nie należy do SOLID, ale pojawia się w tych samych komentarzach.

| Skrót | Nazwa angielska | Nazwa polska | Co oznacza | Objaw naruszenia | Przykład z laboratorium |
|---|---|---|---|---|---|
| **DRY** | Don't Repeat Yourself | Nie powtarzaj się | Każda reguła ma w kodzie jedną definicję | Tę samą zmianę trzeba wprowadzić w kilku miejscach, a kopie zaczynają się różnić | Dwa formularze inaczej sprawdzają zakres referencyjny i pokazują inny wynik dla tej samej próbki |
