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
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.samplesGrid = new System.Windows.Forms.DataGridView();
            this.exportSamplesButton = new System.Windows.Forms.Button();
            this.exportResultsButton = new System.Windows.Forms.Button();
            this.validateButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.samplesGrid)).BeginInit();
            this.SuspendLayout();
            //
            // statusComboBox
            //
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.Location = new System.Drawing.Point(12, 12);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(200, 21);
            this.statusComboBox.TabIndex = 0;
            //
            // samplesGrid
            //
            this.samplesGrid.AllowUserToAddRows = false;
            this.samplesGrid.AllowUserToDeleteRows = false;
            this.samplesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.samplesGrid.Location = new System.Drawing.Point(12, 42);
            this.samplesGrid.Name = "samplesGrid";
            this.samplesGrid.ReadOnly = true;
            this.samplesGrid.RowHeadersVisible = false;
            this.samplesGrid.Size = new System.Drawing.Size(660, 150);
            this.samplesGrid.TabIndex = 1;
            //
            // exportSamplesButton
            //
            this.exportSamplesButton.Location = new System.Drawing.Point(12, 200);
            this.exportSamplesButton.Name = "exportSamplesButton";
            this.exportSamplesButton.Size = new System.Drawing.Size(130, 23);
            this.exportSamplesButton.TabIndex = 3;
            this.exportSamplesButton.Text = "Eksportuj próbki";
            this.exportSamplesButton.UseVisualStyleBackColor = true;
            this.exportSamplesButton.Click += new System.EventHandler(this.ExportSamplesButton_Click);
            //
            // exportResultsButton
            //
            this.exportResultsButton.Location = new System.Drawing.Point(148, 200);
            this.exportResultsButton.Name = "exportResultsButton";
            this.exportResultsButton.Size = new System.Drawing.Size(130, 23);
            this.exportResultsButton.TabIndex = 4;
            this.exportResultsButton.Text = "Eksportuj wyniki";
            this.exportResultsButton.UseVisualStyleBackColor = true;
            this.exportResultsButton.Click += new System.EventHandler(this.ExportResultsButton_Click);
            //
            // validateButton
            //
            this.validateButton.Location = new System.Drawing.Point(284, 200);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(130, 23);
            this.validateButton.TabIndex = 5;
            this.validateButton.Text = "Waliduj przykład";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            //
            // outputTextBox
            //
            this.outputTextBox.Location = new System.Drawing.Point(12, 232);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(660, 160);
            this.outputTextBox.TabIndex = 7;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 404);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.exportSamplesButton);
            this.Controls.Add(this.exportResultsButton);
            this.Controls.Add(this.validateButton);
            this.Controls.Add(this.samplesGrid);
            this.Controls.Add(this.statusComboBox);
            this.Name = "MainForm";
            this.Text = "Eksport i walidacja (Problem)";
            ((System.ComponentModel.ISupportInitialize)(this.samplesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.DataGridView samplesGrid;
        private System.Windows.Forms.Button exportSamplesButton;
        private System.Windows.Forms.Button exportResultsButton;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.TextBox outputTextBox;
    }
}
