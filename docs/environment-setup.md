# Przygotowanie środowiska

## Wymagania

- Windows 10 lub 11
- Visual Studio 2022 z obciążeniem **.NET desktop development** i komponentem **.NET Framework 4.8 targeting pack**
- .NET 8 SDK, potrzebny do testów z celem `net8.0`
- Dostęp do NuGet, potrzebny przy pierwszym przywracaniu pakietów (xUnit)

## Sprawdzenie

Z katalogu modułu:

```
cd src/day-1-csharp-mechanisms/01-extension-methods
dotnet build ExtensionMethods.sln
dotnet build Solution/Lims.Problem.Tests
```

Potem uruchom w Visual Studio projekt `Lims.Problem` z folderu `Solution`.

## macOS i Linux

Projekty da się skompilować, a testy z `Exercise/Starter` uruchomić z `-f net8.0`. Aplikacji WinForms i testów net48 nie da się tam uruchomić.
