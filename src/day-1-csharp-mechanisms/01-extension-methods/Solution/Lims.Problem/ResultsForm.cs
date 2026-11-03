using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lims.Domain;
using Lims.Problem.Extensions;
using Lims.Problem.Helpers;

namespace Lims.Problem
{
    public partial class ResultsForm : Form
    {
        public ResultsForm(IEnumerable<Sample> samples, IEnumerable<TestResult> results)
        {
            InitializeComponent();

            LimsHelper.EnableDoubleBuffering(resultsGrid);
            resultsGrid.DataBindingComplete += ResultsGrid_DataBindingComplete;

            // TODO: refaktoryzacja: użyć wspólnej reguły "po terminie".
            // PROBLEM: formularz zawiera regułę biznesową (SRP), będącą kopią z SampleListForm (DRY).
            var now = DateTime.Now;
            var overdueCount = 0;
            foreach (var sample in samples)
            {
                if (sample.DueAt < now
                    && sample.Status != SampleStatus.Approved
                    && sample.Status != SampleStatus.Rejected)
                {
                    overdueCount++;
                }
            }
            summaryLabel.Text = "Próbki po terminie: " + overdueCount;

            var rows = new List<ResultRow>();
            foreach (var result in results)
            {
                rows.Add(new ResultRow
                {                    
                    Barcode = result.SampleCode.FormatBarcode(),
                    Analyte = result.Analyte,
                    Value = result.Value,
                    Unit = result.Unit,
                    Range = result.ReferenceLow + " - " + result.ReferenceHigh,
                    
                    IsOutOfRange = result.IsOutOfRange()
                });
            }

            resultsGrid.DataSource = rows;
        }

        private void ResultsGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // TODO: refaktoryzacja: wydzielić kolorowanie wierszy.
            // PROBLEM: kopia pętli z SampleListForm (DRY).
            foreach (DataGridViewRow row in resultsGrid.Rows)
            {
                var item = (ResultRow)row.DataBoundItem;
                row.DefaultCellStyle.BackColor = item.IsOutOfRange ? Color.MistyRose : Color.Empty;
            }
        }

        private sealed class ResultRow
        {
            [DisplayName("Kod kreskowy")]
            public string Barcode { get; set; }

            [DisplayName("Oznaczenie")]
            public string Analyte { get; set; }

            [DisplayName("Wynik")]
            public decimal Value { get; set; }

            [DisplayName("Jednostka")]
            public string Unit { get; set; }

            [DisplayName("Zakres referencyjny")]
            public string Range { get; set; }

            [Browsable(false)]
            public bool IsOutOfRange { get; set; }
        }
    }
}
