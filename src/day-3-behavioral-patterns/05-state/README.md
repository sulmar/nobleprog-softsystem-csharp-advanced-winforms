# Dzień 3, Moduł 5: State

**State** przenosi zachowanie zależne od stanu do osobnych klas. Obiekt, czyli **kontekst**, przekazuje każdą operację do bieżącego stanu, a **stan** sam decyduje, czy operacja jest dozwolona i dokąd prowadzi. Znikają warunki po statusie rozsiane po kodzie, a dostępność przycisków wynika ze stanu, zamiast być jego kolejną kopią.

## Historia

Obieg próbki opisuje prosty schemat: Zarejestrowana, W analizie, a potem Zatwierdzona lub Odrzucona, a na końcu Zarchiwizowana. W programie ten schemat nie istnieje. Są warunki w logice, w przyciskach i w menu, a każdy mówi coś innego. Audytor znalazł próbkę, która została odrzucona z powodu hemolizy, a chwilę później zatwierdzona, i nie ma śladu, kto to zrobił.

## Problem

Otwórz `Problem/SampleOperations.cs` i `Problem/SampleLifecycleForm.cs`.

| Miejsce | Problem | Objaw |
|---|---|---|
| `SampleOperations` | Warunki wymieniają, czego nie wolno, a reszta przechodzi | **9 z 25 kombinacji statusu i operacji zachowuje się niezgodnie z obiegiem, np. zatwierdzenie próbki odrzuconej** |
| `Sample.Status` | Publiczny setter | Każdy może ustawić dowolny status |
| `UpdateButtons`, `UpdateMenu` | Reguły powielone w trzech miejscach | Menu pozwala zarchiwizować próbkę w analizie, a przycisk nie |
| `Sample.History` | Wpisy dodają tylko dwie operacje | Rozpoczęcia analizy i archiwizacji nie ma w historii |
| `_isEditing`, `_isSaving` | Dwie flagi zamiast jednego trybu | Anulowanie podczas zapisu i tak zapisuje, a uwagi mogą trafić do innej próbki |

## State, Strategy czy tabela przejść

| Pytanie | State | Strategy | Tabela przejść |
|---|---|---|---|
| Kto zmienia implementację? | Sam obiekt, w wyniku operacji | Ktoś z zewnątrz, przy składaniu lub konfiguracji | Nikt, są tylko dane |
| Czy warianty się znają? | Tak, stan wskazuje następny | Nie | Nie dotyczy |
| Co się zmienia w czasie życia obiektu? | Stan, wielokrotnie | Zwykle nic | Wartość statusu |
| Gdzie są warunki, np. „wymaga wyniku”? | W klasie stanu | W klasie strategii | Poza tabelą |
| Kiedy wybrać? | Stany różnią się zachowaniem i warunkami | Jest kilka wymiennych sposobów wykonania tego samego | Stany różnią się tylko dozwolonymi przejściami |

## Reguły

- **Domyślnie odmowa.** Klasa bazowa odrzuca każdą operację, więc zapomniany przypadek jest błędem widocznym, a nie cichym przejściem.
- **Tylko stan zmienia stan.** Bez publicznego settera statusu i z jedną metodą `MoveTo`.
- **Formularz pyta, a nie wie.** Przy kontrolkach nie ma warunków po statusie. Jest jedno miejsce, które ustawia dostępność.
- **Dane w kontekście, zachowanie w stanie.** Klasy stanów nie mają pól z danymi próbki, więc wystarczy po jednej instancji.
- **Enum zostaje do bazy i wyświetlania.** Wiersz w bazie przechowuje status, a `Sample.Restore` odtwarza z niego obiekt stanu.
- **Testuj całą macierz.** Tabela `[Theory]` obejmuje także odmowy, bo to one były tu błędem.
- **Nie każdy status potrzebuje klasy.** Dwa stany i proste przejścia to za mało na ten wzorzec. Zacznij od tabeli, a klasy dodaj, gdy pojawią się warunki i różne zachowania.

## Uruchomienie

```
dotnet build State.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
