using System.Collections.Generic;
using EventStreamR.Client.Core.Messages;
using EventStreamR.Server.Domain.Messages;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace EventStreamR.Server.Core.Persistence
{
	public class RedisEventPersistence : IEventPersistence
	{
        private static PooledRedisClientManager pooledClientManager = new PooledRedisClientManager();

		public void Store(EventMessageDto message)
		{
            using (var redisClient = pooledClientManager.GetClient())
			{
				IRedisTypedClient<EventMessageDto> redis = redisClient.As<EventMessageDto>();

				var eventMessages = redis.Lists["urn:events:current"];
				eventMessages.Add(message);
			}
		}

        public void Increment(string key)
        {
            string eventKey = string.Format("urn:eventcounts:{0}", key);

            using (var redisClient = pooledClientManager.GetClient())
            {
                redisClient.Increment(eventKey, 1);
            }
        }

        public IDictionary<string, long> GetIncrementValues(IEnumerable<string> keys)
        {
            Dictionary<string, string> convertedKeys = new Dictionary<string, string>();
            foreach (string key in keys)
            {
                convertedKeys.Add(key, string.Format("urn:eventcounts:{0}", key));
            }

            IDictionary<string, long> redisReturnValues = null;
            using (var redisClient = pooledClientManager.GetReadOnlyClient())
            {
                redisReturnValues = redisClient.GetAll<long>(convertedKeys.Values);
            }

            Dictionary<string, long> returnValues = new Dictionary<string, long>();
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