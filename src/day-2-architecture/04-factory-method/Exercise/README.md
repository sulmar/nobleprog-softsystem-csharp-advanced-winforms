# Zadanie: import wyników z analizatorów

Czas: około 40–50 minut.

## Sytuacja

Laboratorium ma trzy analizatory różnych producentów. Na koniec zmiany każdy zapisuje wyniki do pliku tekstowego, a technik przepisuje je ręcznie. Kierownik chce, by technik wskazał analizator i plik, a program sam wczytał wyniki i pokazał, co się nie udało. W przyszłym kwartale dojdzie czwarty analizator, którego formatu jeszcze nikt nie zna.

W tym zadaniu nie budujesz okna ani nie czytasz plików z dysku. Wejściem jest nazwa analizatora i lista linii pliku.

## Formaty plików

| Analizator | Przykład | Znaczenie |
|---|---|---|
| Hematon | `SAMPLE;P-1001`, a w kolejnych liniach `HGB;14,2;g/dL` | Linia `SAMPLE` wskazuje próbkę. Kolejne linie to parametr, wartość i jednostka dla tej próbki. Przecinek dziesiętny. |
| Biochem-X | `P-1002\|GLU\|5,0\|mmol/L` | Próbka, parametr, wartość, jednostka. Przecinek dziesiętny. |
| UroLine | `P-1003 PH 6.5` | Próbka, parametr i wartość, oddzielone spacjami. Kropka dziesiętna, bez jednostki. |

## Wymagania

1. **Wybór analizatora.** Technik podaje nazwę analizatora, a wielkość liter nie ma znaczenia. Nieznana nazwa oznacza odmowę z informacją, o jaką nazwę chodziło.
2. **Podsumowanie.** Wynik importu zawiera wczytane wyniki (analizator, próbka, parametr, wartość, jednostka) oraz listę błędów z numerem linii i powodem.
3. **Wspólne reguły dla każdego analizatora.** Puste linie są pomijane, ale liczą się do numeracji. Wartość ujemna jest błędem. Powtórzony wynik tej samej próbki i parametru w jednym pliku jest błędem, a pierwszy wynik zostaje. Błędna linia nie przerywa importu.
4. **Jednostki.** Laboratorium przechowuje glukozę (`GLU`) w mg/dL. Biochem-X podaje ją w mmol/L, więc wartość trzeba pomnożyć przez 18.
5. **Niezależne importy.** Wczytanie jednego pliku nie ma żadnego wpływu na następny.
6. **Czwarty analizator.** Obsługę nowego formatu można dodać, dopisując nowy kod, bez zmian w istniejącym kodzie obsługi trzech analizatorów i wspólnych reguł. Musi to potwierdzać test, który sam dodaje przykładowy analizator.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Hematon: `SAMPLE;P-1001`, `HGB;14,2;g/dL`, `WBC;6,1;tys./µl` | 2 wyniki próbki P-1001 z analizatora Hematon, HGB równe 14,2 g/dL, bez błędów |
| 2 | Hematon: dwie linie `SAMPLE` w jednym pliku | Każdy wynik należy do ostatnio wskazanej próbki |
| 3 | Hematon: pierwsza linia to `HGB;14,2;g/dL` | Brak wyników, błąd w linii 1 |
| 4 | Hematon: po poprawnym pliku następny plik zaczyna się od `HGB;12;g/dL` | W drugim imporcie brak wyników i błąd w linii 1 |
| 5 | Biochem-X: `P-1002\|GLU\|5,0\|mmol/L` | Wynik 90 mg/dL |
| 6 | Biochem-X: `P-1002\|ALT\|31\|U/L` | Wynik 31 U/L, bez przeliczenia |
| 7 | UroLine: `P-1003 PH 6.5` | Próbka P-1003, parametr PH, wartość 6,5 |
| 8 | Biochem-X: poprawna linia, linia `zepsuta linia`, poprawna linia | 2 wyniki, błąd w linii 2 |
| 9 | UroLine: `P-1 PH abc` | Brak wyników, błąd w linii 1 |
| 10 | Każdy analizator: wartość ujemna | Brak wyniku, błąd we właściwej linii |
| 11 | UroLine: `P-1 PH 6.0`, potem `P-1 PH 7.0` | Wynik 6,0, błąd w linii 2 |
| 12 | UroLine: pusta linia, linia ze spacjami, `zepsuta` | Brak wyników, jeden błąd, w linii 3 |
| 13 | Nazwa `Nieznany-1` | Odmowa z tą nazwą w komunikacie |
| 14 | Nazwa `UROLINE` | Import działa jak dla `UroLine` |
| 15 | Przykładowy analizator dodany w teście, format `P-1=7` | Nazwa analizatora w wynikach oraz reguły z wymagania 3 działają bez zmian w istniejącym kodzie |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Podział na klasy i nazwy należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Co musiałby zmienić kolega, który za pół roku dodaje czwarty analizator, i skąd będzie wiedział, gdzie to zrobić? Które reguły należą do wszystkich analizatorów, a które do jednego? Czy trzeci analizator naprawdę potrzebował czegoś innego niż pierwszy?
