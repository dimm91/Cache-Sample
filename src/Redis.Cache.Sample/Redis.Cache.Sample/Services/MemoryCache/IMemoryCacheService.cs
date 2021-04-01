using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Cache.Sample.Services.MemoryCache
{
    public interface IMemoryCacheService
    {
        /// <summary>
        /// Get value with the specify key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetValue<T>(string key);

        /// <summary>
        /// Remove a value from the memory cache
        /// </summary>
        /// <param name="key"></param>
        void RemoveValue(string key);
        /// <summary>
        /// Set a value into the cache 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetValue<T>(string key, T value);
        /// <summary>
        /// Set a value into the cache with an experation timespan
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetValue<T>(string key, T value, TimeSpan expirationTimeSpan);
    }
}
