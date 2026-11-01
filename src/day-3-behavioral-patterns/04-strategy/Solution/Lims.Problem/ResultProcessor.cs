using System;

namespace Lims.Problem
{
    /// <summary>Wartości norm są przykładowe i nie służą do diagnostyki.</summary>
    public static class ResultProcessor
    {
        // TODO: refaktoryzacja: każdą kombinację laboratorium i metody przenieść do osobnej klasy za wspólnym interfejsem.
        // PROBLEM: walidacja, przeliczenie i normy jednej procedury są rozproszone między gałęziami tej samej metody.
        // Każda nowa metoda lub laboratorium to kolejna gałąź w działającym kodzie (OCP), a jednej kombinacji
        // nie da się przeczytać ani sprawdzić bez pozostałych (SRP).
        public static ProcessedResult Process(string laboratory, string method, int age, string sex, decimal reading)
        {
            var result = new ProcessedResult();

            if (laboratory == "Centralne")
            {
                switch (method)
                {
                    case "Urykazowa":
                        if (reading < 0.5m || reading > 20m)
                        {
                            result.Errors.Add("Odczyt poza zakresem pomiarowym metody: 0,5–20 mg/dl");
                            return result;
                        }

                        result.Value = reading;
                        result.Unit = "mg/dl";
                        if (age < 18)
                        {
                            result.Low = 2.0m;
                            result.High = 5.5m;
                        }
                        else if (sex == "K")
                        {
                            result.Low = 2.4m;
                            result.High = 6.0m;
                        }
                        else
                        {
                            result.Low = 3.4m;
                            result.High = 7.0m;
                        }

                        break;

                    case "Kolorymetryczna":
                        if (age < 18)
                        {
                            result.Errors.Add("Metoda kolorymetryczna nie jest dopuszczona dla dzieci");
                            return result;
                        }

                        if (reading < 1m || reading > 15m)
                        {
                            result.Errors.Add("Odczyt poza zakresem pomiarowym metody: 1–15 mg/dl");
                            return result;
                        }

                        // Ta metoda zawyża wynik, więc odejmujemy stałą poprawkę.
                        result.Value = reading - 0.3m;
                        result.Unit = "mg/dl";
                        if (sex == "K")
                        {
                            result.Low = 2.4m;
                            result.High = 6.0m;
                        }
                        else
                        {
                            result.Low = 3.4m;
                            result.High = 7.0m;
                        }

                        break;

                    default:
                        result.Errors.Add("Nieznana metoda: " + method);
                        return result;
                }
            }
            else if (laboratory == "Partnerskie")
            {
                // TODO: refaktoryzacja: niedostępna kombinacja nie powinna dać się w ogóle wybrać.
                // PROBLEM: laboratorium partnerskie ma tylko metodę urykazową, ale nikt nie sprawdza parametru method.
                // Wybór „Kolorymetryczna” daje wynik, którego nikt tą metodą nie zmierzył.
                if (reading < 0.5m || reading > 20m)
                {
                    result.Errors.Add("Odczyt poza zakresem pomiarowym metody: 0,5–20 mg/dl");
                    return result;
                }

                result.Value = Math.Round(reading * 0.0595m, 2, MidpointRounding.AwayFromZero);
                result.Unit = "mmol/l";
                if (age < 18)
                {
                    // TODO: refaktoryzacja: normy i jednostka wyniku powinny być w jednym miejscu.
                    // PROBLEM: gałąź skopiowana z laboratorium centralnego (DRY). Wynik jest w mmol/l, a norma w mg/dl,
                    // więc każde dziecko z tego laboratorium ma wynik „poniżej normy”.
                    result.Low = 2.0m;
                    result.High = 5.5m;
                }
                else if (sex == "K")
                {
                    result.Low = 0.14m;
                    result.High = 0.36m;
                }
                else
                {
                    result.Low = 0.20m;
                    result.High = 0.42m;
                }
            }
            else
            {
                result.Errors.Add("Nieznane laboratorium: " + laboratory);
                return result;
            }

            if (result.Value < result.Low)
            {
                result.Flag = ResultFlag.Low;
            }
            else if (result.Value > result.High)
            {
                result.Flag = ResultFlag.High;
            }
            else
            {
                result.Flag = ResultFlag.Normal;
            }

            return result;
        }
    }
}
