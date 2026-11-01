# Dzień 3, Moduł 3: Command

**Polecenie** to operacja zapisana jako obiekt. Obiekt wie, jak ją wykonać (`Execute`), czy można ją teraz wykonać (`CanExecute`), i informuje, gdy to się zmienia (`CanExecuteChanged`). Przycisk, pozycja menu i skrót klawiaturowy korzystają z tego samego obiektu, więc nie mogą się już różnić. Operacja przestaje też zależeć od okna, a więc można ją przetestować.

## Historia

Kierownik laboratorium ocenia wyniki w jednym oknie: zatwierdza, odrzuca albo zleca powtórzenie badania. Każdą operację można wywołać przyciskiem, z menu i klawiszem. Laborant zatwierdził skrótem wynik krytyczny, choć pozycja w menu była dla niego wyłączona. Analizator dostał trzy zlecenia tej samej próbki, a nowa wartość potasu trafiła do wiersza z kreatyniną.

## Problem

Otwórz `Problem/ResultReviewForm.cs`. Te same operacje są zapisane w kilku kopiach.

| Sytuacja | Przyczyna | Objaw |
|---|---|---|
| Wynik krytyczny, laborant | `RefreshButtons` i `RefreshMenu` mają różne warunki | **Przycisk aktywny, menu nieaktywne** |
| F6 na wyniku krytycznym lub odrzuconym | Skrót ma własne warunki | **Wynik jest zatwierdzony mimo reguł** |
| Zatwierdzenie z menu | Handler odświeża tylko menu | Przycisk zostaje aktywny, a jego kliknięcie nadpisuje osobę zatwierdzającą |
| Powtórzenie badania z przycisku, potem menu i F8 | Blokada dotyczy tylko jednego przycisku | **Trzy zlecenia dla jednej próbki** |
| Zmiana wiersza podczas powtórzenia | Handler czyta zaznaczenie po `await` | **Nowa wartość trafia do innej próbki** |
| Zatwierdzenie podczas powtórzenia | Nic tego nie blokuje | Zatwierdzenie przepada, a nazwisko zostaje przy nowej wartości |
| Błąd analizatora z menu lub skrótu | `async void` bez `try`/`catch` | Wyjątek trafia do okna błędu aplikacji |
| Testy | Logika w handlerach | Reguł nie da się sprawdzić bez okna |

## Reguły

- **Jedna operacja to jeden obiekt.** Każde miejsce w interfejsie korzysta z tej samej instancji.
- **Dostępność należy do polecenia,** a nie do kontrolki. Kontrolka tylko ją pokazuje.
- **`Execute` sprawdza `CanExecute`.** Wyłączony przycisk nie jest zabezpieczeniem reguły.
- **Nikt nie pamięta o odświeżaniu.** Zmiana stanu wywołuje zdarzenie, a kontrolki same się aktualizują.
- **Blokada obejmuje polecenie,** a nie przycisk. Dzięki temu działa w każdym miejscu.
- **Dane operacji odczytuj przed `await`.** Po powrocie użytkownik może stać już na innym wierszu.
- **`async void` tylko w handlerze zdarzenia,** a błędy łap wcześniej (Dzień 1, moduł 4).
- **Polecenie przy przycisku nie pamięta swoich wykonań.** Cofanie wymaga wpisu tworzonego przy każdym wykonaniu.
- **Polecenia nie są potrzebne wszędzie.** Operacja dostępna z jednego przycisku, bez warunków, może zostać w handlerze.

## Uruchomienie

```
dotnet build Command.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
