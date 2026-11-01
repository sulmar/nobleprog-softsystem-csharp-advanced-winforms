using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class ResultViewerForm : Form
    {
        // TODO: refaktoryzacja: przyjmować serwis przez konstruktor, a składać go w Program.cs.
        // PROBLEM: okno samo tworzy konkretną klasę, więc nie da się zmienić zestawu działań bez zmiany okna (DIP).
        private readonly ResultService _service = new ResultService();

        public ResultViewerForm()
        {
            InitializeComponent();

            userComboBox.Items.AddRange(new object[]
            {
                UserAccounts.Diagnostician,
                UserAccounts.Technician,
                UserAccounts.Registrar
            });
            userComboBox.SelectedIndex = 0;
            sampleTextBox.Text = "S-100";

            RefreshLog();
        }

        private void UserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.CurrentUser = (UserAccount)userComboBox.SelectedItem;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                var result = _service.GetResult(sampleTextBox.Text);
                stopwatch.Stop();

                resultLabel.Text = result == null
                    ? "Brak wyniku"
                    : result.PatientCode + ", " + result.Analyte + ": " + result.Value + " " + result.Unit;
                statusLabel.Text = "Czas odczytu: " + stopwatch.ElapsedMilliseconds + " ms";
            }
            catch (AccessDeniedException ex)
            {
                resultLabel.Text = string.Empty;
                statusLabel.Text = ex.Message;
            }

            RefreshLog();
        }

        private void CorrectButton_Click(object sender, EventArgs e)
        {
            decimal newValue;
            if (!decimal.TryParse(valueTextBox.Text, out newValue))
            {
                statusLabel.Text = "Podaj liczbę";
                return;
            }

            try
            {
                _service.CorrectResult(sampleTextBox.Text, newValue);
                statusLabel.Text = "Wynik skorygowany";
            }
            catch (AccessDeniedException ex)
            {
                statusLabel.Text = ex.Message;
            }
            catch (KeyNotFoundException ex)
            {
                statusLabel.Text = ex.Message;
            }

            RefreshLog();
        }

        private void RefreshLog()
        {
            logListBox.Items.Clear();
            if (File.Exists(ResultService.LogPath))
            {
                logListBox.Items.AddRange(File.ReadAllLines(ResultService.LogPath));
            }
        }
    }
}
