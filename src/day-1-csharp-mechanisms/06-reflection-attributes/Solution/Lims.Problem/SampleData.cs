using System;
using System.Collections.Generic;

namespace Lims.Problem
{
    /// <summary>Dane przykładowe. Numery PESEL są fikcyjne.</summary>
    public static class SampleData
    {
        public static List<Sample> Samples()
        {
            var due = new DateTime(2026, 11, 2, 12, 0, 0);

            return new List<Sample>
            {
                new Sample { Code = "S-2026-000501", PatientPesel = "00000000001", Material = "Krew", Status = SampleStatus.Registered, DueAt = due },
                new Sample { Code = "S-2026-000502", PatientPesel = "00000000002", Material = "Surowica", Status = SampleStatus.InAnalysis, DueAt = due },
                new Sample { Code = "S-2026-000503", PatientPesel = "00000000003", Material = "Mocz", Status = SampleStatus.Approved, DueAt = due },
                new Sample { Code = "S-2026-000504", PatientPesel = "00000000004", Material = "Krew", Status = SampleStatus.Rejected, DueAt = due },
                new Sample { Code = "S-2026-000505", PatientPesel = "00000000005", Material = "Krew", Status = SampleStatus.Archived, DueAt = due }
            };
        }

        public static List<TestResult> Results()
        {
            return new List<TestResult>
            {
                new TestResult { SampleCode = "S-2026-000501", Analyte = "Glukoza", Value = 88.5m, Unit = "mg/dl" },
                new TestResult { SampleCode = "S-2026-000502", Analyte = "Hemoglobina", Value = 14.1m, Unit = "g/dl" }
            };
        }
    }
}
