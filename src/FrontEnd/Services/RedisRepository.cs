using System.Threading.Tasks;
using FrontEnd.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace FrontEnd.Services
{
    public class RedisRepository<TKey, TValue> : IRepository<TKey, TValue>
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisRepository(IOptions<RedisOptions> redisOptionsAccessor)
        {
            var redisOption = redisOptionsAccessor.Value;
            _connectionMultiplexer = ConnectionMultiplexer.Connect(redisOption.HostName);
        }
        
        public Task Save(TKey key, TValue value)
        {
           var database = _connectionMultiplexer.GetDatabase();
           
           return database.StringSetAsync(key.ToString(), JsonConvert.SerializeObject(value));
        }

        public async Task<TValue> Get(TKey key)
        {
            var database = _connectionMultiplexer.GetDatabase();
            var value = await database.StringGetAsync(key.ToString());

            return !string.IsNullOrEmpty(value)
                ? JsonConvert.DeserializeObject<TValue>(value)
                : default(TValue);
        }
    }
}