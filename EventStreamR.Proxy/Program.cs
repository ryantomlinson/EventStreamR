using System;
using EventStreamR.Server.Domain.Mapping;
using Microsoft.Owin.Hosting;
using Owin;
using System.Threading;
using EventStreamR.Proxy.Processing;

namespace EventStreamR.Proxy
{
	class Program
	{
		static void Main(string[] args)
		{
			string url = "http://localhost:8082";

			ObjectMapping.Configure();

			using (WebApplication.Start<Startup>(url))
			{
                TimerCallback timeCB = new TimerCallback(ProcessStats);
                Timer t = new Timer(
                    timeCB, // The TimerCallback delegate object.
                    null, // Any info to pass into the called method (null for no info).
                    1000, // Amount of time to wait before starting (in milliseconds).
                    2500 // Interval of time between calls (in milliseconds).
                 ); 

				Console.WriteLine("Server running on {0}", url);
				Console.ReadLine();
			}
		}


        private static void ProcessStats(object state)
        {
            Console.WriteLine("Processing");
            new AggregateEventCounts().SendCounts();
        }
	}

	class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapHubs();
		}
	}
}
