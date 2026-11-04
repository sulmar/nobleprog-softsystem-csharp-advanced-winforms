using Lims.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lims.Problem
{
    public partial class SamplePreviewForm : Form
    {
        private readonly ISampleRepository repository;

        public SamplePreviewForm(ISampleRepository repository)
        {
            InitializeComponent();
            this.repository = repository;
        }

        private void SamplePreviewForm_Load(object sender, EventArgs e)
        {


          
        }

        private void buttonGetSample_Click(object sender, EventArgs e)
        {
            var sample = repository.GetByPesel(textBoxPesel.Text);
            analyteLabel.Text = sample.Analyte;

        }
    }
}
