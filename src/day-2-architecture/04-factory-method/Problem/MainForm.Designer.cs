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
            this.ordersGrid = new System.Windows.Forms.DataGridView();
            this.enterResultsButton = new System.Windows.Forms.Button();
            this.previewReportButton = new System.Windows.Forms.Button();
            this.nightlyExportButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.reportTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGrid)).BeginInit();
            this.SuspendLayout();
            //
            // ordersGrid
            //
            this.ordersGrid.Location = new System.Drawing.Point(12, 12);
            this.ordersGrid.Name = "ordersGrid";
            this.ordersGrid.Size = new System.Drawing.Size(560, 180);
            this.ordersGrid.TabIndex = 0;
            this.ordersGrid.AllowUserToAddRows = false;
            this.ordersGrid.AllowUserToDeleteRows = false;
            this.ordersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ordersGrid.MultiSelect = false;
            this.ordersGrid.ReadOnly = true;
            this.ordersGrid.RowHeadersVisible = false;
            this.ordersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //
            // enterResultsButton
            //
            this.enterResultsButton.Location = new System.Drawing.Point(12, 200);
            this.enterResultsButton.Name = "enterResultsButton";
            this.enterResultsButton.Size = new System.Drawing.Size(130, 23);
            this.enterResultsButton.TabIndex = 1;
            this.enterResultsButton.Text = "Wprowadź wyniki";
            this.enterResultsButton.UseVisualStyleBackColor = true;
            this.enterResultsButton.Click += new System.EventHandler(this.EnterResultsButton_Click);
            //
            // previewReportButton
            //
            this.previewReportButton.Location = new System.Drawing.Point(152, 200);
            this.previewReportButton.Name = "previewReportButton";
            this.previewReportButton.Size = new System.Drawing.Size(130, 23);
            this.previewReportButton.TabIndex = 2;
            this.previewReportButton.Text = "Podgląd raportu";
            this.previewReportButton.UseVisualStyleBackColor = true;
            this.previewReportButton.Click += new System.EventHandler(this.PreviewReportButton_Click);
            //
            // nightlyExportButton
            //
            this.nightlyExportButton.Location = new System.Drawing.Point(292, 200);
            this.nightlyExportButton.Name = "nightlyExportButton";
            this.nightlyExportButton.Size = new System.Drawing.Size(130, 23);
            this.nightlyExportButton.TabIndex = 3;
            this.nightlyExportButton.Text = "Eksport nocny";
            this.nightlyExportButton.UseVisualStyleBackColor = true;
            this.nightlyExportButton.Click += new System.EventHandler(this.NightlyExportButton_Click);
            //
            // aboutButton
            //
            this.aboutButton.Location = new System.Drawing.Point(482, 200);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(90, 23);
            this.aboutButton.TabIndex = 4;
            this.aboutButton.Text = "O programie";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            //
            // reportTextBox
            //
            this.reportTextBox.Location = new System.Drawing.Point(12, 232);
            this.reportTextBox.Name = "reportTextBox";
            this.reportTextBox.Size = new System.Drawing.Size(560, 200);
            this.reportTextBox.TabIndex = 5;
            this.reportTextBox.Multiline = true;
            this.reportTextBox.ReadOnly = true;
            this.reportTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 444);
            this.Controls.Add(this.reportTextBox);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.nightlyExportButton);
            this.Controls.Add(this.previewReportButton);
            this.Controls.Add(this.enterResultsButton);
            this.Controls.Add(this.ordersGrid);
            this.Name = "MainForm";
            this.Text = "Zlecenia badań (Problem)";
            ((System.ComponentModel.ISupportInitialize)(this.ordersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView ordersGrid;
        private System.Windows.Forms.Button enterResultsButton;
        private System.Windows.Forms.Button previewReportButton;
        private System.Windows.Forms.Button nightlyExportButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.TextBox reportTextBox;
    }
}
