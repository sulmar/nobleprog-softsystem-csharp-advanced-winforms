using System;
using System.Linq;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class BatchApprovalForm : Form
    {
        public BatchApprovalForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            ordersListBox.Items.Clear();
            ordersListBox.Items.AddRange(Lab.Orders.All().Where(order => order.Status == OrderStatus.Pending).Cast<object>().ToArray());
        }

        // TODO: refaktoryzacja: użyć tej samej procedury co pozostałe okna, osobno dla każdego zlecenia.
        // PROBLEM: trzecia kopia procedury, inna od dwóch poprzednich (DRY):
        // - rozliczenie jest przed zapisem,
        // - pacjent nie dostaje powiadomienia,
        // - etykieta ma inny format,
        // - błąd przy jednym zleceniu przerywa całą pętlę, a tamto zlecenie zostaje bez wpisu w audycie.
        private void ApproveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(approverTextBox.Text))
            {
                statusLabel.Text = "Podaj nazwisko zatwierdzającego";
                return;
            }

            var approver = approverTextBox.Text;
            var count = 0;

            foreach (Order order in ordersListBox.CheckedItems)
            {
                var now = DateTime.Now;
                Lab.Billing.Charge(order.Clinic, order.Code, order.Price);
                Lab.Orders.MarkApproved(order.Code, approver, now);
                Lab.Printer.Print(order.Code + "/" + order.Analyte);
                Lab.Audit.Record("Zatwierdzono zbiorczo", order.Code, approver, now);
                count++;
            }

            statusLabel.Text = "Zatwierdzono zleceń: " + count;
            LoadOrders();
        }
    }
}
