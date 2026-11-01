using System;
using System.Linq;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class ReceptionApprovalForm : Form
    {
        public ReceptionApprovalForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            orderComboBox.Items.Clear();
            orderComboBox.Items.AddRange(Lab.Orders.All().Where(order => order.Status == OrderStatus.Pending).Cast<object>().ToArray());
            orderComboBox.SelectedIndex = orderComboBox.Items.Count > 0 ? 0 : -1;
        }

        // TODO: refaktoryzacja: zastąpić całą sekwencję jednym wywołaniem prostej operacji poza oknem.
        // PROBLEM: formularz zna pięć podsystemów, ich kolejność i format tekstów (SRP, DIP). To najbardziej
        // kompletna kopia procedury, ale wciąż tylko jedna z trzech (DRY).
        private void ApproveButton_Click(object sender, EventArgs e)
        {
            var order = (Order)orderComboBox.SelectedItem;
            if (order == null)
            {
                statusLabel.Text = "Brak zleceń do zatwierdzenia";
                return;
            }

            if (string.IsNullOrWhiteSpace(approverTextBox.Text))
            {
                statusLabel.Text = "Podaj nazwisko zatwierdzającego";
                return;
            }

            var approver = approverTextBox.Text;
            var now = DateTime.Now;

            // TODO: refaktoryzacja: ustalić, co się dzieje, gdy krok w środku sekwencji się nie uda.
            // PROBLEM: brak obsługi błędu. Gdy drukarka nie ma papieru, zlecenie jest zatwierdzone i rozliczone,
            // pacjent nie dostaje powiadomienia, a użytkownik widzi nieobsłużony wyjątek.
            Lab.Orders.MarkApproved(order.Code, approver, now);
            Lab.Billing.Charge(order.Clinic, order.Code, order.Price);
            Lab.Audit.Record("Zatwierdzono zlecenie", order.Code, approver, now);
            Lab.Printer.Print(order.Code + " | " + order.PatientName + " | " + order.Analyte + (order.IsUrgent ? " | CITO" : ""));
            Lab.Sms.Send(order.PatientPhone, "Zlecenie " + order.Code + " (" + order.Analyte + ") przyjęte do realizacji.");

            statusLabel.Text = "Zatwierdzono " + order.Code;
            LoadOrders();
        }
    }
}
