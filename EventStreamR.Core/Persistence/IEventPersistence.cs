using System.Collections.Generic;
using EventStreamR.Core.Messages;

namespace EventStreamR.Core.Persistence
{
	public interface IEventPersistence
	{
		void Store(EventMessage message);
        void Increment(string key);
        IDictionary<string, uint> GetIncrementValues(IEnumerable<string> keys);
	}
}