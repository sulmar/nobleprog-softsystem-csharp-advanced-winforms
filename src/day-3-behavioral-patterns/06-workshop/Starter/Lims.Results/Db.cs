using System;
using System.Collections.Generic;

namespace Lims.Results
{
    public static class Db
    {
        public static List<LabResult> Results = new List<LabResult>();
        public static List<string> Audit = new List<string>();

        static Db()
        {
            Add("P-2026-0101", "Jan Testowy", "00000000001", "Biochemia", "Glukoza", "5,2", "mmol/l", 3.9m, 5.5m, "Nowy");
            Add("P-2026-0102", "Anna Przykładowa", "00000000002", "Biochemia", "Glukoza", "6,8", "mmol/l", 3.9m, 5.5m, "Nowy");
            Add("P-2026-0103", "Piotr Wzorcowy", "00000000003", "Hematologia", "Hemoglobina", "14,1", "g/dl", 12m, 16m, "Zweryfikowany", verifiedBy: "mgr A. Nowak");
            Add("P-2026-0104", "Maria Fikcyjna", "00000000004", "Hematologia", "Leukocyty", "31", "10^9/l", 4m, 10m, "Zweryfikowany", verifiedBy: "mgr A. Nowak");
            Add("P-2026-0105", "Jan Testowy", "00000000001", "Koagulacja", "INR", "5,1", "", 0.9m, 1.2m, "Zweryfikowany", verifiedBy: "dr C. Wrona");
            Add("P-2026-0106", "Ewa Modelowa", "00000000006", "Mikrobiologia", "Posiew moczu", "Ujemny", "", 0m, 0m, "Nowy");
            Add("P-2026-0107", "Tomasz Bezdanych", "", "Biochemia", "Kreatynina", "0,9", "mg/dl", 0.7m, 1.3m, "Zatwierdzony", verifiedBy: "mgr A. Nowak", approvedBy: "dr C. Wrona", approvedAt: new DateTime(2026, 3, 2, 9, 15, 0));
            Add("P-2026-0108", "Anna Przykładowa", "00000000002", "Mikrobiologia", "Posiew krwi", "Dodatni", "", 0m, 0m, "Zweryfikowany", verifiedBy: "mgr B. Lis");
            Add("P-2026-0109", "Piotr Wzorcowy", "00000000003", "Biochemia", "CRP", "3,2", "mg/l", 0m, 5m, "Zatwierdzony", verifiedBy: "mgr B. Lis", approvedBy: "dr C. Wrona", approvedAt: new DateTime(2026, 3, 2, 10, 40, 0));
            Add("P-2026-0110", "Maria Fikcyjna", "00000000004", "Biochemia", "Glukoza", "4,7", "mmol/l", 3.9m, 5.5m, "Wysłany", verifiedBy: "mgr B. Lis", approvedBy: "dr C. Wrona", approvedAt: new DateTime(2026, 3, 1, 14, 5, 0), sentAt: new DateTime(2026, 3, 1, 14, 20, 0));
            Add("P-2026-0111", "Ewa Modelowa", "00000000006", "Hematologia", "Płytki krwi", "", "10^9/l", 150m, 400m, "Nowy");
            Add("P-2026-0112", "Jan Testowy", "00000000001", "Koagulacja", "INR", "1,05", "", 0.9m, 1.2m, "Odrzucony", comment: "Hemoliza próbki");
        }

        private static void Add(string code, string patient, string patientId, string type, string analyte, string value, string unit,
            decimal low, decimal high, string status, string verifiedBy = "", string approvedBy = "", DateTime? approvedAt = null,
            DateTime? sentAt = null, string comment = "")
        {
            Results.Add(new LabResult
            {
                SampleCode = code,
                PatientName = patient,
                PatientId = patientId,
                TestType = type,
                Analyte = analyte,
                Value = value,
                Unit = unit,
                RefLow = low,
                RefHigh = high,
                Status = status,
                VerifiedBy = verifiedBy,
                ApprovedBy = approvedBy,
                ApprovedAt = approvedAt,
                SentAt = sentAt,
                Comment = comment
            });
        }
    }
}
