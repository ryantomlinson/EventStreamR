using EventStreamR.Client.Core.Messages;
using EventStreamR.Server.Core.Persistence;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using EventStreamR.Proxy.Hubs;

namespace EventStreamR.Proxy.Processing
{
    public class AggregateEventCounts
    {
        public void SendCounts()
        {
            IEventPersistence redisPersistence = new RedisEventPersistence();
            HashSet<string> keyNames = IncrementalKeyStore.Instance.GetKeys();
            if (keyNames.Count > 0)
            {
                EventCountMessage message = new EventCountMessage(redisPersistence.GetIncrementValues(keyNames));
                var context = GlobalHost.ConnectionManager.GetHubContext<EventCountViewerHub>();
                context.Clients.All.eventCountMessageReceived(message);
            }
        }
    }
}
