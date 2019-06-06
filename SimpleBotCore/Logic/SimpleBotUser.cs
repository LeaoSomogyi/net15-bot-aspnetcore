using MongoDB.Bson;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        SimpleMongoContext<SimpleMessage> _context = null;

        public SimpleBotUser()
        {
            _context = new SimpleMongoContext<SimpleMessage>();
        }

        public string Reply(SimpleMessage message)
        {
            _context.Insert(message);

            var filter = new BsonDocument() { { "Id", message.Id } };

            var count = _context.CountMessages(filter);

            var _message = $"{message.User} disse '{message.Text}' ({count} mensagen(s) enviada(s))";

            return _message;
        }
    }
}