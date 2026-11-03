using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lims.Problem
{
    internal class CostCalculator
    {
        public static decimal Calculate(int copies)
        {
            if (copies >= 100)
            {
                return copies * 0.05m;
            }

            if (copies >= 10)
            {
                return copies * 0.08m;
            }

            return copies * 0.10m;
        }
    }
}
