using System;
using System.Threading.Tasks;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: analizator za interfejsem, aby test sam decydował, kiedy praca się kończy.
    // PROBLEM: klasa statyczna z opóźnieniem (DIP). Nie da się sprawdzić, co dzieje się w trakcie pracy.
    internal static class AnalyzerClient
    {
        public static int OrdersSent { get; private set; }

        public static async Task<decimal> RetestAsync(string sampleCode)
        {
            OrdersSent++;
            await Task.Delay(3000);

            if (sampleCode == "P-1003")
            {
                throw new InvalidOperationException("Analizator odrzucił próbkę " + sampleCode + ": skrzep w materiale.");
            }

            return sampleCode == "P-1002" ? 4.3m : 95m;
        }
    }
}
