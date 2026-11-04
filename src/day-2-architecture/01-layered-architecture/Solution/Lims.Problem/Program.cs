using Lims.Application;
using Lims.Domain;
using Lims.Infrastucture;
using Microsoft.Extensions.DependencyInjection;
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

            // Install-Package Microsoft.Extensions.DependencyInjection

            var services = new ServiceCollection();

            services.AddTransient<PriceCalculator>();
            services.AddTransient<IPriceCalculator>(provider =>
            {
                var calculator = provider.GetRequiredService<PriceCalculator>();

                return new PriorityPriceDecorator(calculator);
            });

            // services.AddSingleton<ISampleRepository, InMemorySampleRepository>();

            services.AddSingleton<ISampleRepository>(provider =>
            {
                return new AuthorizedSampleRepositoryProxy( new CachedSampleRepositoryProxy(new InMemorySampleRepository()), new UserIdentity("01234567891"));
            });

            services.AddTransient<ILabelPrinterFactory>(provider =>
            {
                var factory = new LabelPrinterFactory2();
                factory.Register("Glukoza", new LabelTechLabelPrinter("COM3"));
                factory.Register("Morfologia", new FakeLabelPrinter());

                return factory;
            });

            services.AddTransient<SampleRegistrationService>();
           

            services.AddSingleton<SampleRegistrationForm>();

            services.AddTransient<SamplePreviewForm>();

            services.AddTransient<IFormFactory, FormFactory>();

            using (var provider = services.BuildServiceProvider())
            using (var scope = provider.CreateScope()) 
            {

                SampleRegistrationForm form = scope.ServiceProvider.GetService<SampleRegistrationForm>();

                System.Windows.Forms.Application.Run(form);
            }

            
        }
    }
}
