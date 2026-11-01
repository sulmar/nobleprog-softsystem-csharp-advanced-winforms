using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class ApprovalForm : Form
    {
        private readonly MainForm _mainForm;

        public ApprovalForm(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            RefreshPending();
        }

        // TODO: refaktoryzacja: zatwierdzenie w klasie bez okna, która ogłasza zdarzenie biznesowe ResultApproved.
        // PROBLEM: zdarzenie interfejsu (Click) robi wszystko: zmienia stan i wie, kto ma się o tym dowiedzieć (SRP).
        // Nowy odbiorca oznacza zmianę tej metody i dwóch kolejnych (OCP).
        private void ApproveButton_Click(object sender, EventArgs e)
        {
            var result = SelectedResult();
            if (result == null || string.IsNullOrWhiteSpace(approverTextBox.Text))
            {
                messageLabel.Text = "Wybierz wynik i podaj nazwisko.";
                return;
            }

            try
            {
                result.Status = LabResult.Approved;
                result.DecidedBy = approverTextBox.Text;

                // TODO: refaktoryzacja: zatwierdzający nie powinien znać odbiorców.
                // PROBLEM: okno zna listę, panel statystyk i pasek stanu, a listy szuka w Application.OpenForms
                // po typie, więc kompilator nie sprawdzi, że ktoś tego typu w ogóle istnieje (DIP).
                // Wyjątek jednego odbiorcy zatrzymuje kolejnych.
                var listForm = Application.OpenForms.OfType<ResultListForm>().FirstOrDefault();
                listForm?.RefreshList();
                _mainForm.StatisticsPanel.UpdateStatistics();
                _mainForm.ShowStatus("Zatwierdzono " + result.Code);
                LabData.RaiseResultChanged(result);

                messageLabel.Text = "Zatwierdzono " + result.Code;
            }
            catch (Exception exception)
            {
                // PROBLEM: stan jest już zmieniony, a użytkownik czyta, że się nie udało.
                messageLabel.Text = "Nie udało się zatwierdzić wyniku: " + exception.Message;
            }

            RefreshPending();
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            var result = SelectedResult();
            if (result == null || string.IsNullOrWhiteSpace(approverTextBox.Text))
            {
                messageLabel.Text = "Wybierz wynik i podaj nazwisko.";
                return;
            }

            result.Status = LabResult.Rejected;
            result.DecidedBy = approverTextBox.Text;

            // TODO: refaktoryzacja: jedna definicja tego, kto dowiaduje się o decyzji.
            // PROBLEM: kopia sekwencji z ApproveButton_Click, bez panelu statystyk i kontroli jakości (DRY).
            // Licznik „Odrzucone” jest więc nieaktualny, a kontrola jakości nie widzi odrzuceń.
            var listForm = Application.OpenForms.OfType<ResultListForm>().FirstOrDefault();
            listForm?.RefreshList();
            _mainForm.ShowStatus("Odrzucono " + result.Code);

            messageLabel.Text = "Odrzucono " + result.Code;
            RefreshPending();
        }

        private async void AutoApproveButton_Click(object sender, EventArgs e)
        {
            autoApproveButton.Enabled = false;
            try
            {
                // TODO: refaktoryzacja: automat ogłasza zdarzenie, a to odbiorca przechodzi na swój wątek.
                // PROBLEM: praca działa na wątku z puli, a sekwencja dotyka kontrolek, które należą do wątku
                // interfejsu. Pod debuggerem to InvalidOperationException, a bez niego zachowanie jest nieokreślone.
                await Task.Run(() =>
                {
                    var toApprove = LabData.Results
                        .Where(result => result.Status == LabResult.Pending && result.IsNumericAndInRange())
                        .ToList();

                    foreach (var result in toApprove)
                    {
                        result.Status = LabResult.Approved;
                        result.DecidedBy = "Automat";

                        var listForm = Application.OpenForms.OfType<ResultListForm>().FirstOrDefault();
                        listForm?.RefreshList();
                        _mainForm.StatisticsPanel.UpdateStatistics();
                        _mainForm.ShowStatus("Automat zatwierdził " + result.Code);
                        LabData.RaiseResultChanged(result);
                    }
                });

                messageLabel.Text = "Automat zakończył pracę.";
            }
            catch (Exception exception)
            {
                messageLabel.Text = "Automat przerwał pracę: " + exception.Message;
            }

            autoApproveButton.Enabled = true;
            RefreshPending();
        }

        private LabResult SelectedResult()
        {
            return pendingGrid.CurrentRow == null ? null : pendingGrid.CurrentRow.DataBoundItem as LabResult;
        }

        private void RefreshPending()
        {
            pendingGrid.DataSource = LabData.Results.Where(result => result.Status == LabResult.Pending).ToList();
        }
    }
}
