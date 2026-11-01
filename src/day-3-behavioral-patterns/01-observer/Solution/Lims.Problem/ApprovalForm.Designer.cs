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
            this.approverLabel = new System.Windows.Forms.Label();
            this.approverTextBox = new System.Windows.Forms.TextBox();
            this.pendingGrid = new System.Windows.Forms.DataGridView();
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.autoApproveButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pendingGrid)).BeginInit();
            this.SuspendLayout();
            //
            // approverLabel
            //
            this.approverLabel.AutoSize = true;
            this.approverLabel.Location = new System.Drawing.Point(12, 15);
            this.approverLabel.Name = "approverLabel";
            this.approverLabel.TabIndex = 0;
            this.approverLabel.Text = "Zatwierdzający:";
            //
            // approverTextBox
            //
            this.approverTextBox.Location = new System.Drawing.Point(110, 12);
            this.approverTextBox.Name = "approverTextBox";
            this.approverTextBox.Size = new System.Drawing.Size(160, 20);
            this.approverTextBox.TabIndex = 1;
            this.approverTextBox.Text = "A. Nowak";
            //
            // pendingGrid
            //
            this.pendingGrid.AllowUserToAddRows = false;
            this.pendingGrid.AllowUserToDeleteRows = false;
            this.pendingGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pendingGrid.Location = new System.Drawing.Point(12, 44);
            this.pendingGrid.MultiSelect = false;
            this.pendingGrid.Name = "pendingGrid";
            this.pendingGrid.ReadOnly = true;
            this.pendingGrid.RowHeadersVisible = false;
            this.pendingGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pendingGrid.Size = new System.Drawing.Size(616, 230);
            this.pendingGrid.TabIndex = 2;
            //
            // approveButton
            //
            this.approveButton.Location = new System.Drawing.Point(12, 284);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(120, 27);
            this.approveButton.TabIndex = 3;
            this.approveButton.Text = "Zatwierdź";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // rejectButton
            //
            this.rejectButton.Location = new System.Drawing.Point(138, 284);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(120, 27);
            this.rejectButton.TabIndex = 4;
            this.rejectButton.Text = "Odrzuć";
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Click += new System.EventHandler(this.RejectButton_Click);
            //
            // autoApproveButton
            //
            this.autoApproveButton.Location = new System.Drawing.Point(264, 284);
            this.autoApproveButton.Name = "autoApproveButton";
            this.autoApproveButton.Size = new System.Drawing.Size(200, 27);
            this.autoApproveButton.TabIndex = 5;
            this.autoApproveButton.Text = "Automat: zatwierdź w zakresie";
            this.autoApproveButton.UseVisualStyleBackColor = true;
            this.autoApproveButton.Click += new System.EventHandler(this.AutoApproveButton_Click);
            //
            // messageLabel
            //
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(12, 320);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.TabIndex = 6;
            //
            // ApprovalForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 345);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.autoApproveButton);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.pendingGrid);
            this.Controls.Add(this.approverTextBox);
            this.Controls.Add(this.approverLabel);
            this.Name = "ApprovalForm";
            this.Text = "Zatwierdzanie wyników (Problem)";
            ((System.ComponentModel.ISupportInitialize)(this.pendingGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label approverLabel;
        private System.Windows.Forms.TextBox approverTextBox;
        private System.Windows.Forms.DataGridView pendingGrid;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button autoApproveButton;
        private System.Windows.Forms.Label messageLabel;
    }
}
