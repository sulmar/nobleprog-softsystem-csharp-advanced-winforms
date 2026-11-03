using Lims.Application;
using Lims.Domain;
using System;
using System.Collections.Generic;

namespace Lims.Infrastucture
{
    public class InMemorySampleRepository : ISampleRepository
    {
        private readonly List<Sample> _samples = new List<Sample>();

        public void Add(Sample sample)
        {
            _samples.Add(sample);
        }

        public IReadOnlyList<Sample> GetAll()
        {
            return _samples;
        }
    }
}
