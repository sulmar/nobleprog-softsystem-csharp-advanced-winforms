# Zadanie: obieg reklamacji wyniku

Czas: około 40–50 minut.

## Sytuacja

Pacjenci i przychodnie zgłaszają reklamacje wyników badań. Dziś obieg reklamacji działa na papierze i w poczcie: zdarza się, że reklamacja zamknięta wraca do pracy, a analityk sam decyduje o sprawie, którą sam wyjaśniał. Audytor zapytał, kto i kiedy podjął decyzję w jednej ze spraw, i nikt nie umiał odpowiedzieć.

Dział jakości chce mieć ten obieg w programie. Okno powstanie później, a na razie potrzebna jest logika, którą okno będzie mogło zapytać, jakie przyciski pokazać danej osobie.

## Wymagania

1. **Obieg.** Reklamacja przechodzi kolejno przez etapy: Zgłoszona, W wyjaśnianiu, Do decyzji, a następnie Uznana lub Odrzucona, a na końcu Zamknięta. Żadnego etapu nie da się pominąć ani cofnąć inaczej, niż opisują to reguły.
2. **Kto i kiedy.** Każda osoba może zrobić tylko to, co pozwalają jej rola i etap reklamacji. Odmowa niczego nie zmienia i mówi, dlaczego działanie jest niemożliwe.
3. **Dostępne działania.** Dla danej osoby i reklamacji program podaje listę działań, które ta osoba może teraz wykonać. Lista zawsze zgadza się z tym, co naprawdę uda się zrobić.
4. **Historia.** Każda zmiana etapu zostaje zapisana: skąd, dokąd, kto, kiedy i z jakim uzasadnieniem. Odmowy nie trafiają do historii.
5. **Nowe etapy.** Dział jakości zapowiada kolejny etap, „Korekta wyniku”. Dodanie go nie powinno wymagać przeglądania całego programu w poszukiwaniu miejsc do zmiany.

## Reguły obiegu

Role to rejestratorka, analityk i kierownik. Osoba prowadząca to ta, która przyjęła reklamację do wyjaśnienia.

| Etap | Działanie | Kto może | Warunek | Następny etap |
|---|---|---|---|---|
| Zgłoszona | Przyjęcie do wyjaśnienia | Analityk lub kierownik | Ta osoba zostaje prowadzącą | W wyjaśnianiu |
| W wyjaśnianiu | Dopisanie ustalenia | Prowadzący | Niepusta treść | Bez zmiany |
| W wyjaśnianiu | Przekazanie do decyzji | Prowadzący | Co najmniej jedno ustalenie | Do decyzji |
| Do decyzji | Uznanie | Kierownik, który nie prowadził sprawy | | Uznana |
| Do decyzji | Odrzucenie | Kierownik, który nie prowadził sprawy | Niepuste uzasadnienie | Odrzucona |
| Do decyzji | Zwrot do wyjaśnienia | Kierownik, który nie prowadził sprawy | Niepuste uzasadnienie | W wyjaśnianiu |
| Uznana | Zamknięcie | Rejestratorka | | Zamknięta |
| Odrzucona | Odwołanie pacjenta | Rejestratorka | Do 14 dni od odrzucenia włącznie, tylko raz w sprawie | W wyjaśnianiu |
| Odrzucona | Zamknięcie | Rejestratorka | Po upływie 14 dni od odrzucenia albo od razu, gdy odwołanie już wykorzystano | Zamknięta |

Z etapu Zamknięta nie ma już żadnych działań.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami.

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Analityk przyjmuje zgłoszoną reklamację | Etap W wyjaśnianiu, analityk jest prowadzącym |
| 2 | Rejestratorka próbuje przyjąć zgłoszoną reklamację | Odmowa, reklamacja nadal Zgłoszona |
| 3 | Inny analityk dopisuje ustalenie | Odmowa, bo nie jest prowadzącym |
| 4 | Prowadzący przekazuje do decyzji bez ustaleń | Odmowa |
| 5 | Kierownik uznaje sprawę prowadzoną przez analityka | Etap Uznana |
| 6 | Kierownik, który sam prowadził sprawę, próbuje ją uznać | Odmowa, potrzebny jest inny kierownik |
| 7 | Kierownik odrzuca bez uzasadnienia | Odmowa, reklamacja nadal Do decyzji |
| 8 | Kierownik zwraca do wyjaśnienia z uzasadnieniem | Etap W wyjaśnianiu, ten sam prowadzący |
| 9 | Rejestratorka zamyka uznaną reklamację | Etap Zamknięta |
| 10 | Odwołanie równo 14 dni po odrzuceniu | Etap W wyjaśnianiu |
| 11 | Odwołanie 14 dni i minutę po odrzuceniu | Odmowa |
| 12 | Zamknięcie odrzuconej 3 dni po odrzuceniu | Odmowa, bo pacjent może się jeszcze odwołać |
| 13 | Zamknięcie odrzuconej 15 dni po odrzuceniu | Etap Zamknięta |
| 14 | Drugie odrzucenie po odwołaniu | Drugie odwołanie jest niemożliwe, a zamknąć można od razu |
| 15 | Dowolne działanie na zamkniętej reklamacji | Odmowa, a lista działań jest pusta |
| 16 | Lista działań dla kierownika, gdy reklamacja jest Do decyzji | Uznanie, odrzucenie, zwrot do wyjaśnienia |
| 17 | Lista działań dla rejestratorki w tym samym momencie | Pusta |
| 18 | Pełna ścieżka do zamknięcia, z próbą niedozwolonego działania po drodze | W historii jest każda zmiana etapu, z osobą i czasem, a odmowy nie ma |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`. Podział na klasy i nazwy należą do Ciebie. Okna nie budujemy.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Co trzeba zmienić, gdy między Do decyzji a Uznana pojawi się etap „Korekta wyniku”? Ile miejsc w Twoim kodzie to dotyka? Które reguły zależą tylko od etapu, a które także od osoby albo od daty?
