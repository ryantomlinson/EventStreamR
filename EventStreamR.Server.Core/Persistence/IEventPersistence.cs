using System.Collections.Generic;
using EventStreamR.Server.Domain.Messages;

namespace EventStreamR.Server.Core.Persistence
{
	public interface IEventPersistence
	{
		void Store(EventMessageDto message);
        void Increment(string key);
        IDictionary<string, uint> GetIncrementValues(IEnumerable<string> keys);
	}
}