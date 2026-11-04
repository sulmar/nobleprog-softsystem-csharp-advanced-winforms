using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Application
{
    // Wzorzec Projektowy Facade
    public class SampleRegistrationService
    {
        private readonly ISampleRepository sampleRepository;
        private readonly ILabelPrinterFactory factory;
        private readonly IPriceCalculator calculator;

        public SampleRegistrationService(ISampleRepository sampleRepository, ILabelPrinterFactory factory, IPriceCalculator calculator)
        {
            this.sampleRepository = sampleRepository;
            this.factory = factory;
            this.calculator = calculator;
        }

        public Sample Register(string pesel, string analyte, Priority priority, PayerType payerType)
        {            
            var price = calculator.Calculate(analyte, priority);


            // Reguły rabatowe zaszyte w procesie rejestracji
            switch(payerType)
            {
                case PayerType.Commercial: break;
                case PayerType.Nfz: price = 0m; break;
                case PayerType.CompanySubscription: price = Math.Max(price - 10m, 0); break;

                default:
                    throw new NotSupportedException(nameof(PayerType));

            }

            Sample sample = new Sample { Pesel = pesel, Analyte = analyte, Priority = priority, Price = price };

            sampleRepository.Add(sample);
            

            ILabelPrinter printer = factory.Create(sample.Analyte);

            printer.Print(sample);

            return sample;
        }

        public IReadOnlyList<Sample> GetRegisteredSamples()
        {
            return sampleRepository.GetAll();
        }
    }
}
