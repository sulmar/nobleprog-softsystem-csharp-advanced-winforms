# Zadanie: magazyn odczynników

Czas: około 40–50 minut.

## Sytuacja

Analizatory pobierają odczynniki z dwóch magazynów, a technicy w tym samym czasie przenoszą je między magazynami. Wszystko dzieje się równocześnie. Ostatnio stan w systemie nie zgadzał się ze stanem na półce, raz zarejestrowano pobranie odczynnika, którego już nie było, a podczas przenoszenia aplikacja przestała odpowiadać i trzeba było ją zamknąć.

Napisz logikę magazynu. Interfejs użytkownika nie jest częścią zadania.

Zacznij od tej klasy:

```csharp
public class ReagentStock
{
}
```

## Wymagania

1. **Poprawny stan.** Żadne pobranie ani uzupełnienie nie może zginąć, nawet gdy dzieją się w tej samej chwili.
2. **Bez wydawania ponad stan.** Pobranie większej ilości, niż jest w magazynie, się nie udaje i nie zmienia stanu. Stan nigdy nie jest ujemny.
3. **Przenoszenie.** Odczynnik można przenieść między dwoma magazynami w obu kierunkach, także jednocześnie. Przenoszenie nigdy nie może zablokować aplikacji, a suma w obu magazynach pozostaje taka sama. Jeśli w magazynie źródłowym brakuje odczynnika, nic się nie zmienia.
4. **Historia.** Każda udana operacja trafia do historii. Żaden wpis nie może zginąć.
5. **Stanowiska przygotowania.** Przygotowanie odczynnika trwa, a magazyn ma dwa stanowiska. Na wolne stanowisko można czekać, ale okno aplikacji nie może w tym czasie stać. Nieudane przygotowanie zwalnia stanowisko.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami. Scenariusze 1–4 uruchamiaj z wielu wątków naraz, tak by szansa na wykrycie błędu była jak największa.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Stan 0, 8 wątków uzupełnia po 10 000 razy po 1 | Stan 80 000 |
| 2 | Stan 100, 50 wątków próbuje pobrać po 5 | Udaje się dokładnie 20 pobrań, a stan to 0 |
| 3 | Stan 3, pobranie 5 | Nie udaje się, stan nadal 3 |
| 4 | Magazyny po 1000, jednocześnie przenoszenie z A do B i z B do A, po 1000 razy | Praca się kończy, a suma to 2000 |
| 5 | Przenoszenie większej ilości, niż jest w źródle | Nie udaje się, a stany się nie zmieniają |
| 6 | 8 wątków uzupełnia po 1000 razy | Historia ma 8000 wpisów |
| 7 | 5 przygotowań, które jeszcze trwają | Działają tylko 2, a reszta czeka |
| 8 | Przygotowanie kończy się błędem | Stanowisko jest znów wolne |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Pozostałe nazwy i sposób rozwiązania należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Test wielowątkowy przeszedł 100 razy z rzędu. Czy to dowodzi, że kod jest poprawny? Co jeszcze sprawdzisz, zanim uznasz go za bezpieczny?
