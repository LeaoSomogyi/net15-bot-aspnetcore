using MongoDB.Bson;

namespace SimpleBotCore.Contracts
{
    public interface ISimpleMongoContext<T>
    {
        void Insert(T document);

        int CountMessages(BsonDocument filter);
    }
}
