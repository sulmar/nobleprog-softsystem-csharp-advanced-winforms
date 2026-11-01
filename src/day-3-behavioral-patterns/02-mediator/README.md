# Dzień 3, Moduł 2: Mediator

**Mediator** to jeden obiekt, który wie, jak kilka komponentów ma ze sobą współdziałać. Komponenty nie mają do siebie referencji: zgłaszają, co się u nich stało, a mediator decyduje, kto i w jakiej kolejności ma zareagować. Dzięki temu reguły współdziałania są w jednym miejscu i można je sprawdzić testem, bez okna.

## Historia

Ekran przeglądu próbek składa się z czterech kontrolek użytkownika: filtrów, listy, szczegółów i paska przycisków. Każda z nich zna pozostałe i każda włącza lub czyści coś u innych. Po kolejnym zgłoszeniu programista dopisał odświeżenie listy po zapisie komentarza i od tego dnia szczegóły znikają zaraz po zapisaniu. Kierownik laboratorium zgłasza też poważniejszą sprawę: zatwierdzona próbka okazała się próbką, której nikt w tym momencie nie widział na ekranie.

## Problem

Otwórz `Problem/`. Formularz ustawia siedem referencji między panelami, a każda zmiana uruchamia łańcuch wywołań.

| Działanie użytkownika | Co się dzieje w kodzie | Objaw |
|---|---|---|
| Wybór próbki, zmiana filtra, „Zatwierdź” | Lista czyści szczegóły, ale pasek pamięta starą próbkę | **Zatwierdzona zostaje próbka, której nie ma już na ekranie** |
| Zapisanie komentarza | `SaveComment` wywołuje `List.Reload`, a to `Details.Clear` | **Szczegóły i wybór znikają zaraz po zapisie** |
| Zapisanie pustego komentarza, „Odrzuć” | `OnCommentSaved` ma kopię reguły bez warunku na treść | **Próbka odrzucona bez podania powodu** |
| „Zatwierdź”, a potem „Odrzuć” | Nikt nie wyłącza przycisków po decyzji | **Status zatwierdzonej próbki zostaje nadpisany** |
| Edycja komentarza, zmiana filtra | Tylko lista pyta o niezapisany komentarz | Komentarz ginie bez pytania, a „Zapisz” kończy się `NullReferenceException` |

## Mediator, Observer i Presenter

| | Observer | Mediator | Presenter |
|---|---|---|---|
| Kto decyduje o reakcji | Każdy obserwator sam za siebie | Jeden obiekt za wszystkich | Presenter, dla swojego widoku |
| Co wie nadawca | Że ktoś może słuchać | Że coś zgłasza | Że ma presentera lub zdarzenia widoku |
| Co łączy | Jednego nadawcę z wieloma słuchaczami | Wiele równorzędnych komponentów | Jeden widok z logiką i modelem |
| Sprawdzian | Usuń obserwatora: reszta działa bez zmian | Usuń wszystkie panele oprócz jednego: klasa traci sens | Zostaw jeden widok: klasa nadal ma sens |

Zdarzenia C# są tu tylko transportem. O tym, czy to Observer, czy Mediator, nie decyduje słowo `event`, tylko to, gdzie zapada decyzja.

## Klasa-bóg

Mediator przyciąga kod, bo „wszystko i tak tam przechodzi”. Trzy pytania przed dopisaniem linii:

| Pytanie | Jeśli tak |
|---|---|
| Czy to zasada, którą opisałby kierownik laboratorium? | Do `Sample` lub osobnej klasy reguł |
| Czy to dotyczy wyglądu kontrolki? | Do panelu |
| Czy mediator obsługuje dwa niezależne obszary ekranu? | Podziel na dwa mediatory |

## Reguły

- **Komponent zgłasza, co się stało, a nie co ma zrobić ktoś inny.** `SaveRequested`, a nie `RefreshListAndClearDetails`.
- **Mediator decyduje, ale nie liczy.** Reguły biznesowe trzyma poza sobą, a sam układa ich skutki.
- **Mediator nie zna typów kontrolek.** Bez `Button` i `TextBox` w konstruktorze, bo wtedy testy wymagają okna.
- **Programowa zmiana kontrolki też wywołuje zdarzenie.** Panel musi odróżnić ją od działania użytkownika.
- **Przycisk to nie zabezpieczenie.** Mediator sprawdza dostępność także po otrzymaniu zgłoszenia.
- **Nie każdy ekran tego potrzebuje.** Dwie kontrolki z jedną zależnością obsłuży zwykły handler w formularzu.

## Uruchomienie

```
dotnet build Mediator.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
