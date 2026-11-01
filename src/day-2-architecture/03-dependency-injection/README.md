# Dzień 2, Moduł 3: Dependency Injection i składanie aplikacji

**Odwrócenie zależności** (DIP) oznacza, że logika zależy od interfejsu opisującego jej potrzebę, a nie od konkretnej bramki czy bazy. **Wstrzykiwanie przez konstruktor** to najprostszy sposób dostarczenia takiej zależności: klasa wymienia w konstruktorze wszystko, czego potrzebuje, a tworzy to kto inny. **Kontener** automatyzuje to tworzenie i pilnuje **czasu życia** obiektów. Całość składa się w jednym miejscu, czyli w **korzeniu składania** w `Program.cs`.

W tym module wolno użyć pakietu `Microsoft.Extensions.DependencyInjection` w wersji 8.0.1. Obsługuje on .NET Framework 4.8 i `netstandard2.0`.

## Historia

Na szkoleniu nowych pracowników ktoś zatwierdził przykładowy wynik krytyczny i lekarz dyżurny dostał prawdziwego SMS-a. Testu napisać się nie da, bo wysyła on SMS-y i zależy od kolejności uruchomienia. Dodatkowo drugie otwarcie okna zatwierdzania kończy się błędem, a przycisk „Raport dnia” nie działa wcale, choć kod się kompiluje.

## Problem

Otwórz `Problem/`. Formularze mają już Presentery, więc tematem jest wyłącznie to, kto tworzy obiekty i jak długo one żyją.

| Miejsce | Problem | Objaw |
|---|---|---|
| `ResultApprovalService` | `new SmsGateway()` w logice | **Test naprawdę wysyła SMS i czeka półtorej sekundy** |
| `ResultDatabase`, `AuditLog`, `LabSettings` | Statyczne singletony | **Wynik testu zależy od kolejności uruchomienia** |
| `ApprovalPresenter`, `ResultsPresenter` | Presenter sam tworzy swoje zależności | Nie ma jak podstawić atrapy |
| `DailyStatistics` | Singleton trzyma sesję pierwszego okna | **Drugie okno kończy się `ObjectDisposedException`** |
| `ResultsForm` | `new ApprovalForm(code).ShowDialog(this)` bez `Dispose` | Formularz otwarty modalnie nie jest zwalniany |
| `ServiceLocator`, `ResultReportService` | Zależności ukryte w treści metody | **„Raport dnia” pada dopiero po kliknięciu** |

## Reguły

- **Klasa nie tworzy swoich zależności.** Wymienia je w konstruktorze.
- **Interfejs nazywa potrzebę:** `IDoctorNotifier`, a nie `ISmsGateway`.
- **Dane to nie zależność.** Kod próbki przychodzi metodą, a nie z kontenera.
- **Tylko korzeń składania zna konkretne klasy i kontener.** Logika go nie widzi, a pilnuje tego test.
- **Obiekt nie może trzymać czegoś, co żyje krócej niż on.**
- **Okno ma własny zakres.** Formularz i jego sesja kończą życie razem z oknem.
- **Włącz `ValidateOnBuild` i `ValidateScopes`.** Błąd złożenia wychodzi przy starcie, a nie u użytkownika.
- **Kontener nie jest obowiązkowy.** W małej aplikacji ręczne składanie wystarcza, a kompilator sprawdza je w całości.

## Uruchomienie

```
dotnet build DependencyInjection.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
