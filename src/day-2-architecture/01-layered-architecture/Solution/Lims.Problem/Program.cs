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

            var service = new SampleRegistrationService(
                new InMemorySampleRepository(),
                new LabelTechLabelPrinter("COM3"),
                new PriorityPriceDecorator(new PriceCalculator()));

            System.Windows.Forms.Application.Run(new SampleRegistrationForm(service));
        }
    }
}
