using Lims.Domain;
using System.Collections.Generic;

namespace Lims.Application
{
    // Interfejs generyczny (szablon interfejsu)
    public interface IEntityRepository<TEntity> where TEntity : Base // constraint
    {
        void Add(TEntity entity);
        IReadOnlyList<TEntity> GetAll();
    }
}
