using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Vendor.Chemtron;
using Vendor.Hemolab;

namespace Lims.Problem
{
    public partial class ResultCollectionForm : Form
    {
        private const string HemolabName = "Hemolab H200";
        private const string ChemtronName = "Chemtron C5";

        private readonly BindingList<ResultRow> _results = new BindingList<ResultRow>();

        public ResultCollectionForm()
        {
            InitializeComponent();

            // TODO: refaktoryzacja: lista analizatorów składana w jednym miejscu, poza formularzem.
            // PROBLEM: nowy producent to zmiana w oknie, w dwóch handlerach i w tej liście (OCP).
            analyzerComboBox.Items.AddRange(new object[] { HemolabName, ChemtronName });
            analyzerComboBox.SelectedIndex = 0;

            resultsGrid.DataSource = _results;
        }

        // TODO: refaktoryzacja: wspólny interfejs analizatora i osobna klasa dla każdego producenta.
        // PROBLEM: formularz zna typy, formaty i kody błędów obu producentów (DIP). Bez urządzenia
        // nie da się uruchomić tej metody, więc reguł nie można sprawdzić testem.
        private void CollectButton_Click(object sender, EventArgs e)
        {
            var sampleCode = sampleTextBox.Text.Trim();
            if (sampleCode.Length == 0)
            {
                statusLabel.Text = "Podaj kod próbki";
                return;
            }

            var analyzer = (string)analyzerComboBox.SelectedItem;
            decimal glucoseMgDl;

            if (analyzer == HemolabName)
            {
                var device = new HemolabDevice();
                try
                {
                    device.Connect("COM3");
                    var message = device.ReadMessage(sampleCode);

                    // TODO: refaktoryzacja: odczyt wiadomości w jednym miejscu, z testem.
                    // PROBLEM: numery segmentu i pola wpisane na sztywno. Pole z jednostką jest
                    // ignorowane, więc po aktualizacji oprogramowania analizatora wynik będzie błędny.
                    var fields = message.Split('\r')[3].Split('|');

                    // TODO: refaktoryzacja: przeliczanie jednostek w jednym miejscu.
                    // PROBLEM: wiedza o mmol/L jest w formularzu, a jej kopia w pomiarze kontrolnym nie ma przeliczenia (DRY).
                    glucoseMgDl = Math.Round(decimal.Parse(fields[5], CultureInfo.InvariantCulture) * 18.016m, 1);
                }
                catch (HemolabCommException ex)
                {
                    // TODO: refaktoryzacja: wyjątki producenta zamienić na wyjątek aplikacji.
                    // PROBLEM: numery błędów producenta w formularzu, a pozostałe błędy trafiają do
                    // użytkownika w surowej postaci, np. „E101 NO DEVICE ON PORT COM3”.
                    statusLabel.Text = ex.ErrorCode == 204 ? "Analizator nie zna tej próbki" : ex.Message;
                    return;
                }
                finally
                {
                    device.Disconnect();
                }
            }
            else
            {
                var client = new ChemtronClient("192.168.0.20");
                try
                {
                    client.Open();
                    var records = client.QueryRecords(sampleCode);

                    // TODO: refaktoryzacja: odczyt rekordów w jednym miejscu, z testem.
                    // PROBLEM: inny format, ten sam kod powielony dla każdego producenta. Brak próbki
                    // poznajemy tu po liczbie rekordów, a u Hemolab po numerze błędu.
                    var lines = records.Split('\r');
                    if (lines.Length < 5)
                    {
                        statusLabel.Text = "Analizator nie zna tej próbki";
                        return;
                    }

                    glucoseMgDl = decimal.Parse(lines[3].Split('|')[3], CultureInfo.InvariantCulture);
                }
                catch (ChemtronException ex)
                {
                    statusLabel.Text = ex.Message;
                    return;
                }
                finally
                {
                    client.Close();
                }
            }

            // TODO: refaktoryzacja: reguły zakresu poza formularzem.
            // PROBLEM: reguła biznesowa w handlerze (SRP), a żeby do niej dojść, potrzebne jest urządzenie.
            string status;
            if (glucoseMgDl < 40m || glucoseMgDl > 200m) status = "Krytyczny";
            else if (glucoseMgDl < 70m) status = "Poniżej normy";
            else if (glucoseMgDl > 100m) status = "Powyżej normy";
            else status = "W normie";

            _results.Add(new ResultRow { Sample = sampleCode, Analyzer = analyzer, GlucoseMgDl = glucoseMgDl, Status = status });
            statusLabel.Text = "Pobrano wynik próbki " + sampleCode;
        }

        // TODO: refaktoryzacja: pomiar kontrolny korzysta z tego samego odczytu co zwykły pomiar.
        // PROBLEM: kopia kodu obu producentów (DRY), która już różni się od oryginału.
        private void ControlButton_Click(object sender, EventArgs e)
        {
            var materialCode = sampleTextBox.Text.Trim();
            var analyzer = (string)analyzerComboBox.SelectedItem;
            decimal value;

            if (analyzer == HemolabName)
            {
                var device = new HemolabDevice();
                try
                {
                    device.Connect("COM3");
                    var message = device.ReadMessage(materialCode);

                    // TODO: refaktoryzacja: odczyt i przeliczenie tylko w jednej klasie dla tego producenta.
                    // PROBLEM: brak przeliczenia z mmol/L. Materiał kontrolny ma 5,00 mmol/L, czyli około 90 mg/dL,
                    // a kod porównuje 5,00 z zakresem 81–99, więc sprawny analizator nigdy nie przechodzi kontroli.
                    value = decimal.Parse(message.Split('\r')[3].Split('|')[5], CultureInfo.InvariantCulture);
                }
                catch (HemolabCommException ex)
                {
                    statusLabel.Text = ex.Message;
                    return;
                }
                finally
                {
                    device.Disconnect();
                }
            }
            else
            {
                // TODO: refaktoryzacja: awaria każdego producenta jako jeden wyjątek aplikacji.
                // PROBLEM: tu nikt nie łapie ChemtronException. Awaria analizatora kończy się
                // nieobsłużonym wyjątkiem w oknie, a połączenie nie zostaje zamknięte.
                var client = new ChemtronClient("192.168.0.20");
                client.Open();
                var records = client.QueryRecords(materialCode);
                value = decimal.Parse(records.Split('\r')[3].Split('|')[3], CultureInfo.InvariantCulture);
                client.Close();
            }

            statusLabel.Text = value >= 81m && value <= 99m
                ? "Kontrola zaliczona: " + value + " mg/dL"
                : "Kontrola NIEZALICZONA: " + value + " mg/dL, oczekiwano 81–99";
        }
    }
}
