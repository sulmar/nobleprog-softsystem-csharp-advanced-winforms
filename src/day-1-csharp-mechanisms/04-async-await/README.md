# Dzień 1, Moduł 4: Programowanie asynchroniczne

**`Task`** reprezentuje pracę, która trwa, a **`Task<T>`** taką, która zakończy się wynikiem typu `T`. **`async` i `await`** to lukier składniowy: kompilator zamienia kod po `await` na kontynuację, więc piszemy go tak, jakby był sekwencyjny, a wątek interfejsu w tym czasie obsługuje okno.

Moduł celowo nie używa współdzielonego stanu ani blokad. To temat modułu 5.

## Historia

Laboratorium bada próbki i wysyła wyniki do lekarza. Każda operacja trwa kilka sekund, a okno w tym czasie stoi. Lekarz chce też dostawać raport zbiorczy z wynikami wszystkich próbek jednej osoby, a użytkownik chce móc przerwać długą wysyłkę.

## Problem

Otwórz `Problem/`. Zegar w oknie pokazuje, czy wątek interfejsu reaguje.

| Przycisk | Problem | Objaw |
|---|---|---|
| Wyślij wynik | Wysyłka w wątku interfejsu | **Zegar i okno stają** |
| Zbadaj i wyślij | Wysyłka potrzebuje wyniku badania | Okno stoi przez sumę obu czasów |
| Raport zbiorczy | Próbki badane po kolei | Czas to suma czasów wszystkich próbek |
| Zbadaj przez `.Result` | Blokada wątku, do którego `await` chce wrócić | **Aplikacja zawisa na zawsze** |
| Wyślij w tle, z polem „Błąd wysyłki” | `async void` w metodzie pomocniczej | `try`/`catch` nie łapie błędu |
| Raport w tle | Brak anulowania, postępu i blokady przycisku | Nie da się przerwać, a drugie kliknięcie uruchamia kolejny raport |

## `ContinueWith` a `await`

```csharp
// Bez lukru składniowego
return Task.Run(() => analyze(sample)).ContinueWith(analysis =>
{
    var result = analysis.Result;
    send(result);
    return result;
});

// Z lukrem składniowym
var result = await Task.Run(() => analyze(sample));
await Task.Run(() => send(result));
return result;
```

## `IProgress<T>`: interfejs i delegat razem

Metoda zależy od **interfejsu** `IProgress<T>` i nie wie, kto jest po drugiej stronie, a klasa `Progress<T>` dostaje sposób reakcji jako **delegat** `Action<T>`. Dzięki temu nie trzeba pisać nowej klasy dla każdego sposobu pokazywania postępu. `Progress<T>` wywołuje delegat w wątku, w którym ją utworzono, czyli w wątku interfejsu.

## Reguły

- **`async` nie oznacza osobnego wątku.** Kod do pierwszego prawdziwego oczekiwania działa w wątku wywołującym.
- **Praca na sieci lub dysku:** `await` na metodzie asynchronicznej. **Długie obliczenia:** `await Task.Run(...)`.
- **Async do końca.** Nie blokuj przez `.Result` ani `.Wait()`, bo w wątku interfejsu grozi to zakleszczeniem.
- **`async void` tylko w handlerach zdarzeń,** z obsługą błędów wewnątrz. W pozostałych metodach zwracaj `Task`.
- **W kodzie biblioteki używaj `ConfigureAwait(false)`,** a w kodzie formularza nie, bo potem zmieniasz kontrolki.
- **`await` na `Task.WhenAll` zgłasza tylko pierwszy wyjątek.** Pozostałe są w `Task.Exception`.
- **W testach nie używaj `Progress<T>`,** bo wywołuje callback później. Napisz prostą implementację `IProgress<T>`.

## Uruchomienie

```
dotnet build AsyncAwait.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
