using System;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: usunąć singleton i brać sesję bieżącego okna.
    // PROBLEM: obiekt żyje przez całą aplikację i na zawsze zapamiętuje pierwszą przekazaną sesję,
    // która żyje tylko tyle co okno. Po zamknięciu pierwszego okna statystyki używają zamkniętej sesji,
    // a kolejne okno kończy się ObjectDisposedException. Argumenty kolejnych wywołań są pomijane.
    public sealed class DailyStatistics
    {
        private static DailyStatistics _instance;
        private readonly DbSession _session;

        private DailyStatistics(DbSession session)
        {
            _session = session;
        }

        public static DailyStatistics GetInstance(DbSession session)
        {
            if (_instance == null)
            {
                _instance = new DailyStatistics(session);
            }

            return _instance;
        }

        public int ApprovedToday()
        {
            return _session.CountApprovedOn(DateTime.Now);
        }
    }
}
