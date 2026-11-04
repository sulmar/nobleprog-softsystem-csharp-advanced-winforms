using Stateless;
using Stateless.Graph;
using System;

namespace Lims.Domain
{
    // Install-Package Stateless
    public class SampleStateMachine
    {
        private readonly StateMachine<SampleStatus, SampleTrigger> machine;

        // Stan jest przechowywany poza maszyna (np. we wlasciwosci Sample.Status)
        public SampleStateMachine(Func<SampleStatus> stateAccessor, Action<SampleStatus> stateMutator)
        {
            machine = new StateMachine<SampleStatus, SampleTrigger>(stateAccessor, stateMutator);

            machine.Configure(SampleStatus.Registered)
                .OnEntry(() => Console.WriteLine("Semd email: Zarejestrowano badanie"))
                .OnEntryFrom(SampleTrigger.CancelAnalysis, () => Console.WriteLine("Nie wysylaj"))
                .Permit(SampleTrigger.StartAnalysis, SampleStatus.InAnalysis); // Registered -> InAnalysis

            machine.Configure(SampleStatus.InAnalysis)
                .Permit(SampleTrigger.CompleteAnalysis, SampleStatus.Completed) //  CompleteAnalysis: InAnalysis -> Completed
                .Permit(SampleTrigger.CancelAnalysis, SampleStatus.Registered)  //  CancelAnalysis: InAnalysis -> Registered
                ;

            machine.Configure(SampleStatus.Completed)
                .Permit(SampleTrigger.CancelAnalysis, SampleStatus.InAnalysis); // CancelAnalysis: Completed -> InAnalysis
        }

        public SampleStatus State => machine.State;

        public void Fire(SampleTrigger trigger) => machine.Fire(trigger);

        public bool CanFire(SampleTrigger trigger) => machine.CanFire(trigger);

        public string ToMermaidGraph() => MermaidGraph.Format(machine.GetInfo());
    }
}
