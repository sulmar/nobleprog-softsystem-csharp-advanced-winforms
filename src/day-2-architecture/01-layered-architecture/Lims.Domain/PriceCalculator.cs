using System;
using System.Diagnostics;

namespace Lims.Domain
{
    // Concrete Decorator A
    public class PriceCalculator : IPriceCalculator
    {
        public decimal Calculate(string analyte, Priority priority)
        {
            switch(analyte)
            {
                case "Hemoglobina": 
                    return 18m;
                case "Morfologia":
                    return 25m;

                default: return 12m;
            }

            // Match Pattern
            //return analyte switch
            //{
            //    "Hemoglobina" => 18m,
            //    "Morfologia" => 25m,
            //    _ => 12m
            //};
        }
    }
}
