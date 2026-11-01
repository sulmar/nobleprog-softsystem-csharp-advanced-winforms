namespace Lims.Problem
{
    partial class OrderListForm
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
            this.ordersListBox = new System.Windows.Forms.ListBox();
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // ordersListBox
            //
            this.ordersListBox.FormattingEnabled = true;
            this.ordersListBox.Location = new System.Drawing.Point(12, 12);
            this.ordersListBox.Name = "ordersListBox";
            this.ordersListBox.Size = new System.Drawing.Size(420, 134);
            this.ordersListBox.TabIndex = 0;
            this.ordersListBox.DoubleClick += new System.EventHandler(this.OpenButton_Click);
            //
            // openButton
            //
            this.openButton.Location = new System.Drawing.Point(12, 156);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(130, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Otwórz zlecenie";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            //
            // OrderListForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 191);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.ordersListBox);
            this.Name = "OrderListForm";
            this.Text = "Zlecenia badań (Problem)";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox ordersListBox;
        private System.Windows.Forms.Button openButton;
    }
}
