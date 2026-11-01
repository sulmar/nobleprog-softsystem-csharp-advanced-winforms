namespace Lims.Problem
{
    partial class ResultReviewForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.resultMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.approveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userLabel = new System.Windows.Forms.Label();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.resultsGrid = new System.Windows.Forms.DataGridView();
            this.sampleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analyteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criticalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewedByColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.retestButton = new System.Windows.Forms.Button();
            this.ordersLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
            this.SuspendLayout();
            //
            // menuStrip
            //
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resultMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(684, 24);
            this.menuStrip.TabIndex = 0;
            //
            // resultMenu
            //
            this.resultMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approveMenuItem,
            this.rejectMenuItem,
            this.retestMenuItem});
            this.resultMenu.Name = "resultMenu";
            this.resultMenu.Size = new System.Drawing.Size(50, 20);
            this.resultMenu.Text = "Wynik";
            //
            // approveMenuItem
            //
            this.approveMenuItem.Name = "approveMenuItem";
            this.approveMenuItem.ShortcutKeyDisplayString = "F6";
            this.approveMenuItem.Size = new System.Drawing.Size(180, 22);
            this.approveMenuItem.Text = "Zatwierdź";
            this.approveMenuItem.Click += new System.EventHandler(this.ApproveMenuItem_Click);
            //
            // rejectMenuItem
            //
            this.rejectMenuItem.Name = "rejectMenuItem";
            this.rejectMenuItem.ShortcutKeyDisplayString = "F7";
            this.rejectMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rejectMenuItem.Text = "Odrzuć";
            this.rejectMenuItem.Click += new System.EventHandler(this.RejectMenuItem_Click);
            //
            // retestMenuItem
            //
            this.retestMenuItem.Name = "retestMenuItem";
            this.retestMenuItem.ShortcutKeyDisplayString = "F8";
            this.retestMenuItem.Size = new System.Drawing.Size(180, 22);
            this.retestMenuItem.Text = "Powtórz badanie";
            this.retestMenuItem.Click += new System.EventHandler(this.RetestMenuItem_Click);
            //
            // userLabel
            //
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(12, 35);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(62, 13);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "Użytkownik:";
            //
            // userComboBox
            //
            this.userComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userComboBox.Location = new System.Drawing.Point(90, 32);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(200, 21);
            this.userComboBox.TabIndex = 2;
            this.userComboBox.SelectedIndexChanged += new System.EventHandler(this.UserComboBox_SelectedIndexChanged);
            //
            // resultsGrid
            //
            this.resultsGrid.AllowUserToAddRows = false;
            this.resultsGrid.AllowUserToDeleteRows = false;
            this.resultsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sampleColumn,
            this.analyteColumn,
            this.valueColumn,
            this.criticalColumn,
            this.statusColumn,
            this.reviewedByColumn});
            this.resultsGrid.Location = new System.Drawing.Point(12, 62);
            this.resultsGrid.MultiSelect = false;
            this.resultsGrid.Name = "resultsGrid";
            this.resultsGrid.ReadOnly = true;
            this.resultsGrid.RowHeadersVisible = false;
            this.resultsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsGrid.Size = new System.Drawing.Size(660, 190);
            this.resultsGrid.TabIndex = 3;
            this.resultsGrid.SelectionChanged += new System.EventHandler(this.ResultsGrid_SelectionChanged);
            //
            // sampleColumn
            //
            this.sampleColumn.HeaderText = "Próbka";
            this.sampleColumn.Name = "sampleColumn";
            this.sampleColumn.ReadOnly = true;
            //
            // analyteColumn
            //
            this.analyteColumn.HeaderText = "Badanie";
            this.analyteColumn.Name = "analyteColumn";
            this.analyteColumn.ReadOnly = true;
            //
            // valueColumn
            //
            this.valueColumn.HeaderText = "Wynik";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.ReadOnly = true;
            //
            // criticalColumn
            //
            this.criticalColumn.HeaderText = "Krytyczny";
            this.criticalColumn.Name = "criticalColumn";
            this.criticalColumn.ReadOnly = true;
            //
            // statusColumn
            //
            this.statusColumn.HeaderText = "Status";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            //
            // reviewedByColumn
            //
            this.reviewedByColumn.HeaderText = "Ocenił";
            this.reviewedByColumn.Name = "reviewedByColumn";
            this.reviewedByColumn.ReadOnly = true;
            //
            // approveButton
            //
            this.approveButton.Location = new System.Drawing.Point(12, 262);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(120, 25);
            this.approveButton.TabIndex = 4;
            this.approveButton.Text = "Zatwierdź";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // rejectButton
            //
            this.rejectButton.Location = new System.Drawing.Point(140, 262);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(120, 25);
            this.rejectButton.TabIndex = 5;
            this.rejectButton.Text = "Odrzuć";
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Click += new System.EventHandler(this.RejectButton_Click);
            //
            // retestButton
            //
            this.retestButton.Location = new System.Drawing.Point(268, 262);
            this.retestButton.Name = "retestButton";
            this.retestButton.Size = new System.Drawing.Size(120, 25);
            this.retestButton.TabIndex = 6;
            this.retestButton.Text = "Powtórz badanie";
            this.retestButton.UseVisualStyleBackColor = true;
            this.retestButton.Click += new System.EventHandler(this.RetestButton_Click);
            //
            // ordersLabel
            //
            this.ordersLabel.AutoSize = true;
            this.ordersLabel.Location = new System.Drawing.Point(400, 268);
            this.ordersLabel.Name = "ordersLabel";
            this.ordersLabel.Size = new System.Drawing.Size(180, 13);
            this.ordersLabel.TabIndex = 7;
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 298);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusLabel.TabIndex = 8;
            //
            // ResultReviewForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 322);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.ordersLabel);
            this.Controls.Add(this.retestButton);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.resultsGrid);
            this.Controls.Add(this.userComboBox);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ResultReviewForm";
            this.Text = "Ocena wyników (Problem)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResultReviewForm_KeyDown);
            this.Shown += new System.EventHandler(this.ResultReviewForm_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem resultMenu;
        private System.Windows.Forms.ToolStripMenuItem approveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retestMenuItem;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.DataGridView resultsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn sampleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn analyteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn criticalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewedByColumn;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button retestButton;
        private System.Windows.Forms.Label ordersLabel;
        private System.Windows.Forms.Label statusLabel;
    }
}
