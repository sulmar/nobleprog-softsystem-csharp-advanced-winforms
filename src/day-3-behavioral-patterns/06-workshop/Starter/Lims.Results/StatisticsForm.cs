using System;
using System.Linq;
using System.Windows.Forms;

namespace Lims.Results
{
    public partial class StatisticsForm : Form
    {
        private static readonly string[] Statuses = { "Nowy", "Zweryfikowany", "Zatwierdzony", "Wysłany", "Odrzucony" };

        private readonly ResultsForm _main;

        public StatisticsForm(ResultsForm main)
        {
            InitializeComponent();

            _main = main;
            RefreshCounts();
        }

        public void RefreshCounts()
        {
            int selected = countsListBox.SelectedIndex;

            countsListBox.Items.Clear();
            foreach (var status in Statuses)
            {
                countsListBox.Items.Add(status + ": " + Db.Results.Count(r => r.Status == status));
            }

            countsListBox.SelectedIndex = selected;

            int critical = Db.Results.Count(r =>
            {
                string flag = _main.EvaluateFlag(r.TestType, r.Value, r.RefLow, r.RefHigh);
                return flag == "HH" || flag == "LL";
            });
            criticalLabel.Text = "Wyniki krytyczne: " + critical;
        }

        private void showInMainButton_Click(object sender, EventArgs e)
        {
            if (countsListBox.SelectedIndex >= 0)
            {
                _main.SetFilter(Statuses[countsListBox.SelectedIndex]);
            }
        }

        private void StatisticsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _main.StatsWindow = null;
        }
    }
}
