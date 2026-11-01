using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class StatisticsPanel : UserControl
    {
        public StatisticsPanel()
        {
            InitializeComponent();
        }

        public void UpdateStatistics()
        {
            var approved = LabData.Results.Where(result => result.Status == LabResult.Approved).ToList();
            var rejected = LabData.Results.Count(result => result.Status == LabResult.Rejected);

            // TODO: refaktoryzacja: błąd statystyk nie może zatrzymać pozostałych odbiorców.
            // PROBLEM: „<2” to poprawny wynik z analizatora, ale tu powoduje FormatException. Wyjątek przerywa
            // całą sekwencję powiadomień w ApprovalForm, więc pasek stanu i kontrola jakości nic nie dostają.
            var average = approved.Count == 0
                ? 0m
                : approved.Average(result => decimal.Parse(result.ValueText, CultureInfo.InvariantCulture));

            approvedLabel.Text = "Zatwierdzone: " + approved.Count;
            rejectedLabel.Text = "Odrzucone: " + rejected;
            pendingLabel.Text = "Oczekujące: " + LabData.Results.Count(result => result.Status == LabResult.Pending);
            averageLabel.Text = "Średnia wartość: " + average.ToString("0.00");
        }

        private void ShowListButton_Click(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: kontrolka ogłasza prośbę, a o otwarciu okna decyduje formularz.
            // PROBLEM: kontrolka zna swój konkretny formularz, więc nie da się jej użyć w innym oknie (DIP).
            ((MainForm)FindForm()).OpenResultList();
        }
    }
}
