using System;

namespace Lims.Domain.States
{
    public class RegisteredState : ISampleState
    {
        public string Name => "Zarejestrowana";

        public void CancelAnalysis(SampleProxy sample)
        {
            throw new InvalidOperationException("Analiza nie zostala jeszcze rozpoczeta.");
        }

        public void CompleteAnalysis(SampleProxy sample)
        {
            throw new InvalidOperationException("Najpierw ropocznij analizę");
        }

        public void StartAnalysis(SampleProxy sample)
        {
            sample.ChangeState(new InAnalysisState());
        }
    }
}
