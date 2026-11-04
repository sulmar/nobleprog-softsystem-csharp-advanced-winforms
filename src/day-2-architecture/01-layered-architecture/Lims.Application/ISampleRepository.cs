using Lims.Domain;
using System;

namespace Lims.Application
{
    public interface ISampleRepository : IEntityRepository<Sample>
    {
        Sample GetByPesel(string pesel);        
    }
}
