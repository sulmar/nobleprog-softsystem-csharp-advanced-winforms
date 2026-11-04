namespace Lims.Problem
{
    partial class SampleRegistrationForm
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
            this.peselLabel = new System.Windows.Forms.Label();
            this.peselTextBox = new System.Windows.Forms.TextBox();
            this.analyteComboBox = new System.Windows.Forms.ComboBox();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.samplesGrid = new System.Windows.Forms.DataGridView();
            this.previewButton = new System.Windows.Forms.Button();
            this.payerTypeComboBox = new System.Windows.Forms.ComboBox();
            this.printButton = new System.Windows.Forms.Button();
            this.StartAnalysisButton = new System.Windows.Forms.Button();
            this.CompleteAnalysisButton = new System.Windows.Forms.Button();
            this.statusAnalysisLabel = new System.Windows.Forms.Label();
            this.cancelAnalysisButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.samplesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // peselLabel
            // 
            this.peselLabel.AutoSize = true;
            this.peselLabel.Location = new System.Drawing.Point(12, 15);
            this.peselLabel.Name = "peselLabel";
            this.peselLabel.Size = new System.Drawing.Size(88, 13);
            this.peselLabel.TabIndex = 0;
            this.peselLabel.Text = "PESEL pacjenta:";
            // 
            // peselTextBox
            // 
            this.peselTextBox.Location = new System.Drawing.Point(110, 12);
            this.peselTextBox.Name = "peselTextBox";
            this.peselTextBox.Size = new System.Drawing.Size(150, 20);
            this.peselTextBox.TabIndex = 1;
            this.peselTextBox.Text = "01234567891";
            // 
            // analyteComboBox
            // 
            this.analyteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.analyteComboBox.Location = new System.Drawing.Point(12, 42);
            this.analyteComboBox.Name = "analyteComboBox";
            this.analyteComboBox.Size = new System.Drawing.Size(120, 21);
            this.analyteComboBox.TabIndex = 2;
            this.analyteComboBox.SelectedIndexChanged += new System.EventHandler(this.analyteComboBox_SelectedIndexChanged);
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityComboBox.Location = new System.Drawing.Point(140, 42);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(120, 21);
            this.priorityComboBox.TabIndex = 3;
            this.priorityComboBox.SelectedIndexChanged += new System.EventHandler(this.priorityComboBox_SelectedIndexChanged);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(12, 72);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(130, 23);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "Zarejestruj próbkę";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(150, 77);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusLabel.TabIndex = 5;
            // 
            // samplesGrid
            // 
            this.samplesGrid.AllowUserToAddRows = false;
            this.samplesGrid.AllowUserToDeleteRows = false;
            this.samplesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.samplesGrid.Location = new System.Drawing.Point(12, 104);
            this.samplesGrid.Name = "samplesGrid";
            this.samplesGrid.ReadOnly = true;
            this.samplesGrid.RowHeadersVisible = false;
            this.samplesGrid.Size = new System.Drawing.Size(560, 200);
            this.samplesGrid.TabIndex = 6;
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(415, 75);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(75, 23);
            this.previewButton.TabIndex = 7;
            this.previewButton.Text = "Podgląd";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // payerTypeComboBox
            // 
            this.payerTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payerTypeComboBox.Location = new System.Drawing.Point(266, 42);
            this.payerTypeComboBox.Name = "payerTypeComboBox";
            this.payerTypeComboBox.Size = new System.Drawing.Size(120, 21);
            this.payerTypeComboBox.TabIndex = 8;
            this.payerTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.payerTypeComboBox_SelectedIndexChanged);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(497, 75);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 9;
            this.printButton.Text = "Drukuj";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // StartAnalysisButton
            // 
            this.StartAnalysisButton.Location = new System.Drawing.Point(15, 329);
            this.StartAnalysisButton.Name = "StartAnalysisButton";
            this.StartAnalysisButton.Size = new System.Drawing.Size(127, 23);
            this.StartAnalysisButton.TabIndex = 10;
            this.StartAnalysisButton.Text = "Rozpocznij analizę";
            this.StartAnalysisButton.UseVisualStyleBackColor = true;
            this.StartAnalysisButton.Click += new System.EventHandler(this.StartAnalysisButton_Click);
            // 
            // CompleteAnalysisButton
            // 
            this.CompleteAnalysisButton.Location = new System.Drawing.Point(445, 329);
            this.CompleteAnalysisButton.Name = "CompleteAnalysisButton";
            this.CompleteAnalysisButton.Size = new System.Drawing.Size(127, 23);
            this.CompleteAnalysisButton.TabIndex = 11;
            this.CompleteAnalysisButton.Text = "Zakoncz analizę";
            this.CompleteAnalysisButton.UseVisualStyleBackColor = true;
            this.CompleteAnalysisButton.Click += new System.EventHandler(this.CompleteAnalysisButton_Click);
            // 
            // statusAnalysisLabel
            // 
            this.statusAnalysisLabel.AutoSize = true;
            this.statusAnalysisLabel.Location = new System.Drawing.Point(213, 334);
            this.statusAnalysisLabel.Name = "statusAnalysisLabel";
            this.statusAnalysisLabel.Size = new System.Drawing.Size(0, 13);
            this.statusAnalysisLabel.TabIndex = 12;
            // 
            // cancelAnalysisButton
            // 
            this.cancelAnalysisButton.Location = new System.Drawing.Point(298, 329);
            this.cancelAnalysisButton.Name = "cancelAnalysisButton";
            this.cancelAnalysisButton.Size = new System.Drawing.Size(137, 23);
            this.cancelAnalysisButton.TabIndex = 13;
            this.cancelAnalysisButton.Text = "Anuluj analizę";
            this.cancelAnalysisButton.UseVisualStyleBackColor = true;
            this.cancelAnalysisButton.Click += new System.EventHandler(this.cancelAnalysisButton_Click);
            // 
            // SampleRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.cancelAnalysisButton);
            this.Controls.Add(this.statusAnalysisLabel);
            this.Controls.Add(this.CompleteAnalysisButton);
            this.Controls.Add(this.StartAnalysisButton);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.payerTypeComboBox);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.samplesGrid);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.priorityComboBox);
            this.Controls.Add(this.analyteComboBox);
            this.Controls.Add(this.peselTextBox);
            this.Controls.Add(this.peselLabel);
            this.Name = "SampleRegistrationForm";
            this.Text = "Rejestracja próbki (Problem)";
            ((System.ComponentModel.ISupportInitialize)(this.samplesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label peselLabel;
        private System.Windows.Forms.TextBox peselTextBox;
        private System.Windows.Forms.ComboBox analyteComboBox;
        private System.Windows.Forms.ComboBox priorityComboBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DataGridView samplesGrid;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.ComboBox payerTypeComboBox;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button StartAnalysisButton;
        private System.Windows.Forms.Button CompleteAnalysisButton;
        private System.Windows.Forms.Label statusAnalysisLabel;
        private System.Windows.Forms.Button cancelAnalysisButton;
    }
}
