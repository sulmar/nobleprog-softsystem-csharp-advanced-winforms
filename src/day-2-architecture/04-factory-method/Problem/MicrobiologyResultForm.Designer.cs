namespace Lims.Problem
{
    partial class MicrobiologyResultForm
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
            this.organismLabel = new System.Windows.Forms.Label();
            this.organismTextBox = new System.Windows.Forms.TextBox();
            this.colonyCountLabel = new System.Windows.Forms.Label();
            this.colonyCountTextBox = new System.Windows.Forms.TextBox();
            this.antibiogramLabel = new System.Windows.Forms.Label();
            this.antibiogramTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // organismLabel
            //
            this.organismLabel.AutoSize = true;
            this.organismLabel.Location = new System.Drawing.Point(12, 15);
            this.organismLabel.Name = "organismLabel";
            this.organismLabel.TabIndex = 0;
            this.organismLabel.Text = "Drobnoustrój:";
            //
            // organismTextBox
            //
            this.organismTextBox.Location = new System.Drawing.Point(140, 12);
            this.organismTextBox.Name = "organismTextBox";
            this.organismTextBox.Size = new System.Drawing.Size(200, 20);
            this.organismTextBox.TabIndex = 1;
            //
            // colonyCountLabel
            //
            this.colonyCountLabel.AutoSize = true;
            this.colonyCountLabel.Location = new System.Drawing.Point(12, 45);
            this.colonyCountLabel.Name = "colonyCountLabel";
            this.colonyCountLabel.TabIndex = 2;
            this.colonyCountLabel.Text = "Miano (CFU/ml):";
            //
            // colonyCountTextBox
            //
            this.colonyCountTextBox.Location = new System.Drawing.Point(140, 42);
            this.colonyCountTextBox.Name = "colonyCountTextBox";
            this.colonyCountTextBox.Size = new System.Drawing.Size(200, 20);
            this.colonyCountTextBox.TabIndex = 3;
            //
            // antibiogramLabel
            //
            this.antibiogramLabel.AutoSize = true;
            this.antibiogramLabel.Location = new System.Drawing.Point(12, 75);
            this.antibiogramLabel.Name = "antibiogramLabel";
            this.antibiogramLabel.TabIndex = 4;
            this.antibiogramLabel.Text = "Antybiogram:";
            //
            // antibiogramTextBox
            //
            this.antibiogramTextBox.Location = new System.Drawing.Point(140, 72);
            this.antibiogramTextBox.Name = "antibiogramTextBox";
            this.antibiogramTextBox.Size = new System.Drawing.Size(200, 90);
            this.antibiogramTextBox.TabIndex = 5;
            this.antibiogramTextBox.Multiline = true;
            this.antibiogramTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //
            // saveButton
            //
            this.saveButton.Location = new System.Drawing.Point(140, 167);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Zapisz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            //
            // cancelButton
            //
            this.cancelButton.Location = new System.Drawing.Point(240, 167);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //
            // MicrobiologyResultForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 202);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AcceptButton = this.saveButton;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.antibiogramTextBox);
            this.Controls.Add(this.antibiogramLabel);
            this.Controls.Add(this.colonyCountTextBox);
            this.Controls.Add(this.colonyCountLabel);
            this.Controls.Add(this.organismTextBox);
            this.Controls.Add(this.organismLabel);
            this.Name = "MicrobiologyResultForm";
            this.Text = "Posiew mikrobiologiczny";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label organismLabel;
        private System.Windows.Forms.TextBox organismTextBox;
        private System.Windows.Forms.Label colonyCountLabel;
        private System.Windows.Forms.TextBox colonyCountTextBox;
        private System.Windows.Forms.Label antibiogramLabel;
        private System.Windows.Forms.TextBox antibiogramTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
