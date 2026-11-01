namespace Lims.Problem
{
    partial class MainForm
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
            this.receptionButton = new System.Windows.Forms.Button();
            this.urgentButton = new System.Windows.Forms.Button();
            this.batchButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.outOfPaperCheckBox = new System.Windows.Forms.CheckBox();
            this.billingDownCheckBox = new System.Windows.Forms.CheckBox();
            this.auditDownCheckBox = new System.Windows.Forms.CheckBox();
            this.journalLabel = new System.Windows.Forms.Label();
            this.journalListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            //
            // receptionButton
            //
            this.receptionButton.Location = new System.Drawing.Point(12, 12);
            this.receptionButton.Name = "receptionButton";
            this.receptionButton.Size = new System.Drawing.Size(110, 23);
            this.receptionButton.TabIndex = 0;
            this.receptionButton.Text = "Rejestracja";
            this.receptionButton.UseVisualStyleBackColor = true;
            this.receptionButton.Click += new System.EventHandler(this.ReceptionButton_Click);
            //
            // urgentButton
            //
            this.urgentButton.Location = new System.Drawing.Point(132, 12);
            this.urgentButton.Name = "urgentButton";
            this.urgentButton.Size = new System.Drawing.Size(110, 23);
            this.urgentButton.TabIndex = 1;
            this.urgentButton.Text = "Cito";
            this.urgentButton.UseVisualStyleBackColor = true;
            this.urgentButton.Click += new System.EventHandler(this.UrgentButton_Click);
            //
            // batchButton
            //
            this.batchButton.Location = new System.Drawing.Point(252, 12);
            this.batchButton.Name = "batchButton";
            this.batchButton.Size = new System.Drawing.Size(110, 23);
            this.batchButton.TabIndex = 2;
            this.batchButton.Text = "Zbiorczo";
            this.batchButton.UseVisualStyleBackColor = true;
            this.batchButton.Click += new System.EventHandler(this.BatchButton_Click);
            //
            // clearButton
            //
            this.clearButton.Location = new System.Drawing.Point(492, 12);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(116, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Wyczyść dziennik";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            //
            // outOfPaperCheckBox
            //
            this.outOfPaperCheckBox.AutoSize = true;
            this.outOfPaperCheckBox.Location = new System.Drawing.Point(12, 45);
            this.outOfPaperCheckBox.Name = "outOfPaperCheckBox";
            this.outOfPaperCheckBox.TabIndex = 4;
            this.outOfPaperCheckBox.Text = "Brak papieru w drukarce";
            this.outOfPaperCheckBox.UseVisualStyleBackColor = true;
            this.outOfPaperCheckBox.CheckedChanged += new System.EventHandler(this.OutOfPaperCheckBox_CheckedChanged);
            //
            // billingDownCheckBox
            //
            this.billingDownCheckBox.AutoSize = true;
            this.billingDownCheckBox.Location = new System.Drawing.Point(200, 45);
            this.billingDownCheckBox.Name = "billingDownCheckBox";
            this.billingDownCheckBox.TabIndex = 5;
            this.billingDownCheckBox.Text = "Awaria rozliczeń";
            this.billingDownCheckBox.UseVisualStyleBackColor = true;
            this.billingDownCheckBox.CheckedChanged += new System.EventHandler(this.BillingDownCheckBox_CheckedChanged);
            //
            // auditDownCheckBox
            //
            this.auditDownCheckBox.AutoSize = true;
            this.auditDownCheckBox.Location = new System.Drawing.Point(350, 45);
            this.auditDownCheckBox.Name = "auditDownCheckBox";
            this.auditDownCheckBox.TabIndex = 6;
            this.auditDownCheckBox.Text = "Awaria audytu";
            this.auditDownCheckBox.UseVisualStyleBackColor = true;
            this.auditDownCheckBox.CheckedChanged += new System.EventHandler(this.AuditDownCheckBox_CheckedChanged);
            //
            // journalLabel
            //
            this.journalLabel.AutoSize = true;
            this.journalLabel.Location = new System.Drawing.Point(12, 75);
            this.journalLabel.Name = "journalLabel";
            this.journalLabel.TabIndex = 7;
            this.journalLabel.Text = "Dziennik podsystemów (w kolejności wywołań):";
            //
            // journalListBox
            //
            this.journalListBox.FormattingEnabled = true;
            this.journalListBox.HorizontalScrollbar = true;
            this.journalListBox.Location = new System.Drawing.Point(12, 95);
            this.journalListBox.Name = "journalListBox";
            this.journalListBox.Size = new System.Drawing.Size(596, 290);
            this.journalListBox.TabIndex = 8;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 400);
            this.Controls.Add(this.journalListBox);
            this.Controls.Add(this.journalLabel);
            this.Controls.Add(this.auditDownCheckBox);
            this.Controls.Add(this.billingDownCheckBox);
            this.Controls.Add(this.outOfPaperCheckBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.batchButton);
            this.Controls.Add(this.urgentButton);
            this.Controls.Add(this.receptionButton);
            this.Name = "MainForm";
            this.Text = "Zatwierdzanie zleceń (Problem)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button receptionButton;
        private System.Windows.Forms.Button urgentButton;
        private System.Windows.Forms.Button batchButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox outOfPaperCheckBox;
        private System.Windows.Forms.CheckBox billingDownCheckBox;
        private System.Windows.Forms.CheckBox auditDownCheckBox;
        private System.Windows.Forms.Label journalLabel;
        private System.Windows.Forms.ListBox journalListBox;
    }
}
