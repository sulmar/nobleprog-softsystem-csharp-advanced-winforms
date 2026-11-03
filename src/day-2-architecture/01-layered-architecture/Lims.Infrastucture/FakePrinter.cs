using Lims.Application;
using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Infrastucture
{
    public class FakeLabelPrinter : ILabelPrinter
    {
        public void Print(Sample sample)
        {
            Console.WriteLine(sample);
        }
    }
}
