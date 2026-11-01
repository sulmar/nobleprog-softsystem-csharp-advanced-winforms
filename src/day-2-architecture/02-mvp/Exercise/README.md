# Zadanie: wyszukiwanie pacjenta

Czas: około 40–50 minut.

## Sytuacja

Rejestratorki w punkcie pobrań wyszukują pacjentów w oknie `PatientSearchForm`. Ekran działa, ale każda poprawka psuje coś innego: raz po zmianie kryteriów na liście zostali pacjenci z poprzedniego wyszukiwania i otwarto kartę niewłaściwej osoby, innym razem zablokowany pacjent dostał nowe zlecenie. Dział jakości wymaga, by zachowanie tego ekranu było potwierdzone przed każdym wdrożeniem, a dziś sprawdza się je tylko ręcznie, klikając po oknie.

Wkrótce listę wyników ma zastąpić tabela z dodatkowymi kolumnami. Zasady działania ekranu mają przy tym pozostać bez zmian.

Kod okna jest w projekcie `Starter/Lims.Exercise.Form`. Przebuduj go tak, aby spełnić poniższe wymagania.

## Wymagania

1. **Sprawdzenie bez okna.** Całe zachowanie ekranu da się sprawdzić automatycznie, bez otwierania okna i bez klikania: co jest dostępne, jakie komunikaty się pojawiają i co widać na liście.
2. **Sprawdzenie bez katalogu.** Sprawdzenie nie wymaga prawdziwego katalogu pacjentów, a awarię katalogu można wywołać na żądanie.
3. **Zmiana wyglądu.** Zamiana listy na tabelę lub przycisków na menu nie wymaga zmiany zasad działania ekranu.
4. **Bez zmian dla użytkownika.** Ekran działa dla rejestratorki tak samo jak dotąd.

## Zasady, których nie wolno zmienić

Zasady są zapisane w kodzie okna i podsumowane w scenariuszach. W wynikach widać tylko 4 ostatnie cyfry numeru PESEL, a lista pokazuje co najwyżej 20 pacjentów. Spacje na początku i na końcu kryterium się nie liczą.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami. Przyciski to: Szukaj, Wyczyść, Otwórz kartę i Nowe zlecenie.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Ekran właśnie otwarto | Lista pusta, wszystkie przyciski niedostępne, komunikat „Wpisz co najmniej 3 znaki” |
| 2 | Wpisano 2 znaki | Szukaj niedostępne, Wyczyść dostępne |
| 3 | Wpisano same spacje | Szukaj niedostępne |
| 4 | Wpisano 3 znaki | Szukaj dostępne, komunikat znika |
| 5 | Wyszukano fragment nazwiska lub numeru PESEL, bez względu na wielkość liter | Pasujący pacjenci na liście, komunikat „Znaleziono: 2”, Otwórz kartę i Nowe zlecenie nadal niedostępne |
| 6 | Wyszukanie pacjenta z numerem PESEL 00000000011 | Na liście widać `*******0011`, a pełnego numeru nie widać |
| 7 | Nikt nie pasuje | Lista pusta, komunikat „Nie znaleziono pacjentów” |
| 8 | Zaznaczono „Tylko z otwartymi zleceniami” i wyszukano | Na liście są tylko pacjenci z otwartymi zleceniami |
| 9 | Pasuje 25 pacjentów | Lista ma 20 pozycji, komunikat „Pokazano 20 z 25, zawęź kryteria” |
| 10 | Wybrano pacjenta z listy | Otwórz kartę i Nowe zlecenie dostępne |
| 11 | Wybrano zablokowanego pacjenta | Otwórz kartę dostępne, Nowe zlecenie niedostępne, komunikat „Pacjent zablokowany: nie można założyć zlecenia” |
| 12 | Kliknięto Otwórz kartę lub Nowe zlecenie | Otwiera się karta lub zlecenie właśnie wybranego pacjenta |
| 13 | Po wyszukaniu zmieniono tekst lub zaznaczenie „Tylko z otwartymi” | Lista pusta, Otwórz kartę i Nowe zlecenie niedostępne, komunikat „Kryteria się zmieniły, wyszukaj ponownie” |
| 14 | Kliknięto Wyczyść | Ekran wygląda jak po otwarciu |
| 15 | Katalog pacjentów jest niedostępny | Ekran działa dalej: lista pusta, komunikat „Katalog pacjentów jest niedostępny, spróbuj ponownie”, Szukaj dostępne |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Nowy kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Podział na klasy i nazwy należą do Ciebie. Na końcu użyj nowego kodu w `Starter/Lims.Exercise.Form`.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Co zostało w kodzie okna i dlaczego? Którego błędu Twoje testy nie wykryją, nawet jeśli wszystkie są zielone? Czy zasada „zablokowany pacjent nie dostaje nowego zlecenia” to ta sama rzecz co „przycisk Nowe zlecenie jest niedostępny”?
