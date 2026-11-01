namespace Lims.Exercise.Form
{
    partial class ResultApprovalForm
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
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.approverLabel = new System.Windows.Forms.Label();
            this.approverTextBox = new System.Windows.Forms.TextBox();
            this.commentLabel = new System.Windows.Forms.Label();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.approveButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // codeLabel
            //
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(12, 15);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.TabIndex = 0;
            this.codeLabel.Text = "Kod próbki:";
            //
            // codeTextBox
            //
            this.codeTextBox.Location = new System.Drawing.Point(110, 12);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(200, 20);
            this.codeTextBox.TabIndex = 1;
            //
            // approverLabel
            //
            this.approverLabel.AutoSize = true;
            this.approverLabel.Location = new System.Drawing.Point(12, 41);
            this.approverLabel.Name = "approverLabel";
            this.approverLabel.TabIndex = 2;
            this.approverLabel.Text = "Zatwierdzający:";
            //
            // approverTextBox
            //
            this.approverTextBox.Location = new System.Drawing.Point(110, 38);
            this.approverTextBox.Name = "approverTextBox";
            this.approverTextBox.Size = new System.Drawing.Size(200, 20);
            this.approverTextBox.TabIndex = 3;
            //
            // commentLabel
            //
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(12, 67);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.TabIndex = 4;
            this.commentLabel.Text = "Komentarz:";
            //
            // commentTextBox
            //
            this.commentTextBox.Location = new System.Drawing.Point(110, 64);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(200, 20);
            this.commentTextBox.TabIndex = 5;
            //
            // approveButton
            //
            this.approveButton.Location = new System.Drawing.Point(110, 92);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(120, 23);
            this.approveButton.TabIndex = 6;
            this.approveButton.Text = "Zatwierdź";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 124);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.TabIndex = 7;
            //
            // ResultApprovalForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 150);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.approverTextBox);
            this.Controls.Add(this.approverLabel);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.codeLabel);
            this.Name = "ResultApprovalForm";
            this.Text = "Zatwierdzanie wyników";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label approverLabel;
        private System.Windows.Forms.TextBox approverTextBox;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Label statusLabel;
    }
}
