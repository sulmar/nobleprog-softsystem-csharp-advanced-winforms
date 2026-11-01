using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lims.Domain;

namespace Lims.Problem
{
    public partial class MainForm : Form
    {
        private const int ResultsPerDay = 30;
        private const int DelayMilliseconds = 500;
        private const int FailingResultIndex = 5;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            // Zegar działa w wątku interfejsu, więc staje razem z oknem.
            clockLabel.Text = "Godzina: " + DateTime.Now.ToString("HH:mm:ss.f");
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var results = ResultData.ForDay(ResultsPerDay);
            var outOfRange = 0;
            progressBar.Maximum = results.Count;

            // TODO: refaktoryzacja: wydzielić obliczanie z formularza i uruchomić ją poza wątkiem interfejsu.
            // PROBLEM: praca działa w wątku interfejsu, więc pętla komunikatów stoi i okno nie reaguje.
            // Formularz oprócz obsługi interfejsu zawiera logikę obliczeń (SRP), a pętla ma kopie niżej (DRY).
            for (var i = 0; i < results.Count; i++)
            {
                Thread.Sleep(DelayMilliseconds);

                if (results[i].IsOutOfRange())
                {
                    outOfRange++;
                }

                progressBar.Value = i + 1;
            }

            statusLabel.Text = "Badania z dnia: " + results.Count + ", poza zakresem: " + outOfRange + " (" + (outOfRange * 100m / results.Count).ToString("0.0") + "%)";
        }

        private void ThreadButton_Click(object sender, EventArgs e)
        {
            var results = ResultData.ForDay(ResultsPerDay);
            var fail = failCheckBox.Checked;
            progressBar.Maximum = results.Count;

            // TODO: refaktoryzacja: użyć wątku tła i obsłużyć wyjątek.
            // PROBLEM: domyślny wątek pierwszoplanowy utrzymuje proces po zamknięciu okna,
            // a nieobsłużony wyjątek w tym wątku kończy całą aplikację.
            var thread = new Thread(() =>
            {
                var outOfRange = 0;

                // TODO: refaktoryzacja: przekazywać aktualizacje do wątku interfejsu.
                // PROBLEM: kontrolki wolno zmieniać tylko z wątku, który je utworzył. Pod debuggerem
                // zgłasza to InvalidOperationException, a bez niego błąd może pozostać ukryty.
                for (var i = 0; i < results.Count; i++)
                {
                    Thread.Sleep(DelayMilliseconds);

                    if (fail && i == FailingResultIndex)
                    {
                        throw new InvalidOperationException("Uszkodzony wynik");
                    }

                    if (results[i].IsOutOfRange())
                    {
                        outOfRange++;
                    }

                    progressBar.Value = i + 1;
                }

                statusLabel.Text = "Badania z dnia: " + results.Count + ", poza zakresem: " + outOfRange + " (" + (outOfRange * 100m / results.Count).ToString("0.0") + "%)";
            });

            thread.Start();
        }

        private void TaskButton_Click(object sender, EventArgs e)
        {
            var results = ResultData.ForDay(ResultsPerDay);

            // TODO: refaktoryzacja: odebrać wynik w kontynuacji zamiast czekać.
            // PROBLEM: praca działa w puli wątków, ale .Result blokuje wątek interfejsu do jej końca,
            // więc okno nadal nie reaguje. Pętla jest kolejną kopią (DRY).
            var outOfRange = Task.Run(() =>
            {
                var count = 0;
                foreach (var result in results)
                {
                    Thread.Sleep(DelayMilliseconds);

                    if (result.IsOutOfRange())
                    {
                        count++;
                    }
                }
                return count;
            }).Result;

            statusLabel.Text = "Badania z dnia: " + results.Count + ", poza zakresem: " + outOfRange + " (" + (outOfRange * 100m / results.Count).ToString("0.0") + "%)";
        }

        private void MonitorButton_Click(object sender, EventArgs e)
        {
            var sensor = new TemperatureSensor();

            // TODO: refaktoryzacja: wydzielić pętlę odczytu i przekazywać odczyty do wątku interfejsu.
            // PROBLEM: kontrolki wolno zmieniać tylko z wątku, który je utworzył. Pod debuggerem zgłasza to
            // InvalidOperationException, a bez niego błąd pozostaje ukryty. Formularz zawiera też pętlę
            // odczytu (SRP), odczytu nie da się zatrzymać, a każde kliknięcie uruchamia kolejny wątek.
            var thread = new Thread(() =>
            {
                while (true)
                {
                    var temperature = sensor.Read();
                    temperatureLabel.Text = "Lodówka z odczynnikami: " + temperature.ToString("0.0") + " °C";
                }
            });

            thread.IsBackground = true;
            thread.Start();
        }
    }
}
