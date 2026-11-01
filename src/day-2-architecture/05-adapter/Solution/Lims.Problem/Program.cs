using System;
using System.Windows.Forms;
using Vendor.Chemtron;
using Vendor.Hemolab;

namespace Lims.Problem
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            SetUpBench();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ResultCollectionForm());
        }

        // Symulacja szkoleniowa: włącza analizatory i wkłada do nich próbki.
        // W prawdziwym laboratorium tych linii nie ma, a bez nich analizatorów po prostu nie ma.
        private static void SetUpBench()
        {
            HemolabBench.PowerOn("COM3");
            HemolabBench.LoadSample("COM3", "S-1001", 5.50m);
            HemolabBench.LoadSample("COM3", "S-1002", 13.88m);
            HemolabBench.LoadSample("COM3", "S-1003", 3.05m);
            HemolabBench.LoadSample("COM3", "KONTROLA", 5.00m);
            HemolabBench.BusyOnSample("COM3", "S-2000");

            ChemtronBench.PowerOn("192.168.0.20");
            ChemtronBench.LoadSample("192.168.0.20", "S-1001", 99m);
            ChemtronBench.LoadSample("192.168.0.20", "S-1002", 250m);
            ChemtronBench.LoadSample("192.168.0.20", "S-1003", 55m);
            ChemtronBench.LoadSample("192.168.0.20", "KONTROLA", 90m);
            ChemtronBench.BusyOnSample("192.168.0.20", "S-2000");
        }
    }
}
