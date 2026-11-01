using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class BloodResultForm : Form
    {
        private readonly LabOrder _order;

        public BloodResultForm(LabOrder order)
        {
            InitializeComponent();
            _order = order;
            Text = "Morfologia krwi: " + order.Code;
        }

        // TODO: refaktoryzacja: wspólna walidacja i zapis poza oknem.
        // PROBLEM: ta sama walidacja i zapis są skopiowane do każdego okna wyników (DRY),
        // a sprawdzić je można tylko, otwierając okno.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hemoglobinTextBox.Text)
                || string.IsNullOrWhiteSpace(leukocytesTextBox.Text))
            {
                MessageBox.Show(this, "Uzupełnij wszystkie pola.", "Wyniki");
                return;
            }

            _order.RecordResults(
                new[]
                {
                    new ResultValue("Hemoglobina", hemoglobinTextBox.Text),
                    new ResultValue("Leukocyty", leukocytesTextBox.Text)
                },
                OrderStatus.ResultsEntered);

            DialogResult = DialogResult.OK;
        }
    }
}
