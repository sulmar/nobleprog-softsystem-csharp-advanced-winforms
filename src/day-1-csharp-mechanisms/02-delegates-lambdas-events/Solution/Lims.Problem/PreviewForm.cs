using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class PreviewForm : Form
    {
        // TODO: refaktoryzacja: przekazać sposób logowania jako delegat.
        // PROBLEM: okno podglądu zna MainForm (DIP) tylko po to, by dopisać wpis do logu.
        internal PreviewForm(Printer printer, int number, MainForm mainForm)
        {
            InitializeComponent();

            Text = "Podgląd wydruków #" + number;

            // TODO: naprawić błąd: usuwać subskrypcję przy zamknięciu okna.
            // PROBLEM: subskrypcja nigdy nie jest usuwana. Drukarka żyje dłużej niż okno i przez delegat trzyma
            // do niego referencję, więc zamknięte okno zostaje w pamięci i nadal reaguje na każdy wydruk.
            printer.PrintCompleted += (document, copies) =>
            {
                mainForm.AddLogEntry("Podgląd #" + number + " obsłużył wydruk: " + document);
                lastPrintLabel.Text = "Ostatni wydruk: " + document + ", kopie: " + copies;
            };
        }
    }
}
