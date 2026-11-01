# Zadanie: wysyłka wyników do przychodni

Czas: około 40–50 minut.

## Sytuacja

Laboratorium wysyła wyniki do przychodni. Wysyłka działa, ale po pierwszych miesiącach pojawiły się zgłoszenia: gdy przychodnia na chwilę przestaje odpowiadać, wynik nie dociera i ktoś musi wysłać go ręcznie. Część przychodni ma w umowie limit połączeń, a dział jakości pyta, kto i kiedy wysłał dany wynik, i nie dostaje odpowiedzi.

Wysyłkę wykonuje klasa `ClinicResultSender` z projektu `Starter/Lims.Exercise`. Okno wysyłki i automat nocny korzystają z niej przez `IResultSender`. Klasa jest sprawdzona i używana w kilku miejscach, więc **nie wolno jej zmieniać**. Nie zmieniaj też `IResultSender`.

## Wymagania

1. **Ponawianie.** Gdy przychodnia chwilowo nie odpowiada, wysyłka próbuje ponownie, łącznie najwyżej 3 razy, z pauzą 30 sekund między próbami. Odrzucenia wyniku przez przychodnię nie ponawiamy, bo powtórzenie niczego nie zmieni.
2. **Limit.** Liczba prób połączenia z jedną przychodnią w ciągu ostatniej godziny jest ograniczona, a wartość limitu zależy od umowy. Gdy limit jest wyczerpany, przychodnia nie dostaje połączenia, a zlecający wysyłkę dowiaduje się, że powodem jest limit. Umowa liczy każdą próbę połączenia, także nieudaną. Próba sprzed dokładnie godziny już się nie liczy.
3. **Historia.** Każde zlecenie wysyłki zostawia jeden wpis: kto, kiedy, jaka próbka, do której przychodni i z jakim skutkiem (wysłano, przychodnia niedostępna, odrzucono, limit). Ponowne próby nie tworzą kolejnych wpisów.
4. **Automat nocny.** Automat sam wznawia pracę następnej nocy, więc nie ponawia wysyłki. Obowiązują go jednak limit i historia.
5. **Testy bez czekania.** Każdy scenariusz da się sprawdzić testem, bez połączenia z przychodnią i bez czekania na pauzę lub upływ godziny.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami. „Próba” oznacza połączenie z przychodnią, a „wpis” oznacza pozycję w historii.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Przychodnia odbiera | 1 próba, bez pauzy, 1 wpis „wysłano” z osobą, czasem, próbką i przychodnią |
| 2 | Przychodnia nie odpowiada raz, potem odbiera | 2 próby, 1 pauza 30 s, 1 wpis „wysłano” |
| 3 | Przychodnia cały czas nie odpowiada | 3 próby, 2 pauzy, 1 wpis „niedostępna”, a zlecający dostaje informację o niepowodzeniu |
| 4 | Przychodnia odrzuca wynik | 1 próba, bez pauzy, 1 wpis „odrzucono”, a zlecający dostaje informację o odrzuceniu |
| 5 | Limit 3, trzy udane wysyłki i czwarta w tej samej godzinie | Czwarta bez próby i bez pauzy, wpis „limit”, a zlecający dostaje informację o limicie |
| 6 | Limit 1, druga wysyłka sekundę przed upływem godziny i trzecia równo po godzinie od pierwszej | Druga odrzucona przez limit, trzecia wysłana |
| 7 | Limit 1 wyczerpany dla przychodni A, wysyłka do przychodni B | Wysyłka do B się udaje, a kolejna do A nadal nie |
| 8 | Limit 3, przychodnia nie odpowiada dwa razy, potem odbiera, a następnie kolejna wysyłka | Pierwsza wysłana po 3 próbach, druga bez próby, z powodu limitu |
| 9 | Limit 2, przychodnia cały czas nie odpowiada | 2 próby, 1 wpis „limit”, a zlecający dostaje informację o limicie |
| 10 | Automat nocny, przychodnia nie odpowiada | 1 próba, bez pauzy, 1 wpis „niedostępna” z automatem jako osobą |
| 11 | Automat nocny, limit 1 i druga wysyłka | Druga bez próby, z informacją o limicie |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Nowy kod napisz w projekcie `Starter/Lims.Exercise`, zaczynając od pliku `Zadanie.cs`, a testy w `Starter/Lims.Exercise.Tests`. Podział na klasy i nazwy należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

Zadanie nie obejmuje okna, wystarczy kod i testy.

## Do dyskusji

Dział jakości prosi o nowe wymaganie: wyniki krytyczne mają omijać limit. Co musisz zmienić w swoim rozwiązaniu, a czego nie? Gdzie w Twoim kodzie widać odpowiedź na pytanie, czy ponowna próba liczy się do limitu? Jak długo użytkownik okna czeka na zakończenie trzech prób i co można z tym zrobić?
