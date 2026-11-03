using System;

namespace Lims.Domain
{
    public class PriceCalculator
    {
        public decimal Calculate(string analyte, string priority)
        {
            decimal price = 12m;
            if (analyte == "Hemoglobina") price = 18m;
            if (analyte == "Morfologia") price = 25m;
            if (priority == "Pilne") price = price * 1.5m;
            if (priority == "Cito") price = price * 2m;


            return price;
        }
    }
}
