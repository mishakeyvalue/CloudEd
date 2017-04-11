using System;
using System.Collections.Generic;
using System.Text;

namespace CES_DAL.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity item);
    }
}
