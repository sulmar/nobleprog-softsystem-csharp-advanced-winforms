namespace Lims.Domain
{
    // Wzorzec Projektowy Dekorator
    public class PriorityPriceDecorator : IPriceCalculator
    {
        private readonly IPriceCalculator calculator;

        public PriorityPriceDecorator(IPriceCalculator calculator)
        {
            this.calculator = calculator;
        }

        public decimal Calculate(string analyte, string priority)
        {
            decimal price = calculator.Calculate(analyte, priority);

            if (priority == "Pilne") price = price * 1.5m;
            if (priority == "Cito") price = price * 2m;

            return price;

        }
    }
}
