using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lims.Domain;

namespace Lims.Problem
{
    public partial class MainForm : Form
    {
        private const int Workers = 8;
        private const int ItemsPerWorker = 100000;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            clockLabel.Text = "Godzina: " + DateTime.Now.ToString("HH:mm:ss.f");
        }

        private static Task RunWorkers(Action work)
        {
            return Task.WhenAll(Enumerable.Range(0, Workers).Select(i => Task.Run(work)));
        }

        private async void CounterButton_Click(object sender, EventArgs e)
        {
            var counter = new SampleCounter();

            await RunWorkers(() =>
            {
                for (var i = 0; i < ItemsPerWorker; i++)
                {
                    counter.Add();
                }
            });

            statusLabel.Text = "Licznik: " + counter.Count + ", powinno być: " + Workers * ItemsPerWorker;
        }

        private async void SlotsButton_Click(object sender, EventArgs e)
        {
            var slots = new AnalyzerSlots(5);

            var attempts = Enumerable.Range(0, 50).Select(i => Task.Run(() => slots.TryReserve())).ToList();
            var reserved = await Task.WhenAll(attempts);

            statusLabel.Text = "Zarezerwowano: " + reserved.Count(r => r) + " przy 5 miejscach, wolne: " + slots.Free;
        }

        private async void CollectorButton_Click(object sender, EventArgs e)
        {
            var collector = new ResultCollector();

            try
            {
                await RunWorkers(() =>
                {
                    for (var i = 0; i < ItemsPerWorker; i++)
                    {
                        collector.Add(new TestResult());
                    }
                });

                statusLabel.Text = "Zebrano: " + collector.Count + ", powinno być: " + Workers * ItemsPerWorker;
            }
            catch (Exception exception)
            {
                statusLabel.Text = "Wyjątek: " + exception.GetType().Name;
            }
        }

        private async void GateButton_Click(object sender, EventArgs e)
        {
            var gate = new AnalyzerGate();

            await Task.WhenAll(Enumerable.Range(0, 6).Select(i => gate.AnalyzeAsync(() => Task.Delay(500))));

            statusLabel.Text = "Najwięcej próbek naraz: " + gate.MaxObserved + ", analizator przyjmuje: 2";
        }

        private async void MoveButton_Click(object sender, EventArgs e)
        {
            var rackA = new Rack("A", Enumerable.Range(0, 1000).Select(i => "S-A-" + i));
            var rackB = new Rack("B", Enumerable.Range(0, 1000).Select(i => "S-B-" + i));

            var moves = Task.WhenAll(
                Task.Run(() => MoveMany(rackA, rackB)),
                Task.Run(() => MoveMany(rackB, rackA)));

            // Limit czasu tylko po to, żeby okno pokazało wynik. Wątki robocze zostają zablokowane.
            var finished = await Task.WhenAny(moves, Task.Delay(TimeSpan.FromSeconds(5)));

            statusLabel.Text = finished == moves
                ? "Przełożono próbki"
                : "Zakleszczenie: po 5 sekundach praca nadal stoi";
        }

        private static void MoveMany(Rack from, Rack to)
        {
            for (var i = 0; i < 1000; i++)
            {
                SampleMover.Move(from, to);
            }
        }
    }
}
