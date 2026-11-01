namespace Lims.Problem
{
    partial class SampleListPanel
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
            this.samplesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            //
            // samplesListBox
            //
            this.samplesListBox.FormattingEnabled = true;
            this.samplesListBox.Location = new System.Drawing.Point(3, 3);
            this.samplesListBox.Name = "samplesListBox";
            this.samplesListBox.Size = new System.Drawing.Size(374, 290);
            this.samplesListBox.TabIndex = 0;
            this.samplesListBox.SelectedIndexChanged += new System.EventHandler(this.SamplesListBox_SelectedIndexChanged);
            //
            // SampleListPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.samplesListBox);
            this.Name = "SampleListPanel";
            this.Size = new System.Drawing.Size(380, 300);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox samplesListBox;
    }
}
