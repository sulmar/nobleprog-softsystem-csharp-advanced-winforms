using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lims.Problem.Extensions
{
    internal static class TestResultExtensions
    {
        // Metoda rozszerzajaca
        public static bool IsOutOfRange(this TestResult result)
        {
            return result.Value < result.ReferenceLow || result.Value > result.ReferenceHigh;
        }
    }


    internal static class SampleExtensions
    {
        public static string FormatBarcode(this string code, string delimeter = "*")
        {
            return delimeter + code.Replace("-", string.Empty) + delimeter;
        }
    }
}
