# Dzień 1, Moduł 6: Refleksja i własne atrybuty

**Refleksja** pozwala programowi w czasie działania odczytać opis typów, np. listę właściwości klasy, i korzystać z nich bez znajomości ich nazw podczas kompilacji. **Atrybut** to dodatkowa informacja zapisana przy klasie, właściwości lub wartości typu wyliczeniowego. Sam nic nie robi, dopóki jakiś kod nie odczyta go przez refleksję.

Dzięki temu jeden kod obsługuje wiele typów, a to, czym się różnią, opisujemy przy nich samych.

## Historia

Laboratorium eksportuje próbki i wyniki do plików CSV. Każdy model ma osobny eksport i osobną walidację, statusy mają po polsku kilka różnych wersji, a kontrola wykazała numery PESEL w wyeksportowanych plikach.

## Problem

Otwórz `Problem/`.

| Miejsce | Problem | Objaw |
|---|---|---|
| `CsvExports` | Osobna metoda na każdy model | Nowy model to nowa metoda, a nowa właściwość to kilka zmian |
| `CsvExports.Samples` | Eksport nie zna znaczenia kolumn | **PESEL trafia do pliku jawnym tekstem** |
| `StatusForExport`, `StatusText` | Dwie kopie `switch` | Inne teksty, a **nowy status eksportuje się jako `?`** |
| `MainForm`, lista statusów | Lista przepisana ręcznie | Brak statusu „Zarchiwizowana” |
| `MainForm`, kolumny siatki | Nazwy właściwości jako napisy | Literówka wychodzi po uruchomieniu, a PESEL jest widoczny |
| `ValidateSample`, `ValidateResult` | Osobna walidacja na model, w formularzu | Powielone warunki, których nie da się przetestować |

## Własny atrybut w trzech krokach

```csharp
// 1. Definicja
[AttributeUsage(AttributeTargets.Property)]
public sealed class ColumnAttribute : Attribute
{
    public ColumnAttribute(string header) { Header = header; }
    public string Header { get; }
    public int Order { get; set; } = int.MaxValue;
}

// 2. Użycie
[Column("Kod", Order = 1)]
public string Code { get; set; }

// 3. Odczyt
var column = property.GetCustomAttribute<ColumnAttribute>();
```

## Reguły

- **Atrybut to dane, a nie zachowanie.** Działa dopiero kod, który go odczytuje.
- **Refleksja jest wolna.** Odczytaj opis typu raz i zapamiętaj go, zamiast powtarzać dla każdego wiersza.
- **Kompilator nie sprawdzi nazw w napisach.** Używaj `nameof`, gdy szukasz składowej po nazwie.
- **`GetProperties` nie gwarantuje kolejności.** Gdy jest ważna, ustal ją jawnie.
- **Dostęp do składowych niepublicznych to wyjątek.** Omija enkapsulację i może przestać działać po aktualizacji biblioteki.
- **Nie zastępuj refleksją zwykłego kodu.** Ma sens, gdy obsługujemy wiele typów, a nie jeden znany.

## Uruchomienie

```
dotnet build ReflectionAttributes.sln
dotnet test Solution/Lims.Problem.Tests
```

`Problem/` to stan wyjściowy, którego nie zmieniamy. Refaktoryzujemy jego kopię w `Solution/Lims.Problem`, a testy piszemy w `Solution/Lims.Problem.Tests`. W solucji oba projekty nazywają się `Lims.Problem`, więc przed uruchomieniem sprawdź, że projektem startowym jest ten z folderu `Solution`.

Aplikacje i testy wymagają Windows. Na macOS i Linuksie można je tylko skompilować.

## Zadanie

Treść jest w [Exercise/README.md](Exercise/README.md).
