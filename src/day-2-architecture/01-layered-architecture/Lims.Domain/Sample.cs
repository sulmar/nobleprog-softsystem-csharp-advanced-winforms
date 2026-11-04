using Lims.Domain.States;
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
        //public ISampleState Status { get; private set; } = new RegisteredState(); // Stan poczatkowy
        public SampleStatus Status => machine.State;

        private readonly SampleStateMachine machine = new SampleStateMachine();

        public string GenerateMermaidGraph => machine.ToMermaidGraph();

        public void ChangeState(ISampleState state)
        {           
            // Status = state;
        }


        public void StartAnalysis()
        {
            // Status.StartAnalysis(this);
            machine.Fire(SampleTrigger.StartAnalysis);
        }

        public bool CanStartAnalysis => machine.CanFire(SampleTrigger.StartAnalysis);
        

        public void CompleteAnalysis() 
        {
            // Status.CompleteAnalysis(this);            
            machine.Fire(SampleTrigger.CompleteAnalysis);
        }

        public void CancelAnalysis()
        {
            machine.Fire(SampleTrigger.CancelAnalysis);
    
            // Status.CancelAnalysis(this);
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

    public enum SampleTrigger
    {
        StartAnalysis,
        CompleteAnalysis,
        CancelAnalysis
    }
}
