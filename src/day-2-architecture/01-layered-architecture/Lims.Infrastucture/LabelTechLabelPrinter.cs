using LabelTech.Sdk;
using Lims.Application;
using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Infrastucture
{
    // Wzorzec Projektowy Adapter (wariant obiektowy)
    public class LabelTechLabelPrinter : ILabelPrinter
    {
        private readonly string port;

        public LabelTechLabelPrinter(string port)
        {
            this.port = port;
        }

        public void Print(Sample sample)
        {
            // Adaptee
            var printer = new LabelTechPrinter();

            printer.Connect(port);
            printer.PrintLine(sample.Pesel + " | " + sample.Analyte + " | " + sample.Priority);
            printer.Disconnect();

        }
    }
}
