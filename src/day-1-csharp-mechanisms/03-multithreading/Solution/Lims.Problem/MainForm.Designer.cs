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
            this.calculateButton = new System.Windows.Forms.Button();
            this.threadButton = new System.Windows.Forms.Button();
            this.taskButton = new System.Windows.Forms.Button();
            this.failCheckBox = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.monitorButton = new System.Windows.Forms.Button();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.processButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.progressBarProcess = new System.Windows.Forms.ProgressBar();
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
            this.clockLabel.Size = new System.Drawing.Size(0, 13);
            this.clockLabel.TabIndex = 0;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(12, 36);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(130, 23);
            this.calculateButton.TabIndex = 1;
            this.calculateButton.Text = "Policz dzień";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // threadButton
            // 
            this.threadButton.Location = new System.Drawing.Point(148, 36);
            this.threadButton.Name = "threadButton";
            this.threadButton.Size = new System.Drawing.Size(130, 23);
            this.threadButton.TabIndex = 2;
            this.threadButton.Text = "Policz w tle";
            this.threadButton.UseVisualStyleBackColor = true;
            this.threadButton.Click += new System.EventHandler(this.ThreadButton_Click);
            // 
            // taskButton
            // 
            this.taskButton.Location = new System.Drawing.Point(284, 36);
            this.taskButton.Name = "taskButton";
            this.taskButton.Size = new System.Drawing.Size(130, 23);
            this.taskButton.TabIndex = 3;
            this.taskButton.Text = "Policz zadaniem";
            this.taskButton.UseVisualStyleBackColor = true;
            this.taskButton.Click += new System.EventHandler(this.TaskButton_Click);
            // 
            // failCheckBox
            // 
            this.failCheckBox.AutoSize = true;
            this.failCheckBox.Location = new System.Drawing.Point(420, 40);
            this.failCheckBox.Name = "failCheckBox";
            this.failCheckBox.Size = new System.Drawing.Size(114, 17);
            this.failCheckBox.TabIndex = 5;
            this.failCheckBox.Text = "Uszkodzony wynik";
            this.failCheckBox.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 70);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(560, 23);
            this.progressBar.TabIndex = 6;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 102);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusLabel.TabIndex = 7;
            // 
            // monitorButton
            // 
            this.monitorButton.Location = new System.Drawing.Point(12, 126);
            this.monitorButton.Name = "monitorButton";
            this.monitorButton.Size = new System.Drawing.Size(130, 23);
            this.monitorButton.TabIndex = 8;
            this.monitorButton.Text = "Monitoruj temperaturę";
            this.monitorButton.UseVisualStyleBackColor = true;
            this.monitorButton.Click += new System.EventHandler(this.MonitorButton_Click);
            // 
            // temperatureLabel
            // 
            this.temperatureLabel.AutoSize = true;
            this.temperatureLabel.Location = new System.Drawing.Point(148, 131);
            this.temperatureLabel.Name = "temperatureLabel";
            this.temperatureLabel.Size = new System.Drawing.Size(0, 13);
            this.temperatureLabel.TabIndex = 9;
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(11, 190);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(130, 23);
            this.processButton.TabIndex = 10;
            this.processButton.Text = "Przetwarzanie";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(148, 189);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // progressBarProcess
            // 
            this.progressBarProcess.Location = new System.Drawing.Point(15, 220);
            this.progressBarProcess.Maximum = 5;
            this.progressBarProcess.Name = "progressBarProcess";
            this.progressBarProcess.Size = new System.Drawing.Size(557, 23);
            this.progressBarProcess.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 321);
            this.Controls.Add(this.progressBarProcess);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.temperatureLabel);
            this.Controls.Add(this.monitorButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.failCheckBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.threadButton);
            this.Controls.Add(this.taskButton);
            this.Controls.Add(this.clockLabel);
            this.Name = "MainForm";
            this.Text = "Podsumowanie dnia (Problem)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Label clockLabel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button threadButton;
        private System.Windows.Forms.Button taskButton;
        private System.Windows.Forms.CheckBox failCheckBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button monitorButton;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ProgressBar progressBarProcess;
    }
}
