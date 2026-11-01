namespace Lims.Problem
{
    partial class ReceptionApprovalForm
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
            this.orderLabel = new System.Windows.Forms.Label();
            this.orderComboBox = new System.Windows.Forms.ComboBox();
            this.approverLabel = new System.Windows.Forms.Label();
            this.approverTextBox = new System.Windows.Forms.TextBox();
            this.approveButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // orderLabel
            //
            this.orderLabel.AutoSize = true;
            this.orderLabel.Location = new System.Drawing.Point(12, 15);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.TabIndex = 0;
            this.orderLabel.Text = "Zlecenie:";
            //
            // orderComboBox
            //
            this.orderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderComboBox.Location = new System.Drawing.Point(110, 12);
            this.orderComboBox.Name = "orderComboBox";
            this.orderComboBox.Size = new System.Drawing.Size(320, 21);
            this.orderComboBox.TabIndex = 1;
            //
            // approverLabel
            //
            this.approverLabel.AutoSize = true;
            this.approverLabel.Location = new System.Drawing.Point(12, 45);
            this.approverLabel.Name = "approverLabel";
            this.approverLabel.TabIndex = 2;
            this.approverLabel.Text = "Zatwierdzający:";
            //
            // approverTextBox
            //
            this.approverTextBox.Location = new System.Drawing.Point(110, 42);
            this.approverTextBox.Name = "approverTextBox";
            this.approverTextBox.Size = new System.Drawing.Size(320, 20);
            this.approverTextBox.TabIndex = 3;
            //
            // approveButton
            //
            this.approveButton.Location = new System.Drawing.Point(110, 72);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(120, 23);
            this.approveButton.TabIndex = 4;
            this.approveButton.Text = "Zatwierdź";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // statusLabel
            //
            this.statusLabel.Location = new System.Drawing.Point(12, 105);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(418, 70);
            this.statusLabel.TabIndex = 5;
            //
            // ReceptionApprovalForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 185);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.approverTextBox);
            this.Controls.Add(this.approverLabel);
            this.Controls.Add(this.orderComboBox);
            this.Controls.Add(this.orderLabel);
            this.Name = "ReceptionApprovalForm";
            this.Text = "Rejestracja: zatwierdzenie zlecenia";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.ComboBox orderComboBox;
        private System.Windows.Forms.Label approverLabel;
        private System.Windows.Forms.TextBox approverTextBox;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Label statusLabel;
    }
}
