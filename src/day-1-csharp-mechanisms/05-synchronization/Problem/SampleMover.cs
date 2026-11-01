using System.Collections.Generic;
using System.Threading;

namespace Lims.Problem
{
    public class Rack
    {
        public Rack(string code, IEnumerable<string> samples)
        {
            Code = code;
            Samples = new List<string>(samples);
        }

        public string Code { get; }
        public List<string> Samples { get; }
    }

    internal static class SampleMover
    {
        public static void Move(Rack from, Rack to)
        {
            // TODO: naprawić błąd: zawsze zajmować statywy w tej samej kolejności.
            // PROBLEM: jeden wątek zajmuje statyw A i czeka na B, a drugi zajmuje B i czeka na A.
            // Żaden nie ustąpi, więc oba czekają na zawsze: to zakleszczenie.
            lock (from)
            {
                // Symulacja wyjęcia próbki. Poszerza okno, w którym dochodzi do zakleszczenia.
                Thread.Sleep(1);

                lock (to)
                {
                    if (from.Samples.Count > 0)
                    {
                        var sample = from.Samples[0];
                        from.Samples.RemoveAt(0);
                        to.Samples.Add(sample);
                    }
                }
            }
        }
    }
}
