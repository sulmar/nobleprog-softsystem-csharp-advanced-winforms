namespace Lims.Problem
{
    partial class SampleRegistrationForm
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
            this.peselLabel = new System.Windows.Forms.Label();
            this.peselTextBox = new System.Windows.Forms.TextBox();
            this.analyteComboBox = new System.Windows.Forms.ComboBox();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.samplesGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.samplesGrid)).BeginInit();
            this.SuspendLayout();
            //
            // peselLabel
            //
            this.peselLabel.AutoSize = true;
            this.peselLabel.Location = new System.Drawing.Point(12, 15);
            this.peselLabel.Name = "peselLabel";
            this.peselLabel.TabIndex = 0;
            this.peselLabel.Text = "PESEL pacjenta:";
            //
            // peselTextBox
            //
            this.peselTextBox.Location = new System.Drawing.Point(110, 12);
            this.peselTextBox.Name = "peselTextBox";
            this.peselTextBox.Size = new System.Drawing.Size(150, 20);
            this.peselTextBox.TabIndex = 1;
            //
            // analyteComboBox
            //
            this.analyteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.analyteComboBox.Location = new System.Drawing.Point(12, 42);
            this.analyteComboBox.Name = "analyteComboBox";
            this.analyteComboBox.Size = new System.Drawing.Size(120, 21);
            this.analyteComboBox.TabIndex = 2;
            //
            // priorityComboBox
            //
            this.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityComboBox.Location = new System.Drawing.Point(140, 42);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(120, 21);
            this.priorityComboBox.TabIndex = 3;
            //
            // registerButton
            //
            this.registerButton.Location = new System.Drawing.Point(12, 72);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(130, 23);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "Zarejestruj próbkę";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.RegisterButton_Click);
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(150, 77);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.TabIndex = 5;
            //
            // samplesGrid
            //
            this.samplesGrid.AllowUserToAddRows = false;
            this.samplesGrid.AllowUserToDeleteRows = false;
            this.samplesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.samplesGrid.Location = new System.Drawing.Point(12, 104);
            this.samplesGrid.Name = "samplesGrid";
            this.samplesGrid.ReadOnly = true;
            this.samplesGrid.RowHeadersVisible = false;
            this.samplesGrid.Size = new System.Drawing.Size(560, 200);
            this.samplesGrid.TabIndex = 6;
            //
            // SampleRegistrationForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 316);
            this.Controls.Add(this.samplesGrid);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.priorityComboBox);
            this.Controls.Add(this.analyteComboBox);
            this.Controls.Add(this.peselTextBox);
            this.Controls.Add(this.peselLabel);
            this.Name = "SampleRegistrationForm";
            this.Text = "Rejestracja próbki (Problem)";
            ((System.ComponentModel.ISupportInitialize)(this.samplesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label peselLabel;
        private System.Windows.Forms.TextBox peselTextBox;
        private System.Windows.Forms.ComboBox analyteComboBox;
        private System.Windows.Forms.ComboBox priorityComboBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DataGridView samplesGrid;
    }
}
