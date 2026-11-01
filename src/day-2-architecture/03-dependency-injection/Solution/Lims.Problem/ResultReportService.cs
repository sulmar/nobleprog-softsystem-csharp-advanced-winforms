namespace Lims.Problem
{
    public class ResultReportService
    {
        // TODO: refaktoryzacja: wymienić zależności w konstruktorze.
        // PROBLEM: pusty konstruktor wygląda, jakby klasa nie potrzebowała niczego. Dopiero treść metody
        // zdradza dwie zależności, a brak jednej z nich wychodzi po kliknięciu „Raport dnia” (DIP).
        public string CreateDailyReport()
        {
            var settings = ServiceLocator.Get<LabSettings>();
            var log = ServiceLocator.Get<AuditLog>();

            return settings.LabName + ": wpisów w dzienniku " + log.Entries.Count;
        }
    }
}
