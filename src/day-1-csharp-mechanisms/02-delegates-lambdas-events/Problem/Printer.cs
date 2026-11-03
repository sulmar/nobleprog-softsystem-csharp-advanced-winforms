using System;

namespace Lims.Problem
{
    internal class Printer
    {
        // TODO: refaktoryzacja: ogłaszać zakończenie drukowania zdarzeniem.
        // PROBLEM: drukarka zna konkretny formularz (DIP). Każdy nowy odbiorca, np. rozliczenia,
        // wymaga zmiany tej klasy (OCP), a powiadamianie nie jest jej zadaniem (SRP).
        public MainForm MainForm { get; set; }

        // TODO: refaktoryzacja: zamienić pole na zdarzenie.
        // PROBLEM: publiczne pole delegata zamiast zdarzenia. Z zewnątrz można je wywołać,
        // ogłaszając wydruk, którego nie było, albo napisać "=" zamiast "+=", co usunie pozostałych odbiorców.
        public Action<string, int> PrintCompleted;

        public int PrintedCopies { get; private set; }

        public int SubscriberCount
        {
            get { return PrintCompleted == null ? 0 : PrintCompleted.GetInvocationList().Length; }
        }

        public decimal Print(string document, int copies, Func<int, decimal> calculateCost)
        {
            // Wydruk jest tu symulowany: liczy się podział odpowiedzialności, nie sam sprzęt.
            PrintedCopies += copies;

            MainForm?.AddLogEntry("Wydrukowano: " + document + ", kopie: " + copies);

            if (PrintCompleted != null)
            {
                PrintCompleted(document, copies);
            }

            // TODO: refaktoryzacja: wynieść obliczanie kosztu poza klasę drukarki.
            // PROBLEM: drukarka oprócz drukowania zna cennik (SRP). Nowy cennik, np. dla klienta
            // z umową, wymaga zmiany tej klasy (OCP), a drukarka zależy od jednego cennika (DIP).
            if (copies >= 100)
            {
                return copies * 0.05m;
            }

            if (copies >= 10)
            {
                return copies * 0.08m;
            }

            return copies * 0.10m;
        }
    }
}
