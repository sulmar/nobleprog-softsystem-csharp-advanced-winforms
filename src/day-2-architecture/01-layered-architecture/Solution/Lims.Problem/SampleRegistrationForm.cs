using System;
using System.Linq;
using System.Windows.Forms;
using LabelTech.Sdk;
using Lims.Application;
using Lims.Domain;
using Lims.Infrastucture;

namespace Lims.Problem
{
    public partial class SampleRegistrationForm : Form
    {
        private readonly SampleRegistrationService service;

        public SampleRegistrationForm(SampleRegistrationService service)
        {
            InitializeComponent();

            analyteComboBox.Items.AddRange(new object[] { "Glukoza", "Hemoglobina", "Morfologia" });
            priorityComboBox.Items.AddRange(new object[] { "Zwykłe", "Pilne", "Cito" });

            analyteComboBox.SelectedIndex = 0;
            priorityComboBox.SelectedIndex = 0;

            this.service = service;

            RefreshGrid();
            
        }

        // TODO: refaktoryzacja: podzielić na warstwy.
        // PROBLEM: jeden handler liczy cenę, zapisuje do bazy i drukuje etykietę (SRP).
        // Żadnej z tych rzeczy nie da się przetestować bez uruchomienia okna, bazy i drukarki.
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var pesel = peselTextBox.Text;
            var analyte = (string)analyteComboBox.SelectedItem;
            var priority = (Priority)priorityComboBox.SelectedIndex;            

            var sample = service.Register(pesel, analyte, priority);
            
            statusLabel.Text = "Zarejestrowano, cena " + sample.Price.ToString("0.00") + " zł";
            peselTextBox.Clear();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            samplesGrid.DataSource = service.GetRegisteredSamples().ToList();

        }
    }
}
