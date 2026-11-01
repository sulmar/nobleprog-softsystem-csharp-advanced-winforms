# Zadanie: zatwierdzanie wyników

Czas: około 40–50 minut.

## Sytuacja

Kierownik laboratorium zatwierdza wyniki badań w oknie `ResultApprovalForm`. Cała logika leży w jednej metodzie obsługi przycisku. Teraz te same zatwierdzenia mają wykonywać też automat nocny oraz system zewnętrzny, które nie mają okna, a dział jakości chce mieć pewność, że reguły działają poprawnie, zanim trafią na produkcję.

Kod okna jest w projekcie `Starter/Lims.Exercise.Form`. Przebuduj go tak, aby spełnić poniższe wymagania, nie zmieniając reguł zatwierdzania.

## Wymagania

1. **Bez okna.** Zatwierdzanie działa bez otwierania żadnego okna, więc automat nocny może użyć tego samego kodu.
2. **Reguły są sprawdzone testami.** Każdą regułę da się sprawdzić testem, bez bazy, wysyłki powiadomień i czekania na konkretną godzinę.
3. **Zmiana bazy.** Przejście na inny sposób przechowywania wyników nie wymaga zmiany reguł zatwierdzania.
4. **Zmiana powiadomień.** Zamiana SMS na e-mail nie wymaga zmiany reguł zatwierdzania.
5. **Okno zostaje proste.** Formularz nadal działa tak samo dla użytkownika, ale odpowiada już tylko za pola i komunikaty.

## Reguły, których nie wolno zmienić

Reguły są zapisane w kodzie okna i podsumowane w scenariuszach. Wynik w zakresie to wartość równa granicy lub między granicami, a wynik krytyczny to wartość większa niż dwukrotność górnej granicy.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami. Zakres referencyjny to 70–100.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Nieznany kod próbki | Odmowa, nic się nie zmienia |
| 2 | Brak nazwiska zatwierdzającego | Odmowa, nic się nie zmienia |
| 3 | Wynik 90 | Zatwierdzony, z nazwiskiem i godziną zatwierdzenia |
| 4 | Wynik 150, bez komentarza | Odmowa, bo wynik poza zakresem wymaga komentarza |
| 5 | Wynik 150, z komentarzem | Zatwierdzony, a komentarz jest zapisany |
| 6 | Wynik 250, z komentarzem | Zatwierdzony, a lekarz dostaje powiadomienie |
| 7 | Wynik 150, z komentarzem | Lekarz nie dostaje powiadomienia |
| 8 | Wynik zatwierdzony wcześniej | Odmowa, a pierwsze zatwierdzenie pozostaje bez zmian |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Nowy kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Podział na klasy i nazwy należą do Ciebie. Na końcu użyj nowego kodu w `Starter/Lims.Exercise.Form`.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Co zostało w formularzu i dlaczego? Gdzie Twoim zdaniem powinna leżeć reguła „wynik poza zakresem wymaga komentarza”, a gdzie wysłanie powiadomienia?
