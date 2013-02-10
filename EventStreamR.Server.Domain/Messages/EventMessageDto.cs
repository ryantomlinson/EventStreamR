using EventStreamR.Client.Core.Messages;
using System;
using System.Collections.Generic;

namespace EventStreamR.Server.Domain.Messages
{
	public class EventMessageDto
	{
		public string Message { get; set; }
		public string Source { get; set; }
		public Severity Severity { get; set; }
		public List<string> Tags { get; set; }
        public DateTime CreatedAt { get; set; }
	}
}