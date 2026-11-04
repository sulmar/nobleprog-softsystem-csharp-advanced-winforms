using Lims.Application;
using Lims.Domain;
using System;
using System.Collections.Generic;

namespace Lims.Infrastucture
{
    public class AuthorizedSampleRepositoryProxy : ISampleRepository
    {
        private readonly ISampleRepository repository;
        private readonly UserIdentity identity;

        public AuthorizedSampleRepositoryProxy(ISampleRepository repository, UserIdentity identity)
        {
            this.repository = repository;
            this.identity = identity;
        }

        public void Add(Sample entity)
        {
            repository.Add(entity);
        }

        public IReadOnlyList<Sample> GetAll()
        {
            return repository.GetAll();
        }

        public Sample GetByPesel(string pesel)
        {
            var sample = repository.GetByPesel(pesel);

            if (sample.Pesel != identity.Pesel)
            {
                throw new UnauthorizedAccessException("Wynik badania może odczytać tylko jego własciciel");
            }

            return sample;
        }
    }


}
