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
        private readonly ILabelPrinter printer;

        public SampleRegistrationService(ISampleRepository sampleRepository, ILabelPrinter printer)
        {
            this.sampleRepository = sampleRepository;
            this.printer = printer;
        }

        public Sample Register(string pesel, string analyte, string priority)
        {
            // Zaleznosci            
            PriceCalculator calculator = new PriceCalculator();

            var price = calculator.Calculate(analyte, priority);

            // TODO: refaktoryzacja: ukryć bazę za interfejsem.
            // PROBLEM: formularz woła statyczną klasę (DIP), więc zmiana bazy dotyka okna.            

            Sample sample = new Sample { Pesel = pesel, Analyte = analyte, Priority = priority, Price = price };

            sampleRepository.Add(sample);

            // TODO: refaktoryzacja: ukryć drukarkę za interfejsem.
            // PROBLEM: formularz zna SDK jednego dostawcy i port urządzenia. Zmiana drukarki to zmiana okna,
            // a każda rejestracja w teście drukowałaby prawdziwą etykietę.

            printer.Print(sample);

            return sample;
        }

        public IReadOnlyList<Sample> GetRegisteredSamples()
        {
            return sampleRepository.GetAll();
        }
    }
}
