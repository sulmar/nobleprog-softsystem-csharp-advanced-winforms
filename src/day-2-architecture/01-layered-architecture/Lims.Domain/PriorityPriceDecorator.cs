namespace Lims.Domain
{
    // Wzorzec Projektowy Dekorator
    // Concrete Decorator B
    public class PriorityPriceDecorator : IPriceCalculator
    {
        private readonly IPriceCalculator calculator;

        public PriorityPriceDecorator(IPriceCalculator calculator)
        {
            this.calculator = calculator;
        }

        public decimal Calculate(string analyte, Priority priority)
        {
            // Operacja
            decimal price = calculator.Calculate(analyte, priority);

            // Dodane zachowanie
            if (priority  == Priority.Urgent) price = price * 1.5m;
            if (priority == Priority.Immediate) price = price * 2m;

            return price;

        }
    }
}
