using SimpleBotCore.Logic;

namespace SimpleBotCore.Contracts
{
    public interface ISimpleMessageRepository
    {
        void Insert<T>(T entity) where T : SimpleMessage;

        int CountMessages(string id);
    }
}
