using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class SampleDetailsPanel : UserControl
    {
        // TODO: refaktoryzacja: szczegóły mają pokazywać próbkę i zgłaszać, co zrobił użytkownik.
        // PROBLEM: panel sam zmienia status próbki, pilnuje przycisków i odświeża listę (SRP, DIP).
        public SampleListPanel List { get; set; }

        public bool HasUnsavedComment { get; private set; }

        private Sample _sample;
        private bool _loading;

        public SampleDetailsPanel()
        {
            InitializeComponent();
        }

        public void ShowSample(Sample sample)
        {
            _sample = sample;
            _loading = true;
            codeValueLabel.Text = sample.Code;
            patientValueLabel.Text = sample.Patient;
            analyteValueLabel.Text = sample.Analyte;
            statusValueLabel.Text = sample.StatusText;
            commentTextBox.Text = sample.Comment;
            commentTextBox.ReadOnly = sample.Status != SampleStatus.Pending;
            _loading = false;
            HasUnsavedComment = false;

            // TODO: refaktoryzacja: jedna definicja tego, kiedy które działanie jest dostępne.
            // PROBLEM: ta sama reguła jest też w SaveButton_Click, z innym warunkiem (DRY).
            approveButton.Enabled = sample.Status == SampleStatus.Pending;
            rejectButton.Enabled = sample.Status == SampleStatus.Pending && sample.Comment.Trim().Length > 0;
            saveButton.Enabled = false;
        }

        private void CommentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_loading)
            {
                return;
            }

            HasUnsavedComment = true;
            saveButton.Enabled = true;
            approveButton.Enabled = false;
            rejectButton.Enabled = false;
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: po decyzji wszystkie panele mają dostać spójny stan.
            // PROBLEM: nikt nie wyłącza przycisków. Zatwierdzoną próbkę można jeszcze odrzucić,
            // a status zostaje po cichu nadpisany (łańcuch skutków).
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
            _sample.Comment = commentTextBox.Text;
            HasUnsavedComment = false;
            messageLabel.Text = "Zapisano komentarz";

            // TODO: refaktoryzacja: usunąć kopię reguły.
            // PROBLEM: kopia reguły z ShowSample, bez warunku na treść komentarza. Po zapisaniu pustego
            // komentarza można odrzucić próbkę bez podania powodu (DRY).
            saveButton.Enabled = false;
            approveButton.Enabled = true;
            rejectButton.Enabled = true;

            // TODO: refaktoryzacja: skutki zapisu mają być opisane w jednym miejscu.
            // PROBLEM: „odświeżmy listę, żeby było widać znacznik komentarza” dopisano tutaj. Reload kasuje
            // wybór na liście, więc szczegóły pokazują próbkę, która nie jest już wybrana (łańcuch skutków).
            List.Reload();
        }
    }
}
