namespace Lims.Problem
{
    partial class PreviewForm
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
            this.lastPrintLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lastPrintLabel
            //
            this.lastPrintLabel.AutoSize = true;
            this.lastPrintLabel.Location = new System.Drawing.Point(12, 20);
            this.lastPrintLabel.Name = "lastPrintLabel";
            this.lastPrintLabel.TabIndex = 0;
            this.lastPrintLabel.Text = "Czekam na wydruk...";
            //
            // PreviewForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 60);
            this.Controls.Add(this.lastPrintLabel);
            this.Name = "PreviewForm";
            this.Text = "Podgląd wydruków";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lastPrintLabel;
    }
}
