using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class ResultReviewForm : Form
    {
        public ResultReviewForm()
        {
            InitializeComponent();

            userComboBox.Items.AddRange(new object[] { "A. Nowak (laborant)", "E. Wiśniewska (kierownik)" });
            userComboBox.SelectedIndex = 0;

            foreach (var result in LabData.Results)
            {
                var index = resultsGrid.Rows.Add();
                resultsGrid.Rows[index].Tag = result;
            }

            RefreshGrid();
            RefreshButtons();
            RefreshMenu();
        }

        private bool IsSupervisor
        {
            get { return userComboBox.SelectedIndex == 1; }
        }

        private string UserName
        {
            get { return IsSupervisor ? "E. Wiśniewska" : "A. Nowak"; }
        }

        private LabResult CurrentResult()
        {
            return resultsGrid.CurrentRow == null ? null : resultsGrid.CurrentRow.Tag as LabResult;
        }

        private void RefreshGrid()
        {
            foreach (DataGridViewRow row in resultsGrid.Rows)
            {
                var result = (LabResult)row.Tag;
                row.Cells[0].Value = result.SampleCode;
                row.Cells[1].Value = result.Analyte;
                row.Cells[2].Value = result.Value.ToString("0.0") + " " + result.Unit;
                row.Cells[3].Value = result.IsCritical ? "Tak" : "";
                row.Cells[4].Value = StatusText(result.Status);
                row.Cells[5].Value = result.ReviewedBy;
            }

            ordersLabel.Text = "Zleceń wysłanych do analizatora: " + AnalyzerClient.OrdersSent;
        }

        private static string StatusText(ResultStatus status)
        {
            switch (status)
            {
                case ResultStatus.Approved: return "Zatwierdzony";
                case ResultStatus.Rejected: return "Odrzucony";
                default: return "Do oceny";
            }
        }

        private void ResultReviewForm_Shown(object sender, EventArgs e)
        {
            RefreshButtons();
            RefreshMenu();
        }

        private void ResultsGrid_SelectionChanged(object sender, EventArgs e)
        {
            RefreshButtons();
            RefreshMenu();
        }

        private void UserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshMenu();
        }

        // TODO: refaktoryzacja: jedna definicja dostępności każdej operacji.
        // PROBLEM: warunki dla przycisków są inne niż w RefreshMenu (DRY). Przycisk „Zatwierdź” nie zna
        // reguły o wyniku krytycznym, więc przy P-1002 laborant widzi aktywny przycisk i nieaktywne menu.
        private void RefreshButtons()
        {
            var result = CurrentResult();
            approveButton.Enabled = result != null && result.Status == ResultStatus.Pending;
            rejectButton.Enabled = result != null && result.Status == ResultStatus.Pending;
            retestButton.Enabled = result != null && result.Status != ResultStatus.Approved;
        }

        // TODO: refaktoryzacja: odświeżać wszystkie miejsca po każdej zmianie, a nie wybrane.
        // PROBLEM: druga kopia warunków. Każdy handler musi pamiętać, co odświeżyć, a pamięta tylko swoje.
        private void RefreshMenu()
        {
            var result = CurrentResult();
            approveMenuItem.Enabled = result != null && result.Status == ResultStatus.Pending && (!result.IsCritical || IsSupervisor);
            rejectMenuItem.Enabled = result != null && result.Status == ResultStatus.Pending;
            retestMenuItem.Enabled = result != null && result.Status != ResultStatus.Approved;
        }

        // TODO: refaktoryzacja: operacja zatwierdzenia jako jeden obiekt, wywoływany z każdego miejsca.
        // PROBLEM: trzy kopie tej samej operacji: przycisk, menu i skrót (DRY). Odświeża tylko przyciski,
        // więc menu pozostaje aktywne. Reguły nie da się przetestować bez okna.
        private void ApproveButton_Click(object sender, EventArgs e)
        {
            var result = CurrentResult();
            if (result == null)
            {
                return;
            }

            result.Status = ResultStatus.Approved;
            result.ReviewedBy = UserName;
            result.ReviewedAt = DateTime.Now;

            RefreshGrid();
            RefreshButtons();
        }

        // TODO: refaktoryzacja: usunąć tę kopię, gdy zatwierdzanie będzie jednym obiektem.
        // PROBLEM: ta kopia jako jedyna sprawdza regułę o wyniku krytycznym i odświeża tylko menu,
        // więc przycisk pozostaje aktywny, a jego kliknięcie nadpisuje osobę i godzinę zatwierdzenia.
        private void ApproveMenuItem_Click(object sender, EventArgs e)
        {
            var result = CurrentResult();
            if (result == null)
            {
                return;
            }

            if (result.IsCritical && !IsSupervisor)
            {
                statusLabel.Text = "Wynik krytyczny może zatwierdzić tylko kierownik.";
                return;
            }

            result.Status = ResultStatus.Approved;
            result.ReviewedBy = UserName;
            result.ReviewedAt = DateTime.Now;

            RefreshGrid();
            RefreshMenu();
        }

        // TODO: refaktoryzacja: odrzucanie jako jeden obiekt, wywoływany z każdego miejsca.
        // PROBLEM: dwie kopie tej samej operacji, a trzecia jest w skrócie F7 (DRY). Każda odświeża tylko siebie.
        private void RejectButton_Click(object sender, EventArgs e)
        {
            var result = CurrentResult();
            if (result == null)
            {
                return;
            }

            result.Status = ResultStatus.Rejected;
            result.ReviewedBy = UserName;
            result.ReviewedAt = DateTime.Now;

            RefreshGrid();
            RefreshButtons();
        }

        private void RejectMenuItem_Click(object sender, EventArgs e)
        {
            var result = CurrentResult();
            if (result == null)
            {
                return;
            }

            result.Status = ResultStatus.Rejected;
            result.ReviewedBy = UserName;
            result.ReviewedAt = DateTime.Now;

            RefreshGrid();
            RefreshMenu();
        }

        // TODO: refaktoryzacja: skrót ma wywoływać tę samą operację co przycisk i menu.
        // PROBLEM: skrót ma własne warunki (DRY). Pomija regułę o wyniku krytycznym, a F6 i F7
        // zmieniają też wynik ocenionego wcześniej. Niczego nie odświeża.
        private void ResultReviewForm_KeyDown(object sender, KeyEventArgs e)
        {
            var result = CurrentResult();
            if (result == null)
            {
                return;
            }

            if (e.KeyCode == Keys.F6)
            {
                result.Status = ResultStatus.Approved;
                result.ReviewedBy = UserName;
                result.ReviewedAt = DateTime.Now;
                RefreshGrid();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F7)
            {
                result.Status = ResultStatus.Rejected;
                result.ReviewedBy = UserName;
                result.ReviewedAt = DateTime.Now;
                RefreshGrid();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F8)
            {
                RetestFromKeyboard();
                e.Handled = true;
            }
        }

        // TODO: refaktoryzacja: jedna blokada na czas pracy i jedna obsługa błędów.
        // PROBLEM: blokuje tylko ten przycisk, więc menu i skrót wysyłają kolejne zlecenia. Podczas pracy
        // można też zatwierdzić wynik. Po await czyta bieżące zaznaczenie, więc nowa wartość trafia do
        // wiersza, na którym użytkownik akurat stoi, a nie do badanej próbki.
        private async void RetestButton_Click(object sender, EventArgs e)
        {
            var result = CurrentResult();
            if (result == null)
            {
                return;
            }

            retestButton.Enabled = false;
            statusLabel.Text = "Analizator pracuje...";

            try
            {
                var task = AnalyzerClient.RetestAsync(result.SampleCode);
                RefreshGrid();
                var value = await task;

                var target = CurrentResult();
                target.Value = value;
                target.Status = ResultStatus.Pending;
                statusLabel.Text = "Powtórzono badanie.";
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Błąd: " + ex.Message;
            }
            finally
            {
                RefreshGrid();
                RefreshButtons();
            }
        }

        // TODO: refaktoryzacja: błędy obsłużyć w jednym miejscu, a async void zostawić tylko w handlerze.
        // PROBLEM: async void bez try/catch. Wyjątek z analizatora nie ma tu kto złapać, więc trafia
        // do kontekstu synchronizacji i kończy się oknem błędu aplikacji (Dzień 1, moduł 4).
        private async void RetestMenuItem_Click(object sender, EventArgs e)
        {
            var result = CurrentResult();
            if (result == null)
            {
                return;
            }

            statusLabel.Text = "Analizator pracuje...";
            var task = AnalyzerClient.RetestAsync(result.SampleCode);
            RefreshGrid();
            var value = await task;

            result.Value = value;
            result.Status = ResultStatus.Pending;
            statusLabel.Text = "Powtórzono badanie.";
            RefreshGrid();
            RefreshMenu();
        }

        // TODO: refaktoryzacja: skrót ma uruchamiać tę samą operację co przycisk i menu.
        // PROBLEM: trzecia kopia, bez warunków, blokady i obsługi błędów. Powtarza też wynik zatwierdzony.
        private async void RetestFromKeyboard()
        {
            var result = CurrentResult();
            statusLabel.Text = "Analizator pracuje...";
            var task = AnalyzerClient.RetestAsync(result.SampleCode);
            RefreshGrid();
            result.Value = await task;
            result.Status = ResultStatus.Pending;
            statusLabel.Text = "Powtórzono badanie.";
            RefreshGrid();
        }
    }
}
