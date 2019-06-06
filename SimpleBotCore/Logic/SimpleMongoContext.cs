using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;

namespace SimpleBotCore.Logic
{
    public class SimpleMongoContext<T>
    {
        private MongoClient MongoClient;
        private IMongoDatabase MongoDatabase;
        private IMongoCollection<T> MongoCollection;

        public SimpleMongoContext()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var config = builder.Build();
            var conn = config["MongoDBConnectionString"];
            var database = config["MongoDBDatabase"];
            var collection = config["MongoDBCollection"];

            MongoClient = new MongoClient(conn);
            MongoDatabase = MongoClient.GetDatabase(database);
            MongoCollection = MongoDatabase.GetCollection<T>(collection);
        }

        public void Insert(T document)
        {
            MongoCollection.InsertOne(document);
        }

        public int CountMessages(BsonDocument filter)
        {
            return MongoCollection.Find(filter).ToList().Count;
        }
    }
}
