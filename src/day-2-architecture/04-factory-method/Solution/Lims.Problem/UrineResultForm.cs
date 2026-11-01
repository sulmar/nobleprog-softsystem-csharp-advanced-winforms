using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class UrineResultForm : Form
    {
        private readonly LabOrder _order;

        public UrineResultForm(LabOrder order)
        {
            InitializeComponent();
            _order = order;
            Text = "Badanie ogólne moczu: " + order.Code;
            colorComboBox.SelectedIndex = 0;
        }

        // TODO: refaktoryzacja: wspólna walidacja i zapis poza oknem.
        // PROBLEM: kopia kodu z BloodResultForm.SaveButton_Click, różnią się tylko pola (DRY).
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(phTextBox.Text)
                || string.IsNullOrWhiteSpace(proteinTextBox.Text))
            {
                MessageBox.Show(this, "Uzupełnij wszystkie pola.", "Wyniki");
                return;
            }

            _order.RecordResults(
                new[]
                {
                    new ResultValue("pH", phTextBox.Text),
                    new ResultValue("Barwa", (string)colorComboBox.SelectedItem),
                    new ResultValue("Białko", proteinTextBox.Text)
                },
                OrderStatus.ResultsEntered);

            DialogResult = DialogResult.OK;
        }
    }
}
