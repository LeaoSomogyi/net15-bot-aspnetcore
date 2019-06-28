using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleBotCore.Context;
using SimpleBotCore.Contracts;
using SimpleBotCore.Logic;

namespace SimpleBotCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region "  MongoDB Connection Settings and Singletons  "

            //MongoConnectionSettings settings = new MongoConnectionSettings();
            //Configuration.Bind("MongoConnectionSettings", settings);

            //SimpleMongoContext<SimpleMessage> dataContext = new SimpleMongoContext<SimpleMessage>(settings);

            //services.AddSingleton<ISimpleMongoContext<SimpleMessage>>(dataContext);

            #endregion

            #region "  SQL Server Connection Settings and Singletons  "

            //SQLServerConnectionSettings settings = new SQLServerConnectionSettings();
            //Configuration.Bind("SQLServerConnectionSettings", settings);

            //ISimpleMessageRepository repo = new SimpleMessageRepository(settings);
            //ISimpleSQLServerContext<SimpleMessage> dataContext = new SimpleSQLServerContext<SimpleMessage>(repo);

            //services.AddSingleton(repo);
            //services.AddSingleton(dataContext);

            #endregion

            #region "  ElasticSearch Connection Settings and Singletons  "

            ElasticSearchConnectionSettings settings = new ElasticSearchConnectionSettings();
            Configuration.Bind("ElasticSearchConnectionSettings", settings);

            ISimpleElasticSearchContext<SimpleMessage> dataContext = new SimpleElasticSearchContext(settings);

            services.AddSingleton(dataContext);

            #endregion

            services.AddSingleton(new SimpleBotUser(dataContext));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
