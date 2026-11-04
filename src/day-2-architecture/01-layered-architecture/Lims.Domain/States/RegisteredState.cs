using System;

namespace Lims.Domain.States
{
    public class RegisteredState : ISampleState
    {
        public string Name => "Zarejestrowana";

        public void CancelAnalysis(Sample sample)
        {
            throw new InvalidOperationException("Analiza nie zostala jeszcze rozpoczeta.");
        }

        public void CompleteAnalysis(Sample sample)
        {
            throw new InvalidOperationException("Najpierw ropocznij analizę");
        }

        public void StartAnalysis(Sample sample)
        {
            sample.ChangeState(new InAnalysisState());
        }
    }
}
