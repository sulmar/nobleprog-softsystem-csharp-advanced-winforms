namespace Lims.Problem
{
    partial class BatchApprovalForm
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
            this.ordersListBox = new System.Windows.Forms.CheckedListBox();
            this.approverLabel = new System.Windows.Forms.Label();
            this.approverTextBox = new System.Windows.Forms.TextBox();
            this.approveButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // ordersListBox
            //
            this.ordersListBox.CheckOnClick = true;
            this.ordersListBox.FormattingEnabled = true;
            this.ordersListBox.Location = new System.Drawing.Point(12, 12);
            this.ordersListBox.Name = "ordersListBox";
            this.ordersListBox.Size = new System.Drawing.Size(418, 124);
            this.ordersListBox.TabIndex = 0;
            //
            // approverLabel
            //
            this.approverLabel.AutoSize = true;
            this.approverLabel.Location = new System.Drawing.Point(12, 151);
            this.approverLabel.Name = "approverLabel";
            this.approverLabel.TabIndex = 1;
            this.approverLabel.Text = "Zatwierdzający:";
            //
            // approverTextBox
            //
            this.approverTextBox.Location = new System.Drawing.Point(110, 148);
            this.approverTextBox.Name = "approverTextBox";
            this.approverTextBox.Size = new System.Drawing.Size(320, 20);
            this.approverTextBox.TabIndex = 2;
            //
            // approveButton
            //
            this.approveButton.Location = new System.Drawing.Point(110, 178);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(150, 23);
            this.approveButton.TabIndex = 3;
            this.approveButton.Text = "Zatwierdź zaznaczone";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // statusLabel
            //
            this.statusLabel.Location = new System.Drawing.Point(12, 211);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(418, 90);
            this.statusLabel.TabIndex = 4;
            //
            // BatchApprovalForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 310);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.approverTextBox);
            this.Controls.Add(this.approverLabel);
            this.Controls.Add(this.ordersListBox);
            this.Name = "BatchApprovalForm";
            this.Text = "Zatwierdzanie zbiorcze";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckedListBox ordersListBox;
        private System.Windows.Forms.Label approverLabel;
        private System.Windows.Forms.TextBox approverTextBox;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Label statusLabel;
    }
}
