using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lims.Problem
{
    internal class TestResultRepository
    {
        public TestResult GetTestResult(int i, CancellationToken cancellationToken = default, IProgress<int> progress = default)
        {
            // Thread.Sleep(5000);

            for (int batch = 0; batch <= 5; batch++)
            {
             
                var processed = new TestResult
                {
                    SampleCode = "S-2026-" + (300 + i).ToString("D6"),
                    Analyte = "Glukoza",
                    Value = i % 3 == 0 ? 150m : 85m,
                    ReferenceLow = 70m,
                    ReferenceHigh = 99m
                };

                // Rozwiazania problemu przekazania zwrotnie informacji o przetworzonych danych

                if (cancellationToken.IsCancellationRequested)
                {
                    var exception = new OperationCanceledException(cancellationToken);
                    exception.Data["BatchId"] = batch;
                    exception.Data["Processed"] = processed;
                    throw exception;
                }

                // Ekwiwalent powyzszego zapisu
                // cancellationToken.ThrowIfCancellationRequested();


                if (cancellationToken.IsCancellationRequested)
                {
                    return new TestResult
                    {
                        SampleCode = "S-2026-" + (300 + i).ToString("D6"),
                        Analyte = "Glukoza",
                        Value = 0,
                        ReferenceLow = 70m,
                        ReferenceHigh = 99m
                    };
                }

                Thread.Sleep(1000);

                progress?.Report(batch);
            }

            return new TestResult
            {
                SampleCode = "S-2026-" + (300 + i).ToString("D6"),
                Analyte = "Glukoza",
                Value = i % 3 == 0 ? 150m : 85m,
                ReferenceLow = 70m,
                ReferenceHigh = 99m
            };
        }

        public Task<TestResult> GetTestResultAsync(int i, CancellationToken cancellationToken = default, IProgress<int> progress = default) => Task.Run(() => GetTestResult(i, cancellationToken, progress));
    }
}
