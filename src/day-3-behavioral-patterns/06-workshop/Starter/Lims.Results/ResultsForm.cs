using System;
using System.Drawing;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LabConnect.Sdk;

namespace Lims.Results
{
    public partial class ResultsForm : Form
    {
        private static readonly CultureInfo Polish = CultureInfo.GetCultureInfo("pl-PL");

        public StatisticsForm StatsWindow;
        public List<ResultDetailsForm> OpenDetails = new List<ResultDetailsForm>();

        private bool _refreshing;
        private bool _loaded;

        public ResultsForm()
        {
            InitializeComponent();

            operatorComboBox.Items.AddRange(new object[] { "mgr A. Nowak", "mgr B. Lis", "dr C. Wrona", "dr D. Sowa" });
            operatorComboBox.SelectedIndex = 0;

            filterComboBox.Items.AddRange(new object[] { "Wszystkie", "Nowy", "Zweryfikowany", "Zatwierdzony", "Wysłany", "Odrzucony" });
            filterComboBox.SelectedIndex = 0;
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            _loaded = true;
            RefreshGrid();
            RefreshAudit();
            statusLabel.Text = "Gotowe.";
        }

        public void RefreshGrid()
        {
            _refreshing = true;

            var previous = SelectedResult();
            string filter = (string)filterComboBox.SelectedItem;
            DataGridViewRow toSelect = null;

            resultsGrid.Rows.Clear();
            foreach (var r in Db.Results)
            {
                if (filter != "Wszystkie" && r.Status != filter)
                {
                    continue;
                }

                string flag = EvaluateFlag(r.TestType, r.Value, r.RefLow, r.RefHigh);
                if (onlyAbnormalCheckBox.Checked && flag == "")
                {
                    continue;
                }

                int index = resultsGrid.Rows.Add(r.SampleCode, r.PatientName, r.TestType, r.Analyte,
                    FormatValue(r.TestType, r.Value, r.Unit), FormatRange(r.TestType, r.RefLow, r.RefHigh), flag, r.Status);
                var row = resultsGrid.Rows[index];
                row.Tag = r;

                if (r.Status == "Odrzucony")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if (flag == "HH" || flag == "LL")
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else if (flag != "")
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else if (r.Status == "Wysłany")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }

                if (r == previous)
                {
                    toSelect = row;
                }
            }

            if (toSelect == null && resultsGrid.Rows.Count > 0)
            {
                toSelect = resultsGrid.Rows[0];
            }

            if (toSelect != null)
            {
                resultsGrid.CurrentCell = toSelect.Cells[0];
            }

            _refreshing = false;
            LoadSelection();
        }

        public void RefreshAudit()
        {
            auditListBox.Items.Clear();
            for (int i = Db.Audit.Count - 1; i >= 0; i--)
            {
                auditListBox.Items.Add(Db.Audit[i]);
            }
        }

        public void AddAudit(string text)
        {
            Db.Audit.Add(DateTime.Now.ToString("HH:mm:ss") + " " + text);
        }

        public void AfterChange()
        {
            RefreshGrid();
            RefreshAudit();

            if (StatsWindow != null && !StatsWindow.IsDisposed)
            {
                StatsWindow.RefreshCounts();
            }

            foreach (var details in OpenDetails)
            {
                details.ReloadFromResult();
            }
        }

        public void SetFilter(string status)
        {
            filterComboBox.SelectedItem = status;
            Activate();
        }

        private LabResult SelectedResult()
        {
            return resultsGrid.CurrentRow == null ? null : resultsGrid.CurrentRow.Tag as LabResult;
        }

        private void LoadSelection()
        {
            var r = SelectedResult();

            commentTextBox.Text = r == null ? "" : r.Comment;
            selectionLabel.Text = r == null ? "Nie wybrano wyniku" : "Wybrano: " + r.SampleCode + ", " + r.PatientName;

            verifyButton.Enabled = r != null && r.Status == "Nowy";
            verifyMenuItem.Enabled = r != null && r.Status == "Nowy";

            approveButton.Enabled = r != null && r.Status == "Zweryfikowany";
            approveMenuItem.Enabled = r != null && r.Status == "Zweryfikowany";

            rejectButton.Enabled = r != null && (r.Status == "Nowy" || r.Status == "Zweryfikowany");
            rejectMenuItem.Enabled = r != null && (r.Status == "Nowy" || r.Status == "Zweryfikowany");

            reopenButton.Enabled = r != null && r.Status == "Odrzucony";
            reopenMenuItem.Enabled = r != null && r.Status == "Odrzucony";

            sendButton.Enabled = r != null && r.Status == "Zatwierdzony";
            sendMenuItem.Enabled = r != null && r.Status == "Zatwierdzony";

            printButton.Enabled = r != null && (r.Status == "Zatwierdzony" || r.Status == "Wysłany");
            printMenuItem.Enabled = r != null && (r.Status == "Zatwierdzony" || r.Status == "Wysłany");

            detailsButton.Enabled = r != null;
            detailsMenuItem.Enabled = r != null;
        }

        private void resultsGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (!_refreshing)
            {
                LoadSelection();
            }
        }

        private void filter_Changed(object sender, EventArgs e)
        {
            if (_loaded)
            {
                RefreshGrid();
            }
        }

        public string ValidateValue(string testType, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "Brak wartości wyniku.";
            }

            decimal number;
            switch (testType)
            {
                case "Biochemia":
                    if (!TryParseNumber(value, out number) || number < 0)
                    {
                        return "Wynik biochemiczny musi być liczbą nieujemną.";
                    }
                    return null;

                case "Hematologia":
                    if (!TryParseNumber(value, out number) || number <= 0)
                    {
                        return "Wynik hematologiczny musi być liczbą dodatnią.";
                    }
                    return null;

                case "Koagulacja":
                    if (!TryParseNumber(value, out number) || number < 0.5m || number > 12m)
                    {
                        return "INR musi mieścić się w zakresie 0,5–12.";
                    }
                    return null;

                case "Mikrobiologia":
                    if (value != "Ujemny" && value != "Dodatni")
                    {
                        return "Wynik posiewu to Ujemny albo Dodatni.";
                    }
                    return null;

                default:
                    return "Nieznany rodzaj badania.";
            }
        }

        public string EvaluateFlag(string testType, string value, decimal low, decimal high)
        {
            decimal number;
            switch (testType)
            {
                case "Biochemia":
                    if (!TryParseNumber(value, out number)) return "";
                    if (number > high * 2) return "HH";
                    if (number > high) return "H";
                    if (number < low / 2) return "LL";
                    if (number < low) return "L";
                    return "";

                case "Hematologia":
                    if (!TryParseNumber(value, out number)) return "";
                    if (number > high * 1.5m) return "HH";
                    if (number > high) return "H";
                    if (number < low * 0.5m) return "LL";
                    if (number < low) return "L";
                    return "";

                case "Koagulacja":
                    if (!TryParseNumber(value, out number)) return "";
                    if (number > 4.5m) return "HH";
                    if (number > high) return "H";
                    if (number < low) return "L";
                    return "";

                case "Mikrobiologia":
                    return value == "Dodatni" ? "POS" : "";

                default:
                    return "";
            }
        }

        public string FormatValue(string testType, string value, string unit)
        {
            decimal number;
            string text;
            switch (testType)
            {
                case "Biochemia":
                    if (!TryParseNumber(value, out number)) return string.IsNullOrEmpty(value) ? "-" : value;
                    text = number.ToString("F1", Polish);
                    break;

                case "Hematologia":
                case "Koagulacja":
                    if (!TryParseNumber(value, out number)) return string.IsNullOrEmpty(value) ? "-" : value;
                    text = number.ToString("F2", Polish);
                    break;

                default:
                    return string.IsNullOrEmpty(value) ? "-" : value;
            }

            return unit == "" ? text : text + " " + unit;
        }

        public string FormatRange(string testType, decimal low, decimal high)
        {
            switch (testType)
            {
                case "Biochemia":
                    return low.ToString("F1", Polish) + "–" + high.ToString("F1", Polish);
                case "Hematologia":
                case "Koagulacja":
                    return low.ToString("F2", Polish) + "–" + high.ToString("F2", Polish);
                case "Mikrobiologia":
                    return "Ujemny";
                default:
                    return "";
            }
        }

        private static bool TryParseNumber(string value, out decimal number)
        {
            return decimal.TryParse((value ?? "").Replace('.', ','), NumberStyles.Number, Polish, out number);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            statusLabel.Text = "Łączenie z analizatorem...";
            statusLabel.Refresh();

            var session = new LcAnalyzerSession();
            int code = session.Open(portTextBox.Text.Trim(), 9600);
            if (code != LcAnalyzerSession.LC_OK)
            {
                Cursor = Cursors.Default;
                statusLabel.Text = "Błąd połączenia.";
                MessageBox.Show("Nie można połączyć z analizatorem (kod " + code + ").", "Import");
                return;
            }

            progressBar.Maximum = session.PendingFrames;
            progressBar.Value = 0;
            int added = 0;
            int skipped = 0;

            while (session.PendingFrames > 0)
            {
                string frame;
                if (session.NextFrame(out frame) != LcAnalyzerSession.LC_OK)
                {
                    break;
                }

                var parts = frame.Split('|');
                if (Db.Results.Any(x => x.SampleCode == parts[0]))
                {
                    skipped++;
                }
                else
                {
                    var r = new LabResult { SampleCode = parts[0], PatientName = parts[1], PatientId = parts[2], Status = "Nowy" };

                    switch (parts[3])
                    {
                        case "BIO": r.TestType = "Biochemia"; break;
                        case "HEM": r.TestType = "Hematologia"; break;
                        case "KOA": r.TestType = "Koagulacja"; break;
                        default: r.TestType = "Mikrobiologia"; break;
                    }

                    switch (parts[4])
                    {
                        case "GLU": r.Analyte = "Glukoza"; r.Unit = "mmol/l"; r.RefLow = 3.9m; r.RefHigh = 5.5m; break;
                        case "CRE": r.Analyte = "Kreatynina"; r.Unit = "mg/dl"; r.RefLow = 0.7m; r.RefHigh = 1.3m; break;
                        case "HGB": r.Analyte = "Hemoglobina"; r.Unit = "g/dl"; r.RefLow = 12m; r.RefHigh = 16m; break;
                        case "WBC": r.Analyte = "Leukocyty"; r.Unit = "10^9/l"; r.RefLow = 4m; r.RefHigh = 10m; break;
                        case "INR": r.Analyte = "INR"; r.Unit = ""; r.RefLow = 0.9m; r.RefHigh = 1.2m; break;
                        default: r.Analyte = "Posiew moczu"; r.Unit = ""; break;
                    }

                    if (parts[5] == "POS") r.Value = "Dodatni";
                    else if (parts[5] == "NEG") r.Value = "Ujemny";
                    else r.Value = parts[5].Replace('.', ',');

                    Db.Results.Add(r);
                    added++;
                }

                progressBar.Value = progressBar.Value + 1;
                progressBar.Refresh();
            }

            session.Close();
            progressBar.Value = 0;
            Cursor = Cursors.Default;

            AddAudit("Import z analizatora: dodano " + added + ", pominięto " + skipped);
            statusLabel.Text = "Import: dodano " + added + ", pominięto " + skipped + ".";

            if (added > 0)
            {
                AfterChange();
            }
            else
            {
                RefreshAudit();
            }
        }

        private void importMenuItem_Click(object sender, EventArgs e)
        {
            importButton_Click(sender, e);
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            var r = SelectedResult();
            string op = (string)operatorComboBox.SelectedItem;

            string error = ValidateValue(r.TestType, r.Value);
            if (error != null)
            {
                MessageBox.Show(error, "Weryfikacja");
                return;
            }

            r.Status = "Zweryfikowany";
            r.VerifiedBy = op;
            r.Comment = commentTextBox.Text.Trim();
            AddAudit("Zweryfikowano " + r.SampleCode + ", " + op);
            statusLabel.Text = "Zweryfikowano " + r.SampleCode + ".";
            AfterChange();
        }

        private void verifyMenuItem_Click(object sender, EventArgs e)
        {
            var r = SelectedResult();
            string op = (string)operatorComboBox.SelectedItem;

            string error = ValidateValue(r.TestType, r.Value);
            if (error != null)
            {
                MessageBox.Show(error, "Weryfikacja");
                return;
            }

            r.Status = "Zweryfikowany";
            r.VerifiedBy = op;
            r.Comment = commentTextBox.Text.Trim();
            AddAudit("Zweryfikowano " + r.SampleCode + ", " + op);
            statusLabel.Text = "Zweryfikowano " + r.SampleCode + ".";
            AfterChange();
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            var r = SelectedResult();
            string op = (string)operatorComboBox.SelectedItem;
            string comment = commentTextBox.Text.Trim();

            if (!op.StartsWith("dr "))
            {
                MessageBox.Show("Zatwierdzać może tylko diagnosta (dr).", "Zatwierdzanie");
                return;
            }

            if (op == r.VerifiedBy)
            {
                MessageBox.Show("Zatwierdzający musi być inną osobą niż weryfikujący.", "Zatwierdzanie");
                return;
            }

            string flag = EvaluateFlag(r.TestType, r.Value, r.RefLow, r.RefHigh);
            if (flag != "" && comment == "")
            {
                MessageBox.Show("Wynik poza zakresem wymaga komentarza.", "Zatwierdzanie");
                return;
            }

            r.Status = "Zatwierdzony";
            r.ApprovedBy = op;
            r.ApprovedAt = DateTime.Now;
            r.Comment = comment;
            AddAudit("Zatwierdzono " + r.SampleCode + ", " + op);

            bool critical = flag == "HH" || flag == "LL";
            if (critical)
            {
                File.AppendAllText("powiadomienia.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " Wynik krytyczny " + r.SampleCode
                    + " (" + r.PatientName + "): " + FormatValue(r.TestType, r.Value, r.Unit) + ". Zatwierdził: " + op + Environment.NewLine);
                AddAudit("Powiadomiono lekarza o wyniku " + r.SampleCode);
            }

            statusLabel.Text = "Zatwierdzono " + r.SampleCode + ".";
            AfterChange();

            if (critical)
            {
                MessageBox.Show("Wynik krytyczny, powiadomiono lekarza prowadzącego.", "Zatwierdzanie");
            }
        }

        private void approveMenuItem_Click(object sender, EventArgs e)
        {
            approveButton_Click(sender, e);
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            var r = SelectedResult();
            string op = (string)operatorComboBox.SelectedItem;
            string comment = commentTextBox.Text.Trim();

            if (comment == "")
            {
                MessageBox.Show("Odrzucenie wymaga podania powodu w komentarzu.", "Odrzucanie");
                return;
            }

            r.Status = "Odrzucony";
            r.VerifiedBy = "";
            r.Comment = comment;
            AddAudit("Odrzucono " + r.SampleCode + ", " + op + ": " + comment);
            statusLabel.Text = "Odrzucono " + r.SampleCode + ".";
            AfterChange();
        }

        private void rejectMenuItem_Click(object sender, EventArgs e)
        {
            rejectButton_Click(sender, e);
        }

        private void reopenButton_Click(object sender, EventArgs e)
        {
            var r = SelectedResult();
            string op = (string)operatorComboBox.SelectedItem;

            r.Status = "Nowy";
            r.VerifiedBy = "";
            AddAudit("Przywrócono " + r.SampleCode + ", " + op);
            statusLabel.Text = "Przywrócono " + r.SampleCode + " do poprawy.";
            AfterChange();
        }

        private void reopenMenuItem_Click(object sender, EventArgs e)
        {
            reopenButton_Click(sender, e);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            var r = SelectedResult();

            Cursor = Cursors.WaitCursor;
            statusLabel.Text = "Wysyłanie " + r.SampleCode + "...";
            statusLabel.Refresh();

            var message = new StringBuilder();
            message.Append("MSH|LIMS|ORU\n");
            message.Append("PID|" + r.PatientId + "|" + r.PatientName + "\n");

            string flag = EvaluateFlag(r.TestType, r.Value, r.RefLow, r.RefHigh);
            switch (r.TestType)
            {
                case "Biochemia":
                case "Hematologia":
                case "Koagulacja":
                    decimal number;
                    TryParseNumber(r.Value, out number);
                    message.Append("OBX|NM|" + r.Analyte + "|" + number.ToString(CultureInfo.InvariantCulture) + "|" + r.Unit + "|" + flag);
                    break;

                case "Mikrobiologia":
                    message.Append("OBX|ST|" + r.Analyte + "|" + (r.Value == "Dodatni" ? "POS" : "NEG") + "||" + flag);
                    break;
            }

            string ack;
            int code = new LcHisUplink().Transmit(message.ToString(), out ack);
            Cursor = Cursors.Default;

            if (code == LcHisUplink.LC_OK)
            {
                r.Status = "Wysłany";
                r.SentAt = DateTime.Now;
                AddAudit("Wysłano " + r.SampleCode + " do systemu szpitalnego");
                statusLabel.Text = "Wysłano " + r.SampleCode + ": " + ack;
                AfterChange();
            }
            else
            {
                AddAudit("Błąd wysyłki " + r.SampleCode + ": kod " + code);
                statusLabel.Text = "Błąd wysyłki.";
                RefreshAudit();
                MessageBox.Show("System szpitalny odrzucił wynik (kod " + code + "): " + ack, "Wysyłka");
            }
        }

        private void sendMenuItem_Click(object sender, EventArgs e)
        {
            sendButton_Click(sender, e);
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            var r = SelectedResult();
            string flag = EvaluateFlag(r.TestType, r.Value, r.RefLow, r.RefHigh);

            var report = new StringBuilder();
            report.AppendLine("LABORATORIUM DIAGNOSTYCZNE");
            report.AppendLine("Raport wyniku badania");
            report.AppendLine("Próbka: " + r.SampleCode);
            report.AppendLine("Pacjent: " + r.PatientName + " (" + (r.PatientId == "" ? "brak identyfikatora" : r.PatientId) + ")");
            report.AppendLine("Badanie: " + r.TestType + ", " + r.Analyte);
            report.AppendLine("Wynik: " + FormatValue(r.TestType, r.Value, r.Unit));
            report.AppendLine("Zakres: " + FormatRange(r.TestType, r.RefLow, r.RefHigh));
            if (flag != "")
            {
                report.AppendLine("Flaga: " + flag);
            }

            switch (r.TestType)
            {
                case "Biochemia":
                    report.AppendLine("Materiał: surowica.");
                    break;

                case "Hematologia":
                    report.AppendLine("Materiał: krew EDTA.");
                    if (flag != "")
                    {
                        report.AppendLine("Zalecany rozmaz ręczny.");
                    }
                    break;

                case "Koagulacja":
                    report.AppendLine("Materiał: osocze cytrynianowe.");
                    report.AppendLine("Zakres terapeutyczny dla leczonych VKA: 2,00–3,00.");
                    break;

                case "Mikrobiologia":
                    report.AppendLine("Materiał: zgodnie ze zleceniem.");
                    report.AppendLine(r.Value == "Dodatni" ? "Antybiogram w osobnym raporcie." : "Inkubacja 48 h bez wzrostu.");
                    break;
            }

            if (r.Comment != "")
            {
                report.AppendLine("Komentarz: " + r.Comment);
            }

            report.AppendLine("Zatwierdził: " + r.ApprovedBy + ", " + r.ApprovedAt.Value.ToString("yyyy-MM-dd HH:mm"));

            Directory.CreateDirectory("raporty");
            string path = Path.Combine("raporty", "raport_" + r.SampleCode + ".txt");
            File.WriteAllText(path, report.ToString());

            AddAudit("Wydrukowano raport " + r.SampleCode);
            statusLabel.Text = "Raport zapisano: " + path;
            RefreshAudit();
        }

        private void printMenuItem_Click(object sender, EventArgs e)
        {
            printButton_Click(sender, e);
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            var r = SelectedResult();
            if (r == null)
            {
                return;
            }

            var existing = OpenDetails.FirstOrDefault(x => x.Result == r);
            if (existing != null)
            {
                existing.Activate();
                return;
            }

            var details = new ResultDetailsForm(r, this);
            OpenDetails.Add(details);
            details.Show(this);
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            if (StatsWindow == null || StatsWindow.IsDisposed)
            {
                StatsWindow = new StatisticsForm(this);
                StatsWindow.Show(this);
            }
            else
            {
                StatsWindow.Activate();
            }
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var r = SelectedResult();

            switch (keyData)
            {
                case Keys.F2:
                    if (r != null && r.Status == "Nowy")
                    {
                        verifyMenuItem_Click(this, EventArgs.Empty);
                    }
                    return true;

                case Keys.F3:
                    if (r != null && r.Status == "Zweryfikowany")
                    {
                        string approver = (string)operatorComboBox.SelectedItem;
                        string comment = commentTextBox.Text.Trim();

                        if (!approver.StartsWith("dr "))
                        {
                            MessageBox.Show("Zatwierdzać może tylko diagnosta (dr).", "Zatwierdzanie");
                            return true;
                        }

                        if (approver == r.VerifiedBy)
                        {
                            MessageBox.Show("Zatwierdzający musi być inną osobą niż weryfikujący.", "Zatwierdzanie");
                            return true;
                        }

                        string flag = EvaluateFlag(r.TestType, r.Value, r.RefLow, r.RefHigh);
                        if (flag != "" && comment == "")
                        {
                            MessageBox.Show("Wynik poza zakresem wymaga komentarza.", "Zatwierdzanie");
                            return true;
                        }

                        r.Status = "Zatwierdzony";
                        r.ApprovedBy = approver;
                        r.ApprovedAt = DateTime.Now;
                        r.Comment = comment;
                        AddAudit("Zatwierdzono " + r.SampleCode + ", " + approver);

                        if (flag == "HH" || flag == "LL")
                        {
                            File.AppendAllText("powiadomienia.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " Wynik krytyczny " + r.SampleCode
                                + " (" + r.PatientName + "): " + FormatValue(r.TestType, r.Value, r.Unit) + ". Zatwierdził: " + approver + Environment.NewLine);
                            AddAudit("Powiadomiono lekarza o wyniku " + r.SampleCode);
                            statusLabel.Text = "Zatwierdzono " + r.SampleCode + ".";
                            AfterChange();
                            MessageBox.Show("Wynik krytyczny, powiadomiono lekarza prowadzącego.", "Zatwierdzanie");
                        }
                        else
                        {
                            statusLabel.Text = "Zatwierdzono " + r.SampleCode + ".";
                            AfterChange();
                        }
                    }
                    return true;

                case Keys.F4:
                    if (r != null && (r.Status == "Nowy" || r.Status == "Zweryfikowany"))
                    {
                        rejectButton_Click(this, EventArgs.Empty);
                    }
                    return true;

                case Keys.F5:
                    importButton_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F6:
                    if (r != null && r.Status == "Zatwierdzony")
                    {
                        sendButton_Click(this, EventArgs.Empty);
                    }
                    return true;

                case Keys.F9:
                    statisticsButton_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.P:
                    if (r != null && (r.Status == "Zatwierdzony" || r.Status == "Wysłany"))
                    {
                        printButton_Click(this, EventArgs.Empty);
                    }
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
