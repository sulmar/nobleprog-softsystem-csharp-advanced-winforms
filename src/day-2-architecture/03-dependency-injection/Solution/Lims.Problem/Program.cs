using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // TODO: refaktoryzacja: złożyć tu całą aplikację, a nie tylko ten jeden wpis.
            // PROBLEM: lista rejestracji nie wynika z żadnego kodu, więc łatwo o niej zapomnieć. Brakuje
            // tu AuditLog i dowiemy się o tym dopiero po kliknięciu „Raport dnia” (DIP).
            ServiceLocator.Register(LabSettings.Instance);

            Application.Run(new ResultsForm());
        }
    }
}
