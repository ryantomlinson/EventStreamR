using System.Collections.Generic;
using EventStreamR.Server.Domain.Messages;

namespace EventStreamR.Server.Core.Persistence
{
	public interface IEventPersistence
	{
		void Store(EventMessageDto message);
        void Increment(string key);
        IDictionary<string, long> GetIncrementValues(IEnumerable<string> keys);
	}
}