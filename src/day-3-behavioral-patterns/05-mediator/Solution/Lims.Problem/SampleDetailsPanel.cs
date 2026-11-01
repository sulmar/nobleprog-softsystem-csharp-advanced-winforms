using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class SampleDetailsPanel : UserControl
    {
        // TODO: refaktoryzacja: szczegóły mają pokazywać próbkę i zgłaszać edycję komentarza.
        // PROBLEM: panel szczegółów włącza przyciski i odświeża listę, choć nie są to jego sprawy (SRP, DIP).
        public SampleListPanel List { get; set; }
        public ActionBarPanel Actions { get; set; }

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
        }

        public void Clear()
        {
            _sample = null;
            _loading = true;
            codeValueLabel.Text = "";
            patientValueLabel.Text = "";
            analyteValueLabel.Text = "";
            statusValueLabel.Text = "";
            commentTextBox.Text = "";
            commentTextBox.ReadOnly = true;
            _loading = false;
            HasUnsavedComment = false;
        }

        public void SaveComment()
        {
            _sample.Comment = commentTextBox.Text;
            HasUnsavedComment = false;

            // TODO: refaktoryzacja: skutki zapisu mają być opisane w jednym miejscu.
            // PROBLEM: „odświeżmy listę, żeby było widać znacznik komentarza” dopisano tutaj. Reload czyści
            // szczegóły i wybór, więc zapis psuje panel, który właśnie go wykonał (łańcuch skutków).
            Actions.OnCommentSaved();
            List.Reload();
        }

        private void CommentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_loading)
            {
                return;
            }

            HasUnsavedComment = true;
            Actions.OnCommentEdited();
        }
    }
}
