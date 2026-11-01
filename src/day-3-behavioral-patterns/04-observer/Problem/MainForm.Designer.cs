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
            this.components = new System.ComponentModel.Container();
            this.openApprovalButton = new System.Windows.Forms.Button();
            this.openQualityControlButton = new System.Windows.Forms.Button();
            this.statisticsPanel = new Lims.Problem.StatisticsPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.subscriptionsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // openApprovalButton
            //
            this.openApprovalButton.Location = new System.Drawing.Point(12, 12);
            this.openApprovalButton.Name = "openApprovalButton";
            this.openApprovalButton.Size = new System.Drawing.Size(160, 27);
            this.openApprovalButton.TabIndex = 0;
            this.openApprovalButton.Text = "Zatwierdzanie wyników";
            this.openApprovalButton.UseVisualStyleBackColor = true;
            this.openApprovalButton.Click += new System.EventHandler(this.OpenApprovalButton_Click);
            //
            // openQualityControlButton
            //
            this.openQualityControlButton.Location = new System.Drawing.Point(178, 12);
            this.openQualityControlButton.Name = "openQualityControlButton";
            this.openQualityControlButton.Size = new System.Drawing.Size(160, 27);
            this.openQualityControlButton.TabIndex = 1;
            this.openQualityControlButton.Text = "Kontrola jakości";
            this.openQualityControlButton.UseVisualStyleBackColor = true;
            this.openQualityControlButton.Click += new System.EventHandler(this.OpenQualityControlButton_Click);
            //
            // statisticsPanel
            //
            this.statisticsPanel.Location = new System.Drawing.Point(12, 50);
            this.statisticsPanel.Name = "statisticsPanel";
            this.statisticsPanel.Size = new System.Drawing.Size(596, 150);
            this.statisticsPanel.TabIndex = 2;
            //
            // statusStrip
            //
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.subscriptionsLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 218);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(620, 22);
            this.statusStrip.TabIndex = 3;
            //
            // statusLabel
            //
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(100, 17);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "Gotowe";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // subscriptionsLabel
            //
            this.subscriptionsLabel.Name = "subscriptionsLabel";
            this.subscriptionsLabel.Size = new System.Drawing.Size(70, 17);
            this.subscriptionsLabel.Text = "Subskrypcje: 0";
            //
            // refreshTimer
            //
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 500;
            this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 240);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.statisticsPanel);
            this.Controls.Add(this.openQualityControlButton);
            this.Controls.Add(this.openApprovalButton);
            this.Name = "MainForm";
            this.Text = "Laboratorium (Problem)";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button openApprovalButton;
        private System.Windows.Forms.Button openQualityControlButton;
        private Lims.Problem.StatisticsPanel statisticsPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel subscriptionsLabel;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
