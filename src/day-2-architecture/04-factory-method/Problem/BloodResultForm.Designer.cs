namespace Lims.Problem
{
    partial class BloodResultForm
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
            this.hemoglobinLabel = new System.Windows.Forms.Label();
            this.hemoglobinTextBox = new System.Windows.Forms.TextBox();
            this.leukocytesLabel = new System.Windows.Forms.Label();
            this.leukocytesTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // hemoglobinLabel
            //
            this.hemoglobinLabel.AutoSize = true;
            this.hemoglobinLabel.Location = new System.Drawing.Point(12, 15);
            this.hemoglobinLabel.Name = "hemoglobinLabel";
            this.hemoglobinLabel.TabIndex = 0;
            this.hemoglobinLabel.Text = "Hemoglobina (g/dL):";
            //
            // hemoglobinTextBox
            //
            this.hemoglobinTextBox.Location = new System.Drawing.Point(140, 12);
            this.hemoglobinTextBox.Name = "hemoglobinTextBox";
            this.hemoglobinTextBox.Size = new System.Drawing.Size(200, 20);
            this.hemoglobinTextBox.TabIndex = 1;
            //
            // leukocytesLabel
            //
            this.leukocytesLabel.AutoSize = true;
            this.leukocytesLabel.Location = new System.Drawing.Point(12, 45);
            this.leukocytesLabel.Name = "leukocytesLabel";
            this.leukocytesLabel.TabIndex = 2;
            this.leukocytesLabel.Text = "Leukocyty (tys./µl):";
            //
            // leukocytesTextBox
            //
            this.leukocytesTextBox.Location = new System.Drawing.Point(140, 42);
            this.leukocytesTextBox.Name = "leukocytesTextBox";
            this.leukocytesTextBox.Size = new System.Drawing.Size(200, 20);
            this.leukocytesTextBox.TabIndex = 3;
            //
            // saveButton
            //
            this.saveButton.Location = new System.Drawing.Point(140, 77);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Zapisz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            //
            // cancelButton
            //
            this.cancelButton.Location = new System.Drawing.Point(240, 77);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //
            // BloodResultForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 112);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AcceptButton = this.saveButton;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.leukocytesTextBox);
            this.Controls.Add(this.leukocytesLabel);
            this.Controls.Add(this.hemoglobinTextBox);
            this.Controls.Add(this.hemoglobinLabel);
            this.Name = "BloodResultForm";
            this.Text = "Morfologia krwi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label hemoglobinLabel;
        private System.Windows.Forms.TextBox hemoglobinTextBox;
        private System.Windows.Forms.Label leukocytesLabel;
        private System.Windows.Forms.TextBox leukocytesTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
