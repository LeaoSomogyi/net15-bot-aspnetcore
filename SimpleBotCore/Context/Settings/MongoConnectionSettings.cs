namespace SimpleBotCore.Context
{
    public class MongoConnectionSettings : BaseConnectionSettings
    {
        public string Database { get; set; }

        public string Collection { get; set; }
    }
}
