using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class MicrobiologyResultForm : Form
    {
        private readonly LabOrder _order;

        public MicrobiologyResultForm(LabOrder order)
        {
            InitializeComponent();
            _order = order;
            Text = "Posiew mikrobiologiczny: " + order.Code;
        }

        // TODO: refaktoryzacja: wspólna walidacja i zapis poza oknem, a reguła weryfikacji poza formularzem.
        // PROBLEM: reguła „wynik posiewu czeka na weryfikację” jest zaszyta w kodzie okna (SRP),
        // więc nie da się jej sprawdzić testem.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(organismTextBox.Text)
                || string.IsNullOrWhiteSpace(colonyCountTextBox.Text)
                || string.IsNullOrWhiteSpace(antibiogramTextBox.Text))
            {
                MessageBox.Show(this, "Uzupełnij wszystkie pola.", "Wyniki");
                return;
            }

            _order.RecordResults(
                new[]
                {
                    new ResultValue("Drobnoustrój", organismTextBox.Text),
                    new ResultValue("Miano", colonyCountTextBox.Text),
                    new ResultValue("Antybiogram", antibiogramTextBox.Text)
                },
                OrderStatus.AwaitingVerification);

            DialogResult = DialogResult.OK;
        }
    }
}
