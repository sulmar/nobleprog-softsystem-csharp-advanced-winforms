using System;

namespace Lims.Domain.States
{
    public class InAnalysisState : ISampleState
    {
        public string Name => "W trakcie analizy";

        public void CancelAnalysis(SampleProxy sample)
        {
            sample.ChangeState(new RegisteredState());
        }

        public void CompleteAnalysis(SampleProxy sample)
        {            
            sample.ChangeState(new CompleteState());
        }

        public void StartAnalysis(SampleProxy sample)
        {
            throw new InvalidOperationException("Analiza już trwa");
        }
    }
}
