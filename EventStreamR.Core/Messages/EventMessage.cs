using System;
using System.Collections.Generic;

namespace EventStreamR.Client.Core.Messages
{
	public class EventMessage
	{
		public string Message { get; set; }
		public string Source { get; set; }
		public Severity Severity { get; set; }
		public List<string> Tags { get; set; }
        public DateTime CreatedAt { get; set; }

        public EventMessage()
        {
            CreatedAt = DateTime.Now;
        }

		public EventMessage WithMessage(string message)
		{
			this.Message = message;
			return this;
		}

		public EventMessage WithSource(string source)
		{
			this.Source = source;
			return this;
		}

		public EventMessage WithSeverity(Severity severity)
		{
			this.Severity = severity;
			return this;
		}

		public EventMessage WithTags(string tags)
		{
			this.Tags = new List<string>(tags.Split(' '));
			return this;
		}

		public void Send()
		{
			EventStreamer.Instance.Send(this);
		}
	}

	public enum Severity
	{
		Critical,
		UnhandledError,
		HandledError,
		Debug,
		Info
	}
}