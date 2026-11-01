# Dzień 2, Moduł 1: Architektura aplikacji WinForms

**Warstwy** dzielą aplikację według odpowiedzialności: interfejs użytkownika, koordynacja przypadków użycia, reguły biznesowe i dostęp do świata zewnętrznego. Dzięki temu regułę można przetestować bez okna, a bazę lub drukarkę wymienić bez zmiany reguł.

Ten moduł przygotowuje grunt pod kolejne: MVP (moduł 2) odchudza formularz jeszcze bardziej, a Dependency Injection (moduł 3) automatyzuje składanie aplikacji.

## Historia

Formularz rejestracji próbki powstał jako prosty ekran i rósł z każdym zgłoszeniem. Dziś jedna metoda obsługi przycisku waliduje dane, liczy cenę i termin, zapisuje do bazy i drukuje etykietę. Każda zmiana jest ryzykowna, nic nie ma testów, a pacjent usłyszał inną cenę, niż trafiła do bazy.

## Problem

Otwórz `Problem/SampleRegistrationForm.cs`.

| Odpowiedzialność | Gdzie jest teraz | Skutek |
|---|---|---|
| Odczyt pól i komunikaty | `RegisterButton_Click` | Właściwe miejsce, ale wymieszane z resztą |
| Walidacja i cennik | `RegisterButton_Click` | **Podgląd ceny ma inny mnożnik niż zapis: 18,00 zł zamiast 19,20 zł** |
| Termin wykonania | `RegisterButton_Click` | `DateTime.Now` uniemożliwia test dla ustalonego czasu |
| Zapis | Statyczna klasa `Database` | Zmiana bazy dotyka formularza |
| Etykieta | `File.AppendAllText` w handlerze | Każde uruchomienie logiki drukuje |
| Testy | Brak | Logiki nie da się uruchomić bez okna |

## Gdzie co umieścić

| Pytanie | Warstwa |
|---|---|
| Czy to zasada, którą opisałby kierownik laboratorium? | Domena |
| Czy to kolejność kroków jednej operacji? | Aplikacja |
| Czy dotyka bazy, pliku, sieci lub drukarki? | Infrastruktura |
| Czy dotyka kontrolek? | Interfejs użytkownika |

## Reguły

- **Formularz nie zawiera reguł biznesowych.** Czyta pola, wywołuje serwis i pokazuje wynik.
- **Warstwa aplikacyjna definiuje interfejsy,** a infrastruktura je implementuje.
- **Bieżący czas jest zależnością.** Przekazuj go z zewnątrz, by testy mogły go ustalić.
- **Tylko `Program.cs` zna wszystkie warstwy.** To jedyne miejsce, które składa aplikację.
- **Warstwy to środek, a nie cel.** Mały ekran do jednorazowego użytku nie potrzebuje czterech projektów.

## Uruchomienie

```
dotnet build LayeredArchitecture.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
