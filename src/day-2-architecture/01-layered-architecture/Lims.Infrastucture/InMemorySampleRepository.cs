using Lims.Application;
using Lims.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

        public Sample GetByPesel(string pesel)
        {
             
            Thread.Sleep(2000);
            return _samples.FirstOrDefault(s => s.Pesel == pesel);           
        }
    }

    public class UserIdentity
    {
        public UserIdentity(string pesel)
        {
            Pesel = pesel;
        }

        public string Pesel { get; }
    }


}
