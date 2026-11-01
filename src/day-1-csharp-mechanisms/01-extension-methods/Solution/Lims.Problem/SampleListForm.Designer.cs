namespace Lims.Problem
{
    partial class SampleListForm
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
            this.samplesGrid = new System.Windows.Forms.DataGridView();
            this.overdueOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.showResultsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.samplesGrid)).BeginInit();
            this.SuspendLayout();
            //
            // samplesGrid
            //
            this.samplesGrid.AllowUserToAddRows = false;
            this.samplesGrid.AllowUserToDeleteRows = false;
            this.samplesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.samplesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.samplesGrid.Location = new System.Drawing.Point(12, 44);
            this.samplesGrid.Name = "samplesGrid";
            this.samplesGrid.ReadOnly = true;
            this.samplesGrid.RowHeadersVisible = false;
            this.samplesGrid.Size = new System.Drawing.Size(760, 305);
            this.samplesGrid.TabIndex = 2;
            //
            // overdueOnlyCheckBox
            //
            this.overdueOnlyCheckBox.AutoSize = true;
            this.overdueOnlyCheckBox.Location = new System.Drawing.Point(12, 16);
            this.overdueOnlyCheckBox.Name = "overdueOnlyCheckBox";
            this.overdueOnlyCheckBox.Size = new System.Drawing.Size(110, 17);
            this.overdueOnlyCheckBox.TabIndex = 0;
            this.overdueOnlyCheckBox.Text = "Tylko po terminie";
            this.overdueOnlyCheckBox.UseVisualStyleBackColor = true;
            this.overdueOnlyCheckBox.CheckedChanged += new System.EventHandler(this.OverdueOnlyCheckBox_CheckedChanged);
            //
            // showResultsButton
            //
            this.showResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showResultsButton.Location = new System.Drawing.Point(652, 12);
            this.showResultsButton.Name = "showResultsButton";
            this.showResultsButton.Size = new System.Drawing.Size(120, 23);
            this.showResultsButton.TabIndex = 1;
            this.showResultsButton.Text = "Wyniki badań...";
            this.showResultsButton.UseVisualStyleBackColor = true;
            this.showResultsButton.Click += new System.EventHandler(this.ShowResultsButton_Click);
            //
            // SampleListForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.showResultsButton);
            this.Controls.Add(this.overdueOnlyCheckBox);
            this.Controls.Add(this.samplesGrid);
            this.Name = "SampleListForm";
            this.Text = "Lista próbek (Problem)";
            ((System.ComponentModel.ISupportInitialize)(this.samplesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView samplesGrid;
        private System.Windows.Forms.CheckBox overdueOnlyCheckBox;
        private System.Windows.Forms.Button showResultsButton;
    }
}
