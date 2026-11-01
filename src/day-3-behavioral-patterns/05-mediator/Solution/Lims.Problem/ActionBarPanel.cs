using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class ActionBarPanel : UserControl
    {
        // TODO: refaktoryzacja: pasek ma tylko zgłaszać, który przycisk naciśnięto.
        // PROBLEM: pasek zna listę i szczegóły, sam zmienia status próbki i sam pilnuje swojego stanu (SRP, DIP).
        public SampleListPanel List { get; set; }
        public SampleDetailsPanel Details { get; set; }

        // TODO: refaktoryzacja: jedna informacja o wybranej próbce.
        // PROBLEM: druga kopia informacji „która próbka jest wybrana”. Lista i szczegóły mają własne,
        // a po odświeżeniu listy tylko ta nie jest czyszczona (DRY).
        private Sample _sample;

        public ActionBarPanel()
        {
            InitializeComponent();
        }

        public void SetSample(Sample sample)
        {
            _sample = sample;

            // TODO: refaktoryzacja: jedna definicja tego, kiedy które działanie jest dostępne.
            // PROBLEM: ta sama reguła jest też w OnCommentSaved, z innym warunkiem (DRY).
            approveButton.Enabled = sample.Status == SampleStatus.Pending;
            rejectButton.Enabled = sample.Status == SampleStatus.Pending && sample.Comment.Trim().Length > 0;
            saveButton.Enabled = false;
        }

        public void OnCommentEdited()
        {
            saveButton.Enabled = true;
            approveButton.Enabled = false;
            rejectButton.Enabled = false;
        }

        public void OnCommentSaved()
        {
            // TODO: refaktoryzacja: usunąć kopię reguły.
            // PROBLEM: kopia reguły z SetSample, bez warunku na treść komentarza. Po zapisaniu pustego
            // komentarza można odrzucić próbkę bez podania powodu (DRY).
            saveButton.Enabled = false;
            approveButton.Enabled = true;
            rejectButton.Enabled = true;
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: po decyzji wszystkie panele mają dostać spójny stan.
            // PROBLEM: lista i szczegóły się czyszczą, a przyciski zostają włączone. Zatwierdzoną próbkę
            // można jeszcze odrzucić, a status zostaje po cichu nadpisany (łańcuch skutków).
            _sample.Status = SampleStatus.Approved;
            messageLabel.Text = "Zatwierdzono " + _sample.Code;
            List.Reload();
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            _sample.Status = SampleStatus.Rejected;
            messageLabel.Text = "Odrzucono " + _sample.Code;
            List.Reload();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: przycisk ma być dostępny tylko wtedy, gdy jest co zapisać.
            // PROBLEM: po zmianie filtra szczegóły nie mają już próbki, a ten przycisk jest nadal włączony,
            // więc SaveComment kończy się wyjątkiem NullReferenceException.
            Details.SaveComment();
            messageLabel.Text = "Zapisano komentarz";
        }
    }
}
