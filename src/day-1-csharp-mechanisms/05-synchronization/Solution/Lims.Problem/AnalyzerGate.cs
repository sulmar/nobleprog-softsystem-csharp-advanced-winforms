using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lims.Problem
{
    /// <summary>Analizator przyjmuje naraz tylko dwie próbki, ale nic tego nie pilnuje.</summary>
    internal class AnalyzerGate
    {
        private int _running;
        private int _maxObserved;

        public int MaxObserved
        {
            get { return _maxObserved; }
        }

        public async Task AnalyzeAsync(Func<Task> work)
        {
            // TODO: naprawić błąd: ograniczyć liczbę próbek w analizatorze do dwóch.
            // PROBLEM: wszystkie próbki trafiają do analizatora naraz. Zwykłe lock tu nie pomoże,
            // bo wewnątrz niego nie wolno użyć await (CS1996).
            var running = Interlocked.Increment(ref _running);
            UpdateMax(running);

            await work();

            Interlocked.Decrement(ref _running);
        }

        private void UpdateMax(int running)
        {
            int current;
            do
            {
                current = _maxObserved;
            }
            while (running > current && Interlocked.CompareExchange(ref _maxObserved, running, current) != current);
        }
    }
}
