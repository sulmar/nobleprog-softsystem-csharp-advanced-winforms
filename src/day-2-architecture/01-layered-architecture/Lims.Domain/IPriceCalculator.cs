namespace Lims.Domain
{
    // Dekorator
    public interface IPriceCalculator
    {
        // Operacja
        decimal Calculate(string analyte, Priority priority);
      // Komponent
    }
}
