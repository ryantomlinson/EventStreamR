using System.Collections.Generic;

namespace tombola.eventstreamer.core.Messages
{
    public class EventCountMessage
    {
        //note: look to see if we can send a dictionary over signalr
        public IEnumerable<KeyValuePair<string, int>> Items { get; set; }

        public EventCountMessage(IEnumerable<KeyValuePair<string, int>> items)
        {
            Items = items;
        }
    }
}
