using System;

namespace Lims.Problem
{
    public sealed class BillingSystem
    {
        private readonly LabJournal _journal;
        private int _lastChargeNumber;

        public BillingSystem(LabJournal journal)
        {
            _journal = journal;
        }

        public bool Unavailable { get; set; }

        public string Charge(string clinic, string orderCode, decimal amount)
        {
            if (Unavailable)
            {
                throw new InvalidOperationException("System rozliczeń jest niedostępny");
            }

            var chargeId = "R-" + (++_lastChargeNumber);
            _journal.Add("Rozliczenie: " + chargeId + ", " + orderCode + ", " + clinic + ", " + amount.ToString("0.00") + " zł");
            return chargeId;
        }

        public void CancelCharge(string chargeId)
        {
            _journal.Add("Anulowanie rozliczenia: " + chargeId);
        }
    }
}
