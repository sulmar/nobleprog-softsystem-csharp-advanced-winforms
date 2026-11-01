using System.Collections.Generic;

namespace Lims.Problem.Model
{
    public enum OrderStatus
    {
        New,
        InProgress,
        Completed,
        Cancelled
    }

    public enum OrderPriority
    {
        Normal,
        Urgent,
        Immediate
    }

    /// <summary>Zlecenie badania. Co wolno zrobić w danym stanie, to zasada laboratorium, więc jest tutaj.</summary>
    public class LabOrder
    {
        public string Code { get; set; }
        public string PatientName { get; set; }
        public string Analyte { get; set; }
        public OrderPriority Priority { get; set; }
        public string Physician { get; set; }
        public string Notes { get; set; }
        public OrderStatus Status { get; set; }

        public bool CanEdit
        {
            get { return Status == OrderStatus.New || Status == OrderStatus.InProgress; }
        }

        public bool CanChangeAnalyte
        {
            get { return Status == OrderStatus.New; }
        }

        public bool CanCancel
        {
            get { return Status == OrderStatus.New; }
        }

        public LabOrder Copy()
        {
            return (LabOrder)MemberwiseClone();
        }
    }

    /// <summary>Dane, które użytkownik może zmienić w zleceniu: same wartości, bez kontrolek.</summary>
    public class OrderChanges
    {
        public string Analyte { get; set; }
        public OrderPriority Priority { get; set; }
        public string Physician { get; set; }
        public string Notes { get; set; }
    }

    public class OperationResult
    {
        private OperationResult(IReadOnlyList<string> errors)
        {
            Errors = errors;
        }

        public IReadOnlyList<string> Errors { get; }

        public bool IsSuccess
        {
            get { return Errors.Count == 0; }
        }

        public static OperationResult Success()
        {
            return new OperationResult(new string[0]);
        }

        public static OperationResult Failure(IReadOnlyList<string> errors)
        {
            return new OperationResult(errors);
        }

        public static OperationResult Failure(string error)
        {
            return new OperationResult(new[] { error });
        }
    }
}
