# Dzień 3, Moduł 4: Strategy

**Strategy** zamyka wymienny sposób działania w osobnej klasie za wspólnym **interfejsem strategii**. Klasa, która z niego korzysta, czyli **kontekst**, zna tylko interfejs i nie sprawdza, z którym wariantem pracuje. O wyborze decyduje ktoś z zewnątrz, także **podczas działania aplikacji**: użytkownik na liście albo konfiguracja.

Moduł rozwija pomysł z modułu 2 Dnia 1, w którym cennik wydruku był delegatem `Func<int, decimal>`. Tam wystarczała jedna operacja. Tu jest ich kilka i muszą do siebie pasować, dlatego jeden delegat nie wystarczy.

## Historia

Laboratorium centralne podpisało umowę z laboratorium partnerskim, które raportuje kwas moczowy w mmol/l, a nie w mg/dl. Kolejna gałąź trafiła do i tak długiego `if`/`switch`. Po wdrożeniu lekarze pytają, czemu każde badane dziecko ma wynik poniżej normy. Podobnie jest z rozliczeniem wydruku: nowa klinika płaci w euro, a na rachunku jest PLN.

Wartości norm w module są przykładowe i nie służą do diagnostyki.

## Problem

Otwórz `Problem/ResultProcessor.cs` i `Problem/PrintBilling.cs`.

| Kod | Problem | Objaw |
|---|---|---|
| `ResultProcessor.Process` | Walidacja, przeliczenie i normy wszystkich kombinacji w jednej metodzie | **Dziecko z laboratorium partnerskiego, odczyt 4,0 mg/dl: wynik 0,24 mmol/l, norma 2,0–5,5, ocena „poniżej normy”** |
| `ResultProcessor.Process` | Nikt nie sprawdza metody w laboratorium partnerskim | **„Partnerskie” i „Kolorymetryczna” dają wynik, choć tej metody tam nie ma** |
| `PrintBilling` | Te same przypadki klientów w trzech metodach | **Klinika Baltic, 1000 kopii: 19,00 PLN zamiast 19,00 EUR** |
| `MainForm` | Okno ma własną kopię wiedzy o jednostkach | Nowe laboratorium to zmiana także w oknie |

## Delegat czy interfejs

| Pytanie | Delegat (moduł 2 Dnia 1) | Interfejs strategii (ten moduł) |
|---|---|---|
| Ile operacji? | Jedna, np. `Func<int, decimal>` jako koszt | Kilka powiązanych: koszt, rabat, waluta |
| Czy muszą pasować do siebie? | Nie ma czego pilnować | Tak, jeden obiekt pilnuje, że pochodzą od tego samego klienta |
| Dane wariantu | W domknięciu, np. `PerCopy(0.04m)` | W polach, np. `ContractPriceList` |
| Nazwa na liście, własna walidacja | Trzeba dołożyć osobno | Część interfejsu |
| Ilość kodu | Jedna lambda | Interfejs i klasy |

## Strategy a State

Oba wzorce mają taką samą budowę: interfejs, kilka implementacji i klasę, która do nich deleguje. Różni je to, kto i dlaczego zmienia wariant.

| | Strategy | State (kolejny moduł) |
|---|---|---|
| Kto wybiera | Ktoś z zewnątrz: użytkownik, konfiguracja | Sam obiekt, w reakcji na to, co się z nim dzieje |
| Czy warianty znają się nawzajem | Nie | Często tak, bo wskazują następny stan |
| Co oznacza zmiana | Inny sposób wykonania tego samego zadania | Obiekt jest teraz w innym etapie życia |

## Reguły

- **Wariant to osobna klasa, gdy różni się algorytmem.** Gdy różni się tylko liczbami, wystarczy nowy obiekt z innymi danymi.
- **Jedna operacja to zwykle delegat.** Interfejs jest potrzebny, gdy operacji jest kilka i muszą do siebie pasować.
- **Kontekst nie sprawdza, kogo dostał.** `if (procedure is PartnerUricaseProcedure)` oznacza powrót do punktu wyjścia.
- **Klasy konkretne zna jedno miejsce.** Nowy wariant to nowa klasa i jeden wiersz.
- **Literówka nie może wybrać innego wariantu.** Nieznana nazwa z konfiguracji kończy się pustym wyborem, a nie domyślnym laboratorium.
- **Strategy nie jest celem samym w sobie.** Dwa stabilne warianty i prosty `if` są lepsze niż interfejs i trzy klasy.

## Uruchomienie

```
dotnet build Strategy.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
