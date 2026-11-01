using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            laboratoryComboBox.Items.AddRange(new object[] { "Centralne", "Partnerskie" });
            methodComboBox.Items.AddRange(new object[] { "Urykazowa", "Kolorymetryczna" });
            sexComboBox.Items.AddRange(new object[] { "K", "M" });
            customerComboBox.Items.AddRange(new object[]
            {
                "Cennik standardowy", "Przychodnia Zdrowie", "Klinika Nord", "Klinika Baltic", "Szpital Miejski"
            });

            laboratoryComboBox.SelectedIndex = 0;
            methodComboBox.SelectedIndex = 0;
            sexComboBox.SelectedIndex = 0;
            customerComboBox.SelectedIndex = 0;
        }

        private void LaboratoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: refaktoryzacja: jednostkę ma podawać wybrana procedura.
            // PROBLEM: kopia wiedzy z ResultProcessor (DRY). Nowe laboratorium to zmiana także w oknie.
            if ((string)laboratoryComboBox.SelectedItem == "Partnerskie")
            {
                unitLabel.Text = "Jednostka wyniku: mmol/l";
            }
            else
            {
                unitLabel.Text = "Jednostka wyniku: mg/dl";
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int age;
            decimal reading;
            if (!int.TryParse(ageTextBox.Text, out age) || !decimal.TryParse(readingTextBox.Text, out reading))
            {
                resultLabel.Text = "Podaj wiek i odczyt";
                return;
            }

            var result = ResultProcessor.Process(
                (string)laboratoryComboBox.SelectedItem,
                (string)methodComboBox.SelectedItem,
                age,
                (string)sexComboBox.SelectedItem,
                reading);

            if (result.Errors.Count > 0)
            {
                resultLabel.Text = string.Join(Environment.NewLine, result.Errors);
                return;
            }

            resultLabel.Text = string.Format(
                "Wynik: {0} {1}, norma {2}–{3}, ocena: {4}",
                result.Value,
                result.Unit,
                result.Low,
                result.High,
                FlagText(result.Flag));
        }

        private static string FlagText(ResultFlag flag)
        {
            if (flag == ResultFlag.Low)
            {
                return "poniżej normy";
            }

            return flag == ResultFlag.High ? "powyżej normy" : "w normie";
        }

        private void BillButton_Click(object sender, EventArgs e)
        {
            int copies;
            if (!int.TryParse(copiesTextBox.Text, out copies) || copies <= 0)
            {
                billingLabel.Text = "Podaj liczbę kopii";
                return;
            }

            var customer = (string)customerComboBox.SelectedItem;
            var cost = PrintBilling.CalculateCost(customer, copies);
            var discount = PrintBilling.CalculateDiscount(customer, copies, cost);

            billingLabel.Text = string.Format(
                "Koszt {0:0.00}, rabat {1:0.00}, do zapłaty {2:0.00} {3}",
                cost,
                discount,
                cost - discount,
                PrintBilling.GetCurrency(customer));
        }
    }
}
