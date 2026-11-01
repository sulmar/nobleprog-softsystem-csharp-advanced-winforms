# Zadanie: przyjęcie próbki od kuriera

Czas: około 40–50 minut.

## Sytuacja

Kurier przywozi do laboratorium próbki z przychodni. Przyjęcie próbki to procedura złożona z kilku czynności w różnych systemach: chłodnia, rejestr przyjęć, księga kontroli jakości, drukarka etykiet i wiadomość do przychodni.

Dziś procedurę wykonują recepcja i nocny dyżur, a wkrótce dołączy punkt samoobsługowy dla kurierów. Każde stanowisko robi to trochę inaczej. Nocny dyżur pomija księgę, przychodnia dostaje wiadomość o próbce, której potem nie przyjęto, a po awarii drukarki nikt nie wie, co zostało zrobione. Kontrola jakości wymaga, by procedura przebiegała zawsze tak samo.

Przygotuj rozwiązanie, które pozwoli każdemu stanowisku przyjąć próbkę jednym poleceniem i dowiedzieć się, jak się to skończyło. Okna nie są częścią zadania.

## Wymagania

1. **Pełna procedura.** Przyjęcie próbki kolejno: rezerwuje miejsce w chłodni, dopisuje próbkę do rejestru przyjęć, robi wpis w księdze, drukuje etykietę z numerem miejsca i wysyła wiadomość do przychodni.
2. **Jedna procedura dla wszystkich.** Stanowisko podaje tylko dane z dostawy: kod próbki, kuriera, przychodnię i zmierzoną temperaturę. Nie musi wiedzieć, jakie są kroki i w jakiej kolejności.
3. **Temperatura.** Próbka jest przyjmowana w temperaturze od 2 do 8°C, włącznie z granicami. Inną próbkę odrzucamy: nie zajmuje miejsca i nie trafia do rejestru, ale odrzucenie musi być zapisane w księdze, a przychodnia musi o nim wiedzieć.
4. **Próbka przyjęta albo nie.** Bez miejsca w chłodni, wpisu w rejestrze i wpisu w księdze próbka nie jest przyjęta i nie może po niej zostać ślad w chłodni ani w rejestrze.
5. **Awaria drukarki lub wysyłki nie cofa przyjęcia.** Próbka leży już w chłodni. Stanowisko musi się jednak dowiedzieć, co trzeba dokończyć ręcznie.
6. **Uczciwa odpowiedź.** Stanowisko zawsze wie, jak zakończyła się operacja i co ewentualnie ma zrobić człowiek. Awaria systemu nie może skończyć się błędem programu na ekranie.
7. **Ponowny wydruk.** Etykietę przyjętej próbki można wydrukować jeszcze raz, bez powtarzania pozostałych czynności.
8. **Sprawdzone testami.** Scenariusze da się sprawdzić bez prawdziwej chłodni, drukarki, wysyłki i bez czekania na konkretną godzinę.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Próbka w 5°C, wszystko działa | Przyjęta. Czynności wykonane w kolejności z wymagania 1, a etykieta zawiera numer miejsca |
| 2 | Próbka w 2°C i w 8°C | Przyjęta |
| 3 | Próbka w 1,9°C i w 8,1°C | Odrzucona. Jest wpis w księdze i wiadomość do przychodni, nie ma miejsca, rejestru ani etykiety |
| 4 | Odrzucona próbka, a księga nie działa | Nadal odrzucona. Wiadomość idzie do przychodni, a stanowisko wie, że wpis trzeba zrobić ręcznie |
| 5 | Próbka już przyjęta wcześniej | Odmowa, żadna czynność nie jest wykonana |
| 6 | Brak nazwiska kuriera | Odmowa, żadna czynność nie jest wykonana |
| 7 | Brak wolnego miejsca w chłodni | Nieprzyjęta, stanowisko zna powód, a przychodnia nie dostaje wiadomości |
| 8 | Rejestr przyjęć nie działa | Nieprzyjęta, a miejsce w chłodni jest z powrotem wolne |
| 9 | Księga nie działa | Nieprzyjęta, próbki nie ma w rejestrze, a miejsce jest wolne |
| 10 | Księga nie działa i nie da się zwolnić miejsca | Nieprzyjęta, a stanowisko wie, które miejsce trzeba zwolnić ręcznie |
| 11 | Drukarka nie działa | Przyjęta, przychodnia dostaje wiadomość, a stanowisko wie, że etykietę trzeba wydrukować |
| 12 | Wysyłka wiadomości nie działa | Przyjęta, a stanowisko wie, że trzeba zadzwonić do przychodni |
| 13 | Po naprawie drukarki ponowny wydruk etykiety | Tylko wydruk, z tym samym numerem miejsca |
| 14 | Ponowny wydruk etykiety próbki, której nie przyjęto | Odmowa, nic się nie drukuje |
| 15 | Kurier przywozi trzy próbki, a druga jest już przyjęta | Pierwsza i trzecia przyjęte, druga z odmową. Każda ma własny wynik |
| 16 | Po awarii księgi kurier ponawia tę samą próbkę | Przyjęta normalnie, jedno miejsce i jeden wpis w rejestrze |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Podział na klasy i nazwy należą do Ciebie. Prawdziwe systemy nie istnieją, więc w testach zastąp je własnymi prostymi wersjami.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Dlaczego wiadomość do przychodni jest na końcu procedury? Co zrobić, gdyby księgę dało się wypełnić dopiero po wydruku etykiety? Co dopisałbyś do swojego rozwiązania, a czego wolałbyś nie dopisywać, gdyby kierownik poprosił o raport przyjęć z całego dnia?
