using System.Collections.Generic;
using EventStreamR.Client.Core.Messages;

namespace EventStreamR.Server.Domain.Messages
{
	public class EventMessageDto
	{
		public string Message { get; set; }
		public string Source { get; set; }
		public Severity Severity { get; set; }
		public List<string> Tags { get; set; }
	}
}