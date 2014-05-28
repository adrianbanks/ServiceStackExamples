﻿using System;
using System.Web;
using Funq;
using ServiceStack;

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
                container.Register<IHost>(c => new Host());
                container.Register<IClock>(c => new Clock());
            }
        }
   }
}
