using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class SampleRegistrationForm : Form
    {
        public SampleRegistrationForm()
        {
            InitializeComponent();

            materialComboBox.Items.AddRange(new object[] { "Krew", "Surowica", "Mocz" });
            analyteComboBox.Items.AddRange(new object[] { "Glukoza", "Hemoglobina", "Morfologia" });
            priorityComboBox.Items.AddRange(new object[] { "Zwykłe", "Pilne", "Cito" });

            materialComboBox.SelectedIndex = 0;
            analyteComboBox.SelectedIndex = 0;
            priorityComboBox.SelectedIndex = 0;

            RefreshGrid();
        }

        private void PriceInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: jedna definicja cennika.
            // PROBLEM: kopia obliczenia z RegisterButton_Click, z innym mnożnikiem dla priorytetu „Pilne” (DRY).
            // Rejestratorka podaje pacjentowi jedną cenę, a do bazy trafia inna.
            decimal price = 12m;
            if ((string)analyteComboBox.SelectedItem == "Hemoglobina") price = 18m;
            if ((string)analyteComboBox.SelectedItem == "Morfologia") price = 25m;
            if ((string)priorityComboBox.SelectedItem == "Pilne") price = price * 1.5m;
            if ((string)priorityComboBox.SelectedItem == "Cito") price = price * 2m;

            pricePreviewLabel.Text = "Cena: " + price.ToString("0.00") + " zł";
        }

        // TODO: refaktoryzacja: podzielić na warstwy.
        // PROBLEM: jeden handler odpowiada za odczyt pól, walidację, reguły biznesowe, zapis, wydruk
        // i odświeżenie okna (SRP). Każda zmiana dotyka tej samej metody, a żadnej reguły nie da się
        // przetestować bez uruchomienia okna, bazy i drukarki.
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var pesel = peselTextBox.Text;
            var material = (string)materialComboBox.SelectedItem;
            var analyte = (string)analyteComboBox.SelectedItem;
            var priority = (string)priorityComboBox.SelectedItem;

            // TODO: refaktoryzacja: przenieść walidację do warstwy domeny.
            // PROBLEM: reguła biznesowa zna kontrolkę i komunikat w oknie (SRP).
            if (pesel.Length != 11 || !pesel.All(char.IsDigit))
            {
                statusLabel.Text = "PESEL musi mieć 11 cyfr";
                peselTextBox.Focus();
                return;
            }

            // TODO: refaktoryzacja: ukryć dostęp do danych za interfejsem.
            // PROBLEM: formularz zna szczegóły przechowywania danych (DIP), więc zmiana bazy dotyka okna.
            var now = DateTime.Now;
            if (Database.Exists(pesel, analyte, now))
            {
                statusLabel.Text = "To badanie zarejestrowano już dziś dla tego pacjenta";
                return;
            }

            // TODO: refaktoryzacja: przenieść cennik i terminy do warstwy domeny.
            // PROBLEM: reguły biznesowe w handlerze. Nowy priorytet lub badanie to zmiana w formularzu (OCP),
            // a odczyt DateTime.Now uniemożliwia sprawdzenie terminu dla ustalonego czasu.
            decimal price = 12m;
            if (analyte == "Hemoglobina") price = 18m;
            if (analyte == "Morfologia") price = 25m;
            if (priority == "Pilne") price = price * 1.6m;
            if (priority == "Cito") price = price * 2m;

            DateTime dueAt;
            if (priority == "Cito")
            {
                dueAt = now.AddHours(4);
            }
            else if (priority == "Pilne")
            {
                dueAt = now.AddHours(24);
            }
            else
            {
                dueAt = now.AddHours(72);
            }

            var code = "S-" + now.Year + "-" + (Database.NextNumber++).ToString("D6");

            Database.Samples.Add(new object[] { code, pesel, material, analyte, priority, dueAt, price, now });

            // TODO: refaktoryzacja: ukryć drukowanie za interfejsem.
            // PROBLEM: formularz zna format etykiety i miejsce wydruku (SRP, DIP). Każda rejestracja
            // w teście drukowałaby prawdziwą etykietę.
            File.AppendAllText("labels.txt", code + " | " + analyte + " | termin " + dueAt.ToString("yyyy-MM-dd HH:mm") + Environment.NewLine);

            statusLabel.Text = "Zarejestrowano " + code + ", cena " + price.ToString("0.00") + " zł";
            peselTextBox.Clear();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            var rows = new List<SampleRow>();
            foreach (var row in Database.Samples)
            {
                rows.Add(new SampleRow
                {
                    Kod = (string)row[0],
                    Oznaczenie = (string)row[3],
                    Priorytet = (string)row[4],
                    Termin = (DateTime)row[5],
                    Cena = (decimal)row[6]
                });
            }

            samplesGrid.DataSource = rows;
        }

        private sealed class SampleRow
        {
            public string Kod { get; set; }
            public string Oznaczenie { get; set; }
            public string Priorytet { get; set; }
            public DateTime Termin { get; set; }
            public decimal Cena { get; set; }
        }
    }
}
