using Lims.Domain;
using System;
using System.Collections.Generic;

namespace Lims.Application
{
    public interface ISampleRepository
    {
        void Add(Sample sample);
        IReadOnlyList<Sample> GetAll();
    }
}
