using Lims.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Infrastucture
{
    public class LabelPrinterFactory : ILabelPrinterFactory
    {
        public ILabelPrinter Create(string analyte)
        {
            switch(analyte) 
            {
                case "Glukoza": return new LabelTechLabelPrinter("COM3");
                case "Morfologia": return new FakeLabelPrinter();

                default: throw new NotSupportedException(analyte);
            }
        }
    }


    public class LabelPrinterFactory2 : ILabelPrinterFactory
    {
        private readonly Dictionary<string, ILabelPrinter> printers = new Dictionary<string, ILabelPrinter>();

        public void Register(string analyte, ILabelPrinter printer)
        {
            printers.Add(analyte, printer);
        }

        public ILabelPrinter Create(string analyte)
        {
            if (!printers.ContainsKey(analyte))
            {
                throw new NotSupportedException(analyte);
            }

            return printers[analyte];
        }
    }


}
