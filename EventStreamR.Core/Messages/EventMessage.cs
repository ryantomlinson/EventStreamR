using System;
using System.Collections.Generic;

namespace EventStreamR.Core.Messages
{
	public class EventMessage
	{
		public string Key { get; set; }
		public string Value { get; set; }

		private string message;
		private string source;
		private Severity severity;
		private List<string> tags;

		public EventMessage WithMessage(string message)
		{
			this.message = message;
			return this;
		}

		public EventMessage WithSeverity(Severity severity)
		{
			this.severity = severity;
			return this;
		}

		public EventMessage WithTags(string tags)
		{
			this.tags = new List<string>(tags.Split(' '));
			return this;
		}

		public EventMessage WithSource(string source)
		{
			this.source = source;
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