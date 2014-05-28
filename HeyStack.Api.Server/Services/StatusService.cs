using HeyStack.ServiceModel.Status;
using ServiceStack;

namespace HeyStack.Api.Server.Services
{
    public class StatusService : Service
    {
        private readonly IHost host;
        private readonly IClock clock;

        public StatusService(IHost host, IClock clock)
        {
            this.host = host;
            this.clock = clock;
        }

        public StatusResultDto Get(GetStatusDto request)
        {
            var message = string.Format("{0} at {1} is OK", host.MachineName, clock.Now);
            return new StatusResultDto {Status = message};
        }
    }
}
