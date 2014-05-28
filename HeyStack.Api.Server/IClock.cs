using System;

namespace HeyStack.Api.Server
{
    public interface IClock
    {
        DateTime Now { get; } 
    }

    public class Clock : IClock
    {
        public DateTime Now { get { return DateTime.Now; }}
    }
}
