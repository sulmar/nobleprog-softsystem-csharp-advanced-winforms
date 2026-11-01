namespace Lims.Problem
{
    partial class UrineResultForm
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
            this.phLabel = new System.Windows.Forms.Label();
            this.phTextBox = new System.Windows.Forms.TextBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.proteinLabel = new System.Windows.Forms.Label();
            this.proteinTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // phLabel
            //
            this.phLabel.AutoSize = true;
            this.phLabel.Location = new System.Drawing.Point(12, 15);
            this.phLabel.Name = "phLabel";
            this.phLabel.TabIndex = 0;
            this.phLabel.Text = "pH:";
            //
            // phTextBox
            //
            this.phTextBox.Location = new System.Drawing.Point(140, 12);
            this.phTextBox.Name = "phTextBox";
            this.phTextBox.Size = new System.Drawing.Size(200, 20);
            this.phTextBox.TabIndex = 1;
            //
            // colorLabel
            //
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(12, 45);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.TabIndex = 2;
            this.colorLabel.Text = "Barwa:";
            //
            // colorComboBox
            //
            this.colorComboBox.Location = new System.Drawing.Point(140, 42);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(200, 21);
            this.colorComboBox.TabIndex = 3;
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.Items.AddRange(new object[] { "Słomkowa", "Żółta", "Bursztynowa", "Czerwonawa" });
            //
            // proteinLabel
            //
            this.proteinLabel.AutoSize = true;
            this.proteinLabel.Location = new System.Drawing.Point(12, 75);
            this.proteinLabel.Name = "proteinLabel";
            this.proteinLabel.TabIndex = 4;
            this.proteinLabel.Text = "Białko (mg/dL):";
            //
            // proteinTextBox
            //
            this.proteinTextBox.Location = new System.Drawing.Point(140, 72);
            this.proteinTextBox.Name = "proteinTextBox";
            this.proteinTextBox.Size = new System.Drawing.Size(200, 20);
            this.proteinTextBox.TabIndex = 5;
            //
            // saveButton
            //
            this.saveButton.Location = new System.Drawing.Point(140, 107);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Zapisz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            //
            // cancelButton
            //
            this.cancelButton.Location = new System.Drawing.Point(240, 107);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //
            // UrineResultForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 142);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AcceptButton = this.saveButton;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.proteinTextBox);
            this.Controls.Add(this.proteinLabel);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.phTextBox);
            this.Controls.Add(this.phLabel);
            this.Name = "UrineResultForm";
            this.Text = "Badanie ogólne moczu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label phLabel;
        private System.Windows.Forms.TextBox phTextBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Label proteinLabel;
        private System.Windows.Forms.TextBox proteinTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
