using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tombola.eventstreamer.core;

namespace ExampleClients.ConsoleEventGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("firing event");
                EventStreamer.Streamer.Send("ryan", "test");
                EventStreamer.Streamer.Increment("incrementtest");
                Thread.Sleep(5000);
            }
        }
    }
}
