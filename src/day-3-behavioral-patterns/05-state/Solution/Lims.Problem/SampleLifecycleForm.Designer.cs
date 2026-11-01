namespace Lims.Problem
{
    partial class SampleLifecycleForm
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
            this.components = new System.ComponentModel.Container();
            this.samplesGrid = new System.Windows.Forms.DataGridView();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analyteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.approveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyLabel = new System.Windows.Forms.Label();
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.enterResultButton = new System.Windows.Forms.Button();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.archiveButton = new System.Windows.Forms.Button();
            this.notesLabel = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.editButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelEditButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.samplesGrid)).BeginInit();
            this.gridContextMenu.SuspendLayout();
            this.SuspendLayout();
            //
            // samplesGrid
            //
            this.samplesGrid.AllowUserToAddRows = false;
            this.samplesGrid.AllowUserToDeleteRows = false;
            this.samplesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.samplesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumn,
            this.analyteColumn,
            this.statusColumn,
            this.resultColumn});
            this.samplesGrid.ContextMenuStrip = this.gridContextMenu;
            this.samplesGrid.Location = new System.Drawing.Point(12, 12);
            this.samplesGrid.MultiSelect = false;
            this.samplesGrid.Name = "samplesGrid";
            this.samplesGrid.ReadOnly = true;
            this.samplesGrid.RowHeadersVisible = false;
            this.samplesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.samplesGrid.Size = new System.Drawing.Size(470, 250);
            this.samplesGrid.TabIndex = 0;
            this.samplesGrid.SelectionChanged += new System.EventHandler(this.SamplesGrid_SelectionChanged);
            //
            // codeColumn
            //
            this.codeColumn.DataPropertyName = "Code";
            this.codeColumn.HeaderText = "Kod";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            //
            // analyteColumn
            //
            this.analyteColumn.DataPropertyName = "Analyte";
            this.analyteColumn.HeaderText = "Badanie";
            this.analyteColumn.Name = "analyteColumn";
            this.analyteColumn.ReadOnly = true;
            //
            // statusColumn
            //
            this.statusColumn.DataPropertyName = "StatusText";
            this.statusColumn.HeaderText = "Status";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            //
            // resultColumn
            //
            this.resultColumn.DataPropertyName = "Result";
            this.resultColumn.HeaderText = "Wynik";
            this.resultColumn.Name = "resultColumn";
            this.resultColumn.ReadOnly = true;
            //
            // gridContextMenu
            //
            this.gridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approveMenuItem,
            this.rejectMenuItem,
            this.archiveMenuItem});
            this.gridContextMenu.Name = "gridContextMenu";
            this.gridContextMenu.Size = new System.Drawing.Size(140, 70);
            //
            // approveMenuItem
            //
            this.approveMenuItem.Name = "approveMenuItem";
            this.approveMenuItem.Size = new System.Drawing.Size(139, 22);
            this.approveMenuItem.Text = "Zatwierdź";
            this.approveMenuItem.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // rejectMenuItem
            //
            this.rejectMenuItem.Name = "rejectMenuItem";
            this.rejectMenuItem.Size = new System.Drawing.Size(139, 22);
            this.rejectMenuItem.Text = "Odrzuć";
            this.rejectMenuItem.Click += new System.EventHandler(this.RejectButton_Click);
            //
            // archiveMenuItem
            //
            this.archiveMenuItem.Name = "archiveMenuItem";
            this.archiveMenuItem.Size = new System.Drawing.Size(139, 22);
            this.archiveMenuItem.Text = "Archiwizuj";
            this.archiveMenuItem.Click += new System.EventHandler(this.ArchiveButton_Click);
            //
            // historyLabel
            //
            this.historyLabel.AutoSize = true;
            this.historyLabel.Location = new System.Drawing.Point(12, 270);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.TabIndex = 1;
            this.historyLabel.Text = "Historia próbki:";
            //
            // historyListBox
            //
            this.historyListBox.Location = new System.Drawing.Point(12, 290);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.Size = new System.Drawing.Size(470, 147);
            this.historyListBox.TabIndex = 2;
            //
            // userLabel
            //
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(500, 15);
            this.userLabel.Name = "userLabel";
            this.userLabel.TabIndex = 3;
            this.userLabel.Text = "Użytkownik:";
            //
            // userTextBox
            //
            this.userTextBox.Location = new System.Drawing.Point(610, 12);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(250, 20);
            this.userTextBox.TabIndex = 4;
            this.userTextBox.Text = "Jan Przykładowy";
            //
            // resultLabel
            //
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(500, 45);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.TabIndex = 5;
            this.resultLabel.Text = "Wynik:";
            //
            // resultTextBox
            //
            this.resultTextBox.Location = new System.Drawing.Point(610, 42);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(80, 20);
            this.resultTextBox.TabIndex = 6;
            //
            // enterResultButton
            //
            this.enterResultButton.Location = new System.Drawing.Point(700, 40);
            this.enterResultButton.Name = "enterResultButton";
            this.enterResultButton.Size = new System.Drawing.Size(160, 25);
            this.enterResultButton.TabIndex = 7;
            this.enterResultButton.Text = "Wpisz wynik";
            this.enterResultButton.Click += new System.EventHandler(this.EnterResultButton_Click);
            //
            // reasonLabel
            //
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(500, 75);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.TabIndex = 8;
            this.reasonLabel.Text = "Powód odrzucenia:";
            //
            // reasonTextBox
            //
            this.reasonTextBox.Location = new System.Drawing.Point(610, 72);
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.Size = new System.Drawing.Size(250, 20);
            this.reasonTextBox.TabIndex = 9;
            //
            // startButton
            //
            this.startButton.Location = new System.Drawing.Point(500, 105);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(175, 30);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Rozpocznij analizę";
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            //
            // approveButton
            //
            this.approveButton.Location = new System.Drawing.Point(685, 105);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(175, 30);
            this.approveButton.TabIndex = 11;
            this.approveButton.Text = "Zatwierdź";
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            //
            // rejectButton
            //
            this.rejectButton.Location = new System.Drawing.Point(500, 140);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(175, 30);
            this.rejectButton.TabIndex = 12;
            this.rejectButton.Text = "Odrzuć";
            this.rejectButton.Click += new System.EventHandler(this.RejectButton_Click);
            //
            // archiveButton
            //
            this.archiveButton.Location = new System.Drawing.Point(685, 140);
            this.archiveButton.Name = "archiveButton";
            this.archiveButton.Size = new System.Drawing.Size(175, 30);
            this.archiveButton.TabIndex = 13;
            this.archiveButton.Text = "Archiwizuj";
            this.archiveButton.Click += new System.EventHandler(this.ArchiveButton_Click);
            //
            // notesLabel
            //
            this.notesLabel.AutoSize = true;
            this.notesLabel.Location = new System.Drawing.Point(500, 180);
            this.notesLabel.Name = "notesLabel";
            this.notesLabel.TabIndex = 14;
            this.notesLabel.Text = "Uwagi:";
            //
            // notesTextBox
            //
            this.notesTextBox.Location = new System.Drawing.Point(500, 200);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ReadOnly = true;
            this.notesTextBox.Size = new System.Drawing.Size(360, 120);
            this.notesTextBox.TabIndex = 15;
            //
            // editButton
            //
            this.editButton.Location = new System.Drawing.Point(500, 330);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(115, 30);
            this.editButton.TabIndex = 16;
            this.editButton.Text = "Edytuj";
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            //
            // saveButton
            //
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(622, 330);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(115, 30);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Zapisz";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            //
            // cancelEditButton
            //
            this.cancelEditButton.Enabled = false;
            this.cancelEditButton.Location = new System.Drawing.Point(745, 330);
            this.cancelEditButton.Name = "cancelEditButton";
            this.cancelEditButton.Size = new System.Drawing.Size(115, 30);
            this.cancelEditButton.TabIndex = 18;
            this.cancelEditButton.Text = "Anuluj";
            this.cancelEditButton.Click += new System.EventHandler(this.CancelEditButton_Click);
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 450);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.TabIndex = 19;
            //
            // SampleLifecycleForm
            //
            this.ClientSize = new System.Drawing.Size(880, 480);
            this.Controls.Add(this.samplesGrid);
            this.Controls.Add(this.historyLabel);
            this.Controls.Add(this.historyListBox);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.enterResultButton);
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.reasonTextBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.archiveButton);
            this.Controls.Add(this.notesLabel);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelEditButton);
            this.Controls.Add(this.statusLabel);
            this.Name = "SampleLifecycleForm";
            this.Text = "Obieg próbki";
            ((System.ComponentModel.ISupportInitialize)(this.samplesGrid)).EndInit();
            this.gridContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView samplesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn analyteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultColumn;
        private System.Windows.Forms.ContextMenuStrip gridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem approveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveMenuItem;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.ListBox historyListBox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button enterResultButton;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.TextBox reasonTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button archiveButton;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelEditButton;
        private System.Windows.Forms.Label statusLabel;
    }
}
