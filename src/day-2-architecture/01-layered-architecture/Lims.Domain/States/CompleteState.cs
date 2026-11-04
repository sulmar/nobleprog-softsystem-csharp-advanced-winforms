using System;

namespace Lims.Domain.States
{
    public class CompleteState : ISampleState
    {
        public string Name => "Zakończona";

        public void CancelAnalysis(SampleProxy sample)
        {
            sample.ChangeState(new InAnalysisState());
        }

        public void CompleteAnalysis(SampleProxy sample)
        {
            throw new InvalidOperationException("Analiza została juz zakonczona");
        }

        public void StartAnalysis(SampleProxy sample)
        {
            throw new InvalidOperationException("Analiza została już zakończona");
        }
    }
}
