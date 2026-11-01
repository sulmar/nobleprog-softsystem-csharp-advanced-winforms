using System.Globalization;

namespace Lims.Problem
{
    public class LabResult
    {
        public const string Pending = "Oczekuje";
        public const string Approved = "Zatwierdzony";
        public const string Rejected = "Odrzucony";

        public string Code { get; set; }
        public string Analyte { get; set; }

        // Tekst, bo analizator zgłasza też wartości poniżej progu oznaczalności, np. „<2”.
        public string ValueText { get; set; }

        public decimal RangeLow { get; set; }
        public decimal RangeHigh { get; set; }
        public string Status { get; set; } = Pending;
        public string DecidedBy { get; set; }

        public bool IsNumericAndInRange()
        {
            decimal value;
            return decimal.TryParse(ValueText, NumberStyles.Number, CultureInfo.InvariantCulture, out value)
                && value >= RangeLow
                && value <= RangeHigh;
        }
    }
}
