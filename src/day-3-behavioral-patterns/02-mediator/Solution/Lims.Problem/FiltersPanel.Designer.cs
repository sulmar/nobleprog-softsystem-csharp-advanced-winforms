namespace Lims.Problem
{
    partial class FiltersPanel
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
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.urgentCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(3, 10);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status:";
            //
            // statusComboBox
            //
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.Location = new System.Drawing.Point(60, 7);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(130, 21);
            this.statusComboBox.TabIndex = 1;
            this.statusComboBox.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // searchLabel
            //
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(210, 10);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.TabIndex = 2;
            this.searchLabel.Text = "Szukaj:";
            //
            // searchTextBox
            //
            this.searchTextBox.Location = new System.Drawing.Point(265, 7);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 20);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.TextChanged += new System.EventHandler(this.Filter_Changed);
            //
            // urgentCheckBox
            //
            this.urgentCheckBox.AutoSize = true;
            this.urgentCheckBox.Location = new System.Drawing.Point(485, 9);
            this.urgentCheckBox.Name = "urgentCheckBox";
            this.urgentCheckBox.TabIndex = 4;
            this.urgentCheckBox.Text = "Tylko pilne";
            this.urgentCheckBox.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            //
            // FiltersPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.urgentCheckBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.statusLabel);
            this.Name = "FiltersPanel";
            this.Size = new System.Drawing.Size(736, 36);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.CheckBox urgentCheckBox;
    }
}
