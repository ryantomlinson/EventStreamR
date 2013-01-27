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

                if (i % 2 == 0)
                {
                    EventStreamer.Instance.Increment("incrementtest2");
                }
                if (i % 3 == 0)
                {
                    EventStreamer.Instance.Increment("incrementtest3");
                }
                if (i % 4 == 0)
                {
                    EventStreamer.Instance.Increment("incrementtest4");
                }
                if (i % 5 == 0)
                {
                    EventStreamer.Instance.Increment("incrementtest5");
                }
                Thread.Sleep(900);
            }
        }
    }
}
