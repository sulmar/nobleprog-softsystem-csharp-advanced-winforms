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
        public SamplePreviewForm(ISampleRepository repository)
        {
            InitializeComponent();

        }        
    }
}
