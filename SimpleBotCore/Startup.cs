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
            MongoConnectionSettings settings = new MongoConnectionSettings();
            Configuration.Bind("MongoConnectionSettings", settings);

            SimpleMongoContext<SimpleMessage> dataContext = new SimpleMongoContext<SimpleMessage>(settings);

            services.AddSingleton<ISimpleMongoContext<SimpleMessage>>(dataContext);
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
