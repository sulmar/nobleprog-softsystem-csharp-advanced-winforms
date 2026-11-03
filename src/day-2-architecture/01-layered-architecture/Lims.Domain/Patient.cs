using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Domain
{
    public class Patient : Base
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
    }
}
