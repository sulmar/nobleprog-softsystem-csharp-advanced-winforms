using LabelTech.Sdk;
using Lims.Application;
using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Infrastucture
{
    // Wzorzec Projektowy Adapter
    public class LabelTechLabelPrinter : ILabelPrinter
    {
        public void Print(Sample sample)
        {
            // Adaptee
            var printer = new LabelTechPrinter();

            printer.Connect("COM3");
            printer.PrintLine(sample.Pesel + " | " + sample.Analyte + " | " + sample.Priority);
            printer.Disconnect();

        }
    }
}
