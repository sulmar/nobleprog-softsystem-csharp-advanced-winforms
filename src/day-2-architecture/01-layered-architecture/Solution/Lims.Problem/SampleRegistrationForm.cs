using LabelTech.Sdk;
using Lims.Application;
using Lims.Domain;
using Lims.Infrastucture;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class SampleRegistrationForm : Form
    {
        private readonly SampleRegistrationService service;
        private readonly IFormFactory formFactory;
        private ICommand printCommand;
        private ICommand sendCommand;

        private readonly Queue<ICommand> commands = new Queue<ICommand>();

        public SampleRegistrationForm(SampleRegistrationService service, IFormFactory formFactory)
        {
            this.service = service;

            

            InitializeComponent();

            analyteComboBox.Items.AddRange(new object[] { "Glukoza", "Hemoglobina", "Morfologia" });
            priorityComboBox.Items.AddRange(new object[] { "Zwykłe", "Pilne", "Cito" });
            payerTypeComboBox.Items.AddRange(new object[] { "Komercja", "NFZ", "Pakiet", "Senior" });

            analyteComboBox.SelectedIndex = 0;
            priorityComboBox.SelectedIndex = 0;



            this.formFactory = formFactory;
            RefreshControls();

        }

        private Sample sample;

        // TODO: refaktoryzacja: podzielić na warstwy.
        // PROBLEM: jeden handler liczy cenę, zapisuje do bazy i drukuje etykietę (SRP).
        // Żadnej z tych rzeczy nie da się przetestować bez uruchomienia okna, bazy i drukarki.
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var pesel = peselTextBox.Text;
            var analyte = (string)analyteComboBox.SelectedItem;
            var priority = (Priority)priorityComboBox.SelectedIndex;
            var payerType = (PayerType)payerTypeComboBox.SelectedIndex;

            sample = new Sample();

            sample.Pesel = pesel;
            sample.Analyte = analyte;
            sample.Priority = priority;

            printCommand = new PrintCommand(sample);
            sendCommand = new SendCommand(sample);
            commands.Enqueue(printCommand);
            commands.Enqueue(sendCommand);

            sample = service.Register(sample, payerType);

            statusLabel.Text = "Zarejestrowano, cena " + sample.Price.ToString("0.00") + " zł";
            peselTextBox.Clear();
             RefreshControls();


            graphTextBox.Text = sample.GenerateMermaidGraph;
        }

        private void RefreshGrid()
        {
            samplesGrid.DataSource = service.GetRegisteredSamples().ToList();
        }

        private void RefreshControls()
        {
            RefreshGrid();

            printButton.Enabled = printCommand != null && printCommand.CanExecute();
            previewButton.Enabled = sendCommand != null && sendCommand.CanExecute();
        }



        private void buttonPreview_Click(object sender, EventArgs e)
        {
            // var form = new SamplePreviewForm(new InMemorySampleRepository());

            var form = formFactory.Create<SamplePreviewForm>();

            form.ShowDialog();
        }

        private void analyteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void priorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void payerTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            while (commands.Count > 0)
            {
                ICommand command = commands.Dequeue();

                if (command.CanExecute())
                    command.Execute();

            }
        }

        private void StartAnalysisButton_Click(object sender, EventArgs e)
        {
            try
            {
                sample.StartAnalysis();
                statusAnalysisLabel.Text = sample.Status.ToString();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Stan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CompleteAnalysisButton_Click(object sender, EventArgs e)
        {
            try
            {

                sample.CompleteAnalysis();
                statusAnalysisLabel.Text = sample.Status.ToString();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Stan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cancelAnalysisButton_Click(object sender, EventArgs e)
        {
            try
            {

                sample.CancelAnalysis();

                statusAnalysisLabel.Text = sample.Status.ToString();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Stan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
