namespace Lims.Problem
{
    partial class ResultsForm
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
            this.resultsGrid = new System.Windows.Forms.DataGridView();
            this.approveButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
            this.SuspendLayout();
            //
            // resultsGrid
            //
            this.resultsGrid.AllowUserToAddRows = false;
            this.resultsGrid.AllowUserToDeleteRows = false;
            this.resultsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultsGrid.Location = new System.Drawing.Point(12, 12);
            this.resultsGrid.MultiSelect = false;
            this.resultsGrid.Name = "resultsGrid";
            this.resultsGrid.ReadOnly = true;
            this.resultsGrid.RowHeadersVisible = false;
            this.resultsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsGrid.Size = new System.Drawing.Size(660, 240);
            this.resultsGrid.TabIndex = 0;
            //
            // approveButton
            //
            this.approveButton.Location = new System.Drawing.Point(12, 262);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(160, 25);
            this.approveButton.TabIndex = 1;
            this.approveButton.Text = "Zatwierdź wybrany wynik";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // reportButton
            //
            this.reportButton.Location = new System.Drawing.Point(180, 262);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(120, 25);
            this.reportButton.TabIndex = 2;
            this.reportButton.Text = "Raport dnia";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.ReportButton_Click);
            //
            // ResultsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 299);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.resultsGrid);
            this.Name = "ResultsForm";
            this.Text = "Wyniki do zatwierdzenia (Problem)";
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView resultsGrid;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button reportButton;
    }
}
