using System.Collections.Generic;
using CloudEd.DAL.Persistence;

namespace CloudEd.DAL.Repositories
{
    public interface IRepository<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {
        TEntity Get(TIdentifier Id);

        IEnumerable<TEntity> GetAll();

        TIdentifier Add(TEntity item);

        void Delete(TEntity item);

        void Delete(TIdentifier Id);

        TEntity Save(TEntity item);
    }
}
