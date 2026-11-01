using System;
using System.Windows.Forms;

namespace Lims.Results
{
    public partial class ResultDetailsForm : Form
    {
        private readonly ResultsForm _main;

        public LabResult Result { get; }

        public ResultDetailsForm(LabResult result, ResultsForm main)
        {
            InitializeComponent();

            Result = result;
            _main = main;
            ReloadFromResult();
        }

        public void ReloadFromResult()
        {
            Text = "Wynik " + Result.SampleCode;
            headerLabel.Text = Result.PatientName + ", " + Result.Analyte + ", status: " + Result.Status;
            valueTextBox.Text = Result.Value;
            commentTextBox.Text = Result.Comment;

            bool closed = Result.Status == "Zatwierdzony" || Result.Status == "Wysłany";
            valueTextBox.ReadOnly = Result.Status != "Nowy";
            commentTextBox.ReadOnly = closed;
            saveButton.Enabled = !closed;

            ShowFlag();
        }

        private void ShowFlag()
        {
            string flag = _main.EvaluateFlag(Result.TestType, valueTextBox.Text.Trim(), Result.RefLow, Result.RefHigh);
            flagLabel.Text = "Flaga: " + (flag == "" ? "brak" : flag);
        }

        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowFlag();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string value = valueTextBox.Text.Trim();
            string comment = commentTextBox.Text.Trim();

            if (Result.Status == "Nowy")
            {
                string error = _main.ValidateValue(Result.TestType, value);
                if (error != null)
                {
                    MessageBox.Show(error, "Szczegóły wyniku");
                    return;
                }

                Result.Value = value;
                Result.Comment = comment;
                _main.AddAudit("Zmieniono wynik " + Result.SampleCode + ": " + value);
            }
            else
            {
                Result.Comment = comment;
                _main.AddAudit("Zmieniono komentarz " + Result.SampleCode);
            }

            _main.AfterChange();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResultDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _main.OpenDetails.Remove(this);
        }
    }
}
