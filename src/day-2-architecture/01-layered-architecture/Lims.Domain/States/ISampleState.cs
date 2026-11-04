namespace Lims.Domain.States
{
    public interface ISampleState
    {
        string Name { get; }
        void StartAnalysis(SampleProxy sample);
        void CompleteAnalysis(SampleProxy sample);
        void CancelAnalysis(SampleProxy sample);
    }
}
