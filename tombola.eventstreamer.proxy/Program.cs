using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using tombola.eventstreamer.core.Messages;
using tombola.eventstreamer.core.Persistence;

namespace tombola.eventstreamer.proxy
{
	class Program
	{
		static void Main(string[] args)
		{
			string url = "http://localhost:8082";

			using (WebApplication.Start<Startup>(url))
			{
				Console.WriteLine("Server running on {0}", url);
				Console.ReadLine();
			}
		}
	}
	class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapHubs();
		}
	}

	public class EventHub : Hub
	{
		public void SendEvent(EventMessage message)
		{
			IEventPersistence redisPersistence = new RedisEventPersistence();
			redisPersistence.Store(message);
			Clients.All.addMessage(message);
		}
	}
}
