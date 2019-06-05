
namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            return $"{message.User} disse '{message.Text}'";
        }
    }
}