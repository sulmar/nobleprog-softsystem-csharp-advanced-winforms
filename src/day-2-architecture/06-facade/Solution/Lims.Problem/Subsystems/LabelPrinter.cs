using System;

namespace Lims.Problem
{
    public sealed class LabelPrinter
    {
        private readonly LabJournal _journal;

        public LabelPrinter(LabJournal journal)
        {
            _journal = journal;
        }

        public bool OutOfPaper { get; set; }

        public void Print(string labelText)
        {
            if (OutOfPaper)
            {
                throw new InvalidOperationException("Brak papieru w drukarce");
            }

            _journal.Add("Etykieta: " + labelText);
        }
    }
}
