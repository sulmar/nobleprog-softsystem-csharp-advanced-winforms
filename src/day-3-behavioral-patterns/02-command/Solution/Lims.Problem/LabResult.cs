using System;

namespace Lims.Problem
{
    public enum ResultStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class LabResult
    {
        public string SampleCode { get; set; }
        public string Analyte { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public bool IsCritical { get; set; }
        public ResultStatus Status { get; set; }
        public string ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }
    }
}
