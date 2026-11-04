# Zaawansowany C# i wzorce w WinForms: materiały dla uczestników

Kod do trzydniowego szkolenia, którego program opisuje [agenda.md](agenda.md), a kolejność tematów [roadmapa](docs/roadmap.xmind) (plik programu Xmind). Domena przykładów to laboratoryjne systemy informatyczne (LIMS).

Układ modułu:

- `README.md`: opis mechanizmu, historia i problem,
- `Problem/`: kod z problemem, stan wyjściowy, którego nie zmieniamy,
- `Solution/`: kopia `Problem` i projekt testów, tu odbywa się refaktoryzacja,
- `Exercise/`: zadanie dla uczestników, w `Starter/` piszesz swoje rozwiązanie.

Moduł `06-workshop` ma inny układ: cała praca odbywa się w `Starter/`.

Stos: .NET Framework 4.8, WinForms, C# 7.3, xUnit. Przygotowanie komputera opisuje [docs/environment-setup.md](docs/environment-setup.md), skróty zasad [docs/solid-glossary.md](docs/solid-glossary.md), a role we wzorcach [docs/design-patterns.md](docs/design-patterns.md).

## Moduły

| Dzień | Moduł |
|---|---|
| Dzień 1 | [01-extension-methods](src/day-1-csharp-mechanisms/01-extension-methods/README.md) |
| Dzień 1 | [02-delegates-lambdas-events](src/day-1-csharp-mechanisms/02-delegates-lambdas-events/README.md) |
| Dzień 1 | [03-multithreading](src/day-1-csharp-mechanisms/03-multithreading/README.md) |
| Dzień 1 | [04-async-await](src/day-1-csharp-mechanisms/04-async-await/README.md) |
| Dzień 1 | [05-synchronization](src/day-1-csharp-mechanisms/05-synchronization/README.md) |
| Dzień 1 | [06-reflection-attributes](src/day-1-csharp-mechanisms/06-reflection-attributes/README.md) |
| Dzień 2 | [01-layered-architecture](src/day-2-architecture/01-layered-architecture/README.md) |
| Dzień 2 | [02-mvp](src/day-2-architecture/02-mvp/README.md) |
| Dzień 2 | [03-dependency-injection](src/day-2-architecture/03-dependency-injection/README.md) |
| Dzień 2 | [04-factory-method](src/day-2-architecture/04-factory-method/README.md) |
| Dzień 2 | [05-adapter](src/day-2-architecture/05-adapter/README.md) |
| Dzień 2 | [06-facade](src/day-2-architecture/06-facade/README.md) |
| Dzień 2 | [07-decorator](src/day-2-architecture/07-decorator/README.md) |
| Dzień 2 | [08-tdd-lab-report](src/day-2-architecture/08-tdd-lab-report/README.md) |
| Dzień 3 | [01-strategy](src/day-3-behavioral-patterns/01-strategy/README.md) |
| Dzień 3 | [02-command](src/day-3-behavioral-patterns/02-command/README.md) |
| Dzień 3 | [03-state](src/day-3-behavioral-patterns/03-state/README.md) |
| Dzień 3 | [04-observer](src/day-3-behavioral-patterns/04-observer/README.md) |
| Dzień 3 | [05-mediator](src/day-3-behavioral-patterns/05-mediator/README.md) |
| Dzień 3 | [06-workshop](src/day-3-behavioral-patterns/06-workshop/README.md) |
