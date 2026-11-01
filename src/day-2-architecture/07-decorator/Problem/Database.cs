using System.Collections.Generic;
using System.Threading;

namespace Lims.Problem
{
    /// <summary>Symulacja bazy danych. W prawdziwej aplikacji byłyby tu połączenie i zapytania SQL.</summary>
    internal static class Database
    {
        private static readonly Dictionary<string, TestResult> Results = new Dictionary<string, TestResult>
        {
            ["S-100"] = new TestResult("S-100", "P-001", "Glukoza", 92m, "mg/dl"),
            ["S-101"] = new TestResult("S-101", "P-002", "Hemoglobina", 14.2m, "g/dl"),
            ["S-102"] = new TestResult("S-102", "P-003", "Potas", 4.1m, "mmol/l")
        };

        public static TestResult Find(string sampleCode)
        {
            Thread.Sleep(300); // Symulacja wolnego zapytania.

            TestResult result;
            return Results.TryGetValue(sampleCode, out result) ? result : null;
        }

        public static void UpdateValue(string sampleCode, decimal value)
        {
            if (!Results.ContainsKey(sampleCode))
            {
                throw new KeyNotFoundException("Nie ma wyniku dla próbki " + sampleCode);
            }

            Results[sampleCode] = Results[sampleCode].WithValue(value);
        }
    }
}
