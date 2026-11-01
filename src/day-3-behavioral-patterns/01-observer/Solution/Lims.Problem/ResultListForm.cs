using System.Linq;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class ResultListForm : Form
    {
        public ResultListForm()
        {
            InitializeComponent();
            RefreshList();
        }

        // TODO: refaktoryzacja: okno samo reaguje na decyzję o wyniku i przestaje mieć publiczne metody do odświeżania.
        // PROBLEM: publiczna metoda istnieje tylko po to, by inne okna mogły ją wywołać (DIP).
        public void RefreshList()
        {
            resultsGrid.DataSource = LabData.Results.ToList();
        }
    }
}
