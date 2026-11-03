using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Domain
{    
    public class Sample
    {
        public string Pesel { get; set; }
        public string Analyte { get; set; }
        public Priority Priority { get; set; }
        public decimal Price { get; set; }
    }

    public enum Priority
    {
        Normal,
        Urgent,
        Immediate
    }
}
