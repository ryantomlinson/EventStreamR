namespace tombola.eventstreamer.core
{
	public sealed class EventStreamer
	{
		EventStreamer(){}

		public static EventStreamer Streamer
		{
			get
			{
				return Nested.instance;
			}
		}

		public void Send(string key, string value)
		{
			SignalRProxyConnection.Send(key, value);
		}

        public void Increment(string key)
        {
            SignalRProxyConnection.Increment(key);
        }


		class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly EventStreamer instance = new EventStreamer();
		}
	}
}