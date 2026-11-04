using Lims.Application;
using Lims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lims.Infrastucture
{
    public class InMemorySampleRepository : ISampleRepository
    {
        private readonly List<Sample> _samples = new List<Sample>();

        private readonly Dictionary<string, Sample> _cache = new Dictionary<string, Sample>();

        public void Add(Sample sample)
        {
            _samples.Add(sample);
        }

        public IReadOnlyList<Sample> GetAll()
        {
            return _samples;
        }

        public Sample GetByPesel(string pesel)
        {
            if (_cache.TryGetValue(pesel, out var sample))
            {
                return sample;
            }

            Thread.Sleep(2000);
            sample = _samples.FirstOrDefault(s => s.Pesel == pesel);

            _cache[pesel] = sample;

            return sample;
        }
    }
}
