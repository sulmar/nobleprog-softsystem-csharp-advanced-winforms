# Dzień 3, Moduł 4: Observer i komunikacja zdarzeniowa

**Observer** to wzorzec, w którym nadawca ogłasza, że coś się stało, a zainteresowani zapisują się sami. Nadawca nie zna odbiorców. W .NET służą do tego `event` oraz interfejsy `IObservable<T>` i `IObserver<T>`, które są w bibliotece standardowej. **Szyna zdarzeń** (event aggregator) dodaje jedno miejsce publikacji, dzięki czemu odbiorca nie musi znać także nadawcy.

Moduł 2 Dnia 1 pokazał `event`, `-=` i wyciek subskrypcji. Tutaj zdarzenie staje się sposobem komunikacji całej aplikacji, a zarządzanie subskrypcjami przestaje zależeć od pamięci programisty.

## Historia

Zatwierdzenie wyniku ma odświeżyć listę wyników, panel statystyk i pasek stanu. Każdy kolejny odbiorca oznaczał zmianę okna zatwierdzania, które zna dziś wszystkie pozostałe okna. Kierownik prosi o okno kontroli jakości, a automat ma zatwierdzać wyniki w tle. Jeden wynik „<2” sprawia, że użytkownik czyta „nie udało się”, choć wynik jest już zatwierdzony.

## Problem

Otwórz `Problem/`. Zacznij od `ApprovalForm.cs`.

| Miejsce | Problem | Objaw |
|---|---|---|
| `ApprovalForm.ApproveButton_Click` | Zdarzenie interfejsu zmienia stan i wie, kto ma się o tym dowiedzieć | Nowy odbiorca to zmiana w trzech metodach (OCP) |
| `Application.OpenForms.OfType<ResultListForm>()` | Okno szuka innego okna po typie | Zależność ukryta przed konstruktorem (DIP) |
| `RejectButton_Click` | Kopia sekwencji powiadomień bez dwóch odbiorców (DRY) | **Licznik „Odrzucone” się nie zmienia** |
| `StatisticsPanel.ShowListButton_Click` | Rzutowanie `(MainForm)FindForm()` | Kontrolka działa tylko w jednym oknie |
| `LabData.ResultChanged` | Statyczne zdarzenie, lambda i brak `-=` | **Zamknięte okna kontroli jakości nadal dostają powiadomienia** |
| `StatisticsPanel.UpdateStatistics` | Wyjątek jednego odbiorcy przerywa sekwencję | **Po zatwierdzeniu „<2” komunikat o błędzie, a wynik jest zatwierdzony** |
| `AutoApproveButton_Click` | Powiadomienia z wątku z puli dotykają kontrolek | Pod debuggerem `InvalidOperationException` |

## Które zdarzenie wybrać

| Pytanie | Wybór |
|---|---|
| Czy to fakt z interfejsu (kliknięcie, zmiana zaznaczenia), ważny tylko dla tego okna? | Zdarzenie kontrolki |
| Czy kontrolka prosi swoje okno o reakcję? | Zwykły `event` w kontrolce |
| Czy opisałby to kierownik laboratorium („wynik zatwierdzono”)? | Zdarzenie biznesowe |
| Jeden nadawca i odbiorcy żyjący tak samo długo jak on? | Zwykły `event` lub `IObservable<T>` z nadawcy |
| Wielu nadawców, a odbiorcy pojawiają się i znikają? | Szyna zdarzeń |

## Reguły

- **Handler `Click` nie ogłasza biznesu.** Wywołuje operację, a zdarzenie biznesowe ogłasza kod, który naprawdę zmienił stan, po zapisaniu tej zmiany.
- **Zdarzenie jest faktem.** Nazwa w czasie przeszłym i dane, których nie można zmienić, bo czyta je wielu odbiorców, także z innych wątków.
- **Subskrypcja ma właściciela.** Każda jest związana z oknem lub kontrolką i kończy się razem z nim. Nie ma tu miejsca na pamiętanie o `-=`.
- **Nadawca nie odpowiada za błąd odbiorcy.** Stan jest już zmieniony, więc wyjątek odbiorcy nie może wrócić jako błąd operacji. Musi jednak trafić do rejestru.
- **`OnError` nie służy do błędów odbiorcy.** Oznacza błąd źródła i koniec strumienia.
- **O wątku decyduje odbiorca.** Nadawca nie wie, kto słucha, więc nie może wiedzieć, jakiego wątku ktoś potrzebuje.
- **Dostawa przez `Post` jest późniejsza.** Po powrocie z `Approve` okna mogą jeszcze nie być odświeżone, a okno może się w tym czasie zamknąć.
- **Nie każde wywołanie to zdarzenie.** Gdy potrzebna jest odpowiedź albo kolejność kroków ma znaczenie, zwykłe wywołanie metody jest czytelniejsze.

## Uruchomienie

```
dotnet build Observer.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
