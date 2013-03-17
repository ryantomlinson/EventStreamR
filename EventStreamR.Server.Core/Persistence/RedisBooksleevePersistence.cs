using BookSleeve;
using EventStreamR.Server.Domain.Messages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStreamR.Server.Core.Persistence
{
    public class RedisBooksleevePersistence : IEventPersistence
    {
        private static RedisConnection conn;

        public RedisBooksleevePersistence()
        {
            if (conn == null)
            {
                conn = GetRedisConnection("localhost").Result;
            }
        }

        private static async Task<RedisConnection> GetRedisConnection(string host)
        {
            RedisConnection c = new RedisConnection(host);
            await c.Open();
            return c;

        }

        public void Store(EventMessageDto message)
        {
            string stringRepresentation = JsonConvert.SerializeObject(message);
            conn.Lists.AddLast(0, "urn:events:current", stringRepresentation);
        }

        public void Increment(string key)
        {
            string eventKey = string.Format("urn:eventcounts:{0}", key);
            conn.Strings.Increment(0, eventKey);
        }

        public IDictionary<string, long> GetIncrementValues(IEnumerable<string> keys)
        {
            return GetIncrementValuesAsync(keys).Result;
        }

        private async Task<IDictionary<string, long>> GetIncrementValuesAsync(IEnumerable<string> keys)
        {
            Dictionary<string, string> convertedKeys = new Dictionary<string, string>();
            foreach (string key in keys)
            {
                convertedKeys.Add(key, string.Format("urn:eventcounts:{0}", key));
            }

            IDictionary<string, long> redisReturnValues = new Dictionary<string, long>();
            string[] keyArray =  convertedKeys.Values.ToArray();

            byte[][] byteResults = await conn.Strings.Get(0, keyArray);
            //build up string array
            for (int i = 0; i < keyArray.Length; i++)
            {
                string stringVal = Encoding.UTF8.GetString(byteResults[i]);
                long lVal = 0;
                if (long.TryParse(stringVal, out lVal))
                {
                    redisReturnValues.Add(keyArray[i], lVal);
                }
            }

            Dictionary<string, long> returnValues = new Dictionary<string, long>();
            if (redisReturnValues != null)
            {
                foreach (KeyValuePair<string, string> kvp in convertedKeys)
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
