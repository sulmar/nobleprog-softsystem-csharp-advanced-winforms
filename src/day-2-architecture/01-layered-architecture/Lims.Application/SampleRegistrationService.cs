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

        public Sample Register(Sample sample, PayerType payerType)
        {
            sample.Price = calculator.Calculate(sample.Analyte, sample.Priority);            

            // Wybieramy strategię
            IDiscountStrategy discount = discountStrategyFactory.Create(payerType);

            sample.Price = discount.Apply(sample.Price);
          
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
