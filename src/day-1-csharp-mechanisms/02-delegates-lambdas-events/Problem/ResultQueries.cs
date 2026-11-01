using System.Collections.Generic;
using System.Text;
using Lims.Domain;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: warunek filtrowania jako parametr.
    // PROBLEM: każdy nowy filtr wymaga nowych metod dla wszystkich kombinacji (OCP),
    // a metody różnią się tylko warunkiem w "if" (DRY).
    internal static class ResultQueries
    {
        public static List<TestResult> GetAll(List<TestResult> results)
        {
            var matching = new List<TestResult>();
            foreach (var result in results)
            {
                matching.Add(result);
            }
            return matching;
        }

        public static List<TestResult> GetOutOfRange(List<TestResult> results)
        {
            var matching = new List<TestResult>();
            foreach (var result in results)
            {
                if (result.IsOutOfRange())
                {
                    matching.Add(result);
                }
            }
            return matching;
        }

        public static List<TestResult> GetForAnalyte(List<TestResult> results, string analyte)
        {
            var matching = new List<TestResult>();
            foreach (var result in results)
            {
                if (result.Analyte == analyte)
                {
                    matching.Add(result);
                }
            }
            return matching;
        }

        public static List<TestResult> GetOutOfRangeForAnalyte(List<TestResult> results, string analyte)
        {
            var matching = new List<TestResult>();
            foreach (var result in results)
            {
                if (result.Analyte == analyte && result.IsOutOfRange())
                {
                    matching.Add(result);
                }
            }
            return matching;
        }

        // TODO: refaktoryzacja: format wiersza jako parametr.
        // PROBLEM: nowy format to nowa metoda (OCP), a raporty różnią się tylko jednym wierszem (DRY).
        public static string BuildShortReport(List<TestResult> results)
        {
            var report = new StringBuilder();
            foreach (var result in results)
            {
                report.AppendLine(result.Analyte + ": " + result.Value);
            }
            return report.ToString();
        }

        public static string BuildFullReport(List<TestResult> results)
        {
            var report = new StringBuilder();
            foreach (var result in results)
            {
                report.AppendLine(result.SampleCode + " " + result.Analyte + ": " + result.Value + " " + result.Unit
                    + " (zakres " + result.ReferenceLow + " - " + result.ReferenceHigh + ")");
            }
            return report.ToString();
        }
    }
}
