namespace Lims.Problem
{
    partial class SampleBrowserForm
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
            this.filtersPanel = new Lims.Problem.FiltersPanel();
            this.samplesPanel = new Lims.Problem.SampleListPanel();
            this.detailsPanel = new Lims.Problem.SampleDetailsPanel();
            this.actionsPanel = new Lims.Problem.ActionBarPanel();
            this.SuspendLayout();
            //
            // filtersPanel
            //
            this.filtersPanel.Location = new System.Drawing.Point(12, 12);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Size = new System.Drawing.Size(736, 36);
            this.filtersPanel.TabIndex = 0;
            //
            // samplesPanel
            //
            this.samplesPanel.Location = new System.Drawing.Point(12, 56);
            this.samplesPanel.Name = "samplesPanel";
            this.samplesPanel.Size = new System.Drawing.Size(380, 300);
            this.samplesPanel.TabIndex = 1;
            //
            // detailsPanel
            //
            this.detailsPanel.Location = new System.Drawing.Point(400, 56);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Size = new System.Drawing.Size(348, 300);
            this.detailsPanel.TabIndex = 2;
            //
            // actionsPanel
            //
            this.actionsPanel.Location = new System.Drawing.Point(12, 364);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Size = new System.Drawing.Size(736, 40);
            this.actionsPanel.TabIndex = 3;
            //
            // SampleBrowserForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 416);
            this.Controls.Add(this.actionsPanel);
            this.Controls.Add(this.detailsPanel);
            this.Controls.Add(this.samplesPanel);
            this.Controls.Add(this.filtersPanel);
            this.Name = "SampleBrowserForm";
            this.Text = "Przegląd próbek (Problem)";
            this.ResumeLayout(false);
        }

        private Lims.Problem.FiltersPanel filtersPanel;
        private Lims.Problem.SampleListPanel samplesPanel;
        private Lims.Problem.SampleDetailsPanel detailsPanel;
        private Lims.Problem.ActionBarPanel actionsPanel;
    }
}
