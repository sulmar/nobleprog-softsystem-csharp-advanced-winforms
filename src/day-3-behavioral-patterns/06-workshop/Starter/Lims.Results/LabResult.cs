using System;

namespace Lims.Results
{
    public class LabResult
    {
        public string SampleCode { get; set; }
        public string PatientName { get; set; }
        public string PatientId { get; set; }
        public string TestType { get; set; }
        public string Analyte { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
        public decimal RefLow { get; set; }
        public decimal RefHigh { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; } = "";
        public string VerifiedBy { get; set; } = "";
        public string ApprovedBy { get; set; } = "";
        public DateTime? ApprovedAt { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
