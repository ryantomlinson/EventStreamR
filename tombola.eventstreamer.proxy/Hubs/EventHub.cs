using Microsoft.AspNet.SignalR;
using tombola.eventstreamer.core.Messages;
using tombola.eventstreamer.core.Persistence;

namespace tombola.eventstreamer.proxy.Hubs
{
    public class EventHub : Hub
    {
        public void SendEvent(EventMessage message)
        {
            IEventPersistence redisPersistence = new RedisEventPersistence();
            redisPersistence.Store(message);
            Clients.All.addMessage(message);
        }

        public void IncrementEventCount(string key)
        {
            IEventPersistence redisPersistence = new RedisEventPersistence();
            redisPersistence.Increment(key);
        }
    }
}
