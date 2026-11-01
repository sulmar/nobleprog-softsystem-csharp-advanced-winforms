# Dzień 2, Moduł 7: Decorator

**Dekorator** to klasa, która implementuje ten sam interfejs co obiekt, który owija. Przekazuje mu wywołanie, a przed nim lub po nim dodaje jedno działanie, np. log, cache albo sprawdzenie uprawnień. Dla kodu wywołującego nic się nie zmienia, a działania można dowolnie włączać, wyłączać i układać bez zmiany właściwego serwisu.

Wzorzec korzysta z tego, co już znamy: wstrzykiwania przez konstruktor (moduł 3) i składania aplikacji w `Program.cs`. Od Adaptera (moduł 5) różni się tym, że nie zmienia interfejsu, a od Facade (moduł 6) tym, że nie upraszcza dostępu do wielu klas, tylko dodaje działanie do jednej.

## Historia

Serwis wyników powstał jako kilka linii odczytu z bazy. Potem doszedł log dla działu jakości, cache, bo baza jest wolna, i uprawnienia po audycie. Dziś rejestratorka widzi wyniki, których nie powinna, jeśli wcześniej otworzył je diagnosta, a w logu nie ma po tym śladu. Po korekcie wyniku przez 5 minut wszyscy widzą starą wartość. Automat nocny chce korzystać z serwisu bez cache, ale nie da się go wyłączyć.

## Problem

Otwórz `Problem/ResultService.cs` oraz `Problem/InheritanceAttempt.cs`.

| Co jest źle | Gdzie | Skutek |
|---|---|---|
| Cache przed uprawnieniami | `ResultService.GetResult` | **Osoba bez uprawnień dostaje wynik z cache** |
| Wyjście z metody przed logowaniem | `ResultService.GetResult` | Odczyt z cache nie trafia do logu |
| Brak usunięcia z cache po korekcie | `ResultService.CorrectResult` | **Przez 5 minut widać starą wartość** |
| Wyjątek omija zapis do logu | `ResultService.CorrectResult` | Błąd bazy nie zostawia śladu |
| Wszystko w jednej klasie | `ResultService` | Działań nie da się wyłączyć ani sprawdzić osobno |
| `DateTime.Now`, statyczna sesja i plik | `ResultService` | Test zależy od zegara, stanu globalnego i dysku |
| Klasa na każdą kombinację | `InheritanceAttempt.cs` | Kopie cache, stała kolejność, 8 zestawów dla 3 działań |

## Dziedziczenie czy dekorator

| Pytanie | Dziedziczenie | Dekorator |
|---|---|---|
| Ile klas dla 3 działań? | Do 8, po jednej na zestaw, i więcej, gdy liczy się kolejność | 3 oraz serwis |
| Kiedy powstaje zestaw działań? | Podczas kompilacji | Podczas składania, w `Program.cs` |
| Jak zmienić kolejność? | Przebudować drzewo klas | Zamienić dwie linie |
| Czy test cache potrzebuje bazy? | Tak, klasa bazowa jest na stałe | Nie, wystarczy atrapa |
| Czy jedno działanie można użyć z innym serwisem? | Nie | Tak, jeśli ma ten sam interfejs |
| Dostęp do składowych chronionych | Tak | Nie, tylko publiczny interfejs |
| Nowa metoda w interfejsie | Klasy pochodne ją dziedziczą | Trzeba ją dopisać w każdym dekoratorze |

Dziedziczenie ma sens, gdy klasa pochodna naprawdę jest szczególnym przypadkiem klasy bazowej, a nie gdy doczepiamy do niej działanie.

## Decorator czy Proxy

Budowa jest taka sama: ten sam interfejs i obiekt w środku. Różni je cel.

| | Decorator | Proxy |
|---|---|---|
| Cel | Dokłada działanie | Kontroluje dostęp do obiektu |
| Przykład | Log | Cache przed wolną bazą, uprawnienia przed danymi |
| Łańcuch | Zwykle kilka warstw | Zwykle jedna warstwa |

Cache i uprawnienia można nazwać obiema nazwami. Liczy się to, co klasa ma osiągnąć.

## Reguły

- **Jeden dekorator, jedno działanie.** Jeśli w nazwie pojawia się „i”, podziel klasę.
- **Dekorator nie zmienia znaczenia operacji.** Zwraca to samo co obiekt w środku, a wyjątek przepuszcza dalej, chyba że obsługa wyjątku jest jego zadaniem.
- **Kolejność to decyzja, a nie szczegół.** Zapisz w `Program.cs`, dlaczego jest taka, a zachowanie sprawdź testem.
- **Uprawnienia przed wspólnym cache.** Wszystko, co jest współdzielone między użytkownikami, musi stać za sprawdzeniem uprawnień.
- **Cache odpowiada też za zapis.** Dekorator cache musi obsłużyć korektę, a nie tylko odczyt.
- **Czas i użytkownik są zależnościami.** Czytaj je przy każdym wywołaniu, a nie raz w konstruktorze, bo użytkownik może się zmienić.
- **Log nie zawiera danych medycznych.** Zapisuj kod próbki i skutek operacji, a nie wartość wyniku.
- **Dekorator nie jest za darmo.** Przy jednym stałym działaniu w jednym miejscu zwykłe wywołanie w serwisie bywa prostsze.

## Uruchomienie

```
dotnet build Decorator.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
