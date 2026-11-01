using System;
using System.Linq;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class UrgentApprovalForm : Form
    {
        public UrgentApprovalForm()
        {
            InitializeComponent();

            // Lista celowo zawiera wszystkie zlecenia Cito, także już zatwierdzone: patrz komentarz w handlerze.
            orderComboBox.Items.AddRange(Lab.Orders.All().Where(order => order.IsUrgent).Cast<object>().ToArray());
            orderComboBox.SelectedIndex = orderComboBox.Items.Count > 0 ? 0 : -1;
        }

        // TODO: refaktoryzacja: użyć tej samej procedury co pozostałe okna.
        // PROBLEM: kopia procedury „na szybko” różni się od oryginału (DRY):
        // - brak wpisu w audycie, więc po zleceniu Cito nie ma śladu, kto je zatwierdził,
        // - powiadomienie idzie jako pierwsze, zanim cokolwiek zostało zapisane,
        // - brak sprawdzenia statusu, więc drugie kliknięcie rozlicza zlecenie drugi raz.
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

            try
            {
                Lab.Sms.Send(order.PatientPhone, "Zlecenie " + order.Code + " przyjęte do realizacji.");
                Lab.Orders.MarkApproved(order.Code, approver, DateTime.Now);
                Lab.Printer.Print(order.Code + " | " + order.PatientName + " | " + order.Analyte + " | CITO");
                Lab.Billing.Charge(order.Clinic, order.Code, order.Price);

                statusLabel.Text = "Zatwierdzono " + order.Code;
            }
            catch (Exception)
            {
                // TODO: refaktoryzacja: wynik musi mówić, co się udało, a co trzeba jeszcze zrobić.
                // PROBLEM: komunikat jest nieprawdziwy. Pacjent dostał już SMS, a zlecenie jest zatwierdzone,
                // tylko nierozliczone. Ponowienie wyśle kolejny SMS.
                statusLabel.Text = "Nie udało się zatwierdzić zlecenia " + order.Code;
            }
        }
    }
}
