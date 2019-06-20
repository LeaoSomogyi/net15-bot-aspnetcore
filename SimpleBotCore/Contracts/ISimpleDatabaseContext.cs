namespace SimpleBotCore.Contracts
{
    public interface ISimpleDatabaseContext<T>
    {
        void Insert(T entity);

        int CountMessages(string id);
    }
}
