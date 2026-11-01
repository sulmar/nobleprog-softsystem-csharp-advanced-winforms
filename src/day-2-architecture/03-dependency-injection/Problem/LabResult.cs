using System;

namespace Lims.Problem
{
    public class LabResult
    {
        public string Code { get; set; }
        public string Analyte { get; set; }
        public decimal Value { get; set; }
        public decimal UpperLimit { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }

        public bool IsCritical
        {
            get { return Value > 2 * UpperLimit; }
        }
    }

    public class ApprovalOutcome
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
