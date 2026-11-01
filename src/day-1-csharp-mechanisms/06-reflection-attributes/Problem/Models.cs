using System;

namespace Lims.Problem
{
    public enum SampleStatus
    {
        Registered,
        InAnalysis,
        Approved,
        Rejected,
        Archived
    }

    public class Sample
    {
        public string Code { get; set; }
        public string PatientPesel { get; set; }
        public string Material { get; set; }
        public SampleStatus Status { get; set; }
        public DateTime DueAt { get; set; }
    }

    public class TestResult
    {
        public string SampleCode { get; set; }
        public string Analyte { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
    }
}
