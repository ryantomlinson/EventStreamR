using System;
using EventStreamR.Core.Messages;

namespace EventStreamR.Core
{
    public sealed class EventStreamer
    {
        private static readonly Lazy<EventStreamer> lazy = new Lazy<EventStreamer>(() => new EventStreamer());

        public static EventStreamer Instance { get { return lazy.Value; } }

        private EventStreamer()
        {
        }

		internal void Send(EventMessage eventMessage)
		{
			SignalRProxyConnection.Send(eventMessage);
		}

		public EventMessage CreateEvent()
		{
			return new EventMessage();
		}

        public void Increment(string key)
        {
            SignalRProxyConnection.Increment(key);
        }
    }
}