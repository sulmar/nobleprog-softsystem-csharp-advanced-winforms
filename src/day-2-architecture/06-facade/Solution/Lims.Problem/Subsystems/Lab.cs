namespace Lims.Problem
{
    // TODO: refaktoryzacja: formularze mają dostać jedną prostą operację zamiast dostępu do pięciu podsystemów.
    // PROBLEM: każdy formularz sięga bezpośrednio po wszystkie podsystemy (DIP), więc kolejności kroków
    // nie da się sprawdzić testem ani zmienić w jednym miejscu.
    public static class Lab
    {
        public static readonly LabJournal Journal = new LabJournal();
        public static readonly OrderDatabase Orders = new OrderDatabase(Journal);
        public static readonly BillingSystem Billing = new BillingSystem(Journal);
        public static readonly AuditLog Audit = new AuditLog(Journal);
        public static readonly LabelPrinter Printer = new LabelPrinter(Journal);
        public static readonly SmsGateway Sms = new SmsGateway(Journal);
    }
}
