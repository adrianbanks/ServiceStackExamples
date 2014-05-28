using System;
using HeyStack.ServiceModel.Status;
using ServiceStack;

namespace HeyStack.DemoApp
{
    internal class Program
    {
        private const string ServiceUrl = "http://localhost:57910";

        internal static void Main(string[] args)
        {
            var client = new JsonServiceClient(ServiceUrl);
            Console.WriteLine("Receiving status from {0}", ServiceUrl);
            var status = client.Get<StatusResultDto>(new GetStatusDto());
            Console.WriteLine(status.Status);
            Console.ReadLine();
        }
    }
}
