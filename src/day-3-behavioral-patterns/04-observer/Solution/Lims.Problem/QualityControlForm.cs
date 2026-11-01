using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class QualityControlForm : Form
    {
        public QualityControlForm()
        {
            InitializeComponent();

            // TODO: refaktoryzacja: subskrypcja zwalniana razem z oknem.
            // PROBLEM: nikt nie wywołuje -=, a lambdy i tak nie dałoby się łatwo wypisać. LabData.ResultChanged
            // trzyma lambdę, a lambda trzyma okno, więc zamknięte okno zostaje w pamięci i dalej dostaje powiadomienia.
            LabData.ResultChanged += result =>
            {
                if (IsDisposed)
                {
                    LabData.DeliveriesToClosedWindows++;
                    return;
                }

                logListBox.Items.Add(result.Code + ": " + result.Analyte + " = " + result.ValueText + ", " + result.DecidedBy);
            };
        }
    }
}
