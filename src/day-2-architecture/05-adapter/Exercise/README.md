# Zadanie: powiadomienia SMS o wynikach krytycznych

Czas: około 40–50 minut.

## Sytuacja

Gdy wynik glukozy jest krytyczny, laboratorium wysyła lekarzowi SMS. Umowa z obecnym operatorem SmsBox kończy się za kilka miesięcy, a nowym operatorem będzie TeleGate. Przez okres przejściowy działają obaj: kierownik laboratorium decyduje, który jest główny, a drugi przejmuje wysyłkę, gdy główny ma awarię.

Biblioteki obu operatorów są w katalogu `Vendors/`. Opis ich działania znajdziesz w komentarzach w kodzie. Nie wolno ich zmieniać, bo należą do operatorów. Klasy `SmsBoxSandbox` i `TeleGateSandbox` to piaskownice: pokazują, co „dotarło” do lekarza, i pozwalają zasymulować awarię lub odrzucenie numeru. Nic nie jest naprawdę wysyłane.

## Wymagania

1. **Tylko wyniki krytyczne.** Lekarz dostaje SMS, gdy glukoza jest poniżej 40 mg/dL albo powyżej 200 mg/dL.
2. **Treść.** `Wynik krytyczny: próbka <kod>, glukoza <wartość> mg/dL.`, a po niej opcjonalny komentarz laboranta.
3. **Numery.** W kartotece numery są zapisywane różnie, np. `600100200`, `600 100 200`, `600-100-200`, `+48 600 100 200`. Każdy z nich musi dotrzeć do lekarza niezależnie od operatora.
4. **Cała treść.** Lekarz dostaje całą treść także wtedy, gdy nie mieści się w jednej wiadomości lub gdy operator nie przyjmuje polskich liter. W takim przypadku dostanie ją bez nich.
5. **Zmiana operatora.** Decyzja, który operator jest główny, oraz późniejsze wyłączenie SmsBox nie wymagają zmiany reguł powiadamiania.
6. **Awarie.** Awaria jednego operatora nie może przeszkodzić w powiadomieniu lekarza. Awaria obu nie może zatrzymać programu: laborant musi się dowiedzieć, że wiadomość nie wyszła.
7. **Sprawdzanie.** Reguły powiadamiania, także te dotyczące awarii, można sprawdzić testem bez udziału bibliotek operatorów.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Wynik 150 lub dokładnie 200 | Nikt nie dostaje SMS, a informacja brzmi „nie było potrzeby” |
| 2 | Wynik 250 lub 39,9 | Lekarz dostaje SMS |
| 3 | Wynik 250, główny SmsBox, numer `600 100 200` | SmsBox dostaje numer `600100200` i treść z polskimi literami |
| 4 | Wynik 250, główny TeleGate, numer `600 100 200` | TeleGate dostaje numer `+48600100200` i treść `Wynik krytyczny: probka ...` |
| 5 | Numer `+48 600-100-200` | Wiadomość dociera tak samo jak w scenariuszach 3 i 4 |
| 6 | Numer `12345` | Żaden operator nie jest wywoływany, a informacja brzmi „błędny numer” |
| 7 | Długi komentarz | Lekarz dostaje kilka wiadomości, które po złożeniu dają całą treść |
| 8 | Główny operator ma awarię | Wiadomość wysyła drugi, a informacja mówi, który to zrobił |
| 9 | Główny działa | Drugi operator nie dostaje nic |
| 10 | Obaj mają awarię | Brak wyjątku, a informacja brzmi „nie wysłano” |
| 11 | Operator odrzuca numer | Drugi nie jest wywoływany, bo numer jest zły, a informacja brzmi „błędny numer” |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Zacznij od klasy `CriticalResultNotifier`. Pozostałe nazwy i podział na klasy należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

Na macOS i Linuksie użyj `-f net8.0`.

## Do dyskusji

Ile kodu trzeba zmienić, gdy dojdzie trzeci operator, a ile, gdy SmsBox zniknie? Gdzie u Ciebie jest informacja, że TeleGate nie przyjmuje polskich liter? Co powinno się stać, gdy główny operator przyjmie dwie z trzech części długiej wiadomości, a potem ulegnie awarii?
