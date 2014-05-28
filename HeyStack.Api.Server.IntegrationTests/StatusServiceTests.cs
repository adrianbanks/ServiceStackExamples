using HeyStack.ServiceModel.Status;
using Moq;
using NUnit.Framework;
using ServiceStack;
using Shouldly;

namespace HeyStack.Api.Server.IntegrationTests
{
    public class StatusServiceTests
    {
        private const string TestServiceUrl = "http://localhost:1337/";

        private Mock<IHost> mockHost;
        private Mock<IClock> mockClock;

        private TestableAppHost host;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            mockHost = new Mock<IHost>();
            mockClock = new Mock<IClock>();
            host = new TestableAppHost(container =>
            {
                container.Register(mockHost.Object);
                container.Register(mockClock.Object);
            });
            host.Init();
            host.Start(TestServiceUrl);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            host.Stop();
        }

        [Test]
        public void StatusService_ReturnsHostNameViaJson()
        {
            mockHost.Setup(h => h.MachineName).Returns("TESTHOST");
            var client = new JsonServiceClient(TestServiceUrl);
            var status = client.Get<StatusResultDto>(new GetStatusDto());
            status.Status.ShouldStartWith("TESTHOST");
        }

        [Test]
        public void StatusService_ReturnsHostNameViaXml()
        {
            mockHost.Setup(h => h.MachineName).Returns("TESTHOST");
            var client = new XmlServiceClient(TestServiceUrl);
            var status = client.Get<StatusResultDto>(new GetStatusDto());
            status.Status.ShouldStartWith("TESTHOST");
        }
    }
}
