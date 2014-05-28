using System;
using Funq;
using HeyStack.Api.Server.Services;
using ServiceStack;

namespace HeyStack.Api.Server.IntegrationTests
{
    public class TestableAppHost : AppSelfHostBase
    {
        private readonly Action<Container> configure;

        public TestableAppHost(Action<Container> configure) 
            : base("HeyStack Test Service", typeof(StatusService).Assembly)
        {
            this.configure = configure;
        }

        public override void Configure(Container container)
        {
            configure(container);
        }
    }
}
