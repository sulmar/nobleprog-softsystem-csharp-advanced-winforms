using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Domain
{    
    public abstract class Base
    {
        public int Id { get; set; }
    }


    public class Sample : Base
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
