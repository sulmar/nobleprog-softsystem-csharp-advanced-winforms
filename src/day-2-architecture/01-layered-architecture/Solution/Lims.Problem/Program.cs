using Lims.Application;
using Lims.Domain;
using Lims.Infrastucture;
using System;
using System.Windows.Forms;

namespace Lims.Problem
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);


            var factory = new LabelPrinterFactory2();
            factory.Register("Glukoza", new LabelTechLabelPrinter("COM3"));
            factory.Register("Morfologia", new FakeLabelPrinter());

            var service = new SampleRegistrationService(
                new InMemorySampleRepository(), 
                factory,
                new PriorityPriceDecorator(new PriceCalculator()));            

            System.Windows.Forms.Application.Run(new SampleRegistrationForm(service));
        }
    }
}
