using MongoDB.Bson;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            var context = new SimpleMongoContext("FiapRobot", "messages");

            context.Insert(message);

            var filtro = new BsonDocument() { { "Id", message.Id } };

            var count = context.CountMessages(filtro);

            var _message = $"{message.User} disse '{message.Text}'({count} mensagens enviadas)";

            return _message;
        }
    }
}