using System.Collections.Generic;

namespace Lims.Domain
{
    /// <summary>Dane przykładowe: wyniki badań z jednego dnia.</summary>
    public static class ResultData
    {
        /// <summary>Co trzeci wynik jest poza zakresem, począwszy od pierwszego.</summary>
        public static List<TestResult> ForDay(int count)
        {
            var results = new List<TestResult>();
            for (var i = 0; i < count; i++)
            {
                results.Add(new TestResult
                {
                    SampleCode = "S-2026-" + (300 + i).ToString("D6"),
                    Analyte = "Glukoza",
                    Value = i % 3 == 0 ? 150m : 85m,
                    ReferenceLow = 70m,
                    ReferenceHigh = 99m
                });
            }
            return results;
        }
    }
}
