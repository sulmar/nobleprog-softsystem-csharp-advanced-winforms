using Lims.Domain.States;

namespace Lims.Domain
{
    // Proxy rozszerza "sterylna" encje Sample o zachowanie oparte na maszynie stanow
    public class SampleProxy : Sample
    {
        private readonly SampleStateMachine machine;

        public SampleProxy()
        {
            machine = new SampleStateMachine(() => Status, state => Status = state);
        }

        public string GenerateMermaidGraph => machine.ToMermaidGraph();

        public void ChangeState(ISampleState state)
        {
            // Status = state;
        }

        public void StartAnalysis()
        {
            // Status.StartAnalysis(this);
            machine.Fire(SampleTrigger.StartAnalysis);
        }

        public bool CanStartAnalysis => machine.CanFire(SampleTrigger.StartAnalysis);

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
}
