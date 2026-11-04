# Zadanie: generator opisów badań laboratoryjnych

Czas: około 30–40 minut.

## Sytuacja

Laboratorium medyczne przygotowuje system udostępniający opisy badań. Użytkownik podaje **kod badania** i określa, czy opis ma zawierać dodatkową instrukcję przygotowania.

Kody badań są wielorazowe. Każde wywołanie tworzy niezależny opis.

Zaimplementuj klasę `LabReportGenerator` z metodą:

```csharp
string GenerateReport(string code, bool preparation)
```

## Wymagania funkcjonalne

1. **Glukoza.** Kod `GLU` zwraca:
   ```text
   Badanie: Glukoza
   ```
2. **Hemoglobina.** Kod `HGB` zwraca:
   ```text
   Badanie: Hemoglobina
   ```
3. **Instrukcja przygotowania.** Gdy `preparation` ma wartość `true`, dodaj w nowym wierszu:
   ```text
   Przygotowanie: zgodnie z instrukcją laboratorium.
   ```
4. **Brak dodatku.** Gdy `preparation` ma wartość `false`, zwróć wyłącznie nazwę badania.
5. **Pusty kod.** Dla `null`, pustego ciągu lub samych spacji rzuć `ArgumentException` z komunikatem `"Test code is required"`.
6. **Nieznany kod.** Rzuć `ArgumentException` z komunikatem `"Invalid test code"`.
7. **Wielokrotne użycie.** Wcześniejsze wywołania nie mogą wpływać na kolejne. Wygenerowanie opisu z instrukcją nie powoduje dodawania jej do następnych opisów.

## Wymagania niefunkcjonalne

- Pracuj zgodnie z techniką **TDD**:
  - **Red**: napisz test, który nie przechodzi.
  - **Green**: dodaj minimalny kod pozwalający przejść test.
  - **Refactor**: uporządkuj kod, zachowując poprawność testów.
- Zadbaj o czytelność i możliwość dodawania nowych badań oraz dodatkowych sekcji opisu.
- Do oddzielania wierszy używaj `Environment.NewLine`. Nie dodawaj pustego wiersza na końcu.

## Przykładowe użycie

```csharp
var generator = new LabReportGenerator();

Console.WriteLine(generator.GenerateReport("GLU", true));
```

Oczekiwany wynik:

```text
Badanie: Glukoza
Przygotowanie: zgodnie z instrukcją laboratorium.
```

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod początkowy jest w `Starter/Lims.Exercise/LabReportGenerator.cs`, a testy pisz w `Starter/Lims.Exercise.Tests/LabReportGeneratorTests.cs`. Zacznij od testu, nie od kodu. Po każdym zielonym teście zrób commit albo przynajmniej zatrzymaj się i zdecyduj, czy jest co refaktoryzować.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Który test pierwszy wymusił coś więcej niż `return "Badanie: Glukoza";`? W którym momencie `if`/`switch` po kodzie badania przestał wystarczać i co go zastąpiło? Co trzeba zmienić, aby dodać trzecie badanie, a co, aby dodać nową sekcję opisu, np. „Czas oczekiwania na wynik”? Który wzorzec z dzisiejszego dnia pasowałby do składania opisu z sekcji?
