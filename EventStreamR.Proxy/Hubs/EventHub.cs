using AutoMapper;
using EventStreamR.Client.Core.Messages;
using EventStreamR.Server.Core.Persistence;
using EventStreamR.Server.Domain.Messages;
using Microsoft.AspNet.SignalR;

namespace EventStreamR.Proxy.Hubs
{
    public class EventHub : Hub
    {
        public void SendEvent(EventMessage message)
        {
            IEventPersistence redisPersistence = new RedisEventPersistence();

			var eventMessageDto = Mapper.Map<EventMessage, EventMessageDto>(message);

			redisPersistence.Store(eventMessageDto);
			Clients.All.eventReceived(eventMessageDto);
        }

        public void IncrementEventCount(string key)
        {
            IEventPersistence redisPersistence = new RedisEventPersistence();
            IncrementalKeyStore.Instance.AddKeyNameIfNeeded(key);
            redisPersistence.Increment(key);
        }
    }
}
