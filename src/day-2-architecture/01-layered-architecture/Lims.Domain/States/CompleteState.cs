using System;

namespace Lims.Domain.States
{
    public class CompleteState : ISampleState
    {
        public string Name => "Zakończona";

        public void CancelAnalysis(Sample sample)
        {
            sample.ChangeState(new InAnalysisState());
        }

        public void CompleteAnalysis(Sample sample)
        {
            throw new InvalidOperationException("Analiza została juz zakonczona");
        }

        public void StartAnalysis(Sample sample)
        {
            throw new InvalidOperationException("Analiza została już zakończona");
        }
    }
}
