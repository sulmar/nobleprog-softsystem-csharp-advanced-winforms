using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class MainForm : Form
    {
        private readonly List<LabOrder> _orders = new List<LabOrder>
        {
            new LabOrder("Z-1001", "Anna Testowa", TestType.Blood),
            new LabOrder("Z-1002", "Jan Przykładowy", TestType.Urine),
            new LabOrder("Z-1003", "Maria Fikcyjna", TestType.Microbiology)
        };

        public MainForm()
        {
            InitializeComponent();
            RefreshGrid();
        }

        // TODO: refaktoryzacja: formularz główny nie powinien znać konkretnych okien.
        // PROBLEM: switch po typie badania i new konkretnych formularzy (OCP, DIP). Tej decyzji nie da się
        // przetestować bez okna, a nowy typ badania wymaga zmiany w tej metodzie.
        // Okna pokazane przez ShowDialog nie są zwalniane po zamknięciu, a tu nikt nie woła Dispose.
        private void EnterResultsButton_Click(object sender, EventArgs e)
        {
            var order = SelectedOrder();
            if (order == null)
            {
                return;
            }

            switch (order.TestType)
            {
                case TestType.Blood:
                    new BloodResultForm(order).ShowDialog(this);
                    break;
                case TestType.Urine:
                    new UrineResultForm(order).ShowDialog(this);
                    break;
                case TestType.Microbiology:
                    new MicrobiologyResultForm(order).ShowDialog(this);
                    break;
            }

            RefreshGrid();
        }

        // TODO: refaktoryzacja: wybór raportu i jego układ poza formularzem.
        // PROBLEM: drugi switch po typie badania, a układ raportu jest kopią tego z NightlyExport (DRY).
        // Podgląd pokazuje posiew poprawnie, a eksport nocny nie, i użytkownik widzi dwa różne dokumenty.
        private void PreviewReportButton_Click(object sender, EventArgs e)
        {
            var order = SelectedOrder();
            if (order == null)
            {
                return;
            }

            string title;
            IEnumerable<string> lines;
            string signature = "Podpis: diagnosta laboratoryjny";

            switch (order.TestType)
            {
                case TestType.Blood:
                    var bloodReport = new BloodReport();
                    title = bloodReport.Title;
                    lines = bloodReport.BodyLines(order);
                    break;
                case TestType.Urine:
                    var urineReport = new UrineReport();
                    title = urineReport.Title;
                    lines = urineReport.BodyLines(order);
                    break;
                case TestType.Microbiology:
                    var microbiologyReport = new MicrobiologyReport();
                    title = microbiologyReport.Title;
                    lines = microbiologyReport.BodyLines(order);
                    signature = "Podpis: mikrobiolog";
                    break;
                default:
                    throw new InvalidOperationException("Nieznany typ badania: " + order.TestType);
            }

            var text = new StringBuilder();
            text.AppendLine(title);
            text.AppendLine("Zlecenie: " + order.Code);
            text.AppendLine("Pacjent: " + order.PatientName);

            foreach (var line in lines)
            {
                text.AppendLine(line);
            }

            text.AppendLine(signature);
            reportTextBox.Text = text.ToString();
        }

        private void NightlyExportButton_Click(object sender, EventArgs e)
        {
            reportTextBox.Text = new NightlyExport().Export(_orders);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            using (var about = new AboutForm())
            {
                about.ShowDialog(this);
            }
        }

        private LabOrder SelectedOrder()
        {
            if (ordersGrid.CurrentRow == null)
            {
                return null;
            }

            return _orders[ordersGrid.CurrentRow.Index];
        }

        private void RefreshGrid()
        {
            ordersGrid.DataSource = _orders
                .Select(order => new
                {
                    Zlecenie = order.Code,
                    Pacjent = order.PatientName,
                    Badanie = order.TestName,
                    Status = order.StatusName
                })
                .ToList();
        }
    }
}
