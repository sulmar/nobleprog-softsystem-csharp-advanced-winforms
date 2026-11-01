using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class FiltersPanel : UserControl
    {
        // TODO: refaktoryzacja: panel ma tylko zgłaszać, że zmieniły się kryteria wyszukiwania.
        // PROBLEM: wyszukiwarka zna konkretną listę i decydują, co ma się z nią stać (DIP).
        public SampleListPanel List { get; set; }

        public FiltersPanel()
        {
            InitializeComponent();

            statusComboBox.Items.AddRange(new object[] { "Wszystkie", "Oczekujące", "Zatwierdzone", "Odrzucone" });
            statusComboBox.SelectedIndex = 0;
        }

        public void ApplyCurrentFilter()
        {
            // TODO: refaktoryzacja: niezapisany komentarz ma być sprawdzany w jednym miejscu.
            // PROBLEM: lista pyta o niezapisany komentarz przed zmianą próbki, a wyszukiwarka o tym nie wie.
            // Po nowym wyszukiwaniu komentarz zostaje przy próbce, której nie ma już na liście (DRY).
            List.ApplyFilter(SelectedStatus(), searchTextBox.Text, urgentCheckBox.Checked);
        }

        private SampleStatus? SelectedStatus()
        {
            switch (statusComboBox.SelectedIndex)
            {
                case 1: return SampleStatus.Pending;
                case 2: return SampleStatus.Approved;
                case 3: return SampleStatus.Rejected;
                default: return null;
            }
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: usunąć sprawdzanie, czy panele są już połączone.
            // PROBLEM: zdarzenie przychodzi też podczas budowania panelu, zanim formularz ustawi referencje.
            if (List == null)
            {
                return;
            }

            ApplyCurrentFilter();
        }
    }
}
