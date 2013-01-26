using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
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
		 
	}
}