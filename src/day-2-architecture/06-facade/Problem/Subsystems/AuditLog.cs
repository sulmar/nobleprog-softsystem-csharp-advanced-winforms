using System;

namespace Lims.Problem
{
    public sealed class AuditLog
    {
        private readonly LabJournal _journal;

        public AuditLog(LabJournal journal)
        {
            _journal = journal;
        }

        public bool Unavailable { get; set; }

        public void Record(string action, string orderCode, string user, DateTime at)
        {
            if (Unavailable)
            {
                throw new InvalidOperationException("Rejestr audytu jest niedostępny");
            }

            _journal.Add("Audyt: " + action + ", " + orderCode + ", " + user + ", " + at.ToString("yyyy-MM-dd HH:mm"));
        }
    }
}
