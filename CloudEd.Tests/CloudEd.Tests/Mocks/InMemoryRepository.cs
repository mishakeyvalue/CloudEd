using System;
using System.Collections.Generic;
using System.Text;
using CloudEd.DAL.Repositories;
using CloudEd.DAL.Persistence;
using System.Linq;

namespace CloudEd.Tests.Mocks
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        private IList<TEntity> _list = new List<TEntity>();

        public Guid Add(TEntity item)
        {
            item.Id = Guid.NewGuid();
            _list.Add(item);
            return item.Id;
        }

        public void Delete(TEntity item)
        {
            _list = _list.Where(e => e.Id != item.Id).ToList();
        }

        public void Delete(Guid Id)
        {
            _list = _list.Where(e => e.Id != Id).ToList();
        }

        public TEntity Get(Guid Id)
        {
            return _list.First(e => e.Id == Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            TEntity[] arr = new TEntity[_list.Count];
            _list.CopyTo(arr, 0);
            return arr;
        }

        public TEntity Save(TEntity item)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].Id == item.Id)
                {
                    _list[i] = item;
                    break;
                }
            }
            return item;
        }
    }
}
