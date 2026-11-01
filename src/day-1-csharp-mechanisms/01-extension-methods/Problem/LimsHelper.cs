using System.Reflection;
using System.Windows.Forms;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: zastąpić metodami rozszerzającymi.
    // PROBLEM: klasa "od wszystkiego" miesza kody kreskowe z kontrolkami (SRP). Wywołania
    // LimsHelper.Xxx(obiekt) nie widać w podpowiedziach na obiekcie, więc kod jest kopiowany (DRY).
    internal static class LimsHelper
    {
        public static string FormatBarcode(string code)
        {
            return "*" + code.Replace("-", string.Empty).ToUpperInvariant() + "*";
        }

        public static void EnableDoubleBuffering(DataGridView grid)
        {
            typeof(DataGridView)
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(grid, true, null);
        }
    }
}
