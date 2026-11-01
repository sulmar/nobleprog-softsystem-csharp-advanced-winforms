using System;
using System.Linq;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            statisticsPanel.UpdateStatistics();
        }

        // TODO: refaktoryzacja: ukryć kontrolkę i metody okna, a odbiorcy niech reagują na zdarzenie.
        // PROBLEM: inne okna sięgają tu po kontrolkę i metody tylko po to, by je odświeżyć (DIP).
        public StatisticsPanel StatisticsPanel
        {
            get { return statisticsPanel; }
        }

        public void ShowStatus(string text)
        {
            statusLabel.Text = text;
        }

        public void OpenResultList()
        {
            var listForm = Application.OpenForms.OfType<ResultListForm>().FirstOrDefault();
            if (listForm != null)
            {
                listForm.Activate();
                return;
            }

            new ResultListForm().Show(this);
        }

        private void OpenApprovalButton_Click(object sender, EventArgs e)
        {
            new ApprovalForm(this).Show(this);
        }

        private void OpenQualityControlButton_Click(object sender, EventArgs e)
        {
            new QualityControlForm().Show(this);
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            var openWindows = Application.OpenForms.OfType<QualityControlForm>().Count();
            subscriptionsLabel.Text = "Subskrypcje: " + LabData.SubscriberCount
                + ", otwarte okna kontroli: " + openWindows
                + ", powiadomienia do zamkniętych: " + LabData.DeliveriesToClosedWindows;
        }
    }
}
