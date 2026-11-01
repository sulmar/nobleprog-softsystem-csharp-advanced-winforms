using System;
using System.Collections.Generic;

namespace Lims.Problem
{
    // Symulacja na potrzeby szkolenia: każdy podsystem dopisuje tu, co zrobił, a okno główne to pokazuje.
    public sealed class LabJournal
    {
        private readonly List<string> _entries = new List<string>();

        public event Action<string> EntryAdded;

        public IReadOnlyList<string> Entries
        {
            get { return _entries; }
        }

        public void Add(string entry)
        {
            _entries.Add(entry);
            EntryAdded?.Invoke(entry);
        }
    }
}
