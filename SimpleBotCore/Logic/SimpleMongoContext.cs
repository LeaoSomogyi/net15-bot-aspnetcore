using MongoDB.Driver;
using MongoDB.Bson;

namespace SimpleBotCore.Logic
{
    public class SimpleMongoContext
    {
        private MongoClient MongoClient;
        private IMongoDatabase MongoDatabase;
        private IMongoCollection<SimpleMessage> MongoCollection;

        public SimpleMongoContext(string database, string collection)
        {
            MongoClient = new MongoClient();
            MongoDatabase = MongoClient.GetDatabase(database);
            MongoCollection = MongoDatabase.GetCollection<SimpleMessage>(collection);
        }

        public void Insert(SimpleMessage document)
        {
            MongoCollection.InsertOne(document);
        }

        public int CountMessages(BsonDocument filter)
        {
            return MongoCollection.Find(filter).ToList().Count;
        }
    }
}
