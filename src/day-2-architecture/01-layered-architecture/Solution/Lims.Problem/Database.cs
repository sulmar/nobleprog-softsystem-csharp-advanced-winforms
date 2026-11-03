using System.Collections.Generic;

namespace Lims.Problem
{
    /// <summary>Symulacja bazy danych. W prawdziwej aplikacji byłyby tu połączenie i zapytania SQL.</summary>
    internal static class Database
    {
        public static readonly List<RegisteredSample> Samples = new List<RegisteredSample>();

        public static void Save(string pesel, string analyte, string priority, decimal price)
        {
            Samples.Add(new RegisteredSample { Pesel = pesel, Analyte = analyte, Priority = priority, Price = price });
        }
    }

    internal class RegisteredSample
    {
        public string Pesel { get; set; }
        public string Analyte { get; set; }
        public string Priority { get; set; }
        public decimal Price { get; set; }
    }
}
