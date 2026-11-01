using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lims.Problem
{
    internal static class CsvExports
    {
        // TODO: refaktoryzacja: jeden eksport dla dowolnego modelu.
        // PROBLEM: każdy model ma własną metodę z tą samą pętlą (DRY). Nowy model to nowa metoda,
        // a nowa właściwość to zmiana nagłówka i wiersza w kilku miejscach (OCP).
        public static string Samples(IEnumerable<Sample> samples)
        {
            var csv = new StringBuilder();

            // TODO: naprawić błąd: nie eksportować numeru PESEL jawnym tekstem.
            // PROBLEM: dane wrażliwe trafiają do pliku, bo eksport zna tylko listę kolumn, a nie ich znaczenie.
            csv.AppendLine("Kod;PESEL;Materiał;Status;Termin");

            foreach (var sample in samples)
            {
                csv.AppendLine(sample.Code + ";" + sample.PatientPesel + ";" + sample.Material + ";"
                    + StatusForExport(sample.Status) + ";" + sample.DueAt.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
            }

            return csv.ToString();
        }

        public static string Results(IEnumerable<TestResult> results)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Próbka;Oznaczenie;Wynik;Jednostka");

            foreach (var result in results)
            {
                csv.AppendLine(result.SampleCode + ";" + result.Analyte + ";"
                    + result.Value.ToString(CultureInfo.InvariantCulture) + ";" + result.Unit);
            }

            return csv.ToString();
        }

        // TODO: naprawić błąd: jedna definicja tekstów statusów.
        // PROBLEM: druga kopia switch z MainForm, z innymi tekstami (DRY). Nowy status Archived
        // nie został tu dopisany, więc trafia do pliku jako znak zapytania (OCP).
        private static string StatusForExport(SampleStatus status)
        {
            switch (status)
            {
                case SampleStatus.Registered: return "Zarejestrowana";
                case SampleStatus.InAnalysis: return "W analizie";
                case SampleStatus.Approved: return "Zatwierdz.";
                case SampleStatus.Rejected: return "Odrzucona";
                default: return "?";
            }
        }
    }
}
