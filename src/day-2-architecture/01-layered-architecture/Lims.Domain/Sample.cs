using Lims.Domain.States;
using Stateless;
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

        // Install-Package Stateless
        private readonly StateMachine<SampleStatus, SampleTrigger> machine;

        public Sample()
        {
            machine = new StateMachine<SampleStatus, SampleTrigger>(SampleStatus.Registered); // Stan poczatkowy

            machine.Configure(SampleStatus.Registered)
                .Permit(SampleTrigger.StartAnalysis, SampleStatus.InAnalysis); // Registered -> InAnalysis

            machine.Configure(SampleStatus.InAnalysis)
                .Permit(SampleTrigger.CompleteAnalysis, SampleStatus.Completed) //  CompleteAnalysis: InAnalysis -> Completed
                .Permit(SampleTrigger.CancelAnalysis, SampleStatus.Registered)  //  CancelAnalysis: InAnalysis -> Registered
                ; 

            machine.Configure(SampleStatus.Completed)
                .Permit(SampleTrigger.CancelAnalysis, SampleStatus.InAnalysis); // CancelAnalysis: Completed -> InAnalysis
        }

        public void ChangeState(ISampleState state)
        {           
            // Status = state;
        }


        public void StartAnalysis()
        {
            // Status.StartAnalysis(this);
            machine.Fire(SampleTrigger.StartAnalysis);
        }

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
