using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tombola.eventstreamer.core;

namespace ConsoleEventGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnection("http://localhost:9999");
            IHubProxy myHub = connection.CreateHubProxy("RecordStatsHub");

            connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }).Wait();



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
