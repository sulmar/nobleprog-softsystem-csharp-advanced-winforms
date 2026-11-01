namespace Lims.Problem
{
    partial class ResultViewerForm
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
            this.userLabel = new System.Windows.Forms.Label();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.sampleLabel = new System.Windows.Forms.Label();
            this.sampleTextBox = new System.Windows.Forms.TextBox();
            this.showButton = new System.Windows.Forms.Button();
            this.valueLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.correctButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            //
            // userLabel
            //
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(12, 15);
            this.userLabel.Name = "userLabel";
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "Użytkownik:";
            //
            // userComboBox
            //
            this.userComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userComboBox.Location = new System.Drawing.Point(100, 12);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(210, 21);
            this.userComboBox.TabIndex = 1;
            this.userComboBox.SelectedIndexChanged += new System.EventHandler(this.UserComboBox_SelectedIndexChanged);
            //
            // sampleLabel
            //
            this.sampleLabel.AutoSize = true;
            this.sampleLabel.Location = new System.Drawing.Point(12, 45);
            this.sampleLabel.Name = "sampleLabel";
            this.sampleLabel.TabIndex = 2;
            this.sampleLabel.Text = "Kod próbki:";
            //
            // sampleTextBox
            //
            this.sampleTextBox.Location = new System.Drawing.Point(100, 42);
            this.sampleTextBox.Name = "sampleTextBox";
            this.sampleTextBox.Size = new System.Drawing.Size(90, 20);
            this.sampleTextBox.TabIndex = 3;
            //
            // showButton
            //
            this.showButton.Location = new System.Drawing.Point(200, 41);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(110, 23);
            this.showButton.TabIndex = 4;
            this.showButton.Text = "Pokaż wynik";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.ShowButton_Click);
            //
            // valueLabel
            //
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(12, 75);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.TabIndex = 5;
            this.valueLabel.Text = "Nowa wartość:";
            //
            // valueTextBox
            //
            this.valueTextBox.Location = new System.Drawing.Point(100, 72);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(90, 20);
            this.valueTextBox.TabIndex = 6;
            //
            // correctButton
            //
            this.correctButton.Location = new System.Drawing.Point(200, 71);
            this.correctButton.Name = "correctButton";
            this.correctButton.Size = new System.Drawing.Size(110, 23);
            this.correctButton.TabIndex = 7;
            this.correctButton.Text = "Koryguj";
            this.correctButton.UseVisualStyleBackColor = true;
            this.correctButton.Click += new System.EventHandler(this.CorrectButton_Click);
            //
            // resultLabel
            //
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(12, 105);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.TabIndex = 8;
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 128);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.TabIndex = 9;
            //
            // logListBox
            //
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(12, 152);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(560, 199);
            this.logListBox.TabIndex = 10;
            //
            // ResultViewerForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.correctButton);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.sampleTextBox);
            this.Controls.Add(this.sampleLabel);
            this.Controls.Add(this.userComboBox);
            this.Controls.Add(this.userLabel);
            this.Name = "ResultViewerForm";
            this.Text = "Wyniki badań (Problem)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.Label sampleLabel;
        private System.Windows.Forms.TextBox sampleTextBox;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Button correctButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ListBox logListBox;
    }
}
