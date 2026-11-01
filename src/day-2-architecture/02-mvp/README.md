# Dzień 2, Moduł 2: Model-View-Presenter

**MVP** rozdziela ekran na trzy role. **Model** to reguły biznesowe i przypadki użycia. **Widok** to formularz, który pokazuje dane i zgłasza, co zrobił użytkownik. **Presenter** to logika prezentacji: reaguje na **zdarzenia Widoku**, woła Model i mówi Widokowi, co pokazać. Presenter zna Widok tylko przez **interfejs**, więc w teście zastępuje go atrapa i całe zachowanie ekranu da się sprawdzić bez otwierania okna.

Używamy odmiany **Passive View**: Widok nie podejmuje żadnych decyzji, a każdy stan przycisku i każdy komunikat ustawia Presenter.

Ten moduł kontynuuje poprzedni: po podziale na warstwy reguły są już poza oknem, ale w formularzu została logika prezentacji. Składaniem Widoku z Presenterem zajmie się kontener DI w module 3.

## Historia

Reguły zleceń mają już testy, a mimo to ze zgłoszeń wynika, że ekran edycji zlecenia zachowuje się dziwnie. Okno pyta o niezapisane zmiany, chociaż nikt nic nie zmienił. Anulowane zlecenie można dalej edytować. Rejestratorka wybrała „Tak, zapisz” przy zamykaniu, zapis się nie udał, a okno i tak się zamknęło razem z wpisanymi danymi. Żadnego z tych błędów nie da się opisać testem, bo wszystkie decyzje leżą w formularzu.

## Problem

Otwórz `Problem/LabOrderEditForm.cs`. Model w `Problem/Model/` jest poprawny i nie wymaga zmian.

| Sytuacja | Objaw | Przyczyna w formularzu |
|---|---|---|
| Otwarcie dowolnego zlecenia | **Zapisz aktywny lub pytanie o zmiany, chociaż nikt nic nie zmienił** | `Priority_SelectedIndexChanged` nie sprawdza flagi `_loading`, a wczytanie zgłasza te same zdarzenia co użytkownik |
| Wpisanie znaku i jego usunięcie | Zlecenie nadal ma „zmiany” | `_dirty` umie się tylko włączyć |
| Anulowanie zlecenia | **Anulowane zlecenie można edytować, a Zapisz kończy się odmową** | Stan pól ustala tylko `LoadOrder`, a `CancelOrderButton_Click` ma niepełną kopię (DRY) |
| Cito bez uwag | Zapisz aktywny, a zapis i tak odmawia | `UpdateButtons` ma niepełną kopię reguły z Modelu (DRY) |
| Zamknięcie, „Tak”, nieudany zapis | **Okno się zamyka, wpisane dane przepadają** | Handler przycisku nie zwraca wyniku, więc `FormClosing` nie wie, że zapis się nie udał |
| Testy | Brak | Każda decyzja czyta kontrolki, a `MessageBox` czeka na kliknięcie |

## Co zostaje w formularzu

MVP nie usuwa formularza i nie sprawia, że jest on przetestowany.

| Co zostaje | Dlaczego tutaj | Kto to sprawdza |
|---|---|---|
| Układ kontrolek, `.Designer.cs` | To sam wygląd | Człowiek |
| Przełożenie właściwości Widoku na kontrolki | Tylko formularz zna kontrolki | Człowiek |
| Zamiana zdarzeń kontrolek na zdarzenia Widoku | Tu powstaje informacja, co zrobił użytkownik | Człowiek: **brak podpięcia jednego pola nie zatrzyma żadnego testu** |
| `MessageBox` i zamiana `DialogResult` na `UnsavedChangesAnswer` | Wygląd pytania należy do okna, a skutek odpowiedzi do Presentera | Człowiek |
| `Close()` i `FormClosing` | Mechanizm zamykania okna | Człowiek |

Formularz może mieć dużo linii, ale nie ma w nim decyzji o zleceniu. Dlatego wystarczy krótka lista kontrolna do ręcznego sprawdzenia.

## Reguły

- **Widok nie decyduje.** Zgłasza „użytkownik kliknął Zapisz”, a nie „zapisz zlecenie”.
- **Interfejs Widoku mówi językiem ekranu, a nie WinForms.** `SaveEnabled` zamiast `Button`, `string` zamiast `ComboBox`.
- **Zasada biznesowa jest w Modelu, a jej skutek na ekranie w Presenterze.** `CanEdit` to Model, `PhysicianEnabled` to Presenter.
- **Stan ekranu licz z danych, a nie zgaduj ze zdarzeń.** Jedna metoda ustala wszystko po każdej zmianie.
- **Atrapa ma zachowywać się jak kontrolka.** Ustawienie wartości z kodu zgłasza zmianę. Inaczej test nie wykryje błędu wczytywania.
- **Nie ufaj wyłączonemu przyciskowi.** Model i tak sprawdza regułę, bo sytuacja mogła się zmienić od chwili otwarcia ekranu.
- **MVP to koszt.** Prosty ekran bez logiki prezentacji nie potrzebuje interfejsu i Presentera.

## Uruchomienie

```
dotnet build Mvp.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
