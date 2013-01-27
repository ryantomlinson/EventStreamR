using System;
using System.Threading;
using EventStreamR.Client.Core;
using EventStreamR.Client.Core.Messages;

namespace ExampleClients.ConsoleEventGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("firing event");
				EventStreamer.Instance.CreateEvent()
										.WithMessage("Some kind of message")
										.WithSeverity(Severity.Critical)
										.WithTags("registration UK")
										.WithSource("web1")
										.Send();
                EventStreamer.Instance.Increment("incrementtest");
                Thread.Sleep(5000);
            }
        }
    }
}
