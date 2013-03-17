using EventStreamR.Server.Core.Persistence;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStreamR.Proxy.PersistantConnections
{
    public class EventIncrementPersistantConnection : PersistentConnection 
    {
        IEventPersistence RedisPersistence = new RedisBooksleevePersistence();

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            IncrementalKeyStore.Instance.AddKeyNameIfNeeded(data);
            RedisPersistence.Increment(data);
            return base.OnReceived(request, connectionId, data);
        }
    }
}
