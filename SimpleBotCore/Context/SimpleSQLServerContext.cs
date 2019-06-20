using SimpleBotCore.Contracts;
using SimpleBotCore.Logic;

namespace SimpleBotCore.Context
{
    public class SimpleSQLServerContext<T> : ISimpleSQLServerContext<T>
    {
        private readonly ISimpleMessageRepository _repository;

        public SimpleSQLServerContext(ISimpleMessageRepository repository)
        {
            _repository = repository;
        }

        public void Insert(T entity)
        {
            _repository.Insert<SimpleMessage>(entity as SimpleMessage);
        }

        public int CountMessages(string id)
        {
            return _repository.CountMessages(id);
        }
    }
}
