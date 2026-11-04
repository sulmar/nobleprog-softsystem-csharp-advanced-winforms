using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Domain
{    

    


    public class Sample : Base
    {
        public string Pesel { get; set; }
        public string Analyte { get; set; }
        public Priority Priority { get; set; }
        public decimal Price { get; set; }
        public SampleStatus Status { get; set; } = SampleStatus.Registered; // Stan poczatkowy
    }

    public enum Priority
    {
        Normal,
        Urgent,
        Immediate
    }



    public enum SampleStatus
    {
        Registered,
        InAnalysis,
        Completed
    }

    public enum SampleTrigger
    {
        StartAnalysis,
        CompleteAnalysis,
        CancelAnalysis
    }
}
