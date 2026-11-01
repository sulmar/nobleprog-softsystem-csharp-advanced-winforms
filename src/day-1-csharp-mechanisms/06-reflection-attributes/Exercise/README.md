# Zadanie: import plików od przychodni

Czas: około 40–50 minut.

## Sytuacja

Przychodnie przysyłają do laboratorium pliki CSV: zlecenia badań, listy pacjentów i rozliczenia. Dziś dla każdego rodzaju pliku jest osobna klasa importu, pisana od nowa, a każdy nowy rodzaj to kolejne dni pracy. Pliki bywają niepoprawne, a jeden zły wiersz przerywa cały import.

Napisz jeden import, który wypełnia obiekty dowolnej klasy danymi z pliku.

Zacznij od tej klasy:

```csharp
public class CsvImporter
{
}
```

## Wymagania

1. **Dowolny rodzaj pliku.** Obsługa nowego rodzaju pliku wymaga dopisania tylko klasy opisującej jego dane. Kodu importu nie zmieniamy.
2. **Polskie nagłówki.** Nagłówki w plikach są po polsku, np. „Kod zlecenia”, a nazwy w kodzie po angielsku. Powiązanie jest zapisane przy danej właściwości klasy, a kolejność kolumn w pliku może być dowolna.
3. **Typy danych.** Wartości z pliku trafiają do właściwości tekstowych, liczbowych i dat. Liczby mają kropkę dziesiętną, a daty format `yyyy-MM-dd`.
4. **Priorytety po polsku.** Plik zawiera priorytet jako tekst, np. „Pilne”. W kodzie jest to wartość typu wyliczeniowego, a teksty są zapisane przy tych wartościach.
5. **Pola obowiązkowe.** Klasa określa, które pola są obowiązkowe. Wiersz z pustym polem obowiązkowym jest niepoprawny.
6. **Odporność na błędy.** Niepoprawny wiersz nie przerywa importu. Pozostałe wiersze są wczytywane, a na końcu wiadomo, które wiersze i dlaczego odrzucono.

## Przykładowy plik

```
Kod zlecenia;Priorytet;Termin;Kwota
Z-1;Pilne;2026-11-02;120.50
Z-2;Zwykłe;2026-11-03;80
```

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Powyższy plik | Dwa zlecenia z poprawnym kodem, priorytetem, terminem i kwotą |
| 2 | Kolumny w innej kolejności | Te same dane |
| 3 | Dodatkowa, nieznana kolumna | Zostaje pominięta |
| 4 | Plik z inną klasą danych, np. listą pacjentów | Działa bez zmian w kodzie importu |
| 5 | Pusty kod zlecenia, gdy jest obowiązkowy | Wiersz odrzucony, a powód wskazuje numer wiersza i nazwę kolumny |
| 6 | Kwota „abc” | Wiersz odrzucony, a pozostałe wczytane |
| 7 | Nieznany priorytet „Kiedyś” | Wiersz odrzucony |
| 8 | Sam nagłówek, bez wierszy | Pusta lista i brak błędów |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Pozostałe nazwy i sposób rozwiązania należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Import może mieć do wczytania milion wierszy. Co w Twoim rozwiązaniu wykonuje się raz na plik, a co raz na wiersz? Co by się stało, gdyby ktoś zmienił nazwę właściwości w klasie opisującej plik?
