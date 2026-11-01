using System;
using System.Collections.Generic;

namespace Lims.Domain
{
    /// <summary>Dane przykładowe. W prawdziwej aplikacji pochodziłyby z bazy lub usługi.</summary>
    public static class SampleData
    {
        public static List<Sample> Samples(DateTime now)
        {
            return new List<Sample>
            {
                new Sample { Code = "S-2026-000123", Material = "Krew", Status = SampleStatus.InAnalysis, DueAt = now.AddHours(-3) },
                new Sample { Code = "S-2026-000124", Material = "Surowica", Status = SampleStatus.InAnalysis, DueAt = now.AddHours(5) },
                new Sample { Code = "S-2026-000125", Material = "Mocz", Status = SampleStatus.Registered, DueAt = now.AddHours(-1) },
                new Sample { Code = "S-2026-000126", Material = "Krew", Status = SampleStatus.Approved, DueAt = now.AddHours(-8) },
                new Sample { Code = "S-2026-000127", Material = "Surowica", Status = SampleStatus.Rejected, DueAt = now.AddHours(-2) }
            };
        }

        public static List<TestResult> Results()
        {
            return new List<TestResult>
            {
                new TestResult { SampleCode = "S-2026-000123", Analyte = "Hemoglobina", Value = 10.2m, Unit = "g/dl", ReferenceLow = 12m, ReferenceHigh = 16m },
                new TestResult { SampleCode = "S-2026-000123", Analyte = "Leukocyty", Value = 6.1m, Unit = "tys./µl", ReferenceLow = 4m, ReferenceHigh = 10m },

                // Wartość równa górnej granicy zakresu: to na niej widać błąd w projekcie Problem.
                new TestResult { SampleCode = "S-2026-000124", Analyte = "Glukoza", Value = 99m, Unit = "mg/dl", ReferenceLow = 70m, ReferenceHigh = 99m },
                new TestResult { SampleCode = "S-2026-000124", Analyte = "Kreatynina", Value = 0.9m, Unit = "mg/dl", ReferenceLow = 0.6m, ReferenceHigh = 1.2m },

                new TestResult { SampleCode = "S-2026-000126", Analyte = "Hemoglobina", Value = 14.1m, Unit = "g/dl", ReferenceLow = 12m, ReferenceHigh = 16m },
                new TestResult { SampleCode = "S-2026-000126", Analyte = "Płytki krwi", Value = 520m, Unit = "tys./µl", ReferenceLow = 150m, ReferenceHigh = 400m }
            };
        }
    }
}
