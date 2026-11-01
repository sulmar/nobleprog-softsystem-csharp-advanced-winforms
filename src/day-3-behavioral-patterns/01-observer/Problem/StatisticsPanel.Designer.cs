namespace Lims.Problem
{
    partial class StatisticsPanel
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
            this.approvedLabel = new System.Windows.Forms.Label();
            this.rejectedLabel = new System.Windows.Forms.Label();
            this.pendingLabel = new System.Windows.Forms.Label();
            this.averageLabel = new System.Windows.Forms.Label();
            this.showListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // approvedLabel
            //
            this.approvedLabel.AutoSize = true;
            this.approvedLabel.Location = new System.Drawing.Point(8, 10);
            this.approvedLabel.Name = "approvedLabel";
            this.approvedLabel.TabIndex = 0;
            this.approvedLabel.Text = "Zatwierdzone: 0";
            //
            // rejectedLabel
            //
            this.rejectedLabel.AutoSize = true;
            this.rejectedLabel.Location = new System.Drawing.Point(8, 34);
            this.rejectedLabel.Name = "rejectedLabel";
            this.rejectedLabel.TabIndex = 1;
            this.rejectedLabel.Text = "Odrzucone: 0";
            //
            // pendingLabel
            //
            this.pendingLabel.AutoSize = true;
            this.pendingLabel.Location = new System.Drawing.Point(8, 58);
            this.pendingLabel.Name = "pendingLabel";
            this.pendingLabel.TabIndex = 2;
            this.pendingLabel.Text = "Oczekujące: 0";
            //
            // averageLabel
            //
            this.averageLabel.AutoSize = true;
            this.averageLabel.Location = new System.Drawing.Point(8, 82);
            this.averageLabel.Name = "averageLabel";
            this.averageLabel.TabIndex = 3;
            this.averageLabel.Text = "Średnia wartość: 0,00";
            //
            // showListButton
            //
            this.showListButton.Location = new System.Drawing.Point(8, 112);
            this.showListButton.Name = "showListButton";
            this.showListButton.Size = new System.Drawing.Size(160, 27);
            this.showListButton.TabIndex = 4;
            this.showListButton.Text = "Pokaż listę wyników";
            this.showListButton.UseVisualStyleBackColor = true;
            this.showListButton.Click += new System.EventHandler(this.ShowListButton_Click);
            //
            // StatisticsPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.showListButton);
            this.Controls.Add(this.averageLabel);
            this.Controls.Add(this.pendingLabel);
            this.Controls.Add(this.rejectedLabel);
            this.Controls.Add(this.approvedLabel);
            this.Name = "StatisticsPanel";
            this.Size = new System.Drawing.Size(596, 150);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label approvedLabel;
        private System.Windows.Forms.Label rejectedLabel;
        private System.Windows.Forms.Label pendingLabel;
        private System.Windows.Forms.Label averageLabel;
        private System.Windows.Forms.Button showListButton;
    }
}
