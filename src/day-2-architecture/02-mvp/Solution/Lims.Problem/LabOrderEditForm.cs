using System;
using System.Windows.Forms;
using Lims.Problem.Model;

namespace Lims.Problem
{
    // TODO: refaktoryzacja: przenieść logikę prezentacji poza formularz, za interfejs widoku.
    // PROBLEM: reguły są już w Modelu, ale formularz nadal decyduje, co włączyć, kiedy można zapisać,
    // jaki komunikat pokazać i co zrobić przy zamykaniu (SRP). Żadnej z tych decyzji nie da się
    // sprawdzić testem, bo wszystkie czytają i zmieniają kontrolki.
    public partial class LabOrderEditForm : Form
    {
        private readonly LabOrderService _service;
        private readonly string _orderCode;

        // TODO: refaktoryzacja: wyliczać „czy są zmiany” z wartości pól.
        // PROBLEM: stan zgaduje się ze zdarzeń kontrolek, a te same zdarzenia zgłasza też kod,
        // który wypełnia pola. Stąd dodatkowa flaga _loading, o której łatwo zapomnieć.
        private bool _dirty;
        private bool _loading;

        public LabOrderEditForm(LabOrderService service, string orderCode)
        {
            InitializeComponent();

            _service = service;
            _orderCode = orderCode;

            foreach (var analyte in LabOrderRules.Analytes)
            {
                analyteComboBox.Items.Add(analyte);
            }

            priorityComboBox.Items.AddRange(new object[] { "Zwykłe", "Pilne", "Cito" });

            LoadOrder();
        }

        internal static string StatusText(OrderStatus status)
        {
            // TODO: refaktoryzacja: przenieść teksty statusów poza formularz.
            // PROBLEM: tekst dla użytkownika to część zachowania ekranu, a tu da się go sprawdzić tylko w oknie.
            switch (status)
            {
                case OrderStatus.New: return "Nowe";
                case OrderStatus.InProgress: return "W realizacji";
                case OrderStatus.Completed: return "Zakończone";
                default: return "Anulowane";
            }
        }

        private void LoadOrder()
        {
            var order = _service.Find(_orderCode);

            _loading = true;
            codeValueLabel.Text = order.Code;
            patientValueLabel.Text = order.PatientName;
            statusValueLabel.Text = StatusText(order.Status);
            analyteComboBox.SelectedItem = order.Analyte;
            priorityComboBox.SelectedIndex = (int)order.Priority;
            physicianTextBox.Text = order.Physician;
            notesTextBox.Text = order.Notes;
            _loading = false;

            // TODO: refaktoryzacja: ustalać stan pól w jednym miejscu.
            // PROBLEM: ta decyzja żyje tylko tutaj, więc anulowanie zlecenia jej nie powtarza (DRY).
            analyteComboBox.Enabled = order.CanChangeAnalyte;
            priorityComboBox.Enabled = order.CanEdit;
            physicianTextBox.Enabled = order.CanEdit;
            notesTextBox.Enabled = order.CanEdit;
            cancelOrderButton.Enabled = order.CanCancel;

            if (order.Status == OrderStatus.InProgress)
            {
                messageLabel.Text = "Zlecenie w realizacji: nie można zmienić badania";
            }
            else if (!order.CanEdit)
            {
                messageLabel.Text = "Zlecenie " + StatusText(order.Status).ToLower() + ": tylko do odczytu";
            }

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            // TODO: refaktoryzacja: jedna definicja warunku zapisu.
            // PROBLEM: stan zlecenia odczytywany z kontrolki (Enabled), a część walidacji to kopia reguły
            // z Modelu, która pomija „Cito wymaga uwag” (DRY). Przycisk jest aktywny, a zapis i tak odmawia.
            saveButton.Enabled = _dirty && physicianTextBox.Enabled && physicianTextBox.Text.Trim().Length > 0;
            Text = "Zlecenie " + _orderCode + (_dirty ? " *" : "");
        }

        // Podpięte do badania, lekarza i uwag.
        private void Field_Changed(object sender, EventArgs e)
        {
            if (_loading)
            {
                return;
            }

            // TODO: refaktoryzacja: porównywać pola z zapisanym zleceniem.
            // PROBLEM: flaga umie się tylko włączyć. Wpisanie litery i jej usunięcie nadal oznacza „zmiany”.
            _dirty = true;
            UpdateButtons();
        }

        private void Priority_SelectedIndexChanged(object sender, EventArgs e)
        {
            notesHintLabel.Visible = (string)priorityComboBox.SelectedItem == "Cito";

            // TODO: refaktoryzacja: usunąć potrzebę sprawdzania _loading.
            // PROBLEM: tu zabrakło sprawdzenia _loading, więc samo wczytanie zlecenia ustawia _dirty.
            // Zapisz jest aktywny, a zamknięcie pyta o zmiany, chociaż nikt nic nie zmienił.
            _dirty = true;
            UpdateButtons();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var result = _service.Save(_orderCode, new OrderChanges
            {
                Analyte = (string)analyteComboBox.SelectedItem,
                Priority = (OrderPriority)priorityComboBox.SelectedIndex,
                Physician = physicianTextBox.Text,
                Notes = notesTextBox.Text
            });

            if (!result.IsSuccess)
            {
                messageLabel.Text = string.Join(", ", result.Errors);
                return;
            }

            _dirty = false;
            messageLabel.Text = "Zapisano zmiany";
            UpdateButtons();
        }

        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: pytanie za interfejsem widoku.
            // PROBLEM: MessageBox zatrzymałby każdy test tej metody, czekając na kliknięcie.
            var answer = MessageBox.Show(this, "Anulować to zlecenie?", "Anulowanie zlecenia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            var result = _service.Cancel(_orderCode);
            if (!result.IsSuccess)
            {
                messageLabel.Text = string.Join(", ", result.Errors);
                return;
            }

            // TODO: refaktoryzacja: po anulowaniu przeliczyć cały stan formularza.
            // PROBLEM: kopia fragmentu LoadOrder, w której brakuje pól (DRY). Anulowane zlecenie
            // nadal można edytować, a Zapisz kończy się odmową z Modelu.
            statusValueLabel.Text = StatusText(OrderStatus.Cancelled);
            cancelOrderButton.Enabled = false;
            messageLabel.Text = "Zlecenie anulowano";
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LabOrderEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_dirty)
            {
                return;
            }

            var answer = MessageBox.Show(this, "Zlecenie ma niezapisane zmiany. Zapisać przed zamknięciem?", "Niezapisane zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (answer == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (answer == DialogResult.Yes)
            {
                // TODO: refaktoryzacja: zamknąć okno tylko wtedy, gdy zapis się udał.
                // PROBLEM: handler przycisku nie zwraca wyniku. Gdy zapis się nie uda, okno i tak się
                // zamyka, a użytkownik traci wpisane dane, choć wybrał „Tak”.
                SaveButton_Click(sender, EventArgs.Empty);
            }
        }
    }
}
