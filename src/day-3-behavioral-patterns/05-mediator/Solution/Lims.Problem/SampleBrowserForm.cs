using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class SampleBrowserForm : Form
    {
        public SampleBrowserForm()
        {
            InitializeComponent();

            // TODO: refaktoryzacja: formularz ma tylko złożyć panele z jednym obiektem, który je koordynuje.
            // PROBLEM: siedem referencji między czterema panelami. Pominięcie jednej linii kończy się
            // wyjątkiem NullReferenceException dopiero po konkretnym kliknięciu (DIP).
            filtersPanel.List = samplesPanel;
            samplesPanel.Details = detailsPanel;
            samplesPanel.Actions = actionsPanel;
            detailsPanel.List = samplesPanel;
            detailsPanel.Actions = actionsPanel;
            actionsPanel.List = samplesPanel;
            actionsPanel.Details = detailsPanel;

            filtersPanel.ApplyCurrentFilter();
        }
    }
}
