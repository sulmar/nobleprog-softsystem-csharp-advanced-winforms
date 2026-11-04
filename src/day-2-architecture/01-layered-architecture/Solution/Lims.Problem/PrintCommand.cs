using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lims.Problem
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }

    public class PrintCommand : ICommand
    {
        private readonly Sample sample;

        public PrintCommand(Sample sample)
        {
            this.sample = sample;
        }

        public void Execute()
        {
            Print();
        }

        public bool CanExecute()
        {
            return CanPrint();
        }

        private bool CanPrint()
        {
            return !string.IsNullOrWhiteSpace(sample.Pesel) && !string.IsNullOrWhiteSpace(sample.Analyte);
        }

        private void Print()
        {
            if (CanPrint())
            {
                Console.WriteLine($"Print {sample}");

            }
        }

    }

    public class SendCommand : ICommand 
    {
        private readonly Sample sample;

        public SendCommand(Sample sample)
        {
            this.sample = sample;
        }

        public bool CanExecute() => !string.IsNullOrWhiteSpace(sample.Pesel);

        public void Execute() 
        {
            Console.WriteLine($"Send {sample.Analyte} by email");
        }
    }
}
