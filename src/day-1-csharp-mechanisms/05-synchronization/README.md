# Dzień 1, Moduł 5: Synchronizacja dostępu

**Wspólny stan** to dane używane przez kilka wątków naraz. Gdy co najmniej jeden z nich je zmienia, wynik zależy od kolejności wykonania, czyli powstaje **wyścig**. **Synchronizacja** porządkuje dostęp do takich danych, a źle użyta prowadzi do **zakleszczenia**, w którym wątki czekają na siebie nawzajem bez końca.

## Historia

Kilka analizatorów pracuje równocześnie i korzysta ze wspólnych danych. Liczniki próbek nie zgadzają się na koniec dnia, analizator dostaje więcej próbek, niż ma miejsc, a podczas przekładania próbek między statywami aplikacja przestaje pracować. Błędy pojawiają się rzadko i trudno je powtórzyć.

## Problem

Otwórz `Problem/`. Każdy przycisk uruchamia pracę wielu wątków na wspólnych danych.

| Przycisk | Problem | Objaw |
|---|---|---|
| Policz próbki | `Count++` nie jest niepodzielne | **Licznik pokazuje za mało** |
| Rezerwuj miejsca | Sprawdzenie i rezerwacja to dwa kroki | **Więcej rezerwacji niż miejsc, a wolne miejsca ujemne** |
| Zbierz wyniki | `List<T>` nie jest bezpieczna wątkowo | Zgubione elementy albo wyjątek |
| Zbadaj 6 próbek | Brak limitu dla pracy z `await` | Wszystkie 6 próbek w analizatorze, który przyjmuje 2 |
| Przełóż próbki | Blokady zajmowane w różnej kolejności | **Zakleszczenie: praca staje na zawsze** |

## Reguły

- **Najlepszy wspólny stan to brak wspólnego stanu.** Lokalne dane i wyniki zwracane z zadania nie wymagają synchronizacji.
- **Blokuj prywatny obiekt,** a nie `this`, typ ani napis. Inaczej ktoś z zewnątrz może zająć tę samą blokadę.
- **Chroń całą operację,** a nie pojedyncze linie. Sprawdzenie i zmiana muszą być pod tą samą blokadą.
- **Trzymaj blokadę krótko.** Bez wywołań sieci, dysku i obcego kodu w środku.
- **`await` w `lock` się nie skompiluje** (CS1996). Do tego służy `SemaphoreSlim.WaitAsync`.
- **Zwalniaj w `finally`.** `lock` robi to sam, a `SemaphoreSlim` i `Monitor` wymagają tego od nas.
- **Zajmuj blokady zawsze w tej samej kolejności.** To usuwa cykl oczekiwania, czyli przyczynę zakleszczenia.
- **Zielony test wielowątkowy nie dowodzi poprawności.** Test zwiększa szansę wykrycia błędu, ale jej nie gwarantuje, więc potrzebny jest też przegląd kodu.

## Uruchomienie

```
dotnet build Synchronization.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
