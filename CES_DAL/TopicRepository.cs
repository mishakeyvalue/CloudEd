using CES_DAL.Enteties;
using CES_DAL.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace CES_DAL
{
    public class TopicRepository : IRepository<Topic>
    {
        private static List<Topic> _collection              = new List<Topic>();
        private static IMongoCollection<BsonDocument> _mongo_c;

        public static IRepository<Topic> GetRepo()
        {
            return new TopicRepository();
        }

        private TopicRepository()
        {

            string connection_string = "mongodb://admin:miDB123@ds151060.mlab.com:51060/cloud_educational_system";
            var client = new MongoClient(connection_string);
            var db = client.GetDatabase("Topic");
            _mongo_c = db.GetCollection<BsonDocument>("Topics");
            
        }

        public void Add(Topic item)
        {
            _collection.Add(item);
        }

        public Topic Get(string _id)
        {
            return _collection.Find((t) => t.TopicTitle == _id);
        }

        public System.Collections.Generic.IEnumerable<Topic> GetAll()
        {
            return _collection;
        }


    }
}
