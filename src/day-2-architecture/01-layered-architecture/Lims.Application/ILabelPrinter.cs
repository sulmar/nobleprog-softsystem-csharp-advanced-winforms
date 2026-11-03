using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Application
{
    public interface ILabelPrinter
    {
        void Print(Sample sample);
    }
}
