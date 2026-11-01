using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lims.Exercise.Form
{
    public partial class PatientSearchForm : System.Windows.Forms.Form
    {
        // Symulacja katalogu pacjentów. Wiersz: imię i nazwisko, PESEL, liczba otwartych zleceń, czy zablokowany.
        private static readonly object[][] Patients = BuildPatients();

        // Wyniki aktualnie widoczne na liście.
        private List<object[]> _results = new List<object[]>();
        private bool _searched;

        public PatientSearchForm()
        {
            InitializeComponent();

            messageLabel.Text = "Wpisz co najmniej 3 znaki";
            UpdateButtons();
        }

        private static object[][] BuildPatients()
        {
            var patients = new List<object[]>
            {
                new object[] { "Anna Testowa", "00000000011", 2, false },
                new object[] { "Adam Testowy", "00000000022", 0, false },
                new object[] { "Piotr Fikcyjny", "00000000033", 1, true },
                new object[] { "Maria Przykładowa", "00000000044", 0, false }
            };

            for (var number = 1; number <= 25; number++)
            {
                patients.Add(new object[] { "Jan Wzorcowy " + number, "111111111" + number.ToString("D2"), number % 2, false });
            }

            return patients.ToArray();
        }

        private void UpdateButtons()
        {
            var selected = resultsListBox.SelectedIndex >= 0 ? _results[resultsListBox.SelectedIndex] : null;

            searchButton.Enabled = queryTextBox.Text.Trim().Length >= 3;
            clearButton.Enabled = queryTextBox.Text.Length > 0 || openOrdersOnlyCheckBox.Checked || _searched;
            openCardButton.Enabled = selected != null;
            newOrderButton.Enabled = selected != null && !(bool)selected[3];
        }

        private void Criteria_Changed(object sender, EventArgs e)
        {
            if (_searched)
            {
                _results = new List<object[]>();
                _searched = false;
                resultsListBox.Items.Clear();
                messageLabel.Text = "Kryteria się zmieniły, wyszukaj ponownie";
            }
            else
            {
                messageLabel.Text = queryTextBox.Text.Trim().Length >= 3 ? "" : "Wpisz co najmniej 3 znaki";
            }

            UpdateButtons();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var query = queryTextBox.Text.Trim();

            if (simulateOutageCheckBox.Checked)
            {
                _results = new List<object[]>();
                _searched = true;
                resultsListBox.Items.Clear();
                messageLabel.Text = "Katalog pacjentów jest niedostępny, spróbuj ponownie";
                UpdateButtons();
                return;
            }

            var found = Patients
                .Where(patient => ((string)patient[0]).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
                    || ((string)patient[1]).Contains(query))
                .Where(patient => !openOrdersOnlyCheckBox.Checked || (int)patient[2] > 0)
                .ToList();

            _results = found.Take(20).ToList();
            _searched = true;

            resultsListBox.Items.Clear();
            foreach (var patient in _results)
            {
                var pesel = (string)patient[1];
                resultsListBox.Items.Add(patient[0] + " | *******" + pesel.Substring(pesel.Length - 4)
                    + " | otwarte zlecenia: " + patient[2] + ((bool)patient[3] ? " | zablokowany" : ""));
            }

            if (found.Count == 0)
            {
                messageLabel.Text = "Nie znaleziono pacjentów";
            }
            else if (found.Count > 20)
            {
                messageLabel.Text = "Pokazano 20 z " + found.Count + ", zawęź kryteria";
            }
            else
            {
                messageLabel.Text = "Znaleziono: " + found.Count;
            }

            UpdateButtons();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            queryTextBox.Clear();
            openOrdersOnlyCheckBox.Checked = false;

            _results = new List<object[]>();
            _searched = false;
            resultsListBox.Items.Clear();
            messageLabel.Text = "Wpisz co najmniej 3 znaki";
            UpdateButtons();
        }

        private void ResultsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultsListBox.SelectedIndex >= 0)
            {
                var selected = _results[resultsListBox.SelectedIndex];
                messageLabel.Text = (bool)selected[3]
                    ? "Pacjent zablokowany: nie można założyć zlecenia"
                    : "Wybrano: " + selected[0];
            }

            UpdateButtons();
        }

        private void OpenCardButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Karta pacjenta: " + _results[resultsListBox.SelectedIndex][0], "Karta pacjenta");
        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Nowe zlecenie dla: " + _results[resultsListBox.SelectedIndex][0], "Nowe zlecenie");
        }
    }
}
