using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Cache.Sample.Services.MemoryCache
{
    public class MemoryCacheService : IMemoryCacheService
    {
        private IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
                
        public T GetValue<T>(string key)
        {
            if (_memoryCache.TryGetValue(key, out T cacheEntry))
            {
                return cacheEntry;
            }

            return default;
        }
                
        public void RemoveValue(string key)
        {
            _memoryCache.Remove(key);
        }
        
        public void SetValue<T>(string key, T value)
        {
            _memoryCache.Set(key, value);
        }
        
        public void SetValue<T>(string key, T value, TimeSpan expirationTimeSpan)
        {
            _memoryCache.Set(key, value, expirationTimeSpan);
        }
    }
}
