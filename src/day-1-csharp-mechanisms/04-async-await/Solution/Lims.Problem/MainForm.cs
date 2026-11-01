using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lims.Domain;

namespace Lims.Problem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            // Zegar działa w wątku interfejsu, więc staje razem z oknem.
            clockLabel.Text = "Godzina: " + DateTime.Now.ToString("HH:mm:ss.f");
        }

        private static Sample FirstSample()
        {
            return SampleData.SamplesForPatient()[0];
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            var result = SampleData.ResultFor(FirstSample());

            // TODO: refaktoryzacja: wysyłać wynik poza wątkiem interfejsu.
            // PROBLEM: wysyłka trwa kilka sekund i działa w wątku interfejsu, więc okno w tym czasie nie reaguje.
            LabService.SendResult(result);

            statusLabel.Text = "Wysłano wynik próbki " + result.SampleCode;
        }

        private void AnalyzeAndSendButton_Click(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: poczekać na wynik badania bez blokowania okna i wtedy go wysłać.
            // PROBLEM: druga operacja potrzebuje wyniku pierwszej. Działają w wątku interfejsu,
            // więc okno stoi przez sumę ich czasów, a formularz zna kolejność kroków (SRP).
            var result = LabService.Analyze(FirstSample());
            LabService.SendResult(result);

            statusLabel.Text = "Zbadano i wysłano próbkę " + result.SampleCode;
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: badać próbki jednocześnie i wysłać raport po zebraniu wszystkich wyników.
            // PROBLEM: próbki są badane po kolei, więc czas to suma czasów, choć analizatory działają
            // niezależnie. Okno stoi przez cały czas, a formularz składa raport (SRP).
            var results = new List<TestResult>();
            foreach (var sample in SampleData.SamplesForPatient())
            {
                results.Add(LabService.Analyze(sample));
            }

            LabService.SendReport(new PatientReport(SampleData.Patient, results));

            statusLabel.Text = "Wysłano raport zbiorczy, wyniki: " + results.Count;
        }

        private void BlockingButton_Click(object sender, EventArgs e)
        {
            // TODO: naprawić błąd: nie blokować wątku interfejsu na metodzie asynchronicznej.
            // PROBLEM: .Result blokuje wątek interfejsu, a await w AnalyzeWithDelayAsync chce wrócić
            // właśnie do niego. Oba czekają na siebie nawzajem, więc aplikacja zawisa na zawsze.
            var result = LabService.AnalyzeWithDelayAsync(FirstSample()).Result;

            statusLabel.Text = "Zbadano próbkę " + result.SampleCode;
        }

        private void BackgroundSendButton_Click(object sender, EventArgs e)
        {
            // TODO: naprawić błąd: zwracać Task z metody pomocniczej i czekać na niego w try.
            // PROBLEM: async void nie zwraca zadania, więc nie ma na co czekać. Ten try/catch
            // kończy się przed błędem wysyłki i nigdy go nie złapie.
            try
            {
                SendInBackground(SampleData.ResultFor(FirstSample()));
            }
            catch (Exception exception)
            {
                statusLabel.Text = "Błąd: " + exception.Message;
            }
        }

        private async void SendInBackground(TestResult result)
        {
            await LabService.SendResultWithDelayAsync(result, failCheckBox.Checked);
            statusLabel.Text = "Wysłano wynik próbki " + result.SampleCode;
        }

        private async void BackgroundReportButton_Click(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: dodać anulowanie, postęp i blokadę przycisku.
            // PROBLEM: użytkownik nie może przerwać pracy ani nie widzi postępu,
            // a ponowne kliknięcie uruchamia drugi raport równolegle z pierwszym.
            var samples = SampleData.SamplesForPatient();
            var results = new List<TestResult>();

            foreach (var sample in samples)
            {
                results.Add(await LabService.AnalyzeWithDelayAsync(sample));
            }

            statusLabel.Text = "Zebrano wyniki do raportu: " + results.Count;
        }
    }
}
