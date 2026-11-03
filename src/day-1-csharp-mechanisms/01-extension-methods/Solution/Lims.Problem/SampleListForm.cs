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
    public partial class SampleListForm : Form
    {
        private readonly List<Sample> _samples;
        private readonly List<TestResult> _results;

        public SampleListForm()
        {
            InitializeComponent();

            _samples = SampleData.Samples(DateTime.Now);
            _results = SampleData.Results();

            LimsHelper.EnableDoubleBuffering(samplesGrid);
            samplesGrid.DataBindingComplete += SamplesGrid_DataBindingComplete;
            LoadRows();
        }

        private void LoadRows()
        {
            var now = DateTime.Now;
            var rows = new List<SampleRow>();

            foreach (var sample in _samples)
            {
                // TODO: refaktoryzacja: wydzielić regułę "po terminie" z formularza.
                // PROBLEM: formularz oprócz obsługi interfejsu zawiera regułę biznesową (SRP), a ResultsForm ma jej kopię (DRY).
                var isOverdue = sample.DueAt < now
                    && sample.Status != SampleStatus.Approved
                    && sample.Status != SampleStatus.Rejected;

                if (overdueOnlyCheckBox.Checked && !isOverdue)
                {
                    continue;
                }

                var outOfRangeCount = 0;
                foreach (var result in _results)
                {
                    // TODO: naprawić błąd i wydzielić regułę zakresu z formularza.
                    // PROBLEM: "<=" i ">=" liczą wartość równą granicy jako przekroczenie. ResultsForm używa "<" i ">" (DRY),
                    // więc glukoza 99 mg/dl (zakres 70-99) jest tu liczona jako wynik poza zakresem, a tam nie.
                    if (result.SampleCode == sample.Code
                        && result.IsOutOfRange())
                    {
                        outOfRangeCount++;
                    }
                }

                rows.Add(new SampleRow
                {
                    Barcode = sample.Code.FormatBarcode("+"),
                    Material = sample.Material,
                    Status = sample.Status.ToString(),
                    DueAt = sample.DueAt,
                    OutOfRangeCount = outOfRangeCount,
                    IsOverdue = isOverdue
                });
            }

            samplesGrid.DataSource = rows;
        }

        private void SamplesGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // TODO: refaktoryzacja: wydzielić kolorowanie wierszy.
            // PROBLEM: ta sama pętla jest także w ResultsForm (DRY).
            foreach (DataGridViewRow row in samplesGrid.Rows)
            {
                var item = (SampleRow)row.DataBoundItem;
                row.DefaultCellStyle.BackColor = item.IsOverdue ? Color.MistyRose : Color.Empty;
            }
        }

        private void OverdueOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadRows();
        }

        private void ShowResultsButton_Click(object sender, EventArgs e)
        {
            new ResultsForm(_samples, _results).Show(this);
        }

        private sealed class SampleRow
        {
            [DisplayName("Kod kreskowy")]
            public string Barcode { get; set; }

            [DisplayName("Materiał")]
            public string Material { get; set; }

            [DisplayName("Status")]
            public string Status { get; set; }

            [DisplayName("Termin")]
            public DateTime DueAt { get; set; }

            [DisplayName("Wyniki poza zakresem")]
            public int OutOfRangeCount { get; set; }

            [Browsable(false)]
            public bool IsOverdue { get; set; }
        }
    }
}
