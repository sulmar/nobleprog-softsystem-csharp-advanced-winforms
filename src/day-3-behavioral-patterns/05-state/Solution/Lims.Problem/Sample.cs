using System.Collections.Generic;

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
        public Sample(string code, string analyte)
        {
            Code = code;
            Analyte = analyte;
            Notes = string.Empty;
        }

        public string Code { get; private set; }

        public string Analyte { get; private set; }

        // TODO: refaktoryzacja: status zmienia się tylko przez operacje próbki.
        // PROBLEM: publiczny setter pozwala każdemu ustawić dowolny status, więc nikt nie pilnuje przejść.
        public SampleStatus Status { get; set; }

        // PROBLEM: kolejny switch po statusie. Nowy status to kolejne miejsce do znalezienia (OCP).
        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case SampleStatus.Registered: return "Zarejestrowana";
                    case SampleStatus.InAnalysis: return "W analizie";
                    case SampleStatus.Approved: return "Zatwierdzona";
                    case SampleStatus.Rejected: return "Odrzucona";
                    default: return "Zarchiwizowana";
                }
            }
        }

        public decimal? Result { get; set; }

        public string ResultEnteredBy { get; set; }

        public string ApprovedBy { get; set; }

        public string RejectionReason { get; set; }

        public string Notes { get; set; }

        // PROBLEM: historia to luźne napisy, a dopisuje je tylko część operacji.
        public List<string> History { get; } = new List<string>();
    }
}
