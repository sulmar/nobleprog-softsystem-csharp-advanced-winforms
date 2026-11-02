using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lims.Problem.Helpers
{
    internal class TestResultHelper
    {
        public static bool IsOutOfRange(TestResult result)
        {
            return result.Value < result.ReferenceLow || result.Value > result.ReferenceHigh;
        }
    }
}
