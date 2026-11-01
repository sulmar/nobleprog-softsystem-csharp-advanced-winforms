using System;

namespace Lims.Problem
{
    public enum OrderStatus
    {
        Pending,
        Approved
    }

    public sealed class Order
    {
        public string Code { get; set; }
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string Analyte { get; set; }
        public string Clinic { get; set; }
        public bool IsUrgent { get; set; }
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }

        public override string ToString()
        {
            return Code + " | " + PatientName + " | " + Analyte + (IsUrgent ? " | CITO" : "");
        }
    }
}
