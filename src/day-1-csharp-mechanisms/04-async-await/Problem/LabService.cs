using System;
using System.Threading;
using System.Threading.Tasks;
using Lims.Domain;

namespace Lims.Problem
{
    /// <summary>Symulacja analizatora i wysyłki: każda operacja trwa kilka sekund.</summary>
    internal static class LabService
    {
        private const int AnalyzeMilliseconds = 2000;
        private const int SendMilliseconds = 1500;

        public static TestResult Analyze(Sample sample)
        {
            Thread.Sleep(AnalyzeMilliseconds);
            return SampleData.ResultFor(sample);
        }

        public static void SendResult(TestResult result)
        {
            Thread.Sleep(SendMilliseconds);
        }

        public static void SendReport(PatientReport report)
        {
            Thread.Sleep(SendMilliseconds);
        }

        public static async Task<TestResult> AnalyzeWithDelayAsync(Sample sample)
        {
            await Task.Delay(AnalyzeMilliseconds);
            return SampleData.ResultFor(sample);
        }

        public static async Task SendResultWithDelayAsync(TestResult result, bool fail)
        {
            await Task.Delay(SendMilliseconds);

            if (fail)
            {
                throw new InvalidOperationException("Serwer lekarza nie odpowiada");
            }
        }
    }
}
