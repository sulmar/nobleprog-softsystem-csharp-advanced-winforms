namespace Lims.Problem
{
    partial class LabOrderEditForm
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
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusValueLabel = new System.Windows.Forms.Label();
            this.analyteLabel = new System.Windows.Forms.Label();
            this.analyteComboBox = new System.Windows.Forms.ComboBox();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.physicianLabel = new System.Windows.Forms.Label();
            this.physicianTextBox = new System.Windows.Forms.TextBox();
            this.notesLabel = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.notesHintLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelOrderButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // codeLabel
            //
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(12, 15);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.TabIndex = 0;
            this.codeLabel.Text = "Zlecenie:";
            //
            // codeValueLabel
            //
            this.codeValueLabel.AutoSize = true;
            this.codeValueLabel.Location = new System.Drawing.Point(120, 15);
            this.codeValueLabel.Name = "codeValueLabel";
            this.codeValueLabel.TabIndex = 1;
            //
            // patientLabel
            //
            this.patientLabel.AutoSize = true;
            this.patientLabel.Location = new System.Drawing.Point(12, 38);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.TabIndex = 2;
            this.patientLabel.Text = "Pacjent:";
            //
            // patientValueLabel
            //
            this.patientValueLabel.AutoSize = true;
            this.patientValueLabel.Location = new System.Drawing.Point(120, 38);
            this.patientValueLabel.Name = "patientValueLabel";
            this.patientValueLabel.TabIndex = 3;
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 61);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status:";
            //
            // statusValueLabel
            //
            this.statusValueLabel.AutoSize = true;
            this.statusValueLabel.Location = new System.Drawing.Point(120, 61);
            this.statusValueLabel.Name = "statusValueLabel";
            this.statusValueLabel.TabIndex = 5;
            //
            // analyteLabel
            //
            this.analyteLabel.AutoSize = true;
            this.analyteLabel.Location = new System.Drawing.Point(12, 90);
            this.analyteLabel.Name = "analyteLabel";
            this.analyteLabel.TabIndex = 6;
            this.analyteLabel.Text = "Badanie:";
            //
            // analyteComboBox
            //
            this.analyteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.analyteComboBox.Location = new System.Drawing.Point(120, 87);
            this.analyteComboBox.Name = "analyteComboBox";
            this.analyteComboBox.Size = new System.Drawing.Size(200, 21);
            this.analyteComboBox.TabIndex = 7;
            this.analyteComboBox.SelectedIndexChanged += new System.EventHandler(this.Field_Changed);
            //
            // priorityLabel
            //
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(12, 118);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.TabIndex = 8;
            this.priorityLabel.Text = "Priorytet:";
            //
            // priorityComboBox
            //
            this.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityComboBox.Location = new System.Drawing.Point(120, 115);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(200, 21);
            this.priorityComboBox.TabIndex = 9;
            this.priorityComboBox.SelectedIndexChanged += new System.EventHandler(this.Priority_SelectedIndexChanged);
            //
            // physicianLabel
            //
            this.physicianLabel.AutoSize = true;
            this.physicianLabel.Location = new System.Drawing.Point(12, 146);
            this.physicianLabel.Name = "physicianLabel";
            this.physicianLabel.TabIndex = 10;
            this.physicianLabel.Text = "Lekarz zlecający:";
            //
            // physicianTextBox
            //
            this.physicianTextBox.Location = new System.Drawing.Point(120, 143);
            this.physicianTextBox.Name = "physicianTextBox";
            this.physicianTextBox.Size = new System.Drawing.Size(320, 20);
            this.physicianTextBox.TabIndex = 11;
            this.physicianTextBox.TextChanged += new System.EventHandler(this.Field_Changed);
            //
            // notesLabel
            //
            this.notesLabel.AutoSize = true;
            this.notesLabel.Location = new System.Drawing.Point(12, 174);
            this.notesLabel.Name = "notesLabel";
            this.notesLabel.TabIndex = 12;
            this.notesLabel.Text = "Uwagi:";
            //
            // notesTextBox
            //
            this.notesTextBox.Location = new System.Drawing.Point(120, 171);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(320, 60);
            this.notesTextBox.TabIndex = 13;
            this.notesTextBox.TextChanged += new System.EventHandler(this.Field_Changed);
            //
            // notesHintLabel
            //
            this.notesHintLabel.AutoSize = true;
            this.notesHintLabel.Location = new System.Drawing.Point(120, 236);
            this.notesHintLabel.Name = "notesHintLabel";
            this.notesHintLabel.TabIndex = 14;
            this.notesHintLabel.Text = "Dla priorytetu Cito uwagi są obowiązkowe";
            this.notesHintLabel.Visible = false;
            //
            // messageLabel
            //
            this.messageLabel.Location = new System.Drawing.Point(12, 258);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(428, 32);
            this.messageLabel.TabIndex = 15;
            //
            // saveButton
            //
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(12, 296);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Zapisz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            //
            // cancelOrderButton
            //
            this.cancelOrderButton.Location = new System.Drawing.Point(120, 296);
            this.cancelOrderButton.Name = "cancelOrderButton";
            this.cancelOrderButton.Size = new System.Drawing.Size(120, 23);
            this.cancelOrderButton.TabIndex = 17;
            this.cancelOrderButton.Text = "Anuluj zlecenie";
            this.cancelOrderButton.UseVisualStyleBackColor = true;
            this.cancelOrderButton.Click += new System.EventHandler(this.CancelOrderButton_Click);
            //
            // closeButton
            //
            this.closeButton.Location = new System.Drawing.Point(340, 296);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 23);
            this.closeButton.TabIndex = 18;
            this.closeButton.Text = "Zamknij";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            //
            // LabOrderEditForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 331);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.cancelOrderButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.notesHintLabel);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.notesLabel);
            this.Controls.Add(this.physicianTextBox);
            this.Controls.Add(this.physicianLabel);
            this.Controls.Add(this.priorityComboBox);
            this.Controls.Add(this.priorityLabel);
            this.Controls.Add(this.analyteComboBox);
            this.Controls.Add(this.analyteLabel);
            this.Controls.Add(this.statusValueLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.patientValueLabel);
            this.Controls.Add(this.patientLabel);
            this.Controls.Add(this.codeValueLabel);
            this.Controls.Add(this.codeLabel);
            this.Name = "LabOrderEditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LabOrderEditForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label codeValueLabel;
        private System.Windows.Forms.Label patientLabel;
        private System.Windows.Forms.Label patientValueLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label statusValueLabel;
        private System.Windows.Forms.Label analyteLabel;
        private System.Windows.Forms.ComboBox analyteComboBox;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.ComboBox priorityComboBox;
        private System.Windows.Forms.Label physicianLabel;
        private System.Windows.Forms.TextBox physicianTextBox;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label notesHintLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelOrderButton;
        private System.Windows.Forms.Button closeButton;
    }
}
