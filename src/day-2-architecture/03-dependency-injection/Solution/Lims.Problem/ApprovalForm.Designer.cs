namespace Lims.Problem
{
    partial class ApprovalForm
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
            this.codeLabel = new System.Windows.Forms.Label();
            this.analyteLabel = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            this.approvedTodayLabel = new System.Windows.Forms.Label();
            this.approverLabel = new System.Windows.Forms.Label();
            this.approverTextBox = new System.Windows.Forms.TextBox();
            this.approveButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // codeLabel
            //
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(12, 15);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.TabIndex = 0;
            //
            // analyteLabel
            //
            this.analyteLabel.AutoSize = true;
            this.analyteLabel.Location = new System.Drawing.Point(12, 38);
            this.analyteLabel.Name = "analyteLabel";
            this.analyteLabel.TabIndex = 1;
            //
            // valueLabel
            //
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(12, 61);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.TabIndex = 2;
            //
            // approvedTodayLabel
            //
            this.approvedTodayLabel.AutoSize = true;
            this.approvedTodayLabel.Location = new System.Drawing.Point(12, 84);
            this.approvedTodayLabel.Name = "approvedTodayLabel";
            this.approvedTodayLabel.TabIndex = 3;
            //
            // approverLabel
            //
            this.approverLabel.AutoSize = true;
            this.approverLabel.Location = new System.Drawing.Point(12, 112);
            this.approverLabel.Name = "approverLabel";
            this.approverLabel.TabIndex = 4;
            this.approverLabel.Text = "Zatwierdzający:";
            //
            // approverTextBox
            //
            this.approverTextBox.Location = new System.Drawing.Point(110, 109);
            this.approverTextBox.Name = "approverTextBox";
            this.approverTextBox.Size = new System.Drawing.Size(238, 20);
            this.approverTextBox.TabIndex = 5;
            //
            // approveButton
            //
            this.approveButton.Location = new System.Drawing.Point(12, 142);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(100, 25);
            this.approveButton.TabIndex = 6;
            this.approveButton.Text = "Zatwierdź";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // messageLabel
            //
            this.messageLabel.Location = new System.Drawing.Point(120, 142);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(228, 30);
            this.messageLabel.TabIndex = 7;
            //
            // ApprovalForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 184);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.approverTextBox);
            this.Controls.Add(this.approverLabel);
            this.Controls.Add(this.approvedTodayLabel);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.analyteLabel);
            this.Controls.Add(this.codeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApprovalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zatwierdzenie wyniku (Problem)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ApprovalForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label analyteLabel;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label approvedTodayLabel;
        private System.Windows.Forms.Label approverLabel;
        private System.Windows.Forms.TextBox approverTextBox;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Label messageLabel;
    }
}
