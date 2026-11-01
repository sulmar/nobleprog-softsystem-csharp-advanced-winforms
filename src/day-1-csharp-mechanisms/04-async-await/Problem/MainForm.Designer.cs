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
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.clockLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.analyzeAndSendButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.blockingButton = new System.Windows.Forms.Button();
            this.backgroundSendButton = new System.Windows.Forms.Button();
            this.backgroundReportButton = new System.Windows.Forms.Button();
            this.failCheckBox = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // clockTimer
            //
            this.clockTimer.Enabled = true;
            this.clockTimer.Tick += new System.EventHandler(this.ClockTimer_Tick);
            //
            // clockLabel
            //
            this.clockLabel.AutoSize = true;
            this.clockLabel.Location = new System.Drawing.Point(12, 12);
            this.clockLabel.Name = "clockLabel";
            this.clockLabel.TabIndex = 0;
            //
            // sendButton
            //
            this.sendButton.Location = new System.Drawing.Point(12, 36);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(150, 23);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Wyślij wynik";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            //
            // analyzeAndSendButton
            //
            this.analyzeAndSendButton.Location = new System.Drawing.Point(168, 36);
            this.analyzeAndSendButton.Name = "analyzeAndSendButton";
            this.analyzeAndSendButton.Size = new System.Drawing.Size(150, 23);
            this.analyzeAndSendButton.TabIndex = 2;
            this.analyzeAndSendButton.Text = "Zbadaj i wyślij";
            this.analyzeAndSendButton.UseVisualStyleBackColor = true;
            this.analyzeAndSendButton.Click += new System.EventHandler(this.AnalyzeAndSendButton_Click);
            //
            // reportButton
            //
            this.reportButton.Location = new System.Drawing.Point(324, 36);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(150, 23);
            this.reportButton.TabIndex = 3;
            this.reportButton.Text = "Raport zbiorczy";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.ReportButton_Click);
            //
            // blockingButton
            //
            this.blockingButton.Location = new System.Drawing.Point(12, 66);
            this.blockingButton.Name = "blockingButton";
            this.blockingButton.Size = new System.Drawing.Size(150, 23);
            this.blockingButton.TabIndex = 4;
            this.blockingButton.Text = "Zbadaj przez .Result";
            this.blockingButton.UseVisualStyleBackColor = true;
            this.blockingButton.Click += new System.EventHandler(this.BlockingButton_Click);
            //
            // backgroundSendButton
            //
            this.backgroundSendButton.Location = new System.Drawing.Point(168, 66);
            this.backgroundSendButton.Name = "backgroundSendButton";
            this.backgroundSendButton.Size = new System.Drawing.Size(150, 23);
            this.backgroundSendButton.TabIndex = 5;
            this.backgroundSendButton.Text = "Wyślij w tle";
            this.backgroundSendButton.UseVisualStyleBackColor = true;
            this.backgroundSendButton.Click += new System.EventHandler(this.BackgroundSendButton_Click);
            //
            // backgroundReportButton
            //
            this.backgroundReportButton.Location = new System.Drawing.Point(324, 66);
            this.backgroundReportButton.Name = "backgroundReportButton";
            this.backgroundReportButton.Size = new System.Drawing.Size(150, 23);
            this.backgroundReportButton.TabIndex = 6;
            this.backgroundReportButton.Text = "Raport w tle";
            this.backgroundReportButton.UseVisualStyleBackColor = true;
            this.backgroundReportButton.Click += new System.EventHandler(this.BackgroundReportButton_Click);
            //
            // failCheckBox
            //
            this.failCheckBox.AutoSize = true;
            this.failCheckBox.Location = new System.Drawing.Point(12, 100);
            this.failCheckBox.Name = "failCheckBox";
            this.failCheckBox.TabIndex = 10;
            this.failCheckBox.Text = "Błąd wysyłki";
            this.failCheckBox.UseVisualStyleBackColor = true;
            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(12, 126);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(462, 23);
            this.progressBar.TabIndex = 11;
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 158);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.TabIndex = 12;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 186);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.failCheckBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.analyzeAndSendButton);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.blockingButton);
            this.Controls.Add(this.backgroundSendButton);
            this.Controls.Add(this.backgroundReportButton);
            this.Controls.Add(this.clockLabel);
            this.Name = "MainForm";
            this.Text = "Wysyłka wyników (Problem)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Label clockLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button analyzeAndSendButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Button blockingButton;
        private System.Windows.Forms.Button backgroundSendButton;
        private System.Windows.Forms.Button backgroundReportButton;
        private System.Windows.Forms.CheckBox failCheckBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label statusLabel;
    }
}
