# Dzień 1, Moduł 2: Delegaty, lambdy i zdarzenia

**Delegat** to typ, którego wartością jest metoda, więc zachowanie można przekazać jako parametr, zapisać w zmiennej lub połączyć z innym. 

**Lambda** to krótki zapis takiej metody, a domknięcie pozwala jej korzystać ze zmiennych z otoczenia. 

**Zdarzenie** to delegat z ograniczonym dostępem: nadawca powiadamia odbiorców, nie wiedząc, kim są.

## Historia

Aplikacja wyników badań rosła z każdym zgłoszeniem: nowe filtry, import z analizatora, okna podglądu. Każda zmiana wymagała edycji tego samego kodu, a użytkownicy zgłaszają spowolnienie po całym dniu pracy.

## Problem

Otwórz `Problem/`. Aplikacja pokazuje wyniki badań, pozwala je filtrować, importować i drukować raporty, a okna podglądu pokazują ostatni wydruk.

| Miejsce | Problem | Objaw |
|---|---|---|
| `ResultImporter` | Logowanie zaszyte w metodzie importu | Inny sposób logowania wymaga jej zmiany, a test zapisuje plik |
| `Printer` | Drukarka sama liczy koszt wydruku | Nowy cennik wymaga zmiany klasy drukarki |
| `Printer` | Drukarka zna `MainForm`, by ogłosić koniec drukowania | Każdy nowy odbiorca wymaga zmiany klasy drukarki |
| `Printer.PrintCompleted` | Publiczne pole delegata zamiast zdarzenia | Każdy może je wywołać lub nadpisać przez `=` |
| `ResultQueries` | Osobna metoda na każdą kombinację filtrów | Kolejny filtr podwaja liczbę metod |
| `ResultQueries` | Dwa raporty różnią się jednym wierszem | Powielona pętla |
| `ResultImporter` | Import zna `MainForm`, by pokazać postęp | Bez formularza trzeba przekazać `null` |
| `PreviewForm` | Okno zna `MainForm`, by dopisać wpis do logu | `AddLogEntry` nie może być prywatna |
| `PreviewForm` | Subskrypcja nie jest usuwana | **Zamknięte okna nadal obsługują wydruki** |

Aby zobaczyć ostatni problem, otwórz i zamknij dwa podglądy, a potem kliknij „Drukuj raport”. Licznik pokazuje 2 subskrypcje przy 0 otwartych oknach, a log pokazuje wpisy od zamkniętych podglądów.

## Action, Func i Predicate

```csharp
Action<string> log = text => Console.WriteLine(text);          // nic nie zwraca
Func<TestResult, string> format = result => result.Analyte;    // ostatni typ to wynik
Predicate<TestResult> filter = result => result.IsOutOfRange(); // zwraca bool
```

`Predicate<T>` i `Func<T, bool>` mają tę samą sygnaturę, ale są różnymi typami. `List<T>.FindAll` oczekuje `Predicate<T>`, a LINQ `Where` oczekuje `Func<T, bool>`. Lambdę można przekazać do obu, ale gotowej zmiennej jednego typu nie przypiszemy do drugiego bez konwersji.

## Delegat a zdarzenie

`event` to delegat z ograniczonym dostępem: kompilator tworzy prywatne pole oraz publiczne metody `add` i `remove`. Poza klasą dostępne są tylko `+=` i `-=`.

| Operacja poza klasą | Pole delegata | `event` |
|---|---|---|
| `+=` i `-=` | Działa | Działa |
| `printer.PrintCompleted = handler` | Działa i usuwa pozostałych | CS0070 |
| `printer.PrintCompleted = null` | Działa i usuwa wszystkich | CS0070 |
| `printer.PrintCompleted(...)` | Działa | CS0070 |

Delegat jako parametr pasuje, gdy wywołujący podaje jedno zachowanie. Zdarzenie pasuje, gdy obiekt ogłasza, że coś się stało, a odbiorcy zapisują się sami.

## Domknięcia

- **Przechwytywana jest zmienna, nie wartość.** Lambda widzi późniejsze zmiany zmiennej.
- **Przechwycona zmienna żyje tak długo jak lambda,** co może wydłużyć życie obiektów.

## Zarządzanie subskrypcjami

- **Nadawca trzyma referencję do odbiorcy.** Jeśli nadawca żyje dłużej, odbiorca musi się wypisać, inaczej nie zostanie zwolniony z pamięci.
- **Lambdy nie da się wypisać inną, identyczną lambdą.** To dwa różne delegaty, więc `-=` nic nie zrobi. Użyj metody lub zapisz delegat w polu.
- **Dwukrotne `+=` to dwa wywołania.** Pomaga wypisanie tuż przed zapisaniem.
- **Usuwanie nieistniejącej subskrypcji jest bezpieczne.**
- **Kontrolki formularza nie wymagają wypisywania,** jeśli nadawca i odbiorca żyją tyle samo, np. przycisk i jego formularz.

## Uruchomienie

```
dotnet build DelegatesLambdasEvents.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
