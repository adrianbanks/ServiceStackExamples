using System;
using ServiceStack;

namespace HeyStack.Api.Server.Services
{
    public class StatusService : Service
    {
        public StatusResultDto Get(GetStatusDto request)
        {
            var message = string.Format("{0} at {1} is OK", Environment.MachineName, DateTime.Now);
            return new StatusResultDto {Status = message};
        }
    }
}
