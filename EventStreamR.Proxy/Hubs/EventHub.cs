using AutoMapper;
using EventStreamR.Client.Core.Messages;
using EventStreamR.Server.Core.Persistence;
using EventStreamR.Server.Domain.Messages;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace EventStreamR.Proxy.Hubs
{
    public class EventHub : Hub
    {
        IEventPersistence RedisPersistence = new RedisEventPersistence();

        public void SendEvent(EventMessage message)
        {
			var eventMessageDto = Mapper.Map<EventMessage, EventMessageDto>(message);

            RedisPersistence.Store(eventMessageDto);
			Clients.All.eventReceived(eventMessageDto);
        }
    }
}
