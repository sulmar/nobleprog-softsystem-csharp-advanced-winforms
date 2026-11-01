namespace Lims.Problem
{
    public sealed class SmsGateway
    {
        private readonly LabJournal _journal;

        public SmsGateway(LabJournal journal)
        {
            _journal = journal;
        }

        public void Send(string phone, string message)
        {
            _journal.Add("Powiadomienie: " + phone + ", " + message);
        }
    }
}
