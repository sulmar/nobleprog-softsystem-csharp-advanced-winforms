using Lims.Domain;
using Lims.Domain.Discounts;
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
        private readonly DiscountStrategyFactory discountStrategyFactory;

        public SampleRegistrationService(ISampleRepository sampleRepository, ILabelPrinterFactory factory, IPriceCalculator calculator,
            DiscountStrategyFactory discountStrategyFactory)
        {
            this.sampleRepository = sampleRepository;
            this.factory = factory;
            this.calculator = calculator;
            this.discountStrategyFactory = discountStrategyFactory;
        }

        public Sample Register(string pesel, string analyte, Priority priority, PayerType payerType)
        {
            var price = calculator.Calculate(analyte, priority);

            // Wybieramy strategię
            IDiscountStrategy discount = discountStrategyFactory.Create(payerType);

            price = discount.Apply(price);

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
