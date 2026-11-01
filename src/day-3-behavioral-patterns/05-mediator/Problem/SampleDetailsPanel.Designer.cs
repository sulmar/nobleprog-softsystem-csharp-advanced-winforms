namespace Lims.Problem
{
    partial class SampleDetailsPanel
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
            this.codeValueLabel = new System.Windows.Forms.Label();
            this.patientLabel = new System.Windows.Forms.Label();
            this.patientValueLabel = new System.Windows.Forms.Label();
            this.analyteLabel = new System.Windows.Forms.Label();
            this.analyteValueLabel = new System.Windows.Forms.Label();
            this.sampleStatusLabel = new System.Windows.Forms.Label();
            this.statusValueLabel = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // codeLabel
            //
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(3, 6);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.TabIndex = 0;
            this.codeLabel.Text = "Kod:";
            //
            // codeValueLabel
            //
            this.codeValueLabel.Location = new System.Drawing.Point(80, 6);
            this.codeValueLabel.Name = "codeValueLabel";
            this.codeValueLabel.Size = new System.Drawing.Size(260, 16);
            this.codeValueLabel.TabIndex = 1;
            //
            // patientLabel
            //
            this.patientLabel.AutoSize = true;
            this.patientLabel.Location = new System.Drawing.Point(3, 30);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.TabIndex = 2;
            this.patientLabel.Text = "Pacjent:";
            //
            // patientValueLabel
            //
            this.patientValueLabel.Location = new System.Drawing.Point(80, 30);
            this.patientValueLabel.Name = "patientValueLabel";
            this.patientValueLabel.Size = new System.Drawing.Size(260, 16);
            this.patientValueLabel.TabIndex = 3;
            //
            // analyteLabel
            //
            this.analyteLabel.AutoSize = true;
            this.analyteLabel.Location = new System.Drawing.Point(3, 54);
            this.analyteLabel.Name = "analyteLabel";
            this.analyteLabel.TabIndex = 4;
            this.analyteLabel.Text = "Badanie:";
            //
            // analyteValueLabel
            //
            this.analyteValueLabel.Location = new System.Drawing.Point(80, 54);
            this.analyteValueLabel.Name = "analyteValueLabel";
            this.analyteValueLabel.Size = new System.Drawing.Size(260, 16);
            this.analyteValueLabel.TabIndex = 5;
            //
            // sampleStatusLabel
            //
            this.sampleStatusLabel.AutoSize = true;
            this.sampleStatusLabel.Location = new System.Drawing.Point(3, 78);
            this.sampleStatusLabel.Name = "sampleStatusLabel";
            this.sampleStatusLabel.TabIndex = 6;
            this.sampleStatusLabel.Text = "Status:";
            //
            // statusValueLabel
            //
            this.statusValueLabel.Location = new System.Drawing.Point(80, 78);
            this.statusValueLabel.Name = "statusValueLabel";
            this.statusValueLabel.Size = new System.Drawing.Size(260, 16);
            this.statusValueLabel.TabIndex = 7;
            //
            // commentLabel
            //
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(3, 104);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.TabIndex = 8;
            this.commentLabel.Text = "Komentarz:";
            //
            // commentTextBox
            //
            this.commentTextBox.Location = new System.Drawing.Point(6, 124);
            this.commentTextBox.Multiline = true;
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.ReadOnly = true;
            this.commentTextBox.Size = new System.Drawing.Size(334, 116);
            this.commentTextBox.TabIndex = 9;
            this.commentTextBox.TextChanged += new System.EventHandler(this.CommentTextBox_TextChanged);
            //
            // approveButton
            //
            this.approveButton.Enabled = false;
            this.approveButton.Location = new System.Drawing.Point(6, 246);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(100, 26);
            this.approveButton.TabIndex = 20;
            this.approveButton.Text = "Zatwierdź";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // rejectButton
            //
            this.rejectButton.Enabled = false;
            this.rejectButton.Location = new System.Drawing.Point(112, 246);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(100, 26);
            this.rejectButton.TabIndex = 21;
            this.rejectButton.Text = "Odrzuć";
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Click += new System.EventHandler(this.RejectButton_Click);
            //
            // saveButton
            //
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(218, 246);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(124, 26);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Zapisz komentarz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            //
            // messageLabel
            //
            this.messageLabel.Location = new System.Drawing.Point(6, 278);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(334, 16);
            this.messageLabel.TabIndex = 23;
            //
            // SampleDetailsPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.statusValueLabel);
            this.Controls.Add(this.sampleStatusLabel);
            this.Controls.Add(this.analyteValueLabel);
            this.Controls.Add(this.analyteLabel);
            this.Controls.Add(this.patientValueLabel);
            this.Controls.Add(this.patientLabel);
            this.Controls.Add(this.codeValueLabel);
            this.Controls.Add(this.codeLabel);
            this.Name = "SampleDetailsPanel";
            this.Size = new System.Drawing.Size(348, 300);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label codeValueLabel;
        private System.Windows.Forms.Label patientLabel;
        private System.Windows.Forms.Label patientValueLabel;
        private System.Windows.Forms.Label analyteLabel;
        private System.Windows.Forms.Label analyteValueLabel;
        private System.Windows.Forms.Label sampleStatusLabel;
        private System.Windows.Forms.Label statusValueLabel;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label messageLabel;
    }
}
