using System.Collections.Generic;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: ukryć za interfejsem i przekazywać przez konstruktor.
    // PROBLEM: statyczny singleton. Test nie podstawi własnego dziennika, a wpisy zostają między testami (DIP).
    public sealed class AuditLog
    {
        public static AuditLog Instance { get; } = new AuditLog();

        private AuditLog()
        {
        }

        public List<string> Entries { get; } = new List<string>();

        public void Write(string entry)
        {
            Entries.Add(entry);
        }
    }
}
