using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBotCore.Contracts;

namespace SimpleBotCore.Context
{
    public class SimpleMongoContext<T> : ISimpleMongoContext<T>
    {
        private readonly MongoClient MongoClient;
        private readonly IMongoDatabase MongoDatabase;
        private readonly IMongoCollection<T> MongoCollection;

        public SimpleMongoContext(MongoConnectionSettings settings)
        {
            MongoClient = new MongoClient(settings.ConnectionString);
            MongoDatabase = MongoClient.GetDatabase(settings.Database);
            MongoCollection = MongoDatabase.GetCollection<T>(settings.Collection);
        }

        public void Insert(T document)
        {
            MongoCollection.InsertOne(document);
        }

        public int CountMessages(string id)
        {
            BsonDocument filter = new BsonDocument() { { "Id", id } };

            return MongoCollection.Find(filter).ToList().Count;
        }
    }
}
