﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using tombola.eventstreamer.core.Messages;

namespace tombola.eventstreamer.core
{
	internal static class SignalRProxyConnection
	{
		private static bool connected;
		private static Object connectionLock = new Object();
		private static IHubProxy proxy;
		private static HubConnection hubConnection;
		private static string connectionUrl = ConfigurationManager.AppSettings["SignalRDashboardUrl"];

		public static void Send(string key, string value)
		{
			// locking this operation so that it's thread safe
			lock (connectionLock)
			{
				if (!connected)
				{
					Connect();
				}

				if (hubConnection.State == ConnectionState.Connected)
					proxy.Invoke("SendEvent", new EventMessage{Key = key, Value = value});
				else
				{
					Connect();
					proxy.Invoke("SendEvent", new EventMessage { Key = key, Value = value });
				}
			}
		}

		private static void Connect()
		{
			hubConnection = new HubConnection(connectionUrl);
			proxy = hubConnection.CreateHubProxy("EventHub");
			hubConnection.Start().Wait();
			connected = true;
		}
	}
}
