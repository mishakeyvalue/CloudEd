using CES_BLL;
using CES_BLL.Interfaces;
using System;
using System.Collections.Generic;

namespace CES_DAL
{
    public class TopicRepository : IRepository<Topic>
    {
        private static List<Topic> _collection = new List<Topic>();

        public static IRepository<Topic> GetRepo()
        {
            return new TopicRepository();
        }

        private TopicRepository()
        {

        }

        public void Add(Topic item)
        {
            _collection.Add(item);
        }

        public Topic Get(int id)
        {
            try {
            return _collection[id];
            }
            catch (Exception) {

                return null;
            }
        }

        public System.Collections.Generic.IEnumerable<Topic> GetAll()
        {
            return _collection;
        }
    }
}
