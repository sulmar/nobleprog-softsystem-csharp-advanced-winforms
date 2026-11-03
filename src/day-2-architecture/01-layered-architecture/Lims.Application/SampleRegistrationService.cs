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
        private readonly IPriceCalculator calculator;

        public SampleRegistrationService(ISampleRepository sampleRepository, ILabelPrinter printer, IPriceCalculator calculator)
        {
            this.sampleRepository = sampleRepository;
            this.printer = printer;
            this.calculator = calculator;
        }

        public Sample Register(string pesel, string analyte, Priority priority)
        {            
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
