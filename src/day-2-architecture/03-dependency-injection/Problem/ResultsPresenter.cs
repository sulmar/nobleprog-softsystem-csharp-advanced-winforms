using System.Collections.Generic;

namespace Lims.Problem
{
    public interface IResultsView
    {
        void ShowPending(IReadOnlyList<LabResult> results);

        void ShowReport(string report);
    }

    public class ResultsPresenter
    {
        private readonly IResultsView _view;

        public ResultsPresenter(IResultsView view)
        {
            _view = view;
        }

        public void Refresh()
        {
            // TODO: refaktoryzacja: sesja przez konstruktor.
            // PROBLEM: `new` wiąże Presenter z konkretną bazą (DIP).
            using (var session = new DbSession())
            {
                _view.ShowPending(session.Pending());
            }
        }

        public void CreateReport()
        {
            // TODO: refaktoryzacja: serwis przez konstruktor.
            // PROBLEM: `new` w metodzie ukrywa zależność, a klasa raportu ukrywa kolejne (DIP).
            _view.ShowReport(new ResultReportService().CreateDailyReport());
        }
    }
}
