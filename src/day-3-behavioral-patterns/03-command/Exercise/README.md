# Zadanie: praca nad sprawozdaniem z badań

Czas: około 40–50 minut.

## Sytuacja

Diagnosta przygotowuje sprawozdanie z badań dla zleceniodawcy: dopisuje uwagi, podpisuje je i wysyła. Te same działania są dostępne na pasku narzędzi, w menu pod prawym przyciskiem myszy i pod klawiszami. W obecnej aplikacji każde z tych miejsc ma własne warunki i zachowuje się trochę inaczej, więc ktoś podpisał sprawozdanie bez uprawnień, a inne zostało wysłane do zleceniodawcy dwa razy.

Dział jakości chce też widzieć, kto i co zrobił ze sprawozdaniem, a diagnosta chce móc wycofać się z pomyłki.

Napisz logikę pracy nad jednym sprawozdaniem. Okno nie jest częścią zadania, ale kod ma być gotowy do podłączenia do wielu miejsc naraz.

## Wymagania

1. **Jedno zachowanie.** Działanie wywołane z dowolnego miejsca zachowuje się tak samo. Dodanie kolejnego miejsca, np. przycisku w innym oknie, nie wymaga kopiowania żadnych warunków.
2. **Spójna dostępność.** Każde miejsce może zapytać, czy działanie jest teraz dostępne, i dowiaduje się, gdy to się zmieni. Niedostępne działanie, wywołane mimo to, niczego nie zmienia.
3. **Długa wysyłka.** Wysyłka trwa, a okno nie może w tym czasie stanąć. Podczas wysyłki sprawozdania nie można zmieniać ani wysłać drugi raz. Nieudana wysyłka nie może zakończyć aplikacji: użytkownik dostaje informację o błędzie i może spróbować ponownie.
4. **Historia.** Każde działanie zostawia wpis: co zrobiono, kto i kiedy. Historii nie da się skrócić.
5. **Wycofanie.** Diagnosta może wycofać ostatnie działanie, a potem kolejne. Wysłania nie można wycofać, bo sprawozdanie jest już u zleceniodawcy.
6. **Sprawdzone testami.** Wszystko da się sprawdzić bez okna, bez prawdziwej wysyłki i bez czekania na upływ czasu.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami. Sprawozdanie zaczyna jako szkic. Podpisywać może tylko osoba z uprawnieniem do podpisu.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Szkic, wpisana uwaga | Dodanie uwagi jest dostępne, uwaga trafia do sprawozdania, pole na uwagę zostaje wyczyszczone |
| 2 | Szkic, pusta uwaga lub same spacje | Dodanie uwagi jest niedostępne |
| 3 | Pole uwagi przestaje być puste | Miejsca korzystające z dodawania uwagi dowiadują się o zmianie |
| 4 | Szkic, użytkownik z uprawnieniem | Podpis jest dostępny, sprawozdanie jest podpisane, z nazwiskiem i godziną |
| 5 | Szkic, użytkownik bez uprawnienia | Podpis jest niedostępny, próba niczego nie zmienia |
| 6 | Zmiana użytkownika na takiego z uprawnieniem | Podpis staje się dostępny, a miejsca dowiadują się o tym |
| 7 | Sprawozdanie podpisane | Dodanie uwagi i ponowny podpis są niedostępne, a wysyłka dostępna |
| 8 | Szkic | Wysyłka jest niedostępna |
| 9 | Wysyłka w toku | Druga próba nie wysyła nic więcej. Wycofanie jest niedostępne |
| 10 | Wysyłka zakończona powodzeniem | Sprawozdanie jest wysłane, a wszystkie działania, także wycofanie, są niedostępne |
| 11 | Wysyłka zakończona błędem | Użytkownik dostaje powód, sprawozdanie jest znów podpisane, wysyłkę i wycofanie znów można wykonać |
| 12 | Uwaga, a potem podpis, a potem dwa wycofania | Szkic bez podpisu i bez uwagi |
| 13 | Nic jeszcze nie zrobiono | Wycofanie jest niedostępne |
| 14 | Uwaga, podpis, nieudana i udana wysyłka | W historii są cztery wpisy we właściwej kolejności, każdy z nazwiskiem i godziną |
| 15 | Wycofanie uwagi | Historia ma dwa wpisy: dodanie i wycofanie |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Podział na klasy i nazwy należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Co trzeba by dopisać, aby dodać przycisk „Podpisz” w drugim oknie, a co, aby dodać nowe działanie „Zwróć do poprawy”? Co zrobić z wycofaniem, gdy sprawozdanie otwierają dwie osoby naraz?
