using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class SampleListPanel : UserControl
    {
        // TODO: refaktoryzacja: lista ma tylko zgłaszać wybór próbki.
        // PROBLEM: lista zna szczegóły i pasek przycisków, a każdy z nich zna listę. Nie da się jej
        // użyć ani sprawdzić bez pozostałych paneli (DIP).
        public SampleDetailsPanel Details { get; set; }
        public ActionBarPanel Actions { get; set; }

        public Sample SelectedSample { get; private set; }

        private SampleStatus? _status;
        private string _search = "";
        private bool _urgentOnly;
        private bool _restoringSelection;

        public SampleListPanel()
        {
            InitializeComponent();
        }

        public void ApplyFilter(SampleStatus? status, string search, bool urgentOnly)
        {
            _status = status;
            _search = search;
            _urgentOnly = urgentOnly;
            Reload();
        }

        public void Reload()
        {
            samplesListBox.Items.Clear();
            SelectedSample = null;

            foreach (var sample in SampleDatabase.All())
            {
                if (Matches(sample))
                {
                    samplesListBox.Items.Add(sample);
                }
            }

            // TODO: refaktoryzacja: „nic nie jest wybrane” ma być jedną regułą dla wszystkich paneli.
            // PROBLEM: szczegóły są czyszczone, ale nikt nie wyłącza przycisków. Pasek pamięta poprzednią
            // próbkę, więc „Zatwierdź” działa na próbce, której użytkownik już nie widzi (SRP).
            Details.Clear();
        }

        private bool Matches(Sample sample)
        {
            // TODO: refaktoryzacja: przenieść regułę filtrowania do klasy bez kontrolek.
            // PROBLEM: reguły nie da się sprawdzić bez okna (SRP).
            if (_status.HasValue && sample.Status != _status.Value)
            {
                return false;
            }

            if (_urgentOnly && !sample.IsUrgent)
            {
                return false;
            }

            return _search.Length == 0
                || sample.Code.IndexOf(_search, StringComparison.OrdinalIgnoreCase) >= 0
                || sample.Patient.IndexOf(_search, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void SamplesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sample = samplesListBox.SelectedItem as Sample;
            if (_restoringSelection || sample == null || sample == SelectedSample)
            {
                return;
            }

            // TODO: refaktoryzacja: decyzja o niezapisanym komentarzu i pytanie do użytkownika w jednym miejscu.
            // PROBLEM: reguła jest tylko tutaj, a inne drogi zmiany próbki ją omijają (DRY).
            if (Details.HasUnsavedComment
                && MessageBox.Show("Komentarz nie jest zapisany. Porzucić zmiany?", "Przegląd próbek", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                _restoringSelection = true;
                samplesListBox.SelectedItem = SelectedSample;
                _restoringSelection = false;
                return;
            }

            // TODO: refaktoryzacja: skutki wyboru próbki opisać w jednym miejscu.
            // PROBLEM: kolejność wywołań jest częścią reguły, ale nigdzie nie jest opisana (SRP).
            SelectedSample = sample;
            Details.ShowSample(sample);
            Actions.SetSample(sample);
        }
    }
}
