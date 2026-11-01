namespace Lims.Problem
{
    partial class ResultCollectionForm
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
            this.analyzerLabel = new System.Windows.Forms.Label();
            this.analyzerComboBox = new System.Windows.Forms.ComboBox();
            this.sampleLabel = new System.Windows.Forms.Label();
            this.sampleTextBox = new System.Windows.Forms.TextBox();
            this.collectButton = new System.Windows.Forms.Button();
            this.controlButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.resultsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
            this.SuspendLayout();
            //
            // analyzerLabel
            //
            this.analyzerLabel.AutoSize = true;
            this.analyzerLabel.Location = new System.Drawing.Point(12, 15);
            this.analyzerLabel.Name = "analyzerLabel";
            this.analyzerLabel.TabIndex = 0;
            this.analyzerLabel.Text = "Analizator:";
            //
            // analyzerComboBox
            //
            this.analyzerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.analyzerComboBox.Location = new System.Drawing.Point(110, 12);
            this.analyzerComboBox.Name = "analyzerComboBox";
            this.analyzerComboBox.Size = new System.Drawing.Size(170, 21);
            this.analyzerComboBox.TabIndex = 1;
            //
            // sampleLabel
            //
            this.sampleLabel.AutoSize = true;
            this.sampleLabel.Location = new System.Drawing.Point(12, 44);
            this.sampleLabel.Name = "sampleLabel";
            this.sampleLabel.TabIndex = 2;
            this.sampleLabel.Text = "Kod próbki:";
            //
            // sampleTextBox
            //
            this.sampleTextBox.Location = new System.Drawing.Point(110, 41);
            this.sampleTextBox.Name = "sampleTextBox";
            this.sampleTextBox.Size = new System.Drawing.Size(170, 20);
            this.sampleTextBox.TabIndex = 3;
            //
            // collectButton
            //
            this.collectButton.Location = new System.Drawing.Point(12, 70);
            this.collectButton.Name = "collectButton";
            this.collectButton.Size = new System.Drawing.Size(130, 23);
            this.collectButton.TabIndex = 4;
            this.collectButton.Text = "Pobierz wynik";
            this.collectButton.UseVisualStyleBackColor = true;
            this.collectButton.Click += new System.EventHandler(this.CollectButton_Click);
            //
            // controlButton
            //
            this.controlButton.Location = new System.Drawing.Point(150, 70);
            this.controlButton.Name = "controlButton";
            this.controlButton.Size = new System.Drawing.Size(130, 23);
            this.controlButton.TabIndex = 5;
            this.controlButton.Text = "Pomiar kontrolny";
            this.controlButton.UseVisualStyleBackColor = true;
            this.controlButton.Click += new System.EventHandler(this.ControlButton_Click);
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 102);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.TabIndex = 6;
            //
            // resultsGrid
            //
            this.resultsGrid.AllowUserToAddRows = false;
            this.resultsGrid.AllowUserToDeleteRows = false;
            this.resultsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultsGrid.Location = new System.Drawing.Point(12, 124);
            this.resultsGrid.Name = "resultsGrid";
            this.resultsGrid.ReadOnly = true;
            this.resultsGrid.RowHeadersVisible = false;
            this.resultsGrid.Size = new System.Drawing.Size(560, 200);
            this.resultsGrid.TabIndex = 7;
            //
            // ResultCollectionForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 336);
            this.Controls.Add(this.resultsGrid);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.controlButton);
            this.Controls.Add(this.collectButton);
            this.Controls.Add(this.sampleTextBox);
            this.Controls.Add(this.sampleLabel);
            this.Controls.Add(this.analyzerComboBox);
            this.Controls.Add(this.analyzerLabel);
            this.Name = "ResultCollectionForm";
            this.Text = "Pobieranie wyników (Problem)";
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label analyzerLabel;
        private System.Windows.Forms.ComboBox analyzerComboBox;
        private System.Windows.Forms.Label sampleLabel;
        private System.Windows.Forms.TextBox sampleTextBox;
        private System.Windows.Forms.Button collectButton;
        private System.Windows.Forms.Button controlButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DataGridView resultsGrid;
    }
}
