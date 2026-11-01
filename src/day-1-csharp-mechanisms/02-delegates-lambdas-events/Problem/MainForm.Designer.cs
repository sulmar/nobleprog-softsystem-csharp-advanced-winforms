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
            this.analytePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.outOfRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.fullReportCheckBox = new System.Windows.Forms.CheckBox();
            this.addResultButton = new System.Windows.Forms.Button();
            this.previewButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.copiesUpDown = new System.Windows.Forms.NumericUpDown();
            this.printButton = new System.Windows.Forms.Button();
            this.resultsGrid = new System.Windows.Forms.DataGridView();
            this.subscribersLabel = new System.Windows.Forms.Label();
            this.logListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.copiesUpDown)).BeginInit();
            this.SuspendLayout();
            //
            // analytePanel
            //
            this.analytePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analytePanel.Location = new System.Drawing.Point(12, 8);
            this.analytePanel.Name = "analytePanel";
            this.analytePanel.Size = new System.Drawing.Size(876, 34);
            this.analytePanel.TabIndex = 0;
            //
            // outOfRangeCheckBox
            //
            this.outOfRangeCheckBox.AutoSize = true;
            this.outOfRangeCheckBox.Location = new System.Drawing.Point(12, 50);
            this.outOfRangeCheckBox.Name = "outOfRangeCheckBox";
            this.outOfRangeCheckBox.TabIndex = 1;
            this.outOfRangeCheckBox.Text = "Tylko poza zakresem";
            this.outOfRangeCheckBox.UseVisualStyleBackColor = true;
            this.outOfRangeCheckBox.CheckedChanged += new System.EventHandler(this.OutOfRangeCheckBox_CheckedChanged);
            //
            // fullReportCheckBox
            //
            this.fullReportCheckBox.AutoSize = true;
            this.fullReportCheckBox.Location = new System.Drawing.Point(170, 50);
            this.fullReportCheckBox.Name = "fullReportCheckBox";
            this.fullReportCheckBox.TabIndex = 2;
            this.fullReportCheckBox.Text = "Pełny raport";
            this.fullReportCheckBox.UseVisualStyleBackColor = true;
            //
            // addResultButton
            //
            this.addResultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addResultButton.Location = new System.Drawing.Point(468, 46);
            this.addResultButton.Name = "addResultButton";
            this.addResultButton.Size = new System.Drawing.Size(130, 23);
            this.addResultButton.TabIndex = 3;
            this.addResultButton.Text = "Dodaj wynik";
            this.addResultButton.UseVisualStyleBackColor = true;
            this.addResultButton.Click += new System.EventHandler(this.AddResultButton_Click);
            //
            // previewButton
            //
            this.previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.previewButton.Location = new System.Drawing.Point(604, 46);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(130, 23);
            this.previewButton.TabIndex = 4;
            this.previewButton.Text = "Otwórz podgląd";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            //
            // reportButton
            //
            this.reportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reportButton.Location = new System.Drawing.Point(740, 46);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(148, 23);
            this.reportButton.TabIndex = 5;
            this.reportButton.Text = "Raport";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.ReportButton_Click);
            //
            // importButton
            //
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(332, 46);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(130, 23);
            this.importButton.TabIndex = 9;
            this.importButton.Text = "Importuj z analizatora";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            //
            // copiesUpDown
            //
            this.copiesUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copiesUpDown.Location = new System.Drawing.Point(672, 385);
            this.copiesUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.copiesUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.copiesUpDown.Name = "copiesUpDown";
            this.copiesUpDown.Size = new System.Drawing.Size(80, 20);
            this.copiesUpDown.TabIndex = 10;
            this.copiesUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            //
            // printButton
            //
            this.printButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printButton.Location = new System.Drawing.Point(758, 383);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(130, 23);
            this.printButton.TabIndex = 11;
            this.printButton.Text = "Drukuj raport";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.PrintButton_Click);
            //
            // resultsGrid
            //
            this.resultsGrid.AllowUserToAddRows = false;
            this.resultsGrid.AllowUserToDeleteRows = false;
            this.resultsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultsGrid.Location = new System.Drawing.Point(12, 78);
            this.resultsGrid.Name = "resultsGrid";
            this.resultsGrid.ReadOnly = true;
            this.resultsGrid.RowHeadersVisible = false;
            this.resultsGrid.Size = new System.Drawing.Size(876, 304);
            this.resultsGrid.TabIndex = 6;
            //
            // subscribersLabel
            //
            this.subscribersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.subscribersLabel.AutoSize = true;
            this.subscribersLabel.Location = new System.Drawing.Point(12, 388);
            this.subscribersLabel.Name = "subscribersLabel";
            this.subscribersLabel.TabIndex = 7;
            //
            // logListBox
            //
            this.logListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logListBox.Location = new System.Drawing.Point(12, 408);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(876, 134);
            this.logListBox.TabIndex = 8;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 554);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.subscribersLabel);
            this.Controls.Add(this.resultsGrid);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.copiesUpDown);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.addResultButton);
            this.Controls.Add(this.fullReportCheckBox);
            this.Controls.Add(this.outOfRangeCheckBox);
            this.Controls.Add(this.analytePanel);
            this.Name = "MainForm";
            this.Text = "Wyniki badań (Problem)";
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.copiesUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.FlowLayoutPanel analytePanel;
        private System.Windows.Forms.CheckBox outOfRangeCheckBox;
        private System.Windows.Forms.CheckBox fullReportCheckBox;
        private System.Windows.Forms.Button addResultButton;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.NumericUpDown copiesUpDown;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.DataGridView resultsGrid;
        private System.Windows.Forms.Label subscribersLabel;
        private System.Windows.Forms.ListBox logListBox;
    }
}
