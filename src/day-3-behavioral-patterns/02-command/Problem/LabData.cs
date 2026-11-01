using System.Collections.Generic;

namespace Lims.Problem
{
    internal static class LabData
    {
        public static readonly List<LabResult> Results = new List<LabResult>
        {
            new LabResult { SampleCode = "P-1001", Analyte = "Glukoza", Value = 92m, Unit = "mg/dl", Status = ResultStatus.Pending },
            new LabResult { SampleCode = "P-1002", Analyte = "Potas", Value = 7.1m, Unit = "mmol/l", IsCritical = true, Status = ResultStatus.Pending },
            new LabResult { SampleCode = "P-1003", Analyte = "Hemoglobina", Value = 13.9m, Unit = "g/dl", Status = ResultStatus.Pending },
            new LabResult { SampleCode = "P-1004", Analyte = "Kreatynina", Value = 1.0m, Unit = "mg/dl", Status = ResultStatus.Pending },
            new LabResult { SampleCode = "P-1005", Analyte = "Sód", Value = 139m, Unit = "mmol/l", Status = ResultStatus.Rejected, ReviewedBy = "E. Wiśniewska" }
        };
    }
}
