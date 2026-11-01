# Zadanie: długie operacje bez zamrażania okna

Czas: około 35–45 minut.

## Sytuacja

W aplikacji laboratorium przybywa długich operacji: generowanie raportu zbiorczego, eksport wyników do systemu szpitalnego, przeliczanie statystyk. Każda trwa wiele sekund, a użytkownicy skarżą się, że okno wtedy nie reaguje. Kilka formularzy ma już własne, różne próby naprawy, a jeden z nich zamyka się bez komunikatu, gdy eksport się nie uda.

Napisz jedną klasę, której mogą używać wszystkie formularze do uruchamiania takich operacji. Formularz przekazuje operację i mówi, co zrobić z jej wynikiem oraz co zrobić, gdy się nie uda.

Zacznij od tej klasy:

```csharp
public static class BackgroundRunner
{
}
```

## Wymagania

1. **Okno reaguje.** Uruchomienie operacji wraca od razu, a sama operacja działa poza wątkiem, który ją uruchomił.
2. **Wynik trafia do okna.** Po zakończeniu operacji formularz dostaje wynik i może bezpiecznie zmienić swoje kontrolki.
3. **Błąd trafia do okna.** Gdy operacja się nie uda, formularz dostaje informację o błędzie i może ją pokazać, także bezpiecznie dla kontrolek. Aplikacja się nie zamyka.
4. **Różne operacje.** Ta sama klasa obsługuje operacje zwracające różne typy wyników, np. tekst raportu albo liczbę wyeksportowanych rekordów.
5. **Bez okna w testach.** Klasa nie zależy od WinForms, więc da się ją przetestować bez otwierania formularza.
6. **Błędne użycie.** Pominięcie któregoś z potrzebnych elementów (`null`) zgłasza `ArgumentNullException` od razu przy uruchomieniu.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Operacja, która jeszcze trwa | Uruchomienie już się zakończyło, a operacja dalej działa |
| 2 | Dowolna operacja | Działa w innym wątku niż ten, który ją uruchomił |
| 3 | Operacja zwraca 42 | Wynik 42 dociera do formularza, dopiero gdy obsłuży go wątek okna |
| 4 | Operacja zgłasza błąd | Informacja o błędzie dociera tą samą drogą, a wynik nie |
| 5 | Operacja zwraca tekst „Raport” | Tekst dociera do formularza |
| 6 | Brak operacji albo reakcji na wynik lub błąd | `ArgumentNullException` przy uruchomieniu |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Pozostałe nazwy i sposób rozwiązania należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Jak w teście sprawdzić, że wynik dociera do wątku okna, skoro w teście nie ma żadnego okna? Co jeszcze mogłoby się nie udać, gdy użytkownik zamknie formularz w trakcie operacji?
