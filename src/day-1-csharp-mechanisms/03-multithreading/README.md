# Dzień 1, Moduł 3: Wielowątkowość w WinForms

Wątek to niezależna ścieżka wykonywania kodu w procesie. Aplikacja WinForms ma jeden wątek interfejsu, który w pętli obsługuje komunikaty: kliknięcia, rysowanie i zegary. Gdy ten wątek jest zajęty długą pracą, okno przestaje reagować. Dlatego długą pracę uruchamiamy w innym wątku, a kontrolki zmieniamy wyłącznie z wątku interfejsu.

Moduł celowo nie używa `async` i `await` ani współdzielonego stanu. To tematy modułów 4 i 5.

## Historia

Walidacja serii wyników z analizatora trwa kilkanaście sekund. Na ten czas okno dostaje status „Nie odpowiada”, a użytkownicy zamykają je przez menedżer zadań. Kolejne próby naprawy przenoszą pracę do innego wątku, ale wywołują nowe problemy.

## Problem

Otwórz `Problem/`. Zegar w oknie pokazuje, czy wątek interfejsu reaguje: gdy stanie, stoi też całe okno.

| Przycisk | Problem | Objaw |
|---|---|---|
| Waliduj | Praca w wątku interfejsu | **Zegar i okno stają na czas pracy** |
| Waliduj w tle | Wątek pierwszoplanowy | Po zamknięciu okna proces działa do końca pracy |
| Waliduj w tle | Zmiana kontrolek z innego wątku | **Pod debuggerem `InvalidOperationException`** |
| Waliduj w tle, z polem „Błąd analizatora” | Nieobsłużony wyjątek w wątku | Cała aplikacja kończy działanie |
| Waliduj zadaniem | `Task.Run(...).Result` | Praca jest w puli wątków, a okno i tak stoi |

## `Thread` a `Task`

| | `Thread` | `Task` |
|---|---|---|
| Wątek | Nowy, tworzony dla tej pracy | Zwykle z puli wątków |
| Wynik | Trzeba przekazać samodzielnie | `Task<T>.Result` |
| Wyjątek bez obsługi | Kończy proces | Zostaje w zadaniu |
| Kontynuacja | Trzeba napisać samodzielnie | `ContinueWith` |
| Kiedy | Długo działający wątek z własnymi ustawieniami | Domyślny wybór |

## Reguły

- **Kontrolki zmieniamy tylko z wątku, który je utworzył.** Bez debuggera błąd może się nie ujawnić, ale nadal jest błędem.
- **Nie blokuj wątku interfejsu** przez `Thread.Sleep`, `.Result`, `.Wait()` ani `Thread.Join()`.
- **`Invoke` czeka na wątek interfejsu, a `BeginInvoke` nie.** Blokada wątku interfejsu przy `Invoke` to zakleszczenie (moduł 5).
- **Stan kontrolek odczytuj przed startem wątku,** a nie w jego trakcie.
- **Unikaj `Application.DoEvents`.** Pozwala kliknąć przycisk ponownie w trakcie pracy, co prowadzi do trudnych błędów.

## Uruchomienie

```
dotnet build Multithreading.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
