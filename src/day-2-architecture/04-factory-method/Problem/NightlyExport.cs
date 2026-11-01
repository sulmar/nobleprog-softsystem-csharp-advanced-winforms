using System.Collections.Generic;
using System.Text;

namespace Lims.Problem
{
    public class NightlyExport
    {
        public string Export(IEnumerable<LabOrder> orders)
        {
            var text = new StringBuilder();

            foreach (var order in orders)
            {
                if (order.Status == OrderStatus.New)
                {
                    continue;
                }

                string title;
                IEnumerable<string> lines;

                // TODO: refaktoryzacja: jeden wybór raportu dla całej aplikacji.
                // PROBLEM: kopia switcha z MainForm.PreviewReportButton_Click (DRY). Po dodaniu mikrobiologii
                // nikt tu nie zajrzał, więc posiew wpada w default i wychodzi jako raport z morfologii krwi.
                // Kompilator tego nie wykryje, a nowy typ badania wymaga zmiany w każdej kopii (OCP).
                switch (order.TestType)
                {
                    case TestType.Urine:
                        var urineReport = new UrineReport();
                        title = urineReport.Title;
                        lines = urineReport.BodyLines(order);
                        break;
                    default:
                        var bloodReport = new BloodReport();
                        title = bloodReport.Title;
                        lines = bloodReport.BodyLines(order);
                        break;
                }

                // TODO: refaktoryzacja: wspólny układ raportu w jednym miejscu.
                // PROBLEM: nagłówek i podpis są skopiowane z podglądu, a podpis już się od niego różni (DRY).
                text.AppendLine(title);
                text.AppendLine("Zlecenie: " + order.Code);
                text.AppendLine("Pacjent: " + order.PatientName);

                foreach (var line in lines)
                {
                    text.AppendLine(line);
                }

                text.AppendLine("Podpis: diagnosta laboratoryjny");
                text.AppendLine();
            }

            return text.ToString();
        }
    }
}
