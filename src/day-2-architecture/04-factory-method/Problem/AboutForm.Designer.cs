namespace Lims.Problem
{
    partial class AboutForm
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
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // descriptionLabel
            //
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 15);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "LIMS: moduł wyników badań (wersja szkoleniowa)";
            //
            // closeButton
            //
            this.closeButton.Location = new System.Drawing.Point(218, 57);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(90, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Zamknij";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            //
            // AboutForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 92);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AcceptButton = this.closeButton;
            this.CancelButton = this.closeButton;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.descriptionLabel);
            this.Name = "AboutForm";
            this.Text = "O programie";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button closeButton;
    }
}
