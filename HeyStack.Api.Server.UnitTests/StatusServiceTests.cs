using System;
using HeyStack.Api.Server.Services;
using HeyStack.ServiceModel.Status;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace HeyStack.Api.Server.UnitTests
{
    public class StatusServiceTests
    {
        [Test]
        public void StatusService_ReturnsHostName()
        {
            var mockHost = new Mock<IHost>();
            mockHost.Setup(h => h.MachineName).Returns("TESTHOST");
            var mockClock = new Mock<IClock>();
            var service = new StatusService(mockHost.Object, mockClock.Object);
            var result = service.Get(new GetStatusDto());
            result.Status.ShouldStartWith("TESTHOST at ");
        }
    
        [Test]
        public void StatusService_ReturnsTime()
        {
            var mockHost = new Mock<IHost>();
            var mockClock = new Mock<IClock>();
            var dateTime = new DateTime(2014, 5, 28, 13, 30, 0);
            mockClock.Setup(c => c.Now).Returns(dateTime);
            var service = new StatusService(mockHost.Object, mockClock.Object);
            var result = service.Get(new GetStatusDto());
            result.Status.ShouldEndWith(dateTime + " is OK");
        }
    }
}
