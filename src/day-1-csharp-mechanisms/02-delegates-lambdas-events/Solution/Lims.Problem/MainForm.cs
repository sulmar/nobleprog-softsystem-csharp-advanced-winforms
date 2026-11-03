using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lims.Domain;
using static Lims.Problem.ResultImporter;

namespace Lims.Problem
{
    public partial class MainForm : Form
    {
        private readonly List<TestResult> _results;
        private readonly Printer _printer;
        private string _selectedAnalyte;
        private int _sequence;
        private int _previewNumber;
        private int _openPreviews;

        public MainForm()
        {
            InitializeComponent();

            _results = ResultData.Results();
            _printer = new Printer { MainForm = this };

            CreateAnalyteButtons();
            RefreshResults();
        }

        private void CreateAnalyteButtons()
        {
            var allButton = new Button { Text = "Wszystkie", AutoSize = true };
            allButton.Click += (s, e) =>
            {
                _selectedAnalyte = null;
                RefreshResults();
            };
            analytePanel.Controls.Add(allButton);

            foreach (var analyte in ResultData.Analytes)
            {
                var button = new Button { Text = analyte, AutoSize = true };
                button.Click += (s, e) =>
                {
                    _selectedAnalyte = analyte;
                    RefreshResults();
                };

                analytePanel.Controls.Add(button);
            }
        }

        private void RefreshResults()
        {
            // TODO: refaktoryzacja: zastąpić rozgałęzienie jednym filtrem.
            // PROBLEM: każdy nowy filtr dokłada kolejne gałęzie i metody w ResultQueries (OCP).
            List<TestResult> results;
            if (_selectedAnalyte == null && !outOfRangeCheckBox.Checked)
            {
                results = ResultQueries.GetAll(_results);
            }
            else if (_selectedAnalyte == null)
            {
                results = ResultQueries.GetOutOfRange(_results);
            }
            else if (!outOfRangeCheckBox.Checked)
            {
                results = ResultQueries.GetForAnalyte(_results, _selectedAnalyte);
            }
            else
            {
                results = ResultQueries.GetOutOfRangeForAnalyte(_results, _selectedAnalyte);
            }

            resultsGrid.DataSource = results.Select(ResultRow.From).ToList();
            UpdateSubscriptionInfo();
        }

        private void UpdateSubscriptionInfo()
        {
            subscribersLabel.Text = "Subskrypcje podglądów: " + _printer.SubscriberCount
                + ", otwarte podglądy: " + _openPreviews;
        }

        // TODO: refaktoryzacja: przekazać metodę jako delegat i uczynić ją prywatną.
        // PROBLEM: nie może być prywatna, bo wywołuje ją PreviewForm (DIP).
        internal void AddLogEntry(string text)
        {
            logListBox.Items.Insert(0, text);
        }

        private void OutOfRangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshResults();
        }

        private void AddResultButton_Click(object sender, EventArgs e)
        {
            _results.Add(ResultData.NewResult(_sequence++));
            RefreshResults();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            var incoming = Enumerable.Range(_sequence, 3).Select(ResultData.NewResult).ToList();
            _sequence += incoming.Count;

            // LogWriter log = WriteToFile;
            Action<string> log = WriteToFile;

            log += WriteToConsole;
            log += Console.WriteLine;            

            // Metoda anonimowa (funkcja inline)
            log += delegate (string text)
            {
                Console.WriteLine(text);
            };
       
            // Wyrazenie lambda f(x) => x + 2;
            log += text => Console.WriteLine(text);

            Action<string> f = text => Console.WriteLine(text);

            // NET CORE 8
            // var f = text => Console.WriteLine(text);

            log += f;

            ResultImporter.Import(incoming, _results, log, this);
            RefreshResults();

            MessageBox.Show(this, "Zaimportowano wyniki: " + incoming.Count + ". Szczegóły w pliku import.log.", "Import");
        }

        private static void WriteToFile(string text)
        {
            File.AppendAllText("import.log", text + Environment.NewLine);
        }

        private static void WriteToConsole(string message)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // TODO: refaktoryzacja: przekazać postęp jako delegat i usunąć tę metodę.
        // PROBLEM: metoda istnieje tylko dla ResultImporter, który przez nią zależy od formularza (DIP).
        internal void ShowImportProgress(int done, int total)
        {
            Text = "Wyniki badań (Problem), import: " + done + "/" + total;
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            var preview = new PreviewForm(_printer, ++_previewNumber, this);
            preview.FormClosed += (s, args) =>
            {
                _openPreviews--;
                UpdateSubscriptionInfo();
            };

            _openPreviews++;
            preview.Show(this);
            UpdateSubscriptionInfo();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            var cost = _printer.Print("Raport wyników", (int)copiesUpDown.Value, CostCalculator.Calculate);

            UpdateSubscriptionInfo();
            MessageBox.Show(this, "Koszt wydruku: " + cost.ToString("0.00") + " zł", "Wydruk");
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            var report = fullReportCheckBox.Checked
                ? ResultQueries.BuildFullReport(_results)
                : ResultQueries.BuildShortReport(_results);

            MessageBox.Show(this, report, "Raport wyników");
        }

        private sealed class ResultRow
        {
            [DisplayName("Próbka")]
            public string SampleCode { get; set; }

            [DisplayName("Oznaczenie")]
            public string Analyte { get; set; }

            [DisplayName("Wynik")]
            public decimal Value { get; set; }

            [DisplayName("Jednostka")]
            public string Unit { get; set; }

            [DisplayName("Poza zakresem")]
            public bool IsOutOfRange { get; set; }

            public static ResultRow From(TestResult result)
            {
                return new ResultRow
                {
                    SampleCode = result.SampleCode,
                    Analyte = result.Analyte,
                    Value = result.Value,
                    Unit = result.Unit,
                    IsOutOfRange = result.IsOutOfRange()
                };
            }
        }
    }
}
