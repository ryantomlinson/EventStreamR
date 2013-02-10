using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using EventStreamR.Client.Core.Messages;

namespace EventStreamR.Client.Core
{
	internal static class SignalRProxyConnection
	{
		private static bool connected;
		private static Object connectionLock = new Object();
		private static IHubProxy proxy;
		private static HubConnection hubConnection;
        private static string connectionUrl = ConfigurationManager.AppSettings["SignalREventReceiverUrl"];
        private static Connection incrementPersistantConnection;

		public static void Send(EventMessage eventMessage)
		{
			// locking this operation so that it's thread safe
			lock (connectionLock)
			{
				if (!connected)
				{
                    ConnectEventHub();
				}

				if (hubConnection.State == ConnectionState.Connected)
					proxy.Invoke("SendEvent", eventMessage);
				else
				{
                    ConnectEventHub();
					proxy.Invoke("SendEvent", eventMessage);
				}
			}
		}

        //leaving this as a compleately seperate system to event sending for now
        public static void Increment(string key)
        {
            // locking this operation so that it's thread safe
            if (incrementPersistantConnection == null)
            {
                lock (connectionLock)
                {
                    Console.WriteLine("Creating new persistant connection");
                    incrementPersistantConnection = new Connection(connectionUrl + "events/increment");
                    incrementPersistantConnection.Start().Wait();
                }
            }

            incrementPersistantConnection.Send(key);
        }

		private static void ConnectEventHub()
		{
			hubConnection = new HubConnection(connectionUrl);
			proxy = hubConnection.CreateHubProxy("EventHub");
			hubConnection.Start().Wait();
			connected = true;
		}
	}
}
