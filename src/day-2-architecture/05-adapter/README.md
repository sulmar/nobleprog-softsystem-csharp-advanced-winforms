# Dzień 2, Moduł 5: Adapter

**Adapter** to klasa, która implementuje interfejs potrzebny aplikacji, a w środku wywołuje obcy kod o niezgodnym interfejsie. Tłumaczy nazwy metod, formaty, jednostki i wyjątki, dzięki czemu reszta aplikacji nie wie, z czyjej biblioteki korzysta. Bibliotekę można wtedy wymienić, a logikę przetestować z **atrapą**, bez urządzenia.

Moduł korzysta z podziału na warstwy z modułu 1 i składania aplikacji w jednym miejscu z modułu 3.

## Historia

Laboratorium ma analizatory glukozy różnych producentów. Każdy dostarcza własną bibliotekę: inne nazwy metod, inne jednostki, inny format odpowiedzi i inny sposób zgłaszania błędów. Bibliotek nie można zmienić. Kod okna woła je bezpośrednio, więc sprawny analizator nie przechodzi kontroli, awaria potrafi wywołać nieobsłużony wyjątek, a żadnego testu nie da się uruchomić bez urządzenia.

## Biblioteki producentów

Katalog `Vendors/` udaje biblioteki zewnętrzne. Nie zmieniamy ich. Klasy `*Bench` to część symulacji szkoleniowej: zastępują urządzenie stojące na stole, a bez ich wywołania urządzenia po prostu nie ma.

| | Hemolab | Chemtron | Bioscan |
|---|---|---|---|
| Metody | `Connect`, `ReadMessage`, `Disconnect` | `Open`, `QueryRecords`, `Close` | `Measure` |
| Odpowiedź | Napis w stylu HL7 | Napis w stylu ASTM | `double` przez parametr `out` |
| Jednostka | mmol/L | mg/dL | g/L |
| Błędy | `HemolabCommException` z numerem | `ChemtronException` ze statusem | Kod statusu jako `int` |
| Nieznana próbka | Błąd 204 | Brak rekordu wyniku | Status 2 |

## Problem

Otwórz `Problem/ResultCollectionForm.cs`. Na stole są próbki `S-1001` (około 99 mg/dL), `S-1002` (około 250 mg/dL), `S-1003` (około 55 mg/dL), materiał `KONTROLA` (około 90 mg/dL) oraz `S-2000`, przy której analizator zgłasza zajętość.

| Objaw | Przyczyna |
|---|---|
| **Sprawny Hemolab nie przechodzi kontroli: 5,00 zamiast około 90** | Kopia kodu w pomiarze kontrolnym nie przelicza mmol/L |
| Awaria Chemtrona przy kontroli to nieobsłużony wyjątek | Kopia nie łapie `ChemtronException`, a nieznany kod to `IndexOutOfRangeException` |
| Użytkownik czyta `E301 DEVICE BUSY` | Komunikat producenta trafia wprost do okna |
| Gdy analizator przejdzie na mg/dL, wynik 99 staje się 1783,6 | Pole jednostki jest ignorowane, a numery pól są wpisane na sztywno |
| Nowy producent to zmiany w dwóch handlerach i na liście | Formularz zna wszystkich producentów (OCP, DIP) |
| Żadnego testu nie da się uruchomić bez urządzenia | Biblioteka jest zamknięta i nie ma interfejsu, a reguły leżą za jej wywołaniem |

## Reguły

- **Interfejs pisze aplikacja.** Nazywa jej potrzebę, a nie to, co akurat oferuje biblioteka. Metoda `ReadHl7Message` w interfejsie oznaczałaby, że producent nadal rządzi aplikacją.
- **Typy producenta nie wychodzą poza adapter.** Dotyczy to parametrów, wyników i wyjątków.
- **Jednostka jest częścią wartości.** Goły `decimal` to zaproszenie do pomyłki, której właśnie się pozbywamy.
- **Czytaj jednostkę z odpowiedzi,** zamiast ją zakładać, a nieznaną traktuj jako błąd. Lepszy błąd niż wynik 18 razy za duży.
- **Tłumacz wyjątek, ale zachowaj oryginał.** Aplikacja decyduje na podstawie `Fault`, a serwis diagnozuje po `InnerException`.
- **Adapter nie zawiera reguł biznesowych.** Tłumaczy i deleguje, a o tym, czy wynik jest krytyczny, decyduje aplikacja.
- **Atrapa musi spełniać ten sam kontrakt** co prawdziwy adapter, inaczej testy sprawdzają coś, czego nie ma.
- **Nie każda biblioteka potrzebuje adaptera.** Ma on sens, gdy biblioteka jest niezgodna, może się zmienić albo przeszkadza w testach.

## Uruchomienie

```
dotnet build Adapter.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
