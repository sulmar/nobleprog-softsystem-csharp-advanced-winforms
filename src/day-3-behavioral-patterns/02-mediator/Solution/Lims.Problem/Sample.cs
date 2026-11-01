namespace Lims.Problem
{
    public enum SampleStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class Sample
    {
        public Sample(string code, string patient, string analyte, bool isUrgent)
        {
            Code = code;
            Patient = patient;
            Analyte = analyte;
            IsUrgent = isUrgent;
            Status = SampleStatus.Pending;
            Comment = "";
        }

        public string Code { get; }
        public string Patient { get; }
        public string Analyte { get; }
        public bool IsUrgent { get; }
        public SampleStatus Status { get; set; }
        public string Comment { get; set; }

        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case SampleStatus.Approved: return "Zatwierdzona";
                    case SampleStatus.Rejected: return "Odrzucona";
                    default: return "Oczekuje";
                }
            }
        }

        public override string ToString()
        {
            return Code + "  " + Analyte + "  " + StatusText
                + (IsUrgent ? "  PILNE" : "")
                + (Comment.Length > 0 ? "  [komentarz]" : "");
        }
    }
}
