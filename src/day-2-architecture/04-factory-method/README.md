# Dzień 2, Moduł 4: Factory Method

**Factory Method** (metoda wytwórcza) przekazuje decyzję o tym, jaki obiekt powstanie, klasom pochodnym. **Twórca** zna przebieg pracy i woła swoją metodę wytwórczą, a **konkretny twórca** wybiera **produkt**. Kod korzystający z twórcy nie wie, która klasa produktu została użyta, więc nowy wariant oznacza nową klasę, a nie kolejną gałąź `switch`.

W WinForms ta sama idea pozwala oddzielić przebieg pracy od konkretnego okna. Gdy wariant różni się tylko tym, co tworzy, wystarczy lżejszy `Func<T>` z modułu 2 Dnia 1.

## Historia

Laboratorium wykonuje badania krwi, moczu i posiewy mikrobiologiczne. Każde ma inne okno wprowadzania wyników i inny raport. Gdy doszła mikrobiologia, programista dopisał ją w formularzu głównym, ale nie w eksporcie nocnym. Od tego czasu wynik posiewu wychodzi w nocy jako raport z morfologii krwi, a w podglądzie wygląda poprawnie.

## Problem

Otwórz `Problem/`.

| Miejsce | Co tam jest | Skutek |
|---|---|---|
| `NightlyExport.Export` | `switch` po typie badania bez mikrobiologii | **Posiew wychodzi jako „Raport: morfologia krwi”, z pozycją „norma: brak”** |
| `MainForm.PreviewReportButton_Click` | Druga kopia `switch` i układu raportu | Podpis i treść różnią się od eksportu |
| `MainForm.EnterResultsButton_Click` | Trzecia kopia `switch`, `new` konkretnych okien | Decyzji nie da się przetestować, okna nie są zwalniane |
| `BloodResultForm`, `UrineResultForm`, `MicrobiologyResultForm` | Kopie walidacji i zapisu | Reguła „posiew czeka na weryfikację” jest zaszyta w oknie |

## Klasa, delegat czy `new`

| Sytuacja | Wybór | Przykład |
|---|---|---|
| Jeden wariant, tworzony w jednym miejscu | Zwykły `new` | `AboutForm`, `LabOrder`, `ResultValue` |
| Warianty różnią się tylko tym, co powstaje | `Func<T>` | Okna krwi i moczu |
| Wariant wnosi coś więcej niż `new`, np. regułę lub własny podpis | Klasa pochodna | Wpis i raport mikrobiologii |

## Reguły

- **Twórca ma własną pracę.** Klasa, która tylko zwraca `new`, nie jest jeszcze Factory Method. Sens pojawia się, gdy twórca używa produktu w kodzie wspólnym dla wariantów.
- **Decyzja o wariancie zapada raz.** Wyboru po typie nie da się usunąć, ale można trzymać go w jednym miejscu.
- **Metoda wytwórcza zwraca abstrakcję.** Dzięki temu logika nie zależy od WinForms, a przebieg można sprawdzić atrapą okna.
- **Kto tworzy okno, ten je zwalnia.** Okno pokazane przez `ShowDialog` nie jest zwalniane po zamknięciu, trzeba wywołać `Dispose`.
- **Przekazuj przepis na okno, a nie okno.** Zwolnionego formularza nie da się pokazać ponownie, więc każde wywołanie tworzy nowy.
- **Nie twórz wariantów na zapas.** Dopóki jest jeden wariant, zwykły `new` jest czytelniejszy.

## Uruchomienie

```
dotnet build FactoryMethod.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
