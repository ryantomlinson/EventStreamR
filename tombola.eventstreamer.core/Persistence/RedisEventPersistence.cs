using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System.Collections.Generic;
using tombola.eventstreamer.core.Messages;

namespace tombola.eventstreamer.core.Persistence
{
	public class RedisEventPersistence : IEventPersistence
	{
		public void Store(EventMessage message)
		{
			using (var redisClient = new RedisClient())
			{
				IRedisTypedClient<EventMessage> redis = redisClient.As<EventMessage>();

				var eventMessages = redis.Lists["urn:events:current"];
				eventMessages.Add(message);
			}
		}

        public void Increment(string key)
        {
            string eventKey = string.Format("urn:eventcounts:{0}", key);

            using (var redisClient = new RedisClient())
            {
                redisClient.Increment(eventKey, 1);
            }
        }

        public IDictionary<string, uint> GetIncrementValues(IEnumerable<string> keys)
        {
            Dictionary<string, string> convertedKeys = new Dictionary<string, string>();
            foreach (string key in keys)
            {
                convertedKeys.Add(key, string.Format("urn:eventcounts:{0}", key));
            }

            IDictionary<string, uint> redisReturnValues = null;
            using (var redisClient = new RedisClient())
            {
                redisReturnValues = redisClient.GetAll<uint>(convertedKeys.Values);
            }

            Dictionary<string, uint> returnValues = new Dictionary<string, uint>();
            if (redisReturnValues != null)
            {
                foreach(KeyValuePair<string, string> kvp in convertedKeys)
                {
                    if (redisReturnValues.ContainsKey(kvp.Value))
                    {
                        returnValues.Add(kvp.Key, redisReturnValues[kvp.Value]);
                    }
                }
            }

            return returnValues;
        }
		 
	}
}