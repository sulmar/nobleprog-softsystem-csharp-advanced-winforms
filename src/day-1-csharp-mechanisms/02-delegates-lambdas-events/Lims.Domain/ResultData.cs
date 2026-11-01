using System.Collections.Generic;

namespace Lims.Domain
{
    /// <summary>Dane przykładowe. W prawdziwej aplikacji pochodziłyby z bazy lub analizatora.</summary>
    public static class ResultData
    {
        public static readonly string[] Analytes = { "Glukoza", "Hemoglobina", "Kreatynina" };

        public static List<TestResult> Results()
        {
            return new List<TestResult>
            {
                Glucose("S-2026-000123", 88m),
                Hemoglobin("S-2026-000123", 10.2m),
                Creatinine("S-2026-000123", 0.9m),
                Glucose("S-2026-000124", 142m),
                Hemoglobin("S-2026-000124", 14.1m),
                Creatinine("S-2026-000124", 1.8m)
            };
        }

        /// <summary>Kolejny wynik "z analizatora". Co drugi jest poza zakresem.</summary>
        public static TestResult NewResult(int sequence)
        {
            var code = "S-2026-" + (200 + sequence).ToString("D6");
            var isHigh = sequence % 2 == 1;

            switch (sequence % Analytes.Length)
            {
                case 0: return Glucose(code, isHigh ? 150m : 85m);
                case 1: return Hemoglobin(code, isHigh ? 18m : 14m);
                default: return Creatinine(code, isHigh ? 2.1m : 1m);
            }
        }

        private static TestResult Glucose(string code, decimal value)
        {
            return Create(code, "Glukoza", value, "mg/dl", 70m, 99m);
        }

        private static TestResult Hemoglobin(string code, decimal value)
        {
            return Create(code, "Hemoglobina", value, "g/dl", 12m, 16m);
        }

        private static TestResult Creatinine(string code, decimal value)
        {
            return Create(code, "Kreatynina", value, "mg/dl", 0.6m, 1.2m);
        }

        private static TestResult Create(string code, string analyte, decimal value, string unit, decimal low, decimal high)
        {
            return new TestResult
            {
                SampleCode = code,
                Analyte = analyte,
                Value = value,
                Unit = unit,
                ReferenceLow = low,
                ReferenceHigh = high
            };
        }
    }
}
