using EventStreamR.Core.Messages;
using EventStreamR.Core.Persistence;
using Microsoft.AspNet.SignalR;

namespace EventStreamR.Proxy.Hubs
{
    public class EventHub : Hub
    {
        public void SendEvent(EventMessage message)
        {
            IEventPersistence redisPersistence = new RedisEventPersistence();
            redisPersistence.Store(message);
            Clients.All.eventReceived(message);
        }

        public void IncrementEventCount(string key)
        {
            IEventPersistence redisPersistence = new RedisEventPersistence();
            IncrementalKeyStore.Instance.AddKeyNameIfNeeded(key);
            redisPersistence.Increment(key);
        }
    }
}
