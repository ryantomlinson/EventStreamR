﻿using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using tombola.eventstreamer.core.Messages;
using tombola.eventstreamer.core.Persistence;
using tombola.eventstreamer.proxy.Hubs;

namespace tombola.eventstreamer.proxy.Processing
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
