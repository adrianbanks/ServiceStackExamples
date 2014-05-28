using System;

namespace HeyStack.Api.Server
{
    public interface IHost
    {
        string MachineName { get; }
    }

    public class Host : IHost
    {
        public string MachineName { get { return Environment.MachineName; }}
    }
}
