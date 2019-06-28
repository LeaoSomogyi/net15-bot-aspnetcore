using Nest;
using SimpleBotCore.Contracts;
using SimpleBotCore.Logic;

namespace SimpleBotCore.Context
{
    public class SimpleElasticSearchContext : ISimpleElasticSearchContext<SimpleMessage>
    {
        private readonly ElasticClient ElasticClient;

        public SimpleElasticSearchContext(ElasticSearchConnectionSettings settings)
        {
            ConnectionSettings config = new ConnectionSettings(new System.Uri(settings.ConnectionString))
                .DefaultIndex("Id");

            ElasticClient = new ElasticClient(config);
        }

        public int CountMessages(string id)
        {
            ISearchResponse<SimpleMessage> search = ElasticClient.Search<SimpleMessage>(s => s
                .From(0)
                .Query(q => q
                     .Term(p => p.Id, id)
                )
            );

            return search.Documents.Count;
        }

        public void Insert(SimpleMessage entity)
        {
            ElasticClient.Index(entity, i => i.Id(entity.Id));
        }
    }
}
