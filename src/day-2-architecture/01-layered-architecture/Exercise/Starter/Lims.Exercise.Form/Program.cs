using System;
using System.Windows.Forms;

namespace Lims.Exercise.Form
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ResultApprovalForm());
        }
    }
}
