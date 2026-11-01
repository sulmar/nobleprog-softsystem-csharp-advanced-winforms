namespace Lims.Problem
{
    public interface IApprovalView
    {
        string ApprovedBy { get; }

        void ShowResult(LabResult result);

        void ShowApprovedToday(int count);

        void ShowMessage(string message);

        void CloseWindow();
    }

    public class ApprovalPresenter
    {
        private readonly IApprovalView _view;
        private readonly DbSession _session;
        private readonly ResultApprovalService _service;

        // TODO: refaktoryzacja: przyjąć serwis, statystyki i sesję w konstruktorze.
        // PROBLEM: Presenter sam składa swoje zależności, więc testu z atrapą widoku nie da się napisać
        // bez prawdziwej bazy i bramki SMS (DIP).
        public ApprovalPresenter(IApprovalView view)
        {
            _view = view;
            _session = new DbSession();
            _service = new ResultApprovalService(_session);
        }

        public void Load(string code)
        {
            _view.ShowResult(_session.Find(code));
            _view.ShowApprovedToday(DailyStatistics.GetInstance(_session).ApprovedToday());
        }

        public void Approve(string code)
        {
            var outcome = _service.Approve(code, _view.ApprovedBy);
            _view.ShowMessage(outcome.Message);

            if (outcome.IsSuccess)
            {
                _view.CloseWindow();
            }
        }

        // TODO: refaktoryzacja: o końcu życia sesji powinno decydować miejsce, które ją utworzyło.
        // PROBLEM: tylko dyscyplina okna pilnuje zamknięcia, a sesja jest prywatnym szczegółem Presentera.
        public void Close()
        {
            _session.Dispose();
        }
    }
}
