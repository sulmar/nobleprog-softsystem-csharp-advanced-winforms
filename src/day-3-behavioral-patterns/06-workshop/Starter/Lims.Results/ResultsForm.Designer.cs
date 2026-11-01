namespace Lims.Results
{
    partial class ResultsForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reopenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorLabel = new System.Windows.Forms.Label();
            this.operatorComboBox = new System.Windows.Forms.ComboBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.onlyAbnormalCheckBox = new System.Windows.Forms.CheckBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.resultsGrid = new System.Windows.Forms.DataGridView();
            this.sampleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analyteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rangeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flagColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verifyButton = new System.Windows.Forms.Button();
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.reopenButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.detailsButton = new System.Windows.Forms.Button();
            this.selectionLabel = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.auditLabel = new System.Windows.Forms.Label();
            this.auditListBox = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            //
            // mainMenu
            //
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu, this.resultMenu, this.viewMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1000, 24);
            this.mainMenu.TabIndex = 0;
            //
            // fileMenu
            //
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importMenuItem, this.closeMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Text = "Plik";
            //
            // importMenuItem
            //
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.ShortcutKeyDisplayString = "F5";
            this.importMenuItem.Text = "Importuj z analizatora";
            this.importMenuItem.Click += new System.EventHandler(this.importMenuItem_Click);
            //
            // closeMenuItem
            //
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Text = "Zamknij";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            //
            // resultMenu
            //
            this.resultMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verifyMenuItem, this.approveMenuItem, this.rejectMenuItem, this.reopenMenuItem, this.sendMenuItem, this.printMenuItem, this.detailsMenuItem});
            this.resultMenu.Name = "resultMenu";
            this.resultMenu.Text = "Wynik";
            //
            // verifyMenuItem
            //
            this.verifyMenuItem.Name = "verifyMenuItem";
            this.verifyMenuItem.ShortcutKeyDisplayString = "F2";
            this.verifyMenuItem.Text = "Zweryfikuj";
            this.verifyMenuItem.Click += new System.EventHandler(this.verifyMenuItem_Click);
            //
            // approveMenuItem
            //
            this.approveMenuItem.Name = "approveMenuItem";
            this.approveMenuItem.ShortcutKeyDisplayString = "F3";
            this.approveMenuItem.Text = "Zatwierdź";
            this.approveMenuItem.Click += new System.EventHandler(this.approveMenuItem_Click);
            //
            // rejectMenuItem
            //
            this.rejectMenuItem.Name = "rejectMenuItem";
            this.rejectMenuItem.ShortcutKeyDisplayString = "F4";
            this.rejectMenuItem.Text = "Odrzuć";
            this.rejectMenuItem.Click += new System.EventHandler(this.rejectMenuItem_Click);
            //
            // reopenMenuItem
            //
            this.reopenMenuItem.Name = "reopenMenuItem";
            this.reopenMenuItem.Text = "Przywróć";
            this.reopenMenuItem.Click += new System.EventHandler(this.reopenMenuItem_Click);
            //
            // sendMenuItem
            //
            this.sendMenuItem.Name = "sendMenuItem";
            this.sendMenuItem.ShortcutKeyDisplayString = "F6";
            this.sendMenuItem.Text = "Wyślij";
            this.sendMenuItem.Click += new System.EventHandler(this.sendMenuItem_Click);
            //
            // printMenuItem
            //
            this.printMenuItem.Name = "printMenuItem";
            this.printMenuItem.ShortcutKeyDisplayString = "Ctrl+P";
            this.printMenuItem.Text = "Drukuj";
            this.printMenuItem.Click += new System.EventHandler(this.printMenuItem_Click);
            //
            // detailsMenuItem
            //
            this.detailsMenuItem.Name = "detailsMenuItem";
            this.detailsMenuItem.Text = "Szczegóły";
            this.detailsMenuItem.Click += new System.EventHandler(this.detailsButton_Click);
            //
            // viewMenu
            //
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statisticsMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Text = "Widok";
            //
            // statisticsMenuItem
            //
            this.statisticsMenuItem.Name = "statisticsMenuItem";
            this.statisticsMenuItem.ShortcutKeyDisplayString = "F9";
            this.statisticsMenuItem.Text = "Statystyki";
            this.statisticsMenuItem.Click += new System.EventHandler(this.statisticsButton_Click);
            //
            // operatorLabel
            //
            this.operatorLabel.AutoSize = true;
            this.operatorLabel.Location = new System.Drawing.Point(12, 35);
            this.operatorLabel.Name = "operatorLabel";
            this.operatorLabel.TabIndex = 1;
            this.operatorLabel.Text = "Operator:";
            //
            // operatorComboBox
            //
            this.operatorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operatorComboBox.Location = new System.Drawing.Point(75, 32);
            this.operatorComboBox.Name = "operatorComboBox";
            this.operatorComboBox.Size = new System.Drawing.Size(125, 21);
            this.operatorComboBox.TabIndex = 2;
            //
            // filterLabel
            //
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(212, 35);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.TabIndex = 3;
            this.filterLabel.Text = "Status:";
            //
            // filterComboBox
            //
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.Location = new System.Drawing.Point(260, 32);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(120, 21);
            this.filterComboBox.TabIndex = 4;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filter_Changed);
            //
            // onlyAbnormalCheckBox
            //
            this.onlyAbnormalCheckBox.AutoSize = true;
            this.onlyAbnormalCheckBox.Location = new System.Drawing.Point(392, 34);
            this.onlyAbnormalCheckBox.Name = "onlyAbnormalCheckBox";
            this.onlyAbnormalCheckBox.TabIndex = 5;
            this.onlyAbnormalCheckBox.Text = "Tylko poza zakresem";
            this.onlyAbnormalCheckBox.CheckedChanged += new System.EventHandler(this.filter_Changed);
            //
            // portLabel
            //
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(545, 35);
            this.portLabel.Name = "portLabel";
            this.portLabel.TabIndex = 6;
            this.portLabel.Text = "Port:";
            //
            // portTextBox
            //
            this.portTextBox.Location = new System.Drawing.Point(580, 32);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(60, 20);
            this.portTextBox.TabIndex = 7;
            this.portTextBox.Text = "COM3";
            //
            // importButton
            //
            this.importButton.Location = new System.Drawing.Point(650, 30);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(165, 25);
            this.importButton.TabIndex = 8;
            this.importButton.Text = "Importuj z analizatora";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            //
            // statisticsButton
            //
            this.statisticsButton.Location = new System.Drawing.Point(823, 30);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(165, 25);
            this.statisticsButton.TabIndex = 9;
            this.statisticsButton.Text = "Statystyki";
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButton_Click);
            //
            // resultsGrid
            //
            this.resultsGrid.AllowUserToAddRows = false;
            this.resultsGrid.AllowUserToDeleteRows = false;
            this.resultsGrid.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.resultsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sampleColumn, this.patientColumn, this.typeColumn, this.analyteColumn, this.valueColumn, this.rangeColumn, this.flagColumn, this.statusColumn});
            this.resultsGrid.MultiSelect = false;
            this.resultsGrid.ReadOnly = true;
            this.resultsGrid.RowHeadersVisible = false;
            this.resultsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsGrid.Location = new System.Drawing.Point(12, 64);
            this.resultsGrid.Name = "resultsGrid";
            this.resultsGrid.Size = new System.Drawing.Size(976, 336);
            this.resultsGrid.TabIndex = 10;
            this.resultsGrid.SelectionChanged += new System.EventHandler(this.resultsGrid_SelectionChanged);
            this.resultsGrid.DoubleClick += new System.EventHandler(this.detailsButton_Click);
            //
            // sampleColumn
            //
            this.sampleColumn.HeaderText = "Próbka";
            this.sampleColumn.Name = "sampleColumn";
            this.sampleColumn.ReadOnly = true;
            this.sampleColumn.Width = 90;
            //
            // patientColumn
            //
            this.patientColumn.HeaderText = "Pacjent";
            this.patientColumn.Name = "patientColumn";
            this.patientColumn.ReadOnly = true;
            this.patientColumn.Width = 150;
            //
            // typeColumn
            //
            this.typeColumn.HeaderText = "Rodzaj";
            this.typeColumn.Name = "typeColumn";
            this.typeColumn.ReadOnly = true;
            this.typeColumn.Width = 100;
            //
            // analyteColumn
            //
            this.analyteColumn.HeaderText = "Badanie";
            this.analyteColumn.Name = "analyteColumn";
            this.analyteColumn.ReadOnly = true;
            this.analyteColumn.Width = 120;
            //
            // valueColumn
            //
            this.valueColumn.HeaderText = "Wynik";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.ReadOnly = true;
            this.valueColumn.Width = 110;
            //
            // rangeColumn
            //
            this.rangeColumn.HeaderText = "Zakres";
            this.rangeColumn.Name = "rangeColumn";
            this.rangeColumn.ReadOnly = true;
            this.rangeColumn.Width = 100;
            //
            // flagColumn
            //
            this.flagColumn.HeaderText = "Flaga";
            this.flagColumn.Name = "flagColumn";
            this.flagColumn.ReadOnly = true;
            this.flagColumn.Width = 50;
            //
            // statusColumn
            //
            this.statusColumn.HeaderText = "Status";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            this.statusColumn.Width = 110;
            //
            // verifyButton
            //
            this.verifyButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.verifyButton.Location = new System.Drawing.Point(12, 408);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(110, 25);
            this.verifyButton.TabIndex = 11;
            this.verifyButton.Text = "Zweryfikuj";
            this.verifyButton.UseVisualStyleBackColor = true;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            //
            // approveButton
            //
            this.approveButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.approveButton.Location = new System.Drawing.Point(130, 408);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(110, 25);
            this.approveButton.TabIndex = 12;
            this.approveButton.Text = "Zatwierdź";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.approveButton_Click);
            //
            // rejectButton
            //
            this.rejectButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.rejectButton.Location = new System.Drawing.Point(248, 408);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(110, 25);
            this.rejectButton.TabIndex = 13;
            this.rejectButton.Text = "Odrzuć";
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Click += new System.EventHandler(this.rejectButton_Click);
            //
            // reopenButton
            //
            this.reopenButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.reopenButton.Location = new System.Drawing.Point(366, 408);
            this.reopenButton.Name = "reopenButton";
            this.reopenButton.Size = new System.Drawing.Size(110, 25);
            this.reopenButton.TabIndex = 14;
            this.reopenButton.Text = "Przywróć";
            this.reopenButton.UseVisualStyleBackColor = true;
            this.reopenButton.Click += new System.EventHandler(this.reopenButton_Click);
            //
            // sendButton
            //
            this.sendButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.sendButton.Location = new System.Drawing.Point(484, 408);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(110, 25);
            this.sendButton.TabIndex = 15;
            this.sendButton.Text = "Wyślij";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            //
            // printButton
            //
            this.printButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.printButton.Location = new System.Drawing.Point(602, 408);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(110, 25);
            this.printButton.TabIndex = 16;
            this.printButton.Text = "Drukuj";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            //
            // detailsButton
            //
            this.detailsButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.detailsButton.Location = new System.Drawing.Point(720, 408);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(110, 25);
            this.detailsButton.TabIndex = 17;
            this.detailsButton.Text = "Szczegóły";
            this.detailsButton.UseVisualStyleBackColor = true;
            this.detailsButton.Click += new System.EventHandler(this.detailsButton_Click);
            //
            // selectionLabel
            //
            this.selectionLabel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.selectionLabel.AutoSize = true;
            this.selectionLabel.Location = new System.Drawing.Point(100, 440);
            this.selectionLabel.Name = "selectionLabel";
            this.selectionLabel.TabIndex = 18;
            this.selectionLabel.Text = "Nie wybrano wyniku";
            //
            // commentLabel
            //
            this.commentLabel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(12, 440);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.TabIndex = 19;
            this.commentLabel.Text = "Komentarz:";
            //
            // commentTextBox
            //
            this.commentTextBox.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.commentTextBox.Multiline = true;
            this.commentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commentTextBox.Location = new System.Drawing.Point(12, 458);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(470, 90);
            this.commentTextBox.TabIndex = 20;
            //
            // auditLabel
            //
            this.auditLabel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.auditLabel.AutoSize = true;
            this.auditLabel.Location = new System.Drawing.Point(500, 440);
            this.auditLabel.Name = "auditLabel";
            this.auditLabel.TabIndex = 21;
            this.auditLabel.Text = "Historia operacji:";
            //
            // auditListBox
            //
            this.auditListBox.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.auditListBox.Location = new System.Drawing.Point(500, 458);
            this.auditListBox.Name = "auditListBox";
            this.auditListBox.Size = new System.Drawing.Size(488, 95);
            this.auditListBox.TabIndex = 22;
            //
            // progressBar
            //
            this.progressBar.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.progressBar.Location = new System.Drawing.Point(12, 560);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 18);
            this.progressBar.TabIndex = 23;
            //
            // statusLabel
            //
            this.statusLabel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(324, 562);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.TabIndex = 24;
            //
            // ResultsForm
            //
            this.ClientSize = new System.Drawing.Size(1000, 590);
            this.Controls.Add(this.operatorLabel);
            this.Controls.Add(this.operatorComboBox);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.onlyAbnormalCheckBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.resultsGrid);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.reopenButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.detailsButton);
            this.Controls.Add(this.selectionLabel);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.auditLabel);
            this.Controls.Add(this.auditListBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(1016, 629);
            this.Name = "ResultsForm";
            this.Text = "Wyniki badań";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem importMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultMenu;
        private System.Windows.Forms.ToolStripMenuItem verifyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reopenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem statisticsMenuItem;
        private System.Windows.Forms.Label operatorLabel;
        private System.Windows.Forms.ComboBox operatorComboBox;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.CheckBox onlyAbnormalCheckBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.DataGridView resultsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn sampleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn analyteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rangeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flagColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button reopenButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button detailsButton;
        private System.Windows.Forms.Label selectionLabel;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.Label auditLabel;
        private System.Windows.Forms.ListBox auditListBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label statusLabel;
    }
}
