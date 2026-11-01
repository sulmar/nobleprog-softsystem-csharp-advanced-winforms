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
            this.counterButton = new System.Windows.Forms.Button();
            this.slotsButton = new System.Windows.Forms.Button();
            this.collectorButton = new System.Windows.Forms.Button();
            this.gateButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
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
            // counterButton
            //
            this.counterButton.Location = new System.Drawing.Point(12, 36);
            this.counterButton.Name = "counterButton";
            this.counterButton.Size = new System.Drawing.Size(150, 23);
            this.counterButton.TabIndex = 1;
            this.counterButton.Text = "Policz próbki";
            this.counterButton.UseVisualStyleBackColor = true;
            this.counterButton.Click += new System.EventHandler(this.CounterButton_Click);
            //
            // slotsButton
            //
            this.slotsButton.Location = new System.Drawing.Point(168, 36);
            this.slotsButton.Name = "slotsButton";
            this.slotsButton.Size = new System.Drawing.Size(150, 23);
            this.slotsButton.TabIndex = 2;
            this.slotsButton.Text = "Rezerwuj miejsca";
            this.slotsButton.UseVisualStyleBackColor = true;
            this.slotsButton.Click += new System.EventHandler(this.SlotsButton_Click);
            //
            // collectorButton
            //
            this.collectorButton.Location = new System.Drawing.Point(324, 36);
            this.collectorButton.Name = "collectorButton";
            this.collectorButton.Size = new System.Drawing.Size(150, 23);
            this.collectorButton.TabIndex = 3;
            this.collectorButton.Text = "Zbierz wyniki";
            this.collectorButton.UseVisualStyleBackColor = true;
            this.collectorButton.Click += new System.EventHandler(this.CollectorButton_Click);
            //
            // gateButton
            //
            this.gateButton.Location = new System.Drawing.Point(12, 66);
            this.gateButton.Name = "gateButton";
            this.gateButton.Size = new System.Drawing.Size(150, 23);
            this.gateButton.TabIndex = 4;
            this.gateButton.Text = "Zbadaj 6 próbek";
            this.gateButton.UseVisualStyleBackColor = true;
            this.gateButton.Click += new System.EventHandler(this.GateButton_Click);
            //
            // moveButton
            //
            this.moveButton.Location = new System.Drawing.Point(168, 66);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(150, 23);
            this.moveButton.TabIndex = 5;
            this.moveButton.Text = "Przełóż próbki";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.MoveButton_Click);
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 102);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.TabIndex = 6;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 130);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.counterButton);
            this.Controls.Add(this.slotsButton);
            this.Controls.Add(this.collectorButton);
            this.Controls.Add(this.gateButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.clockLabel);
            this.Name = "MainForm";
            this.Text = "Wspólny stan (Problem)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Label clockLabel;
        private System.Windows.Forms.Button counterButton;
        private System.Windows.Forms.Button slotsButton;
        private System.Windows.Forms.Button collectorButton;
        private System.Windows.Forms.Button gateButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Label statusLabel;
    }
}
