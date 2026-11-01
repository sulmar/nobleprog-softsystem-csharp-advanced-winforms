using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class ApprovalForm : Form, IApprovalView
    {
        private readonly ApprovalPresenter _presenter;
        private readonly string _code;

        public ApprovalForm(string code)
        {
            InitializeComponent();

            // TODO: refaktoryzacja: Presenter przez konstruktor, a dane próbki osobną metodą.
            // PROBLEM: formularz tworzy Presenter, a ten resztę, więc całej tej konstrukcji nie da się podmienić (DIP).
            _code = code;
            _presenter = new ApprovalPresenter(this);

            // Przy drugim otwarciu okna tu poleci ObjectDisposedException. Przyczyna jest w DailyStatistics.
            _presenter.Load(code);
        }

        public string ApprovedBy
        {
            get { return approverTextBox.Text; }
        }

        public void ShowResult(LabResult result)
        {
            codeLabel.Text = "Próbka: " + result.Code;
            analyteLabel.Text = "Badanie: " + result.Analyte;
            valueLabel.Text = "Wynik: " + result.Value + (result.IsCritical ? " (krytyczny)" : string.Empty);
        }

        public void ShowApprovedToday(int count)
        {
            approvedTodayLabel.Text = "Zatwierdzono dziś: " + count;
        }

        public void ShowMessage(string message)
        {
            messageLabel.Text = message;
        }

        public void CloseWindow()
        {
            Close();
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            _presenter.Approve(_code);
        }

        private void ApprovalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _presenter.Close();
        }
    }
}
