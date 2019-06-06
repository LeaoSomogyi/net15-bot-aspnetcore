using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimpleBotCore.Logic
{
    [BsonNoId]
    [BsonIgnoreExtraElements]
    public class SimpleMessage
    {   
        public string Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }

        public SimpleMessage(string id, string username, string text)
        {
            Id = id;
            User = username;
            Text = text;
        }
    }
}