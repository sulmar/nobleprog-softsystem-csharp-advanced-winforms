using System.Collections.Generic;

namespace Lims.Domain
{
    public class Patient
    {
        public string Code { get; set; }
    }

    public class Sample
    {
        public string Code { get; set; }
        public string PatientCode { get; set; }
        public string Analyte { get; set; }
    }

    /// <summary>Wynik badania pojedynczej próbki.</summary>
    public class TestResult
    {
        public string SampleCode { get; set; }
        public string Analyte { get; set; }
        public decimal Value { get; set; }
    }

    /// <summary>Raport zbiorczy: wyniki kilku próbek jednej osoby.</summary>
    public class PatientReport
    {
        public PatientReport(Patient patient, IReadOnlyList<TestResult> results)
        {
            Patient = patient;
            Results = results;
        }

        public Patient Patient { get; }
        public IReadOnlyList<TestResult> Results { get; }
    }
}
