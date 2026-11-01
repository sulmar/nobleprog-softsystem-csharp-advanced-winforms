using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    // Okno główne tylko otwiera ekrany, symuluje awarie i pokazuje, co zrobiły podsystemy.
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Lab.Journal.EntryAdded += Journal_EntryAdded;
        }

        private void Journal_EntryAdded(string entry)
        {
            journalListBox.Items.Add(entry);
            journalListBox.TopIndex = journalListBox.Items.Count - 1;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Lab.Journal.EntryAdded -= Journal_EntryAdded;
        }

        private void ReceptionButton_Click(object sender, EventArgs e)
        {
            new ReceptionApprovalForm().Show(this);
        }

        private void UrgentButton_Click(object sender, EventArgs e)
        {
            new UrgentApprovalForm().Show(this);
        }

        private void BatchButton_Click(object sender, EventArgs e)
        {
            new BatchApprovalForm().Show(this);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            journalListBox.Items.Clear();
        }

        private void OutOfPaperCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Lab.Printer.OutOfPaper = outOfPaperCheckBox.Checked;
        }

        private void BillingDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Lab.Billing.Unavailable = billingDownCheckBox.Checked;
        }

        private void AuditDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Lab.Audit.Unavailable = auditDownCheckBox.Checked;
        }
    }
}
