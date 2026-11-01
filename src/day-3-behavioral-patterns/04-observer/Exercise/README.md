# Zadanie: alarmy z urządzeń laboratorium

Czas: około 40–50 minut.

## Sytuacja

Lodówki z odczynnikami, cieplarki i analizatory zgłaszają alarmy: temperatura poza zakresem, kończący się odczynnik, awaria zasilania. Dziś alarm widać tylko na jednym ekranie, a dyżurny bywa wtedy w innym pomieszczeniu. Alarmy mają docierać do kilku niezależnych odbiorców: ekranu dyżurnego, powiadomień SMS dla kierownika, dziennika audytu i kolejnych, które pojawią się w przyszłości.

Napisz logikę centrum alarmów. Interfejs użytkownika, prawdziwe SMS-y i urządzenia nie są częścią zadania. Ekran i inne elementy zastąp w testach prostymi odpowiednikami.

## Wymagania

1. **Niezależni odbiorcy.** Dodanie nowego odbiorcy nie wymaga zmiany kodu centrum alarmów, a urządzenie zgłaszające alarm nic o odbiorcach nie wie.
2. **Ważność alarmu.** Alarm jest informacyjny, ostrzegawczy lub krytyczny. Każdy odbiorca sam wskazuje najniższą ważność, która go interesuje, np. SMS tylko krytyczne, a dziennik wszystkie.
3. **Rezygnacja.** Odbiorca może w każdej chwili zrezygnować z alarmów, także podczas obsługi alarmu. Ponowna rezygnacja nie jest błędem, a pozostali odbiorcy niczego nie tracą. Centrum nie przechowuje po rezygnacji żadnych informacji o odbiorcy i potrafi podać, ilu odbiorców ma teraz.
4. **Awaria odbiorcy.** Awaria jednego odbiorcy, np. brak zasięgu SMS, nie może wpłynąć na pozostałych ani na urządzenie zgłaszające alarm. Awaria trafia do rejestru: który odbiorca, przy jakim alarmie i z jakiego powodu. Odbiorca po awarii nadal dostaje kolejne alarmy.
5. **Równoczesne zgłoszenia.** Urządzenia działają niezależnie i mogą zgłaszać alarmy dokładnie w tej samej chwili, także wtedy, gdy ktoś właśnie dołącza lub rezygnuje. Żaden alarm ani odbiorca nie może zginąć.
6. **Ekran dyżurnego.** Ekran może zmieniać swoją zawartość tylko w ramach własnej pracy, więc alarm czeka, aż ekran będzie mógł go wyświetlić, a urządzenie na to nie czeka. Alarmy pojawiają się w kolejności zgłoszenia. Po zamknięciu ekranu alarmy, które jeszcze czekały, przepadają i nie są błędem. Awaria podczas wyświetlania trafia do tego samego rejestru.

## Scenariusze

Rozwiązanie jest gotowe, gdy poniższe scenariusze są potwierdzone testami.

Zacznij od klasy centrum alarmów i opisu alarmu. Pozostałe nazwy i sposób rozwiązania należą do Ciebie.

```csharp
public enum AlarmSeverity
{
    Info,
    Warning,
    Critical
}

public class Alarm
{
    public string Device { get; set; }
    public AlarmSeverity Severity { get; set; }
    public string Message { get; set; }
}

public class AlarmCenter
{
    public void Report(Alarm alarm)
    {
        throw new NotImplementedException();
    }
}
```

| # | Sytuacja | Oczekiwany efekt |
|---|---|---|
| 1 | Alarm krytyczny, trzech odbiorców | Każdy dostaje alarm dokładnie raz |
| 2 | Alarm, a nikt nie czeka na alarmy | Nic złego się nie dzieje |
| 3 | Alarm ostrzegawczy, SMS tylko dla krytycznych, dziennik dla wszystkich | Dostaje tylko dziennik |
| 4 | Odbiorca rezygnuje, potem pojawia się alarm | Nie dostaje alarmu, a pozostali dostają |
| 5 | Odbiorca rezygnuje dwa razy | Brak błędu, a liczba odbiorców spada tylko o jeden |
| 6 | Odbiorca rezygnuje podczas obsługi alarmu | Kolejni odbiorcy dostają ten alarm, a on nie dostaje następnego |
| 7 | Pierwszy odbiorca ulega awarii | Drugi dostaje alarm, urządzenie nie widzi błędu, a rejestr zawiera nazwę odbiorcy, alarm i powód |
| 8 | Odbiorca ulega awarii, potem pojawia się kolejny alarm | Odbiorca dostaje też kolejny alarm |
| 9 | Osiem urządzeń zgłasza po 1000 alarmów naraz, a w tym czasie odbiorcy dołączają i rezygnują | Stały odbiorca dostaje 8000 alarmów, a liczba odbiorców na końcu się zgadza |
| 10 | Dyżurny zamyka ekran, gdy alarm czeka na wyświetlenie | Alarm nie zostaje wyświetlony, brak wpisu w rejestrze |
| 11 | Trzy alarmy dla ekranu zgłoszone z innej pracy niż praca ekranu | Urządzenie nie czeka, a ekran wyświetla je we własnej pracy, w kolejności zgłoszenia |
| 12 | Ekran ulega awarii przy wyświetlaniu pierwszego z dwóch alarmów | Awaria jest w rejestrze, a drugi alarm zostaje wyświetlony |

## Jak pracować

Otwórz `ExerciseStarter.sln`. Kod napisz w projekcie `Starter/Lims.Exercise`, a testy w `Starter/Lims.Exercise.Tests`.

```
dotnet test Starter/Lims.Exercise.Tests -f net48
```

## Do dyskusji

Kto powinien decydować o tym, na jakie alarmy czeka odbiorca: centrum czy sam odbiorca? Co powinno się stać z alarmem, gdy przez godzinę nie ma żadnego odbiorcy? Czy Twoje rozwiązanie sprawdziłoby się, gdyby alarmy miały trafiać także do innego programu?
