namespace Lims.Problem
{
    partial class SamplePreviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.analyteLabel = new System.Windows.Forms.Label();
            this.textBoxPesel = new System.Windows.Forms.TextBox();
            this.buttonGetSample = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wynik badania:";
            // 
            // analyteLabel
            // 
            this.analyteLabel.AutoSize = true;
            this.analyteLabel.Location = new System.Drawing.Point(200, 85);
            this.analyteLabel.Name = "analyteLabel";
            this.analyteLabel.Size = new System.Drawing.Size(0, 13);
            this.analyteLabel.TabIndex = 1;
            // 
            // textBoxPesel
            // 
            this.textBoxPesel.Location = new System.Drawing.Point(86, 44);
            this.textBoxPesel.Name = "textBoxPesel";
            this.textBoxPesel.Size = new System.Drawing.Size(210, 20);
            this.textBoxPesel.TabIndex = 2;
            // 
            // buttonGetSample
            // 
            this.buttonGetSample.Location = new System.Drawing.Point(291, 41);
            this.buttonGetSample.Name = "buttonGetSample";
            this.buttonGetSample.Size = new System.Drawing.Size(142, 23);
            this.buttonGetSample.TabIndex = 3;
            this.buttonGetSample.Text = "Pobierz badanie";
            this.buttonGetSample.UseVisualStyleBackColor = true;
            this.buttonGetSample.Click += new System.EventHandler(this.buttonGetSample_Click);
            // 
            // SamplePreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonGetSample);
            this.Controls.Add(this.textBoxPesel);
            this.Controls.Add(this.analyteLabel);
            this.Controls.Add(this.label1);
            this.Name = "SamplePreviewForm";
            this.Text = "SamplePreviewForm";
            this.Load += new System.EventHandler(this.SamplePreviewForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label analyteLabel;
        private System.Windows.Forms.TextBox textBoxPesel;
        private System.Windows.Forms.Button buttonGetSample;
    }
}