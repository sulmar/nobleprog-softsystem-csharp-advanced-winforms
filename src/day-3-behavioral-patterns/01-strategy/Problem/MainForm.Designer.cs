namespace Lims.Problem
{
    partial class MainForm
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
            this.resultGroupBox = new System.Windows.Forms.GroupBox();
            this.laboratoryLabel = new System.Windows.Forms.Label();
            this.laboratoryComboBox = new System.Windows.Forms.ComboBox();
            this.methodLabel = new System.Windows.Forms.Label();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.sexLabel = new System.Windows.Forms.Label();
            this.sexComboBox = new System.Windows.Forms.ComboBox();
            this.readingLabel = new System.Windows.Forms.Label();
            this.readingTextBox = new System.Windows.Forms.TextBox();
            this.unitLabel = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.billingGroupBox = new System.Windows.Forms.GroupBox();
            this.customerLabel = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.copiesLabel = new System.Windows.Forms.Label();
            this.copiesTextBox = new System.Windows.Forms.TextBox();
            this.billButton = new System.Windows.Forms.Button();
            this.billingLabel = new System.Windows.Forms.Label();
            this.resultGroupBox.SuspendLayout();
            this.billingGroupBox.SuspendLayout();
            this.SuspendLayout();
            //
            // resultGroupBox
            //
            this.resultGroupBox.Controls.Add(this.resultLabel);
            this.resultGroupBox.Controls.Add(this.calculateButton);
            this.resultGroupBox.Controls.Add(this.unitLabel);
            this.resultGroupBox.Controls.Add(this.readingTextBox);
            this.resultGroupBox.Controls.Add(this.readingLabel);
            this.resultGroupBox.Controls.Add(this.sexComboBox);
            this.resultGroupBox.Controls.Add(this.sexLabel);
            this.resultGroupBox.Controls.Add(this.ageTextBox);
            this.resultGroupBox.Controls.Add(this.ageLabel);
            this.resultGroupBox.Controls.Add(this.methodComboBox);
            this.resultGroupBox.Controls.Add(this.methodLabel);
            this.resultGroupBox.Controls.Add(this.laboratoryComboBox);
            this.resultGroupBox.Controls.Add(this.laboratoryLabel);
            this.resultGroupBox.Location = new System.Drawing.Point(12, 12);
            this.resultGroupBox.Name = "resultGroupBox";
            this.resultGroupBox.Size = new System.Drawing.Size(536, 190);
            this.resultGroupBox.TabIndex = 0;
            this.resultGroupBox.TabStop = false;
            this.resultGroupBox.Text = "Kwas moczowy";
            //
            // laboratoryLabel
            //
            this.laboratoryLabel.AutoSize = true;
            this.laboratoryLabel.Location = new System.Drawing.Point(10, 28);
            this.laboratoryLabel.Name = "laboratoryLabel";
            this.laboratoryLabel.TabIndex = 0;
            this.laboratoryLabel.Text = "Laboratorium:";
            //
            // laboratoryComboBox
            //
            this.laboratoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.laboratoryComboBox.Location = new System.Drawing.Point(110, 25);
            this.laboratoryComboBox.Name = "laboratoryComboBox";
            this.laboratoryComboBox.Size = new System.Drawing.Size(150, 21);
            this.laboratoryComboBox.TabIndex = 1;
            this.laboratoryComboBox.SelectedIndexChanged += new System.EventHandler(this.LaboratoryComboBox_SelectedIndexChanged);
            //
            // methodLabel
            //
            this.methodLabel.AutoSize = true;
            this.methodLabel.Location = new System.Drawing.Point(275, 28);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.TabIndex = 2;
            this.methodLabel.Text = "Metoda:";
            //
            // methodComboBox
            //
            this.methodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodComboBox.Location = new System.Drawing.Point(365, 25);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(150, 21);
            this.methodComboBox.TabIndex = 3;
            //
            // ageLabel
            //
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(10, 58);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.TabIndex = 4;
            this.ageLabel.Text = "Wiek pacjenta:";
            //
            // ageTextBox
            //
            this.ageTextBox.Location = new System.Drawing.Point(110, 55);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(60, 20);
            this.ageTextBox.TabIndex = 5;
            //
            // sexLabel
            //
            this.sexLabel.AutoSize = true;
            this.sexLabel.Location = new System.Drawing.Point(275, 58);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.TabIndex = 6;
            this.sexLabel.Text = "Płeć:";
            //
            // sexComboBox
            //
            this.sexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexComboBox.Location = new System.Drawing.Point(365, 55);
            this.sexComboBox.Name = "sexComboBox";
            this.sexComboBox.Size = new System.Drawing.Size(150, 21);
            this.sexComboBox.TabIndex = 7;
            //
            // readingLabel
            //
            this.readingLabel.AutoSize = true;
            this.readingLabel.Location = new System.Drawing.Point(10, 88);
            this.readingLabel.Name = "readingLabel";
            this.readingLabel.TabIndex = 8;
            this.readingLabel.Text = "Odczyt (mg/dl):";
            //
            // readingTextBox
            //
            this.readingTextBox.Location = new System.Drawing.Point(110, 85);
            this.readingTextBox.Name = "readingTextBox";
            this.readingTextBox.Size = new System.Drawing.Size(60, 20);
            this.readingTextBox.TabIndex = 9;
            //
            // unitLabel
            //
            this.unitLabel.AutoSize = true;
            this.unitLabel.Location = new System.Drawing.Point(275, 88);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.TabIndex = 10;
            //
            // calculateButton
            //
            this.calculateButton.Location = new System.Drawing.Point(110, 115);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(100, 23);
            this.calculateButton.TabIndex = 11;
            this.calculateButton.Text = "Przelicz";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            //
            // resultLabel
            //
            this.resultLabel.Location = new System.Drawing.Point(10, 146);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(516, 36);
            this.resultLabel.TabIndex = 12;
            //
            // billingGroupBox
            //
            this.billingGroupBox.Controls.Add(this.billingLabel);
            this.billingGroupBox.Controls.Add(this.billButton);
            this.billingGroupBox.Controls.Add(this.copiesTextBox);
            this.billingGroupBox.Controls.Add(this.copiesLabel);
            this.billingGroupBox.Controls.Add(this.customerComboBox);
            this.billingGroupBox.Controls.Add(this.customerLabel);
            this.billingGroupBox.Location = new System.Drawing.Point(12, 208);
            this.billingGroupBox.Name = "billingGroupBox";
            this.billingGroupBox.Size = new System.Drawing.Size(536, 150);
            this.billingGroupBox.TabIndex = 1;
            this.billingGroupBox.TabStop = false;
            this.billingGroupBox.Text = "Rozliczenie wydruku";
            //
            // customerLabel
            //
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(10, 28);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.TabIndex = 0;
            this.customerLabel.Text = "Klient:";
            //
            // customerComboBox
            //
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.Location = new System.Drawing.Point(110, 25);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(200, 21);
            this.customerComboBox.TabIndex = 1;
            //
            // copiesLabel
            //
            this.copiesLabel.AutoSize = true;
            this.copiesLabel.Location = new System.Drawing.Point(10, 58);
            this.copiesLabel.Name = "copiesLabel";
            this.copiesLabel.TabIndex = 2;
            this.copiesLabel.Text = "Liczba kopii:";
            //
            // copiesTextBox
            //
            this.copiesTextBox.Location = new System.Drawing.Point(110, 55);
            this.copiesTextBox.Name = "copiesTextBox";
            this.copiesTextBox.Size = new System.Drawing.Size(60, 20);
            this.copiesTextBox.TabIndex = 3;
            //
            // billButton
            //
            this.billButton.Location = new System.Drawing.Point(110, 85);
            this.billButton.Name = "billButton";
            this.billButton.Size = new System.Drawing.Size(100, 23);
            this.billButton.TabIndex = 4;
            this.billButton.Text = "Rozlicz";
            this.billButton.UseVisualStyleBackColor = true;
            this.billButton.Click += new System.EventHandler(this.BillButton_Click);
            //
            // billingLabel
            //
            this.billingLabel.Location = new System.Drawing.Point(10, 118);
            this.billingLabel.Name = "billingLabel";
            this.billingLabel.Size = new System.Drawing.Size(516, 24);
            this.billingLabel.TabIndex = 5;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 370);
            this.Controls.Add(this.billingGroupBox);
            this.Controls.Add(this.resultGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Przeliczanie wyników i rozliczenia (Problem)";
            this.resultGroupBox.ResumeLayout(false);
            this.resultGroupBox.PerformLayout();
            this.billingGroupBox.ResumeLayout(false);
            this.billingGroupBox.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox resultGroupBox;
        private System.Windows.Forms.Label laboratoryLabel;
        private System.Windows.Forms.ComboBox laboratoryComboBox;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.ComboBox sexComboBox;
        private System.Windows.Forms.Label readingLabel;
        private System.Windows.Forms.TextBox readingTextBox;
        private System.Windows.Forms.Label unitLabel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.GroupBox billingGroupBox;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Label copiesLabel;
        private System.Windows.Forms.TextBox copiesTextBox;
        private System.Windows.Forms.Button billButton;
        private System.Windows.Forms.Label billingLabel;
    }
}
