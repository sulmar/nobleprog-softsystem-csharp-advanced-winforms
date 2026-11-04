using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Domain
{    

    public interface ISampleState
    {
        string Name { get; }
        void StartAnalysis(Sample sample);
        void CompleteAnalysis(Sample sample);
    }


    public class RegisteredState : ISampleState
    {
        public string Name => "Zarejestrowana";

        public void CompleteAnalysis(Sample sample)
        {
            throw new InvalidOperationException("Najpierw ropocznij analizę");
        }

        public void StartAnalysis(Sample sample)
        {
            sample.ChangeState(new InAnalysisState());
        }
    }

    public class InAnalysisState : ISampleState
    {
        public string Name => "W trakcie analizy";

        public void CompleteAnalysis(Sample sample)
        {            
            sample.ChangeState(new CompleteState());
        }

        public void StartAnalysis(Sample sample)
        {
            throw new InvalidOperationException("Analiza już trwa");
        }
    }

    public class CompleteState : ISampleState
    {
        public string Name => "Zakończona";

        public void CompleteAnalysis(Sample sample)
        {
            throw new InvalidOperationException("Analiza została juz zakonczona");
        }

        public void StartAnalysis(Sample sample)
        {
            throw new InvalidOperationException("Analiza została już zakończona");
        }
    }



    public class Sample : Base
    {
        public string Pesel { get; set; }
        public string Analyte { get; set; }
        public Priority Priority { get; set; }
        public decimal Price { get; set; }
        public ISampleState Status { get; private set; } = new RegisteredState(); // Stan poczatkowy

        public void ChangeState(ISampleState state)
        {
            Status = state;
        }


        public void StartAnalysis()
        {
            Status.StartAnalysis(this);
        }

        public void CompleteAnalysis() 
        {
            Status.CompleteAnalysis(this);            
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
        InAnalysis,
        Completed
    }
}
