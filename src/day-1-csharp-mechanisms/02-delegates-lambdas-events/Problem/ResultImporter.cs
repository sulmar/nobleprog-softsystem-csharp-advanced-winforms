using System;
using System.Collections.Generic;
using System.IO;
using Lims.Domain;

namespace Lims.Problem
{
    internal static class ResultImporter
    {
        public static void Import(List<TestResult> incoming, List<TestResult> target, MainForm mainForm)
        {
            for (var i = 0; i < incoming.Count; i++)
            {
                target.Add(incoming[i]);

                // TODO: refaktoryzacja: wydzielić logowanie poza import.
                // PROBLEM: import jest uzależniony od jednego sposobu logowania (DIP). Log na ekranie
                // lub w bazie wymaga zmiany tej metody (OCP), a każdy test zapisze plik na dysku.
                // Importer oprócz logiki importu zawiera obsługę logowania (SRP).
                File.AppendAllText("import.log", "Zaimportowano: " + incoming[i].Analyte + Environment.NewLine);

                // TODO: refaktoryzacja: wydzielić raportowanie postępu poza import.
                // PROBLEM: import zna konkretny formularz (DIP), a bez niego trzeba przekazać null.
                // Inny sposób pokazywania postępu wymaga zmiany tej metody (OCP).
                mainForm?.ShowImportProgress(i + 1, incoming.Count);
            }
        }
    }
}
