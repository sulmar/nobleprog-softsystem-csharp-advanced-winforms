# Zadanie: przyjęcie próbek w punkcie odbioru

Czas: około 40–50 minut.

## Sytuacja

Kurierzy przywożą do laboratorium probówki ze zleceniami z przychodni. Pracownik punktu odbioru wpisuje numer zlecenia, zaznacza, które probówki faktycznie dotarły, w razie braków podaje powód i podejmuje decyzję. Dotychczasowy ekran był przebudowywany tyle razy, że przy każdej zmianie psuło się coś w innej jego części: raz można było przyjąć niekompletne zlecenie bez powodu, innym razem podsumowanie pokazywało dane poprzedniego zlecenia.

Powstaje nowy ekran. Składa się z pięciu części, a każdą z nich może przygotować inna osoba:

| Część ekranu | Co robi użytkownik | Co widzi |
|---|---|---|
| Zlecenie | Wpisuje numer zlecenia | Numer i dane pacjenta |
| Probówki | Zaznacza, które probówki dotarły | Listę wymaganych probówek |
| Powód braków | Wybiera powód z listy | Listę powodów, dostępną lub nie |
| Decyzja | Wybiera „Przyjmij”, „Przyjmij częściowo” albo „Odrzuć” | Dostępne decyzje i komunikat |
| Podsumowanie | Nic | Na przykład „Dotarło 2 z 3” |

Okno jeszcze nie istnieje, a jego układ nie jest przesądzony. Zespół chce mieć pewność, że ekran zachowuje się poprawnie, zanim powstanie pierwszy formularz.

## Wymagania

1. **Zachowanie bez okna.** Każdy scenariusz z tabeli da się sprawdzić testem, bez otwierania okna, bez wydruku i bez bazy.
2. **Części ekranu są niezależne.** Część ekranu nie wie o istnieniu pozostałych. Można ją przepisać albo wymienić bez zmian w innych częściach.
3. **Jedno miejsce na współdziałanie.** Gdy kierownik zmieni zasadę w stylu „po wpisaniu nowego numeru wyczyść powód”, programista wie, gdzie jej szukać, i zmienia jedno miejsce.
4. **Zasady przyjmowania bez ekranu.** Zasady typu „co pozwala przyjąć częściowo” działają i są sprawdzalne bez jakiejkolwiek części ekranu.
5. **Nowa część ekranu.** Dodanie w przyszłości kolejnej części, np. podglądu historii zlecenia, nie wymaga zmian w istniejących częściach.

## Zasady przyjmowania

- „Przyjmij”: dotarły wszystkie probówki.
- „Przyjmij częściowo”: dotarła co najmniej jedna, ale nie wszystkie, i wybrano powód.
- „Odrzuć”: nie dotarła żadna i wybrano powód.
- Powód można wybrać tylko wtedy, gdy czegoś brakuje.
- Po przyjęciu drukuje się po jednej etykiecie na każdą probówkę, która dotarła. Odrzucenie niczego nie drukuje.
- Decyzja jest zapisywana razem z listą probówek, które dotarły, i z powodem.
- Zlecenia z zapisaną decyzją nie można przyjąć ponownie.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami. Zlecenie `ZL-1` wymaga trzech probówek: `A`, `B` i `C`.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Wpisano nieznany numer | Komunikat o nieznanym zleceniu, pozostałe części puste, brak dostępnych decyzji |
| 2 | Wpisano numer zlecenia z zapisaną decyzją | Komunikat, że zlecenie już obsłużono, pozostałe części puste, brak dostępnych decyzji |
| 3 | Wpisano `ZL-1` | Dane pacjenta, trzy probówki, „Dotarło 0 z 3”, powód dostępny, brak dostępnych decyzji |
| 4 | Zaznaczono wszystkie probówki | „Dotarło 3 z 3”, powód niedostępny, dostępne tylko „Przyjmij” |
| 5 | Zaznaczono 2 z 3, bez powodu | Powód dostępny, brak dostępnych decyzji |
| 6 | Zaznaczono 2 z 3 i wybrano powód | Dostępne tylko „Przyjmij częściowo” |
| 7 | Wybrano powód, a potem zaznaczono wszystkie probówki | Powód wyczyszczony i niedostępny, dostępne tylko „Przyjmij” |
| 8 | Nic nie zaznaczono i wybrano powód | Dostępne tylko „Odrzuć” |
| 9 | Przyjęto częściowo 2 z 3 | Zapisana decyzja, dwie etykiety, ekran pusty i gotowy na następne zlecenie, komunikat o przyjęciu |
| 10 | Odrzucono zlecenie | Zapisana decyzja z powodem, żadnej etykiety, ekran pusty, komunikat |
| 11 | Po przyjęciu ponownie wpisano ten sam numer | Tak jak w scenariuszu 2 |
| 12 | Wpisano inny numer, gdy nic nie zaznaczono i nie wybrano powodu | Nowe zlecenie, bez żadnego pytania |
| 13 | Wpisano inny numer po zaznaczeniu probówek, pracownik potwierdza porzucenie | Nowe zlecenie, poprzednie zaznaczenia przepadają, niczego nie zapisano |
| 14 | Wpisano inny numer po zaznaczeniu probówek, pracownik rezygnuje | Wraca poprzedni numer, zaznaczenia i powód zostają bez zmian |
| 15 | Część ekranu zgłasza wybór decyzji, która nie jest dostępna | Nic się nie zapisuje i nic się nie drukuje |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Podział na klasy i nazwy należą do Ciebie.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

Na macOS i Linuksie użyj `-f net8.0`.

## Do dyskusji

Gdzie w Twoim rozwiązaniu leży zasada „przyjąć częściowo można tylko z powodem”, a gdzie „po przyjęciu wyczyść ekran”? Czy obie zmienią się z tego samego powodu? Co by się stało z Twoim kodem, gdyby ekranów przyjęcia było pięć, a zasady przyjmowania wszędzie te same?
