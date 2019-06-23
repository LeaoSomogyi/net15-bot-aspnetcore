using SimpleBotCore.Contracts;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        private readonly ISimpleDatabaseContext<SimpleMessage> _context;

        public SimpleBotUser(ISimpleDatabaseContext<SimpleMessage> context)
        {
            _context = context;
        }

        public string Reply(SimpleMessage message)
        {
            _context.Insert(message);

            

            int count = _context.CountMessages(message.Id);

            string _message = $"{message.User} disse '{message.Text}' ({count} mensagen(s) enviada(s))";

            return _message;
        }
    }
}