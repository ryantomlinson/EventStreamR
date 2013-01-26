using System.Collections.Generic;

namespace tombola.eventstreamer.core.Messages
{
    public class EventCountMessage
    {
        //note: look to see if we can send a dictionary over signalr
        public IEnumerable<EventCountInformation> Items { get; set; }

        public EventCountMessage(IEnumerable<KeyValuePair<string, uint>> items)
        {
            List<EventCountInformation> eventInfoList = new List<EventCountInformation>();
            foreach (KeyValuePair<string, uint> item in items)
            {
                eventInfoList.Add(new EventCountInformation() { Key = item.Key, Count = item.Value});
            }
            Items = eventInfoList;
        }
    }

    public class EventCountInformation
    {
        public string Key { get; set; }
        public uint Count { get; set; }
    }
}
