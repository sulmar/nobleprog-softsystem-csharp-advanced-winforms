namespace Lims.Domain
{
    // Abstract Decorator
    public interface IPriceCalculator
    {
        decimal Calculate(string analyte, Priority priority);
    }
}
