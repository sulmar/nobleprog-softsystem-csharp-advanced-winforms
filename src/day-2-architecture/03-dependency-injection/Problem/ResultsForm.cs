using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class ResultsForm : Form, IResultsView
    {
        private readonly ResultsPresenter _presenter;

        public ResultsForm()
        {
            InitializeComponent();

            // TODO: refaktoryzacja: Presenter przez konstruktor.
            // PROBLEM: formularz decyduje, z czego składa się ekran (DIP).
            _presenter = new ResultsPresenter(this);
            _presenter.Refresh();
        }

        public void ShowPending(IReadOnlyList<LabResult> results)
        {
            resultsGrid.DataSource = null;
            resultsGrid.DataSource = results;
        }

        public void ShowReport(string report)
        {
            MessageBox.Show(this, report, "Raport dnia");
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            if (resultsGrid.CurrentRow == null)
            {
                return;
            }

            var code = ((LabResult)resultsGrid.CurrentRow.DataBoundItem).Code;

            // TODO: refaktoryzacja: okno tworzyć i zwalniać w jednym miejscu, które zna czas życia okna.
            // PROBLEM: formularz otwarty przez ShowDialog nie zwalnia się sam po zamknięciu, a tu nikt
            // nie wywołuje Dispose. Formularz zna też konkretną klasę drugiego okna (DIP).
            new ApprovalForm(code).ShowDialog(this);

            _presenter.Refresh();
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            _presenter.CreateReport();
        }
    }
}
