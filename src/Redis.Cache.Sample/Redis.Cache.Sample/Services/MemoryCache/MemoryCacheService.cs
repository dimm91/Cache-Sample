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
                
        public Task<T> GetValue<T>(string key)
        {
            if (_memoryCache.TryGetValue(key, out T cacheEntry))
            {
                return Task.FromResult(cacheEntry);
            }
            
            return Task.FromResult<T>(default);
        }
                
        public Task RemoveValue(string key)
        {
            _memoryCache.Remove(key);
            return Task.CompletedTask;
        }
        
        public Task SetValue<T>(string key, T value)
        {
            _memoryCache.Set(key, value);
            return Task.CompletedTask;
        }
        
        public Task SetValue<T>(string key, T value, TimeSpan expirationTimeSpan)
        {
            _memoryCache.Set(key, value, expirationTimeSpan);
            return Task.CompletedTask;
        }
    }
}
