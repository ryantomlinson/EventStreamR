﻿using Microsoft.AspNet.SignalR;
using tombola.eventstreamer.core.Messages;

namespace tombola.eventstreamer.proxy.Hubs
{
    public class EventViewerHub : Hub
    {
        public void EventCountNotifyEventViewers(EventCountMessage eventCounts)
        {
            Clients.All.eventCountMessageReceived(eventCounts.Items);
        }
    }
}
