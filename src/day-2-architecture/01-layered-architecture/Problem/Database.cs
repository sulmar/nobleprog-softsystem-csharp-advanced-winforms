using System;
using System.Collections.Generic;

namespace Lims.Problem
{
    /// <summary>Symulacja bazy danych. W prawdziwej aplikacji byłyby tu połączenie i zapytania SQL.</summary>
    internal static class Database
    {
        // Wiersz: kod, PESEL, materiał, oznaczenie, priorytet, termin, cena, data rejestracji.
        public static readonly List<object[]> Samples = new List<object[]>();

        public static int NextNumber = 600;

        public static bool Exists(string pesel, string analyte, DateTime day)
        {
            foreach (var row in Samples)
            {
                if ((string)row[1] == pesel && (string)row[3] == analyte && ((DateTime)row[7]).Date == day.Date)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
