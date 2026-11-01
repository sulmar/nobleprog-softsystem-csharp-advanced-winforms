# Diagramy wzorców projektowych

Każdy diagram pokazuje role we wzorcu, a nie konkretne klasy z przykładów. Na GitHubie diagramy wyświetlają się automatycznie.

| Wzorzec | Dzień | Kiedy pomaga |
|---|---|---|
| [Model-View-Presenter](#model-view-presenter) | 2 | Logikę ekranu trzeba testować bez okna |
| [Factory Method](#factory-method) | 2 | Przebieg jest wspólny, a różni się tworzony obiekt |
| [Adapter](#adapter) | 2 | Obcy kod ma inny interfejs, niż potrzebuje aplikacja |
| [Facade](#facade) | 2 | Jedna operacja wymaga wielu kroków w kilku podsystemach |
| [Decorator](#decorator) | 2 | Do obiektu trzeba dołożyć działanie bez zmiany jego kodu |
| [Strategy](#strategy) | 3 | Sposób działania wybiera się spośród kilku wariantów |
| [Command](#command) | 3 | Operację wywołuje się z wielu miejsc lub trzeba nią zarządzać |
| [State](#state) | 3 | Zachowanie obiektu zależy od jego stanu |
| [Observer](#observer) | 3 | Nadawca ogłasza zmianę, nie znając odbiorców |
| [Mediator](#mediator) | 3 | Wiele komponentów musi współdziałać bez wzajemnych zależności |

## Model-View-Presenter

Widok pokazuje dane i zgłasza działania użytkownika, a Presenter decyduje, co z tego wynika. Dzięki interfejsowi Presenter można testować bez formularza.

```mermaid
classDiagram
    class IView {
        <<interface>>
        +Data
        +ActionRequested event
    }
    class Form
    class Presenter {
        +Presenter(view, model)
        -OnActionRequested()
    }
    class Model {
        +Operation()
    }
    IView <|.. Form
    Presenter --> IView : ustawia dane, słucha zdarzeń
    Presenter --> Model : wywołuje
```

## Factory Method

Twórca zna przebieg pracy, a decyzję, który produkt powstanie, zostawia klasom pochodnym.

```mermaid
classDiagram
    class Creator {
        <<abstract>>
        +Run()
        #CreateProduct()* IProduct
    }
    class ConcreteCreator {
        #CreateProduct() IProduct
    }
    class IProduct {
        <<interface>>
        +Use()
    }
    class ConcreteProduct {
        +Use()
    }
    Creator <|-- ConcreteCreator
    IProduct <|.. ConcreteProduct
    Creator ..> IProduct : używa
    ConcreteCreator ..> ConcreteProduct : tworzy
```

## Adapter

Aplikacja definiuje potrzebny interfejs, a adapter tłumaczy go na wywołania obcego kodu.

```mermaid
classDiagram
    class Client
    class ITarget {
        <<interface>>
        +Request()
    }
    class Adapter {
        +Request()
    }
    class Adaptee {
        +SpecificRequest()
    }
    Client --> ITarget : używa
    ITarget <|.. Adapter
    Adapter --> Adaptee : tłumaczy wywołanie
```

## Facade

Fasada daje jedną prostą operację i zna kolejność kroków. Podsystemy o niej nie wiedzą i nadal można ich używać bezpośrednio.

```mermaid
classDiagram
    class Client
    class Facade {
        +Operation()
    }
    class SubsystemA {
        +StepA()
    }
    class SubsystemB {
        +StepB()
    }
    class SubsystemC {
        +StepC()
    }
    Client --> Facade : używa
    Facade --> SubsystemA : 1
    Facade --> SubsystemB : 2
    Facade --> SubsystemC : 3
```

## Decorator

Dekorator ma ten sam interfejs co obiekt, który owija. Przekazuje mu wywołanie i dokłada jedno działanie, a dekoratory można układać w łańcuch.

```mermaid
classDiagram
    class Client
    class IComponent {
        <<interface>>
        +Operation()
    }
    class ConcreteComponent {
        +Operation()
    }
    class DecoratorA {
        +Operation()
    }
    class DecoratorB {
        +Operation()
    }
    Client --> IComponent : używa
    IComponent <|.. ConcreteComponent
    IComponent <|.. DecoratorA
    IComponent <|.. DecoratorB
    DecoratorA o-- IComponent : owija
    DecoratorB o-- IComponent : owija
```

## Strategy

Kontekst zna tylko interfejs strategii i nie sprawdza, z którym wariantem pracuje. Wariant wybiera ktoś z zewnątrz.

```mermaid
classDiagram
    class Client
    class Context {
        +Context(strategy)
        +Run()
    }
    class IStrategy {
        <<interface>>
        +Execute()
    }
    class StrategyA {
        +Execute()
    }
    class StrategyB {
        +Execute()
    }
    Client ..> StrategyA : wybiera
    Client --> Context : używa
    Context --> IStrategy : deleguje
    IStrategy <|.. StrategyA
    IStrategy <|.. StrategyB
```

## Command

Polecenie to operacja zapisana jako obiekt. Przycisk, menu i skrót korzystają z tego samego polecenia i nie znają szczegółów operacji.

```mermaid
classDiagram
    class Invoker {
        +Click()
    }
    class ICommand {
        <<interface>>
        +CanExecute() bool
        +Execute()
        +CanExecuteChanged event
    }
    class ConcreteCommand {
        +CanExecute() bool
        +Execute()
    }
    class Receiver {
        +Action()
    }
    Invoker --> ICommand : wywołuje
    ICommand <|.. ConcreteCommand
    ConcreteCommand --> Receiver : wykonuje
```

## State

Kontekst przekazuje operacje do bieżącego stanu, a stan decyduje, czy operacja jest dozwolona i jaki stan będzie następny.

```mermaid
classDiagram
    class Context {
        -IState state
        +Request()
        ~MoveTo(state)
    }
    class IState {
        <<interface>>
        +Handle(context)
    }
    class StateA {
        +Handle(context)
    }
    class StateB {
        +Handle(context)
    }
    Context --> IState : deleguje
    IState <|.. StateA
    IState <|.. StateB
    StateA ..> Context : zmienia stan
    StateB ..> Context : zmienia stan
```

## Observer

Nadawca ogłasza, że coś się stało, a zainteresowani zapisują się sami. W C# rolę nadawcy i listy odbiorców zwykle pełni `event`.

```mermaid
classDiagram
    class Subject {
        +Changed event
        +DoWork()
    }
    class ObserverA {
        +OnChanged()
    }
    class ObserverB {
        +OnChanged()
    }
    Subject ..> ObserverA : powiadamia
    Subject ..> ObserverB : powiadamia
    ObserverA --> Subject : zapisuje się
    ObserverB --> Subject : zapisuje się
```

## Mediator

Komponenty nie mają do siebie referencji. Zgłaszają, co się stało, a mediator decyduje, kto i w jakiej kolejności ma zareagować.

```mermaid
classDiagram
    class Mediator {
        -OnEventFromA()
        -OnEventFromB()
    }
    class ComponentA {
        +EventA event
        +ShowData()
    }
    class ComponentB {
        +EventB event
        +ShowData()
    }
    class ComponentC {
        +ShowData()
    }
    ComponentA ..> Mediator : zgłasza
    ComponentB ..> Mediator : zgłasza
    Mediator --> ComponentA : polecenia
    Mediator --> ComponentB : polecenia
    Mediator --> ComponentC : polecenia
```
