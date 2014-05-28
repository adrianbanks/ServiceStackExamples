using System;
using System.Configuration;
using System.Web;
using Funq;
using HeyStack.Api.Server.Data;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.OrmLite;

namespace HeyStack.Api.Server
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }

        public class AppHost : AppHostBase
        {
            public AppHost() 
                : base("HeyStack Demo", typeof(AppHost).Assembly)
            {}

            public override void Configure(Container container)
            {
                Plugins.Add(new SwaggerFeature());

                var connectionString = ConfigurationManager.ConnectionStrings["SharedInstance"].ConnectionString;
                var connectionFactory = new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider);
                container.Register<IMovieDatabase>(c => new SqlMovieDatabase(connectionFactory));

                container.Register<IHost>(c => new Host());
                container.Register<IClock>(c => new Clock());
            }
        }
    }
}
