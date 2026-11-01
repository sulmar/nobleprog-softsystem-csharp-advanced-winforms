namespace Lims.Results
{
    partial class StatisticsForm
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
            this.countsLabel = new System.Windows.Forms.Label();
            this.countsListBox = new System.Windows.Forms.ListBox();
            this.criticalLabel = new System.Windows.Forms.Label();
            this.showInMainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // countsLabel
            //
            this.countsLabel.AutoSize = true;
            this.countsLabel.Location = new System.Drawing.Point(12, 12);
            this.countsLabel.Name = "countsLabel";
            this.countsLabel.TabIndex = 1;
            this.countsLabel.Text = "Liczba wyników według statusu:";
            //
            // countsListBox
            //
            this.countsListBox.Location = new System.Drawing.Point(12, 32);
            this.countsListBox.Name = "countsListBox";
            this.countsListBox.Size = new System.Drawing.Size(280, 95);
            this.countsListBox.TabIndex = 2;
            //
            // criticalLabel
            //
            this.criticalLabel.AutoSize = true;
            this.criticalLabel.Location = new System.Drawing.Point(12, 136);
            this.criticalLabel.Name = "criticalLabel";
            this.criticalLabel.TabIndex = 3;
            this.criticalLabel.Text = "Wyniki krytyczne: 0";
            //
            // showInMainButton
            //
            this.showInMainButton.Location = new System.Drawing.Point(12, 160);
            this.showInMainButton.Name = "showInMainButton";
            this.showInMainButton.Size = new System.Drawing.Size(280, 25);
            this.showInMainButton.TabIndex = 4;
            this.showInMainButton.Text = "Pokaż w oknie wyników";
            this.showInMainButton.UseVisualStyleBackColor = true;
            this.showInMainButton.Click += new System.EventHandler(this.showInMainButton_Click);
            //
            // StatisticsForm
            //
            this.ClientSize = new System.Drawing.Size(304, 197);
            this.Controls.Add(this.countsLabel);
            this.Controls.Add(this.countsListBox);
            this.Controls.Add(this.criticalLabel);
            this.Controls.Add(this.showInMainButton);
            this.MinimumSize = new System.Drawing.Size(320, 236);
            this.Name = "StatisticsForm";
            this.Text = "Statystyki";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StatisticsForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label countsLabel;
        private System.Windows.Forms.ListBox countsListBox;
        private System.Windows.Forms.Label criticalLabel;
        private System.Windows.Forms.Button showInMainButton;
    }
}
