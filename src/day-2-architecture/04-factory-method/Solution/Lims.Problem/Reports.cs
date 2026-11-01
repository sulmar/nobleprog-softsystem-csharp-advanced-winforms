using System.Collections.Generic;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: wspólna abstrakcja raportu.
    // PROBLEM: raporty mają te same składowe, ale nic ich nie łączy, więc każde miejsce użycia
    // musi znać konkretną klasę i wybierać ją własnym switchem (DIP).
    public class BloodReport
    {
        private static readonly Dictionary<string, string> ReferenceRanges = new Dictionary<string, string>
        {
            { "Hemoglobina", "12–16 g/dL" },
            { "Leukocyty", "4–10 tys./µl" }
        };

        public string Title
        {
            get { return "Raport: morfologia krwi"; }
        }

        public IEnumerable<string> BodyLines(LabOrder order)
        {
            foreach (var result in order.Results)
            {
                string range;
                if (!ReferenceRanges.TryGetValue(result.Name, out range))
                {
                    range = "brak";
                }

                yield return result.Name + ": " + result.Value + " (norma: " + range + ")";
            }
        }
    }

    public class UrineReport
    {
        public string Title
        {
            get { return "Raport: badanie ogólne moczu"; }
        }

        public IEnumerable<string> BodyLines(LabOrder order)
        {
            foreach (var result in order.Results)
            {
                yield return result.Name + ": " + result.Value;
            }
        }
    }

    public class MicrobiologyReport
    {
        public string Title
        {
            get { return "Raport: posiew mikrobiologiczny"; }
        }

        public IEnumerable<string> BodyLines(LabOrder order)
        {
            foreach (var result in order.Results)
            {
                yield return result.Name + ": " + result.Value;
            }

            if (order.Status == OrderStatus.AwaitingVerification)
            {
                yield return "Uwaga: wynik wstępny, czeka na weryfikację.";
            }
        }
    }
}
