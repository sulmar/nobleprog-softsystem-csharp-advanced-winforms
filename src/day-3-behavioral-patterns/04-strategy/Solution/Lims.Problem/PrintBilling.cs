using System;

namespace Lims.Problem
{
    public static class PrintBilling
    {
        // TODO: refaktoryzacja: koszt, rabat i walutę jednego klienta trzymać razem, w jednej klasie.
        // PROBLEM: te same przypadki klientów są w trzech metodach (DRY). Nowy klient to zmiana we wszystkich
        // trzech (OCP), a kompilator nie przypomni o żadnej z nich.
        public static decimal CalculateCost(string customer, int copies)
        {
            switch (customer)
            {
                case "Przychodnia Zdrowie":
                    return copies * 0.06m;

                case "Klinika Nord":
                case "Klinika Baltic":
                    return copies * 0.02m;

                case "Szpital Miejski":
                    return copies <= 500 ? 40m : 40m + (copies - 500) * 0.06m;

                default:
                    if (copies >= 100)
                    {
                        return copies * 0.05m;
                    }

                    return copies >= 10 ? copies * 0.08m : copies * 0.10m;
            }
        }

        public static decimal CalculateDiscount(string customer, int copies, decimal cost)
        {
            switch (customer)
            {
                case "Przychodnia Zdrowie":
                    return copies >= 100 ? cost * 0.10m : 0m;

                case "Klinika Nord":
                case "Klinika Baltic":
                    return copies >= 500 ? cost * 0.05m : 0m;

                default:
                    return 0m;
            }
        }

        public static string GetCurrency(string customer)
        {
            // TODO: refaktoryzacja: waluta musi należeć do tego samego cennika co koszt.
            // PROBLEM: przy dodawaniu kliniki Baltic zmieniono koszt i rabat, a o walucie zapomniano.
            // Stawka 0,02 jest w euro, a na rachunku jest PLN.
            if (customer == "Klinika Nord")
            {
                return "EUR";
            }

            return "PLN";
        }
    }
}
