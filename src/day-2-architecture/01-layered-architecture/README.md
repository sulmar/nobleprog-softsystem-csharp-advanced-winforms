# Dzień 2, Moduł 1: Architektura aplikacji WinForms

**Warstwy** dzielą aplikację według odpowiedzialności: interfejs użytkownika, koordynacja przypadków użycia, reguły biznesowe i dostęp do świata zewnętrznego. Dzięki temu regułę można przetestować bez okna, a bazę lub drukarkę wymienić bez zmiany reguł.

Ten moduł przygotowuje grunt pod kolejne: MVP (moduł 2) odchudza formularz jeszcze bardziej, a Dependency Injection (moduł 3) automatyzuje składanie aplikacji.

## Historia

Formularz rejestracji próbki to prosty ekran. Jedna metoda obsługi przycisku liczy cenę, zapisuje do bazy i drukuje etykietę na drukarce jednego dostawcy. Laboratorium zmienia drukarkę na model innego dostawcy, a kierownik chce testów cennika.

## Problem

Otwórz `Problem/SampleRegistrationForm.cs`.

| Odpowiedzialność | Gdzie jest teraz | Skutek |
|---|---|---|
| Cennik | if w `RegisterButton_Click` | Reguły nie da się przetestować bez okna |
| Zapis | Statyczna klasa `Database` | Zmiana bazy dotyka formularza |
| Etykieta | SDK `LabelTechPrinter` w handlerze | Zmiana drukarki dotyka formularza, test drukuje |

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
