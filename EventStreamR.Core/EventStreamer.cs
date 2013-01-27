using System;

namespace EventStreamR.Core
{
    public sealed class EventStreamer
    {
        private static readonly Lazy<EventStreamer> lazy = new Lazy<EventStreamer>(() => new EventStreamer());

        public static EventStreamer Instance { get { return lazy.Value; } }

        private EventStreamer()
        {
        }

        public void Send(string key, string value)
        {
            SignalRProxyConnection.Send(key, value);
        }

        public void Increment(string key)
        {
            SignalRProxyConnection.Increment(key);
        }
    }
}