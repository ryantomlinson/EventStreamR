using tombola.eventstreamer.core.Messages;

namespace tombola.eventstreamer.core.Persistence
{
	public interface IEventPersistence
	{
		void Store(EventMessage message);
	}
}