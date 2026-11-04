using Lims.Domain.States;
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

        public void CancelAnalysis()
        {
            Status.CancelAnalysis(this);
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
