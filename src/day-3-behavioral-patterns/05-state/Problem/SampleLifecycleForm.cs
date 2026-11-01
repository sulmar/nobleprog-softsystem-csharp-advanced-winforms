using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class SampleLifecycleForm : Form
    {
        private readonly BindingList<Sample> _samples = new BindingList<Sample>();

        // TODO: refaktoryzacja: tryb formularza staje się jawnym stanem: Przeglądanie, Edycja, Zapisywanie.
        // PROBLEM: dwie flagi dają cztery kombinacje, a sensowne są tylko trzy. Każda kontrolka sama je interpretuje.
        private bool _isEditing;
        private bool _isSaving;

        public SampleLifecycleForm()
        {
            InitializeComponent();

            samplesGrid.AutoGenerateColumns = false;
            AddDemoSamples();
            samplesGrid.DataSource = _samples;
        }

        private Sample CurrentSample
        {
            get
            {
                return samplesGrid.CurrentRow == null ? null : samplesGrid.CurrentRow.DataBoundItem as Sample;
            }
        }

        private string CurrentUser
        {
            get { return userTextBox.Text; }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ShowCurrentSample();
        }

        private void AddDemoSamples()
        {
            _samples.Add(new Sample("P-1001", "Glukoza"));
            _samples.Add(new Sample("P-1002", "Kreatynina") { Status = SampleStatus.InAnalysis, Result = 1.1m, ResultEnteredBy = "Anna Testowa" });
            _samples.Add(new Sample("P-1003", "Potas") { Status = SampleStatus.InAnalysis });
        }

        private void SamplesGrid_SelectionChanged(object sender, EventArgs e)
        {
            // PROBLEM: siatka jest aktywna podczas edycji, więc zmiana wiersza po cichu kasuje wpisany tekst.
            ShowCurrentSample();
        }

        private void ShowCurrentSample()
        {
            var sample = CurrentSample;

            notesTextBox.Text = sample == null ? string.Empty : sample.Notes;
            resultTextBox.Text = sample == null || !sample.Result.HasValue
                ? string.Empty
                : sample.Result.Value.ToString(CultureInfo.InvariantCulture);
            reasonTextBox.Clear();

            historyListBox.Items.Clear();
            if (sample != null)
            {
                foreach (var entry in sample.History)
                {
                    historyListBox.Items.Add(entry);
                }
            }

            UpdateButtons();
            UpdateMenu();
        }

        // TODO: refaktoryzacja: formularz pyta próbkę, co można, zamiast znać reguły.
        // PROBLEM: reguły obiegu są tu powtórzone po raz drugi, obok SampleOperations (DRY).
        private void UpdateButtons()
        {
            var sample = CurrentSample;
            if (sample == null)
            {
                return;
            }

            var status = sample.Status;

            startButton.Enabled = status == SampleStatus.Registered && !_isEditing;
            enterResultButton.Enabled = (status == SampleStatus.Registered || status == SampleStatus.InAnalysis) && !_isEditing;

            // PROBLEM: przycisk jest aktywny dla próbki odrzuconej, a logika to przepuszcza.
            approveButton.Enabled = status != SampleStatus.Registered && status != SampleStatus.Archived && !_isEditing;

            // PROBLEM: tu brakuje sprawdzenia edycji, więc można odrzucić próbkę w trakcie zmiany uwag.
            rejectButton.Enabled = status != SampleStatus.Archived;

            archiveButton.Enabled = (status == SampleStatus.Approved || status == SampleStatus.Rejected) && !_isEditing;

            editButton.Enabled = status != SampleStatus.Archived && !_isEditing;
            saveButton.Enabled = _isEditing && !_isSaving;

            // PROBLEM: anulowanie zostaje aktywne podczas zapisu, a zapisu to nie zatrzyma.
            cancelEditButton.Enabled = _isEditing;

            notesTextBox.ReadOnly = !_isEditing || _isSaving;
        }

        // PROBLEM: trzecia kopia reguł. Menu pozwala zarchiwizować próbkę w analizie, a przycisk nie (DRY).
        private void UpdateMenu()
        {
            var sample = CurrentSample;
            if (sample == null)
            {
                return;
            }

            var status = sample.Status;

            approveMenuItem.Enabled = status == SampleStatus.InAnalysis;
            rejectMenuItem.Enabled = status == SampleStatus.Registered || status == SampleStatus.InAnalysis;
            archiveMenuItem.Enabled = status != SampleStatus.Registered && status != SampleStatus.Archived;
        }

        private void RunOperation(Action<Sample> operation, string message)
        {
            var sample = CurrentSample;
            if (sample == null)
            {
                return;
            }

            try
            {
                operation(sample);
                statusLabel.Text = message;
            }
            catch (InvalidOperationException exception)
            {
                statusLabel.Text = exception.Message;
            }

            _samples.ResetItem(_samples.IndexOf(sample));
            ShowCurrentSample();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            RunOperation(sample => SampleOperations.StartAnalysis(sample, CurrentUser), "Rozpoczęto analizę.");
        }

        private void EnterResultButton_Click(object sender, EventArgs e)
        {
            decimal value;
            if (!decimal.TryParse(resultTextBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
            {
                statusLabel.Text = "Wpisz wynik jako liczbę, np. 5.4.";
                return;
            }

            RunOperation(sample => SampleOperations.EnterResult(sample, value, CurrentUser), "Wpisano wynik.");
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            RunOperation(sample => SampleOperations.Approve(sample, CurrentUser), "Zatwierdzono próbkę.");
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            RunOperation(sample => SampleOperations.Reject(sample, CurrentUser, reasonTextBox.Text), "Odrzucono próbkę.");
        }

        private void ArchiveButton_Click(object sender, EventArgs e)
        {
            RunOperation(sample => SampleOperations.Archive(sample, CurrentUser), "Zarchiwizowano próbkę.");
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            _isEditing = true;
            UpdateButtons();
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            _isEditing = false;

            // PROBLEM: użytkownik widzi anulowanie, ale trwający zapis i tak zakończy się zmianą danych.
            statusLabel.Text = "Anulowano edycję.";
            ShowCurrentSample();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            var notes = notesTextBox.Text;

            _isSaving = true;
            statusLabel.Text = "Zapisywanie...";
            UpdateButtons();

            // Symulacja zapisu na serwerze.
            await Task.Delay(3000);

            // PROBLEM: po await bieżącym wierszem może być już inna próbka, a uwagi trafią właśnie do niej.
            var sample = CurrentSample;
            if (sample != null)
            {
                sample.Notes = notes;
            }

            _isSaving = false;
            _isEditing = false;
            statusLabel.Text = "Zapisano uwagi.";
            ShowCurrentSample();
        }
    }
}
