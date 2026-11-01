using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lims.Exercise.Form
{
    public partial class ResultApprovalForm : System.Windows.Forms.Form
    {
        // Symulacja bazy danych. Wiersz: wartość, górna granica, dolna granica, zatwierdzający, data, komentarz.
        private static readonly Dictionary<string, object[]> Results = new Dictionary<string, object[]>
        {
            { "S-1", new object[] { 90m, 100m, 70m, null, null, null } },
            { "S-2", new object[] { 150m, 100m, 70m, null, null, null } },
            { "S-3", new object[] { 250m, 100m, 70m, null, null, null } }
        };

        public ResultApprovalForm()
        {
            InitializeComponent();
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            var code = codeTextBox.Text;
            var approver = approverTextBox.Text;
            var comment = commentTextBox.Text;

            if (!Results.ContainsKey(code))
            {
                statusLabel.Text = "Nieznany kod próbki";
                return;
            }

            if (approver.Length == 0)
            {
                statusLabel.Text = "Podaj nazwisko zatwierdzającego";
                approverTextBox.Focus();
                return;
            }

            var row = Results[code];

            if (row[3] != null)
            {
                statusLabel.Text = "Wynik został już zatwierdzony przez " + row[3];
                return;
            }

            var value = (decimal)row[0];
            var high = (decimal)row[1];
            var low = (decimal)row[2];

            if ((value < low || value > high) && comment.Length == 0)
            {
                statusLabel.Text = "Wynik poza zakresem wymaga komentarza";
                commentTextBox.Focus();
                return;
            }

            row[3] = approver;
            row[4] = DateTime.Now;
            row[5] = comment;

            if (value > high * 2)
            {
                // Symulacja wysłania SMS do lekarza.
                File.AppendAllText("sms.txt", "Wynik krytyczny próbki " + code + ": " + value + Environment.NewLine);
            }

            statusLabel.Text = "Zatwierdzono wynik próbki " + code;
        }
    }
}
