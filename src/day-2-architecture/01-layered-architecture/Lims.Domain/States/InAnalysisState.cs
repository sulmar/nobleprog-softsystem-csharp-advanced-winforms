using System;

namespace Lims.Domain.States
{
    public class InAnalysisState : ISampleState
    {
        public string Name => "W trakcie analizy";

        public void CancelAnalysis(Sample sample)
        {
            sample.ChangeState(new RegisteredState());
        }

        public void CompleteAnalysis(Sample sample)
        {            
            sample.ChangeState(new CompleteState());
        }

        public void StartAnalysis(Sample sample)
        {
            throw new InvalidOperationException("Analiza już trwa");
        }
    }
}
