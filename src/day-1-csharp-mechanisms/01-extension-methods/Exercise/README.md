# Zadanie: najpierw wyniki najbardziej odbiegające od normy

Czas: około 25–30 minut.

## Sytuacja

Lekarz przegląda dziesiątki wyników i chce najpierw widzieć te, które najbardziej odbiegają od normy. Programiści potrzebują do tego dwóch operacji na wynikach i chcą je znajdować w podpowiedziach, wpisując kropkę przy wyniku lub przy liście wyników.

Klasa `TestResult` pochodzi ze wspólnej biblioteki `Lims.Domain` i nie wolno jej zmieniać.

## Jak chcemy tego używać

```csharp
var result = new TestResult { Value = 120m, ReferenceLow = 80m, ReferenceHigh = 100m };

decimal deviation = result.DeviationPercent();   // 20

var critical = results.CriticalFirst(20m);       // odchylenie co najmniej 20%, od największego
```

## Wymagania

1. **Odchylenie od normy.** Odchylenie to odległość wyniku od przekroczonej granicy zakresu, wyrażona w procentach tej granicy. Wynik w zakresie, także równy granicy, ma odchylenie 0. Zakładamy, że granice zakresu są większe od zera.
2. **Wyniki krytyczne.** Z dowolnej kolekcji wyników wybieramy te, których odchylenie jest równe progowi lub większe, zaczynając od największego. Kolekcja, od której zaczynamy, pozostaje bez zmian.
3. **Brak danych.** Wywołanie bez wyniku lub bez kolekcji (`null`) zgłasza `ArgumentNullException` od razu, a nie dopiero przy przeglądaniu wyników.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami. Zakres referencyjny to 80–100.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Wynik 120 | Odchylenie 20 |
| 2 | Wynik 60 | Odchylenie 25 |
| 3 | Wyniki 80, 90 i 100 | Odchylenie 0 |
| 4 | Wyniki 110, 120, 150 i 90, próg 20 | Kolejno 150 i 120 |
| 5 | Lista wyników 120 i 150, próg 10 | Po wybraniu lista nadal ma kolejność 120, 150 |
| 6 | Brak wyniku | `ArgumentNullException` |
| 7 | Brak kolekcji | `ArgumentNullException` przy samym wywołaniu |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Pozostałe nazwy i sposób rozwiązania należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Dla chętnych (wymaga Windows)

Użyj odchylenia w aplikacji `Solution/Lims.Problem`: w oknie wyników oznacz na czerwono wyniki z odchyleniem co najmniej 50%, a pozostałe wyniki poza zakresem zostaw oznaczone jak dotąd.

## Do dyskusji

Kolega proponuje operację `ToBarcode()` dostępną przy każdym napisie, tak aby kod próbki można było zamienić na kod kreskowy. Co o tym sądzisz? Pomyśl o tym, co zobaczy każdy programista w podpowiedziach przy dowolnym napisie.
