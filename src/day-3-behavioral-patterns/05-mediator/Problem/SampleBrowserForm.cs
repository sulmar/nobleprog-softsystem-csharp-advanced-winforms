using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class SampleBrowserForm : Form
    {
        public SampleBrowserForm()
        {
            InitializeComponent();

            // TODO: refaktoryzacja: formularz ma tylko złożyć panele z jednym obiektem, który je koordynuje.
            // PROBLEM: trzy panele trzymają referencje do siebie nawzajem. Pominięcie jednej linii kończy się
            // wyjątkiem NullReferenceException dopiero po konkretnym kliknięciu (DIP).
            filtersPanel.List = samplesPanel;
            samplesPanel.Details = detailsPanel;
            detailsPanel.List = samplesPanel;

            filtersPanel.ApplyCurrentFilter();
        }
    }
}
