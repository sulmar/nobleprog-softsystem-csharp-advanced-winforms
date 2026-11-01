# Dzień 1, Moduł 1: Metody rozszerzające

**Metody rozszerzające** *(Extension Methods)* pozwalają dodać nową operację do istniejącego typu bez zmiany jego kodu i bez dziedziczenia. To szczególnie przydatne przy typach, których nie możemy zmienić, jak klasy z bibliotek czy kontrolki WinForms. Technicznie to zwykłe metody statyczne, ale wywołuje się je tak jak metody obiektu, np. `result.IsOutOfRange()`, więc pojawiają się w podpowiedziach IntelliSense. Na tej zasadzie działa też LINQ.

## Historia

Diagnosta zgłasza, że próbka na liście ma wynik poza zakresem, ale po otwarciu wyników nic nie jest oznaczone. Okazuje się, że ta sama reguła istnieje w dwóch formularzach. Klas modeli nie możemy zmienić, bo pochodzą ze wspólnej biblioteki.

## Problem

Otwórz `Problem/`. Dwa formularze, lista próbek i wyniki badań, powielają tę samą logikę:

| Reguła | `SampleListForm` | `ResultsForm` |
|---|---|---|
| Wynik poza zakresem | `<=` i `>=` | `<` i `>` |
| Próbka po terminie | kopia warunku | kopia warunku |
| Kod kreskowy | `LimsHelper.FormatBarcode` | napisany od nowa |
| Kolorowanie wierszy | pętla w handlerze | kopia pętli |

**Widoczny błąd:** glukoza próbki `S-2026-000124` ma wartość 99 mg/dl przy zakresie 70–99. Lista próbek pokazuje dla niej 1 wynik poza zakresem, a okno wyników nie oznacza go jako przekroczenia.

Klasy `Sample` i `TestResult` należą do `Lims.Domain`, której w tym scenariuszu nie zmieniamy, a `DataGridView` to kontrolka frameworka. Nie możemy więc dopisać tam metod. Statyczny `LimsHelper` działa, ale trudno go znaleźć, więc kod i tak jest kopiowany.

## Jak utworzyć metodę rozszerzającą

Metoda musi być statyczna, leżeć w statycznej klasie niezagnieżdżonej i mieć `this` przy pierwszym parametrze:

```csharp
public static bool IsOutOfRange(this TestResult result) { ... }
```

Kompilator zamienia `result.IsOutOfRange()` na `TestResultExtensions.IsOutOfRange(result)`.

Po parametrze z `this` można dodać zwykłe parametry, także opcjonalne. Podajemy je w nawiasach przy wywołaniu:

```csharp
public static string FormatBarcode(this Sample sample, string delimiter = "*") { ... }

sample.FormatBarcode();      // *S2026000123*
sample.FormatBarcode("");    // S2026000123
```

## Ograniczenia

- **Metoda instancyjna wygrywa.** Rozszerzenie o tej samej sygnaturze nie zostanie wywołane, a dodanie takiej metody do klasy po cichu zmieni działanie istniejącego kodu.
- **Wywołanie na `null` jest dozwolone.** To zwykłe wywołanie metody statycznej, więc trzeba jawnie zdecydować, co ma się stać.
- **Brak dostępu do składowych prywatnych.** Rozszerzenie widzi tylko to, co widziałby każdy inny kod (błąd CS0122).
- **Wymagany `using`.** Bez przestrzeni nazw metoda nie pojawi się w podpowiedziach.
- **Brak stanu.** Metoda nie doda pola do typu ani nie przyjmie zależności przez konstruktor.

## Dobre praktyki

- Rozszerzaj konkretne typy. Metody na `object` lub `string` zaśmiecają podpowiedzi w całym projekcie.
- Dla kolekcji przyjmuj `IEnumerable<T>` i nie zmieniaj danych wejściowych.
- Sprawdzaj `null` poza iteratorem, bo w metodzie z `yield` wyjątek pojawi się dopiero przy wyliczaniu.
- Czas i inne wartości zewnętrzne przekazuj parametrem zamiast odczytywać `DateTime.Now` w środku.
- Nie używaj rozszerzeń do logiki wymagającej zależności, takich jak baza czy usługi. Do tego służą serwisy (Dzień 2).

## Uruchomienie

```
dotnet build ExtensionMethods.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
