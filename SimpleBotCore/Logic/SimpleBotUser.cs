using MongoDB.Bson;
using SimpleBotCore.Contracts;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        private readonly ISimpleMongoContext<SimpleMessage> _context;

        public SimpleBotUser(ISimpleMongoContext<SimpleMessage> context)
        {
            _context = context;
        }

        public string Reply(SimpleMessage message)
        {
            _context.Insert(message);

            BsonDocument filter = new BsonDocument() { { "Id", message.Id } };

            int count = _context.CountMessages(filter);

            string _message = $"{message.User} disse '{message.Text}' ({count} mensagen(s) enviada(s))";

            return _message;
        }
    }
}