using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MongoUrl u = MongoUrl.Create("mongodb://mi:mi@ds151060.mlab.com:51060");

            var client = new MongoClient(u);
            var db = client.GetDatabase("cloud_educational_system");
            var collection = db.GetCollection<Question>("questions");
            

            Question q = new Question() {
                Title = "What is love?",
                Answers =
                {
                    ["Dont hurt me"]=true,
                    ["No more!"]= false
                        }
            };
            collection.InsertOne(q);
            var bson = q.ToBsonDocument();
            Console.WriteLine(bson);
        }
    }
}