using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lims.Domain;

namespace Lims.Problem
{
    public partial class MainForm : Form
    {
        private const int BatchSize = 30;
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

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            var results = ResultData.Batch(BatchSize);
            var outOfRange = 0;
            progressBar.Maximum = results.Count;

            // TODO: refaktoryzacja: wydzielić walidację z formularza i uruchomić ją poza wątkiem interfejsu.
            // PROBLEM: praca działa w wątku interfejsu, więc pętla komunikatów stoi i okno nie reaguje.
            // Formularz oprócz obsługi interfejsu zawiera logikę walidacji (SRP), a pętla ma kopie niżej (DRY).
            for (var i = 0; i < results.Count; i++)
            {
                Thread.Sleep(DelayMilliseconds);

                if (results[i].IsOutOfRange())
                {
                    outOfRange++;
                }

                progressBar.Value = i + 1;
            }

            statusLabel.Text = "Poza zakresem: " + outOfRange + " z " + results.Count;
        }

        private void ThreadButton_Click(object sender, EventArgs e)
        {
            var results = ResultData.Batch(BatchSize);
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
                        throw new InvalidOperationException("Błąd analizatora");
                    }

                    if (results[i].IsOutOfRange())
                    {
                        outOfRange++;
                    }

                    progressBar.Value = i + 1;
                }

                statusLabel.Text = "Poza zakresem: " + outOfRange + " z " + results.Count;
            });

            thread.Start();
        }

        private void TaskButton_Click(object sender, EventArgs e)
        {
            var results = ResultData.Batch(BatchSize);

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

            statusLabel.Text = "Poza zakresem: " + outOfRange + " z " + results.Count;
        }
    }
}
