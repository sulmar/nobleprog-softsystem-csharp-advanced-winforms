namespace Lims.Exercise.Form
{
    partial class PatientSearchForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.queryLabel = new System.Windows.Forms.Label();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.openOrdersOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.simulateOutageCheckBox = new System.Windows.Forms.CheckBox();
            this.resultsListBox = new System.Windows.Forms.ListBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.openCardButton = new System.Windows.Forms.Button();
            this.newOrderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // queryLabel
            //
            this.queryLabel.AutoSize = true;
            this.queryLabel.Location = new System.Drawing.Point(12, 15);
            this.queryLabel.Name = "queryLabel";
            this.queryLabel.TabIndex = 0;
            this.queryLabel.Text = "Nazwisko lub PESEL:";
            //
            // queryTextBox
            //
            this.queryTextBox.Location = new System.Drawing.Point(130, 12);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(220, 20);
            this.queryTextBox.TabIndex = 1;
            this.queryTextBox.TextChanged += new System.EventHandler(this.Criteria_Changed);
            //
            // searchButton
            //
            this.searchButton.Location = new System.Drawing.Point(360, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(80, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Szukaj";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            //
            // clearButton
            //
            this.clearButton.Location = new System.Drawing.Point(448, 10);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(80, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Wyczyść";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            //
            // openOrdersOnlyCheckBox
            //
            this.openOrdersOnlyCheckBox.AutoSize = true;
            this.openOrdersOnlyCheckBox.Location = new System.Drawing.Point(130, 40);
            this.openOrdersOnlyCheckBox.Name = "openOrdersOnlyCheckBox";
            this.openOrdersOnlyCheckBox.TabIndex = 4;
            this.openOrdersOnlyCheckBox.Text = "Tylko z otwartymi zleceniami";
            this.openOrdersOnlyCheckBox.UseVisualStyleBackColor = true;
            this.openOrdersOnlyCheckBox.CheckedChanged += new System.EventHandler(this.Criteria_Changed);
            //
            // simulateOutageCheckBox
            //
            this.simulateOutageCheckBox.AutoSize = true;
            this.simulateOutageCheckBox.Location = new System.Drawing.Point(330, 40);
            this.simulateOutageCheckBox.Name = "simulateOutageCheckBox";
            this.simulateOutageCheckBox.TabIndex = 5;
            this.simulateOutageCheckBox.Text = "Symuluj awarię katalogu";
            this.simulateOutageCheckBox.UseVisualStyleBackColor = true;
            //
            // resultsListBox
            //
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.Location = new System.Drawing.Point(12, 66);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(516, 186);
            this.resultsListBox.TabIndex = 6;
            this.resultsListBox.SelectedIndexChanged += new System.EventHandler(this.ResultsListBox_SelectedIndexChanged);
            //
            // messageLabel
            //
            this.messageLabel.Location = new System.Drawing.Point(12, 260);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(516, 20);
            this.messageLabel.TabIndex = 7;
            //
            // openCardButton
            //
            this.openCardButton.Location = new System.Drawing.Point(12, 286);
            this.openCardButton.Name = "openCardButton";
            this.openCardButton.Size = new System.Drawing.Size(110, 23);
            this.openCardButton.TabIndex = 8;
            this.openCardButton.Text = "Otwórz kartę";
            this.openCardButton.UseVisualStyleBackColor = true;
            this.openCardButton.Click += new System.EventHandler(this.OpenCardButton_Click);
            //
            // newOrderButton
            //
            this.newOrderButton.Location = new System.Drawing.Point(130, 286);
            this.newOrderButton.Name = "newOrderButton";
            this.newOrderButton.Size = new System.Drawing.Size(110, 23);
            this.newOrderButton.TabIndex = 9;
            this.newOrderButton.Text = "Nowe zlecenie";
            this.newOrderButton.UseVisualStyleBackColor = true;
            this.newOrderButton.Click += new System.EventHandler(this.NewOrderButton_Click);
            //
            // PatientSearchForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 321);
            this.Controls.Add(this.newOrderButton);
            this.Controls.Add(this.openCardButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.simulateOutageCheckBox);
            this.Controls.Add(this.openOrdersOnlyCheckBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.queryLabel);
            this.Name = "PatientSearchForm";
            this.Text = "Wyszukiwanie pacjenta";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label queryLabel;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox openOrdersOnlyCheckBox;
        private System.Windows.Forms.CheckBox simulateOutageCheckBox;
        private System.Windows.Forms.ListBox resultsListBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button openCardButton;
        private System.Windows.Forms.Button newOrderButton;
    }
}
