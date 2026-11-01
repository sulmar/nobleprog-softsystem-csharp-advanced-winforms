namespace Lims.Results
{
    partial class ResultDetailsForm
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.flagLabel = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // headerLabel
            //
            this.headerLabel.AutoSize = true;
            this.headerLabel.Location = new System.Drawing.Point(12, 12);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Wynik";
            //
            // valueLabel
            //
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(12, 42);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.TabIndex = 2;
            this.valueLabel.Text = "Wartość:";
            //
            // valueTextBox
            //
            this.valueTextBox.Location = new System.Drawing.Point(90, 39);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(160, 20);
            this.valueTextBox.TabIndex = 3;
            this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
            //
            // flagLabel
            //
            this.flagLabel.AutoSize = true;
            this.flagLabel.Location = new System.Drawing.Point(262, 42);
            this.flagLabel.Name = "flagLabel";
            this.flagLabel.TabIndex = 4;
            this.flagLabel.Text = "Flaga: brak";
            //
            // commentLabel
            //
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(12, 72);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.TabIndex = 5;
            this.commentLabel.Text = "Komentarz:";
            //
            // commentTextBox
            //
            this.commentTextBox.Multiline = true;
            this.commentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commentTextBox.Location = new System.Drawing.Point(90, 69);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(300, 80);
            this.commentTextBox.TabIndex = 6;
            //
            // saveButton
            //
            this.saveButton.Location = new System.Drawing.Point(214, 160);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 25);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Zapisz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            //
            // closeButton
            //
            this.closeButton.Location = new System.Drawing.Point(305, 160);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(85, 25);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Zamknij";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            //
            // ResultDetailsForm
            //
            this.ClientSize = new System.Drawing.Size(404, 197);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.flagLabel);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.closeButton);
            this.MinimumSize = new System.Drawing.Size(420, 236);
            this.Name = "ResultDetailsForm";
            this.Text = "Wynik";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultDetailsForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Label flagLabel;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
    }
}
