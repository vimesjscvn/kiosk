using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace CS.Common.Caching
{
    public class MemoryCache : ICacheService
    {
        private readonly IMemoryCache _cache;

        public MemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key, Func<T> func, TimeSpan? timeout = null)
        {
            if (timeout == null) timeout = TimeSpan.FromMinutes(10);
            return _cache.GetOrCreate(key, cacheEntry =>
            {
                cacheEntry.AbsoluteExpiration = DateTime.Now.Add(timeout.Value);
                cacheEntry.Priority = CacheItemPriority.High;
                return func();
            });
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> func, TimeSpan? timeout = null)
        {
            if (timeout == null) timeout = TimeSpan.FromMinutes(10);
            return await _cache.GetOrCreate(key, cacheEntry =>
            {
                cacheEntry.AbsoluteExpiration = DateTime.Now.Add(timeout.Value);
                cacheEntry.Priority = CacheItemPriority.High;
                return func();
            });
        }
    }
}