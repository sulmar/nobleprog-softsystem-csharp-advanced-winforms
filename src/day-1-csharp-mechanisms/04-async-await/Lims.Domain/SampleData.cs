using System.Collections.Generic;

namespace Lims.Domain
{
    /// <summary>Dane przykładowe. W prawdziwej aplikacji pochodziłyby z bazy.</summary>
    public static class SampleData
    {
        public static readonly Patient Patient = new Patient { Code = "P-1001" };

        public static List<Sample> SamplesForPatient()
        {
            return new List<Sample>
            {
                new Sample { Code = "S-2026-000401", PatientCode = Patient.Code, Analyte = "Glukoza" },
                new Sample { Code = "S-2026-000402", PatientCode = Patient.Code, Analyte = "Hemoglobina" },
                new Sample { Code = "S-2026-000403", PatientCode = Patient.Code, Analyte = "Kreatynina" }
            };
        }

        public static TestResult ResultFor(Sample sample)
        {
            return new TestResult { SampleCode = sample.Code, Analyte = sample.Analyte, Value = 90m };
        }
    }
}
