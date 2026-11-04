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
        public SampleStatus Status { get; set; }


        public void StartAnalysis()
        {
            if (Status == SampleStatus.IsAnalysis)
                throw new InvalidOperationException("Analiza już trwa");

            if (Status == SampleStatus.Completed)
                throw new InvalidOperationException("Analiza została już zakończona");

            Status = SampleStatus.IsAnalysis;
        }

        public void CompleteAnalysis() 
        {
            if (Status == SampleStatus.Registered)
                throw new InvalidOperationException("Najpierw ropocznij analizę");

            if (Status == SampleStatus.Completed)
                throw new InvalidOperationException("Analiza została juz zakonczona");

            Status = SampleStatus.Completed;
        }
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
        IsAnalysis,
        Completed
    }
}
