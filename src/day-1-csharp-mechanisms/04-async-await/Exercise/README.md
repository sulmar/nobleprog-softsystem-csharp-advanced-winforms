# Zadanie: wysyłka wyników do systemów zewnętrznych

Czas: około 40–50 minut.

## Sytuacja

Po zatwierdzeniu wyników laboratorium przekazuje je do kilku systemów zewnętrznych: szpitala, przychodni i rejestru badań. Każdy system odpowiada w innym czasie, a niektóre bywają niedostępne. Dziś wysyłka odbywa się po kolei, trwa długo, a awaria jednego systemu zatrzymuje pozostałe. Użytkownik nie wie, jak daleko jest wysyłka, i nie może jej przerwać.

Napisz logikę wysyłki. Interfejs użytkownika nie jest częścią zadania, ale okno, które z niej skorzysta, ma cały czas reagować.

Zacznij od tej klasy:

```csharp
public class ResultExporter
{
}
```

## Wymagania

1. **Krótki czas.** Wysyłka do wszystkich systemów trwa tyle co do najwolniejszego z nich, a nie sumę ich czasów.
2. **Okno reaguje.** Rozpoczęcie wysyłki nie zatrzymuje wątku, który ją uruchomił.
3. **Postęp.** Użytkownik widzi, do ilu systemów wysyłka już się zakończyła, także gdy zakończyła się błędem.
4. **Odporność na awarie.** Niedostępny system nie zatrzymuje pozostałych. Na końcu wiadomo, które systemy przyjęły wyniki, a które nie.
5. **Przerwanie.** Użytkownik może przerwać wysyłkę w dowolnej chwili. Przerwanie to nie awaria: kod wywołujący musi móc je odróżnić.
6. **Testy bez czekania.** Testy nie mogą zależeć od rzeczywistego czasu odpowiedzi systemów.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Trzy systemy, żaden jeszcze nie odpowiedział | Wysyłka trwa do wszystkich trzech jednocześnie |
| 2 | Wszystkie systemy przyjmują wyniki | Na końcu wszystkie są na liście udanych |
| 3 | Jeden z trzech systemów jest niedostępny | Pozostałe dwa przyjmują wyniki, a jeden jest na liście nieudanych |
| 4 | Systemy odpowiadają jeden po drugim | Postęp: 1, 2, 3 |
| 5 | System niedostępny | Liczy się do postępu tak samo jak pozostałe |
| 6 | Użytkownik przerywa w trakcie | Wysyłka kończy się sygnałem o przerwaniu, a nie listą nieudanych systemów |
| 7 | Brak systemów | Wysyłka kończy się od razu z pustymi listami |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Pozostałe nazwy i sposób rozwiązania należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Co się stanie, gdy kod wywołujący zablokuje wątek okna, czekając na zakończenie wysyłki? Jak zadbać, by Twoja klasa nie była podatna na taki błąd?
