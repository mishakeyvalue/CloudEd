using System;
using System.Collections.Generic;
using System.Text;

namespace CES_BLL.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity item);
    }
}
