namespace Lims.Problem
{
    partial class ActionBarPanel
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
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // approveButton
            //
            this.approveButton.Enabled = false;
            this.approveButton.Location = new System.Drawing.Point(3, 7);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(100, 26);
            this.approveButton.TabIndex = 0;
            this.approveButton.Text = "Zatwierdź";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // rejectButton
            //
            this.rejectButton.Enabled = false;
            this.rejectButton.Location = new System.Drawing.Point(111, 7);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(100, 26);
            this.rejectButton.TabIndex = 1;
            this.rejectButton.Text = "Odrzuć";
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Click += new System.EventHandler(this.RejectButton_Click);
            //
            // saveButton
            //
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(219, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(130, 26);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Zapisz komentarz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            //
            // messageLabel
            //
            this.messageLabel.Location = new System.Drawing.Point(360, 12);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(370, 16);
            this.messageLabel.TabIndex = 3;
            //
            // ActionBarPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.approveButton);
            this.Name = "ActionBarPanel";
            this.Size = new System.Drawing.Size(736, 40);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label messageLabel;
    }
}
