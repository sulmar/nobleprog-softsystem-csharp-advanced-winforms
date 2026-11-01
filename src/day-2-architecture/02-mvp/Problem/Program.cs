using System;
using System.Windows.Forms;
using Lims.Problem.Model;

namespace Lims.Problem
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var service = new LabOrderService(InMemoryLabOrderRepository.WithSampleData());
            Application.Run(new OrderListForm(service));
        }
    }
}
