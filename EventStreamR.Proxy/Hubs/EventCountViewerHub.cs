using EventStreamR.Client.Core.Messages;
using Microsoft.AspNet.SignalR;

namespace EventStreamR.Proxy.Hubs
{
    public class EventCountViewerHub : Hub
    {
        public void EventCountNotifyEventViewers(EventCountMessage eventCounts)
        {
            Clients.All.eventCountMessageReceived(eventCounts.Items);
        }
    }
}
