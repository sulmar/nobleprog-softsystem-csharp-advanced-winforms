# Dzień 2, Moduł 6: Facade

**Fasada** (Facade) to prosta operacja przed kilkoma podsystemami. Klient prosi o to, czego potrzebuje, a fasada zna kroki, ich kolejność i reakcję na błędy. Pracę nadal wykonują **podsystemy**, które o fasadzie nie wiedzą i które wciąż można wywołać bezpośrednio, gdy trzeba.

Moduł 1 wprowadził serwis przypadku użycia. Fasada patrzy na to samo z innej strony: ile musi wiedzieć klient, aby skorzystać z kilku współpracujących podsystemów.

## Historia

Zatwierdzenie zlecenia to pięć kroków w pięciu systemach: zapis, rozliczenie, audyt, etykieta i powiadomienie. Procedurę skopiowano do okna rejestracji, a potem do okien Cito i zatwierdzania zbiorczego, za każdym razem trochę inaczej. Audytor pyta, kto zatwierdził zlecenie Cito, a w rejestrze nic nie ma. Przychodnia reklamuje podwójną opłatę, a pacjent dostał SMS o zleceniu, którego rzekomo nie udało się zatwierdzić.

## Problem

Otwórz `Problem/`. Okno główne ma dziennik, który pokazuje kolejność wywołań podsystemów, oraz przełączniki awarii.

| Okno | Kolejność | Co jest nie tak |
|---|---|---|
| Rejestracja | Zapis, rozliczenie, audyt, etykieta, powiadomienie | Wzorcowa kolejność, ale **brak papieru kończy się nieobsłużonym wyjątkiem**, a pacjent nie dostaje powiadomienia |
| Cito | Powiadomienie, zapis, etykieta, rozliczenie | **Brak audytu.** SMS przed zapisem. **Drugie kliknięcie rozlicza drugi raz.** Po błędzie komunikat „nie udało się”, choć zlecenie jest zatwierdzone |
| Zbiorczo | Rozliczenie, zapis, etykieta, audyt | **Brak powiadomienia,** inny format etykiety. Błąd przerywa pętlę, a zlecenie zostaje rozliczone i bez audytu |

## Błąd w środku sekwencji

| Krok | Rodzaj | Gdy się nie uda |
|---|---|---|
| Zapis, rozliczenie, audyt | Obowiązkowe | Wycofaj wykonane kroki w odwrotnej kolejności i zwróć `Failed` |
| Etykieta, powiadomienie | Dalsze, do powtórzenia | Zlecenie zostaje zatwierdzone, a wynik mówi, co trzeba dokończyć |
| Wycofanie | Ostatnia linia obrony | Wynik wymienia, co trzeba cofnąć ręcznie |

Kolejność wynika z tej polityki: najpierw to, co da się cofnąć, a na końcu powiadomienie, którego cofnąć się nie da. Fasada nie daje transakcji. Tu jest ona poskładana ręcznie, bo podsystemy nie mają wspólnej bazy.

## Czym fasada nie jest

| | Fasada | Klasa-bóg | Adapter (moduł 5) |
|---|---|---|---|
| Cel | Uprościć dostęp do kilku podsystemów | Brak: rośnie, bo tak najłatwiej | Dopasować jeden obcy interfejs do oczekiwanego |
| Zakres | Jeden obszar, kilka metod | Wszystko naraz | Jeden obiekt, ta sama funkcja |
| Logika | Tylko kolejność i błędy | Reguły, teksty, dostęp do danych | Tylko tłumaczenie wywołań |
| Podsystemy | Dostępne nadal bezpośrednio | Ukryte w środku lub wchłonięte | Klient widzi tylko interfejs docelowy |

## Reguły

- **Fasada to wygoda, a nie mur.** Klient może użyć podsystemu bezpośrednio, gdy potrzebuje jednej czynności.
- **Fasada koordynuje, a nie liczy.** Reguła biznesowa w fasadzie to pierwszy krok do klasy-boga.
- **Nowy obszar to nowa fasada.** Raport dzienny nie jest powodem, by dodać metodę do fasady zatwierdzania.
- **Polityka błędów jest częścią fasady.** Skoro zna kolejność, tylko ona wie, co trzeba wycofać.
- **Podsystemy nie znają fasady.** Zależność biegnie w jedną stronę.
- **Testuj fasadę na atrapach.** Wspólny rejestr wywołań sprawdza kolejność i brak kroków.
- **Nie każda klasa potrzebuje fasady.** Jedno wywołanie jednego podsystemu nie wymaga pośrednika.

## Uruchomienie

```
dotnet build Facade.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
