namespace Lims.Problem
{
    partial class QualityControlForm
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
            this.logListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            //
            // logListBox
            //
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(12, 12);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(436, 277);
            this.logListBox.TabIndex = 0;
            //
            // QualityControlForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 300);
            this.Controls.Add(this.logListBox);
            this.Name = "QualityControlForm";
            this.Text = "Kontrola jakości (Problem)";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox logListBox;
    }
}
