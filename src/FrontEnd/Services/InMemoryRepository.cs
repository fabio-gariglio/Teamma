using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrontEnd.Services
{
    public class InMemoryRepository<TKey, TValue> : IRepository<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _cache;

        public InMemoryRepository()
        {
            _cache = new ConcurrentDictionary<TKey, TValue>();
        }
        
        public Task Save(TKey key, TValue value)
        {
            _cache[key] = value;

            return Task.CompletedTask;
        }

        public Task<TValue> Get(TKey key)
        {
            var result = _cache.TryGetValue(key, out var value)
                ? value
                : default(TValue);

            return Task.FromResult(result);
        }
    }
}