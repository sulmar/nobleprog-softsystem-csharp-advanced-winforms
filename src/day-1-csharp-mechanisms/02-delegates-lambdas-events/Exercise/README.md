# Zadanie: alarm dla wyników krytycznych

Czas: około 30–40 minut.

## Sytuacja

Do laboratorium spływają wyniki z analizatora. Niektóre z nich są krytyczne, np. bardzo wysoka glukoza, i ktoś musi na nie od razu zareagować. Dziś wyniki krytyczne wyłapuje się ręcznie, a zdarza się je przeoczyć.

Napisz logikę, która sprawdza wyniki i powiadamia o wynikach krytycznych. Interfejs użytkownika nie jest częścią zadania.

## Wymagania

1. **Sprawdzanie wyników.** System sprawdza każdy wynik, który do niego trafia.
2. **Różne kryteria.** O tym, co jest krytyczne, decyduje laboratorium, i każde może mieć inne zasady. Przykłady: glukoza powyżej 300 albo hemoglobina poniżej 7. Dodanie nowego kryterium nie może wymagać zmiany kodu, który sprawdza wyniki.
3. **Niezależni odbiorcy.** Na wynik krytyczny reagują na razie dwa odbiorcy: licznik alarmów dla dyżurnego i rejestr zapisujący nazwy oznaczeń do audytu. Wkrótce dojdą kolejni. Dodanie odbiorcy nie może wymagać zmiany kodu, który sprawdza wyniki.
4. **Wiarygodność alarmu.** Alarm może ogłosić wyłącznie kod, który sprawdza wyniki. Reszta aplikacji nie może zgłosić fałszywego alarmu ani odłączyć innych odbiorców.
5. **Licznik do włączania.** Dyżurny może w trakcie pracy włączać i wyłączać licznik. Wyłączony licznik nie liczy. Dwukrotne włączenie nie może powodować podwójnego liczenia, a wyłączenie niewłączonego licznika nie jest błędem.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami. Kryterium w scenariuszach to glukoza powyżej 300.

Zacznij od klasy, która sprawdza wyniki, i od licznika alarmów:

```csharp
public class ResultAlarm
{
    public void Check(TestResult result)
    {
        throw new NotImplementedException();
    }
}

public class AlarmCounter
{
    public int Count { get; private set; }

    public void Enable(ResultAlarm alarm)
    {
        throw new NotImplementedException();
    }

    public void Disable(ResultAlarm alarm)
    {
        throw new NotImplementedException();
    }
}
```

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Glukoza 450 | Odbiorcy dostają powiadomienie z tym wynikiem |
| 2 | Glukoza 300 | Brak powiadomienia |
| 3 | Glukoza 90 | Brak powiadomienia |
| 4 | Glukoza 450, a nikt nie czeka na powiadomienia | Nic złego się nie dzieje |
| 5 | Glukoza 450, licznik włączony, rejestr podłączony | Licznik pokazuje 1, a rejestr zawiera „Glukoza” |
| 6 | Dwa wyniki 450, licznik włączony przed pierwszym i wyłączony przed drugim | Licznik pokazuje 1 |
| 7 | Glukoza 450, licznik włączony dwukrotnie | Licznik pokazuje 1 |
| 8 | Dwa systemy z różnymi kryteriami, ten sam wynik | Każdy ocenia wynik według swojego kryterium |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Pozostałe nazwy i sposób rozwiązania należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Które mechanizmy z tego modułu wykorzystałeś i dlaczego właśnie te? Co by się zmieniło, gdyby kryterium składało się z kilku powiązanych operacji?
