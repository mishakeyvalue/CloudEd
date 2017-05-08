using CES_DAL.Models;
using CES_DAL.Interfaces;

using System;
using System.Collections.Generic;
using System.IO;

namespace CES_DAL
{
    public class TopicRepository : IRepository<Topic>
    {
        public static IRepository<Topic> GetRepository()
        {
            return new TopicRepository();
        }

        private readonly string _configFile = "C:\\mongo.txt";
        private readonly string _db_name = "cloud_educational_system";
        private string _cStr;
        private TopicRepository()
        {
            _cStr = _loadConnectionString(_configFile); // Connection string
            _cStr = "mongodb://mi:mi@ds151060.mlab.com:51060/cloud_educational_system";


        }
        //private IMongoDatabase _getDataBase()
        //{
        //    var client = new MongoClient(_cStr);
            
        //    var res = client.ListDatabases();
        //    string j = res.ToJson();
        //    return  client.GetDatabase(_db_name);

        //}
        private string _loadConnectionString(string configFile)
        {
            return File.ReadAllText(configFile);
        }

        public async void Add(Topic item)
        {
         //   IMongoDatabase db = _getDataBase();
        //    db.CreateCollection("topics");
        ////    var collection = db.GetCollection<BsonDocument>("topics");

        //    await collection.InsertOneAsync(item.ToBsonDocument());
        }

        public Topic Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetAll()
        {
            throw new NotImplementedException();
        }


    }
}
