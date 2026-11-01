# Dzień 3, Moduł 5: Mediator

**Mediator** to jeden obiekt, który wie, jak kilka komponentów ma ze sobą współdziałać. Komponenty nie mają do siebie referencji: zgłaszają, co się u nich stało, a mediator decyduje, kto i w jakiej kolejności ma zareagować. Dzięki temu reguły współdziałania są w jednym miejscu i można je sprawdzić testem, bez okna.

## Historia

Laborantka szuka próbki po kodzie lub pacjencie na ekranie „Wyszukiwanie próbek”: to jedna formatka z trzema panelami, czyli kryteriami, wynikami oraz szczegółami z przyciskami. Panele znają się nawzajem i każdy sam wywołuje pozostałe. Po nowym wyszukiwaniu kierownik znajduje zatwierdzoną próbkę, której nikt nie oglądał.

## Problem

Otwórz `Problem/`. Formularz łączy panele referencjami, a każda zmiana uruchamia łańcuch wywołań.

| Działanie użytkownika | Co się dzieje w kodzie | Objaw |
|---|---|---|
| Wybór próbki, nowe wyszukiwanie, „Zatwierdź” | Lista odświeża tylko siebie, a szczegóły pamiętają starą próbkę | **Zatwierdzona zostaje próbka, której nie ma w wynikach** |
| Zapisanie komentarza | `SaveButton_Click` wywołuje `List.Reload` | **Wybór na liście znika zaraz po zapisie** |
| Zapisanie pustego komentarza, „Odrzuć” | `SaveButton_Click` ma kopię reguły bez warunku na treść | **Próbka odrzucona bez podania powodu** |
| „Zatwierdź”, a potem „Odrzuć” | Nikt nie wyłącza przycisków po decyzji | **Status zatwierdzonej próbki zostaje nadpisany** |
| Edycja komentarza, nowe wyszukiwanie | Tylko lista pyta o niezapisany komentarz | Komentarz zostaje przy próbce, której nie ma w wynikach |

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
