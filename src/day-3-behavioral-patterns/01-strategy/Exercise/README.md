# Zadanie: wysyłka wyników do różnych odbiorców

Czas: około 40–50 minut.

## Sytuacja

Laboratorium przekazuje zatwierdzone wyniki kilku odbiorcom i każdy chce je dostać w innej postaci. Pracownik wybiera odbiorcę z listy w oknie, a program ma przygotować właściwy plik i odnotować wysyłkę. Dziś robi się to ręcznie w arkuszu. Co kilka miesięcy dochodzi nowy odbiorca, a dział jakości chce mieć pewność, że wprowadzenie kolejnego nie popsuje wysyłki do pozostałych.

Przygotuj logikę wysyłki. Samego okna nie trzeba pisać, ale logika musi dać mu wszystko, czego potrzebuje.

## Dane wejściowe

Każdy wynik ma: PESEL, nazwę badania, wartość, jednostkę, informację, czy jest w normie, oraz informację, czy został zatwierdzony. PESEL-e w przykładach są fikcyjne.

## Odbiorcy

| Odbiorca | Nazwa pliku | Zawartość |
|---|---|---|
| Przychodnia | `przychodnia_RRRRMMDD.csv` | Nagłówek `PESEL;Badanie;Wynik;Jednostka`, potem jeden wiersz na wynik, w kolejności podania |
| Pacjent | `wyniki_RRRRMMDD.txt` | Wiersz `Wyniki badań`, potem np. `Glukoza: 90,5 mg/dl (w normie)` lub `(poza normą)`. Bez PESEL. Tylko wyniki jednej osoby |
| Dyrekcja | `zestawienie_RRRRMM.csv` | Nagłówek `Badanie;Liczba;Poza normą`, potem jeden wiersz na badanie, według nazwy badania. Bez danych osobowych |

Wartości zapisujemy z przecinkiem i bez zbędnych zer, np. `90,5`. Wiersze rozdziela jeden znak nowego wiersza, bez znaku na końcu pliku.

## Wymagania

1. **Lista odbiorców.** Okno dostaje nazwy odbiorców do pokazania, zawsze w tej samej kolejności: Przychodnia, Pacjent, Dyrekcja.
2. **Tylko zatwierdzone.** Wynik niezatwierdzony nie opuszcza laboratorium, niezależnie od odbiorcy.
3. **Odmowa z powodem.** Gdy wysyłka jest niemożliwa, użytkownik dostaje powód, nie powstaje żaden plik i nie ma wpisu w rejestrze.
4. **Rejestr wysyłek.** Każda udana wysyłka zostawia wpis: kiedy, do kogo, nazwa pliku i liczba wyników.
5. **Kolejny odbiorca.** Dodanie odbiorcy, np. ubezpieczyciela, nie wymaga zmiany kodu istniejących odbiorców ani kodu, który prowadzi wysyłkę.
6. **Sprawdzalność.** Wszystkie scenariusze da się sprawdzić testem, bez zapisu na dysk i bez czekania na konkretną datę. Miejsce zapisu plików i rejestru może się w przyszłości zmienić.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami. Bieżąca data to 31 października 2026.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Okno pyta o odbiorców | Przychodnia, Pacjent, Dyrekcja, w tej kolejności |
| 2 | Przychodnia, dwa wyniki dwóch osób | Plik `przychodnia_20261031.csv` z nagłówkiem i dwoma wierszami, np. `00000000001;Glukoza;90,5;mg/dl` |
| 3 | Pacjent, dwa wyniki jednej osoby, jeden poza normą | Plik `wyniki_20261031.txt` z oceną przy każdym wyniku i bez PESEL |
| 4 | Pacjent, wyniki dwóch osób | Odmowa |
| 5 | Dyrekcja: dwa wyniki glukozy, w tym jeden poza normą, i jeden kreatyniny | Plik `zestawienie_202610.csv` z wierszami `Glukoza;2;1` i `Kreatynina;1;0`, bez PESEL |
| 6 | Dowolny odbiorca, jeden wynik niezatwierdzony wśród zatwierdzonych | Niezatwierdzonego nie ma w pliku |
| 7 | Dowolny odbiorca, same wyniki niezatwierdzone | Odmowa |
| 8 | Nieznany lub pusty odbiorca | Odmowa z informacją o nieznanym odbiorcy |
| 9 | Udana wysyłka do przychodni: dwa wyniki zatwierdzone, jeden nie | Jeden wpis w rejestrze: bieżący czas, Przychodnia, nazwa pliku, liczba wyników 2 |
| 10 | Wysyłka, której odmówiono | Brak wpisu w rejestrze |
| 11 | W teście pojawia się nowy odbiorca, którego dotychczasowy kod nie zna | Jest na liście, a wysyłka do niego działa |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Podział na klasy i nazwy należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Które reguły są wspólne dla wszystkich odbiorców, a które należą do jednego z nich? Co trzeba by zmienić, gdyby użytkownik chciał zapisać ustawionego odbiorcę na następny raz?
