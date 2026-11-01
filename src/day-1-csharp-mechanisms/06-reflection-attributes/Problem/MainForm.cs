using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // TODO: refaktoryzacja: odczytać listę statusów z typu wyliczeniowego.
            // PROBLEM: lista jest przepisana ręcznie, więc nowy status Archived do niej nie trafił (OCP).
            statusComboBox.Items.AddRange(new object[] { "Zarejestrowana", "W analizie", "Zatwierdzona", "Odrzucona" });

            samplesGrid.DataBindingComplete += SamplesGrid_DataBindingComplete;
            samplesGrid.CellFormatting += SamplesGrid_CellFormatting;
            samplesGrid.DataSource = SampleData.Samples();
        }

        private void SamplesGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // TODO: refaktoryzacja: opisać kolumny raz, przy modelu.
            // PROBLEM: formularz zna nazwy właściwości jako napisy, więc literówka wyjdzie dopiero po uruchomieniu.
            // Numer PESEL jest widoczny, bo nikt nie pamiętał, by ukryć tę kolumnę.
            samplesGrid.Columns["Code"].HeaderText = "Kod";
            samplesGrid.Columns["PatientPesel"].HeaderText = "PESEL";
            samplesGrid.Columns["Material"].HeaderText = "Materiał";
            samplesGrid.Columns["Status"].HeaderText = "Status";
            samplesGrid.Columns["DueAt"].HeaderText = "Termin";
        }

        private void SamplesGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is SampleStatus)
            {
                e.Value = StatusText((SampleStatus)e.Value);
                e.FormattingApplied = true;
            }
        }

        // TODO: naprawić błąd: jedna definicja tekstów statusów.
        // PROBLEM: inna kopia niż w CsvExports (DRY). Nowy status wymaga zmiany w kilku miejscach (OCP).
        private static string StatusText(SampleStatus status)
        {
            switch (status)
            {
                case SampleStatus.Registered: return "Zarejestrowana";
                case SampleStatus.InAnalysis: return "W analizie";
                case SampleStatus.Approved: return "Zatwierdzona";
                case SampleStatus.Rejected: return "Odrzucona";
                default: return status.ToString();
            }
        }

        private void ExportSamplesButton_Click(object sender, EventArgs e)
        {
            outputTextBox.Text = CsvExports.Samples(SampleData.Samples());
        }

        private void ExportResultsButton_Click(object sender, EventArgs e)
        {
            outputTextBox.Text = CsvExports.Results(SampleData.Results());
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            var errors = new List<string>();
            errors.AddRange(ValidateSample(new Sample { Code = "", Material = "Krew" }));
            errors.AddRange(ValidateResult(new TestResult { SampleCode = "S-1", Analyte = "Glukoza", Value = -5m }));

            outputTextBox.Text = string.Join(Environment.NewLine, errors);
        }

        // TODO: refaktoryzacja: opisać reguły przy modelu i sprawdzać je jednym walidatorem.
        // PROBLEM: każdy model ma własną metodę z tymi samymi warunkami (DRY), a walidacja
        // leży w formularzu, więc reguł nie da się użyć w innym miejscu ani przetestować (SRP).
        private static List<string> ValidateSample(Sample sample)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(sample.Code))
            {
                errors.Add("Pole Kod jest wymagane");
            }
            if (string.IsNullOrEmpty(sample.PatientPesel))
            {
                errors.Add("Pole PESEL jest wymagane");
            }
            return errors;
        }

        private static List<string> ValidateResult(TestResult result)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(result.SampleCode))
            {
                errors.Add("Pole Próbka jest wymagane");
            }
            if (result.Value < 0m || result.Value > 10000m)
            {
                errors.Add("Pole Wynik musi być w zakresie od 0 do 10000");
            }
            return errors;
        }
    }
}
