# Dzień 3, Moduł 6: Warsztat projektowy

Warsztat zamyka szkolenie. Dostajesz działającą aplikację laboratorium i masz doprowadzić ją do stanu, w którym kolejne zmiany z działu biznesowego będą tanie i bezpieczne. Sam oceniasz, co w kodzie przeszkadza, i sam decydujesz, co z tym zrobić. Czas: około 3 godzin, razem z omówieniem.

## Sytuacja

Okno „Wyniki badań” powstało kilka lat temu jako prosty ekran i obsługuje dziś cały obieg wyniku: import z analizatora, weryfikację, zatwierdzenie, odrzucenie, wysyłkę do systemu szpitalnego i wydruk raportu. Aplikacja działa i użytkownicy ją znają.

Problem w tym, że każda zmiana trwa długo i często coś psuje, a nikt nie odważy się jej zrobić bez kilku dni ręcznego sprawdzania. Podczas importu i wysyłki użytkownicy zgłaszają, że okno „wisi”. Kierownik laboratorium ma na najbliższe miesiące listę zmian, a dział jakości chce wreszcie mieć dowód, że reguły działają.

Kod jest w katalogu `Starter/`. Biblioteka `LabConnect.Sdk` to symulacja produktu dostawcy, więc traktuj ją jak kod, którego nie możesz zmienić.

## Jak działa aplikacja

Wynik przechodzi przez statusy: Nowy, Zweryfikowany, Zatwierdzony, Wysłany. Z Nowego i Zweryfikowanego można go też odrzucić, a odrzucony można przywrócić do poprawy. Laboratorium ma cztery rodzaje badań: biochemię, hematologię, koagulację i mikrobiologię. Rodzaje różnią się sposobem sprawdzania wartości, oceną wyniku, formatem i treścią raportu.

## Wymagania

1. **Zachowanie zostaje.** Dla użytkownika aplikacja działa tak samo: te same reguły, komunikaty, skróty i wydruki. Różnica jest jedna: okno nie zamiera w czasie importu i wysyłki.
2. **Reguły mają dowód.** Każdą regułę z tabeli poniżej da się sprawdzić automatycznie, bez otwierania okna, bez biblioteki dostawcy, plików i czekania na konkretną godzinę.
3. **Decyzje ekranu też mają dowód.** Automatycznie da się sprawdzić, co pokaże ekran: które operacje są dostępne, jaki komunikat zobaczy użytkownik i co się stanie po kliknięciu.
4. **Lista zmian jest tania.** Każdą zmianę z tabeli „Zmiany, które mają stać się łatwe” można zrobić w jednym, oczywistym miejscu. Nie musisz ich wdrażać. Musisz umieć pokazać, gdzie i dlaczego będą proste.

## Zachowanie, którego nie wolno zmienić

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Weryfikacja wyniku bez wartości | Odmowa: „Brak wartości wyniku.” |
| 2 | Glukoza 6,8 przy zakresie 3,9–5,5 | Flaga H, żółty wiersz |
| 3 | Glukoza powyżej dwukrotności górnej granicy | Flaga HH, czerwony wiersz |
| 4 | Leukocyty 15 przy zakresie 4–10 | Flaga H, a powyżej 15 już HH |
| 5 | INR powyżej 4,5 | Flaga HH |
| 6 | Posiew dodatni | Flaga POS, wynik nie jest krytyczny |
| 7 | Zatwierdzenie przez osobę bez tytułu „dr” | Odmowa |
| 8 | Zatwierdzenie przez osobę, która weryfikowała | Odmowa |
| 9 | Zatwierdzenie wyniku z flagą, bez komentarza | Odmowa |
| 10 | Zatwierdzenie wyniku krytycznego z komentarzem | Zatwierdzony, wpis w `powiadomienia.txt`, komunikat dla użytkownika |
| 11 | Odrzucenie bez komentarza | Odmowa |
| 12 | Przywrócenie odrzuconego wyniku | Status Nowy, komentarz zostaje, weryfikujący znika |
| 13 | Wysyłka wyniku bez identyfikatora pacjenta (P-2026-0107) | Status bez zmian, komunikat z kodem błędu, wpis w historii |
| 14 | Import z portem innym niż COM | Komunikat z kodem błędu, dane bez zmian |
| 15 | Ponowny import tych samych próbek | Nic nie przybywa, w podsumowaniu liczba pominiętych |
| 16 | Wartość można zmienić tylko w statusie Nowy | Komentarz można zmieniać do chwili zatwierdzenia |
| 17 | Skrót dla operacji niedostępnej w danym statusie | Nic się nie dzieje |
| 18 | Zmiana wyniku w dowolnym oknie | Pozostałe otwarte okna od razu pokazują aktualne dane |

## Zmiany, które mają stać się łatwe

| # | Zgłoszenie z laboratorium | Co ma być prawdą |
|---|---|---|
| A | Od przyszłego kwartału dochodzi immunologia, z własną oceną wyniku i raportem | Dodanie rodzaju badania nie zmienia kodu pozostałych rodzajów ani okna |
| B | Audyt wymaga nowego statusu „Wstrzymany” przed zatwierdzeniem | Nowy status to zmiana w jednym miejscu, a dostępność przycisków nadąża sama |
| C | Komentarz ma być wymagany przy każdym zatwierdzeniu | Reguła zmienia się raz, niezależnie od tego, czy użytkownik użył przycisku, menu czy skrótu |
| D | Nowa operacja „Wyślij ponownie” ma być na przycisku, w menu i pod klawiszem | Dodanie operacji nie wymaga kopiowania jej logiki ani warunków dostępności |
| E | Zmieniamy dostawcę analizatora, a potem bramkę do szpitala | Zmiana dotyka jednego miejsca, a nie obiegu wyników ani okien |
| F | Nowe okno „Tablica alarmów” ma pokazywać wyniki krytyczne na bieżąco | Nowe okno nie wymaga zmian w istniejących oknach |
| G | Automat nocny ma wysyłać zatwierdzone wyniki, bez okna | Te same reguły działają bez żadnego formularza |
| H | Import i wysyłka trwają coraz dłużej | Okno reaguje, a operacji nie da się uruchomić drugi raz w trakcie |

## Jak pracować

Pracuj w parach. Otwórz `Starter/Workshop.Starter.sln`. Projekt `Lims.Results.Tests` jest pusty i czeka na Twoje testy.

```
dotnet build Starter/Workshop.Starter.sln
dotnet test Starter/Lims.Results.Tests
```

1. **Analiza.** Uruchom aplikację i przejdź kilka scenariuszy z tabeli. Przeczytaj kod i spisz, co utrudnia każdą zmianę z listy A–H.
2. **Plan.** Zdecyduj, co zmienisz, a czego celowo nie ruszysz, i uzasadnij to konkretną zmianą z listy.
3. **Refaktoryzacja.** Rób małe kroki. Po każdym aplikacja ma się kompilować i działać, a testy mają być zielone.
4. **Omówienie.** Pokaż grupie jedną zmianę z listy A–H na swoim kodzie.

Nie zdążysz wszystkiego i nie o to chodzi. Lepiej mieć dobrze zrobioną część niż całość rozgrzebaną.

Aplikacja i testy działają tylko na Windows, bo korzystają z WinForms.

## Do dyskusji

Co zostało w formularzu i dlaczego? Która zmiana z listy okazała się najtańsza, a która nadal jest droga? Czego celowo nie zmieniłeś? Czy Twój kod jest teraz prostszy, czy tylko inaczej ułożony?
