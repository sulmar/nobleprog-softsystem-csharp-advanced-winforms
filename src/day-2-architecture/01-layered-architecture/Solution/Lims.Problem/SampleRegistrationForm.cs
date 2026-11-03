using System;
using System.Linq;
using System.Windows.Forms;
using LabelTech.Sdk;

namespace Lims.Problem
{
    public partial class SampleRegistrationForm : Form
    {
        public SampleRegistrationForm()
        {
            InitializeComponent();

            analyteComboBox.Items.AddRange(new object[] { "Glukoza", "Hemoglobina", "Morfologia" });
            priorityComboBox.Items.AddRange(new object[] { "Zwykłe", "Pilne", "Cito" });

            analyteComboBox.SelectedIndex = 0;
            priorityComboBox.SelectedIndex = 0;

            RefreshGrid();
        }

        // TODO: refaktoryzacja: podzielić na warstwy.
        // PROBLEM: jeden handler liczy cenę, zapisuje do bazy i drukuje etykietę (SRP).
        // Żadnej z tych rzeczy nie da się przetestować bez uruchomienia okna, bazy i drukarki.
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var pesel = peselTextBox.Text;
            var analyte = (string)analyteComboBox.SelectedItem;
            var priority = (string)priorityComboBox.SelectedItem;

            // TODO: refaktoryzacja: przenieść cennik do warstwy domeny.
            // PROBLEM: reguła biznesowa zapisana w handlerze i porównująca napisy z listy.
            decimal price = 12m;
            if (analyte == "Hemoglobina") price = 18m;
            if (analyte == "Morfologia") price = 25m;
            if (priority == "Pilne") price = price * 1.5m;
            if (priority == "Cito") price = price * 2m;

            // TODO: refaktoryzacja: ukryć bazę za interfejsem.
            // PROBLEM: formularz woła statyczną klasę (DIP), więc zmiana bazy dotyka okna.
            Database.Save(pesel, analyte, priority, price);

            // TODO: refaktoryzacja: ukryć drukarkę za interfejsem.
            // PROBLEM: formularz zna SDK jednego dostawcy i port urządzenia. Zmiana drukarki to zmiana okna,
            // a każda rejestracja w teście drukowałaby prawdziwą etykietę.
            var printer = new LabelTechPrinter();
            printer.Connect("COM3");
            printer.PrintLine(pesel + " | " + analyte + " | " + priority);
            printer.Disconnect();

            statusLabel.Text = "Zarejestrowano, cena " + price.ToString("0.00") + " zł";
            peselTextBox.Clear();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            samplesGrid.DataSource = Database.Samples.ToList();
        }
    }
}
