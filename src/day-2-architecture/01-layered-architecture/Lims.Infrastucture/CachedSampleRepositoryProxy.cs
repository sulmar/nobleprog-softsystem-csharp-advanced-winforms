using Lims.Application;
using Lims.Domain;
using System.Collections.Generic;

namespace Lims.Infrastucture
{
    // Wzorzec projektowy Proxy (Pośrednik)
    public class CachedSampleRepositoryProxy : ISampleRepository
    {
        private readonly ISampleRepository repository;
        
        private readonly Dictionary<string, Sample> _cache = new Dictionary<string, Sample>();

        public CachedSampleRepositoryProxy(ISampleRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Sample entity)
        {
            repository.Add(entity);

         //   _cache[entity.Pesel] = entity;
        }

        public IReadOnlyList<Sample> GetAll()
        {
            return repository.GetAll();
        }

        public Sample GetByPesel(string pesel)
        {
            if (_cache.TryGetValue(pesel, out var sample))
            {
                return sample;
            }

            // Real Subject            
            sample = repository.GetByPesel(pesel);

            _cache[pesel] = sample;

            return sample;

        }
    }
}
