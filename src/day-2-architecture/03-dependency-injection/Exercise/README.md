# Zadanie: tryb pokazowy i oddziały

Czas: około 40–50 minut.

## Sytuacja

Dział wdrożeń pokazuje system przychodniom na żywo. Podczas ostatniego pokazu przykładowy wynik krytyczny poszedł SMS-em do prawdziwego lekarza dyżurnego. Kierownik wymaga, aby na pokazach żadna wiadomość nie wychodziła na zewnątrz.

W tym samym czasie oddział w Gdyni prosi o powiadomienia e-mailem, bo lekarze nie mają tam służbowych telefonów, a centrala zostaje przy SMS-ach. Podobne prośby będą wracać, a dział jakości nie zgadza się na zmiany w kodzie zatwierdzania przy każdej z nich.

Przygotuj rdzeń zatwierdzania wyników, który spełnia poniższe wymagania. Okna nie są potrzebne. Bazy i bramek też nie: wystarczy, że program zapamięta, co by zapisał i wysłał.

## Wymagania

1. **Dwa tryby pracy.** Aplikacja startuje w trybie pokazowym albo produkcyjnym, a o wyborze decyduje jedno ustawienie.
2. **Pokaz jest bezpieczny.** W trybie pokazowym żadna wiadomość nie wychodzi na zewnątrz. Trafia do skrzynki pokazowej, którą widać na ekranie.
3. **Kanał zależy od oddziału.** W trybie produkcyjnym lekarz dostaje SMS albo e-mail, zależnie od ustawień oddziału.
4. **Reguły są nietknięte.** Dodanie kolejnego kanału, np. komunikatora, nie wymaga zmian w kodzie zatwierdzania.
5. **Błędne ustawienia wychodzą od razu.** Aplikacja z niepełnymi ustawieniami nie uruchamia się i mówi, czego brakuje. Nie czeka z tym do pierwszego wyniku krytycznego w nocy.
6. **Sesje pracy.** Każdy laborant otwiera własną sesję pracy. Ma w niej własne połączenie z bazą i listę wyników zatwierdzonych w tej sesji. Dziennik zatwierdzeń jest jeden dla całej aplikacji.
7. **Nic nie zostaje otwarte.** Zamknięcie sesji zamyka jej połączenie, a zamknięcie aplikacji zamyka wszystkie, także te w sesjach, których ktoś zapomniał zamknąć.

Wynik krytyczny to wartość większa niż dwukrotność górnej granicy zakresu.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami. Górna granica zakresu to 100.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Tryb pokazowy, wynik 250 | Wiadomość w skrzynce pokazowej, brak SMS-a i e-maila |
| 2 | Tryb produkcyjny, oddział z SMS-ami, wynik 250 | SMS na numer lekarza dyżurnego, skrzynka pokazowa pusta |
| 3 | Tryb produkcyjny, oddział z e-mailami, wynik 250 | E-mail na adres lekarza dyżurnego, brak SMS-a |
| 4 | Wynik 90, dowolny tryb i oddział | Żadnej wiadomości, a zatwierdzenie jest w dzienniku |
| 5 | Oddział z SMS-ami bez numeru lekarza albo oddział z e-mailami bez adresu | Aplikacja nie startuje, a komunikat mówi, czego brakuje. W trybie pokazowym te dane nie są wymagane |
| 6 | Nieznany tryb albo nieznany kanał | Aplikacja nie startuje |
| 7 | Dwie sesje otwarte naraz, każda zatwierdza inny wynik | Każda sesja widzi na liście tylko swój wynik, a dziennik ma oba |
| 8 | Zamknięcie jednej z dwóch sesji | Jej połączenie jest zamknięte, a połączenie drugiej nadal otwarte |
| 9 | Nowa sesja po zamknięciu poprzedniej | Działa normalnie |
| 10 | Próba zatwierdzenia w zamkniętej sesji | Odmowa, a dziennik się nie zmienia |
| 11 | Zamknięcie aplikacji, gdy sesja nie została zamknięta | Połączenie tej sesji jest zamknięte |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Podział na klasy i nazwy należą do Ciebie. Możesz dodać pakiet użyty w demach tego modułu.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Ile miejsc w kodzie zmienia się po dodaniu trzeciego kanału? Co u Ciebie istnieje przez cały czas działania aplikacji, a co tylko przez czas sesji, i skąd to wiadomo, patrząc na kod? Co się stanie, gdy dziennik zacznie korzystać z połączenia pierwszej otwartej sesji?
