using System;
using System.Threading;
using EventStreamR.Core;

namespace ExampleClients.ConsoleEventGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("firing event");
                EventStreamer.Instance.Send("ryan", "test");
                EventStreamer.Instance.Increment("incrementtest");
                Thread.Sleep(5000);
            }
        }
    }
}
