namespace Lims.Domain.States
{
    public interface ISampleState
    {
        string Name { get; }
        void StartAnalysis(Sample sample);
        void CompleteAnalysis(Sample sample);
        void CancelAnalysis(Sample sample);
    }
}
