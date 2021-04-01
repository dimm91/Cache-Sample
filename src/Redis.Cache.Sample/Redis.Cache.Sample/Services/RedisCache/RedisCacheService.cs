using Redis.Cache.Sample.Services.Base;
using Redis.Cache.Sample.Services.MemoryCache;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Redis.Cache.Sample.Services.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<T> GetValue<T>(string key)
        {
            var rDatabse = _connectionMultiplexer.GetDatabase();

            var stringValue = await rDatabse.StringGetAsync(key);

            if (stringValue.IsNullOrEmpty || !stringValue.HasValue)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(stringValue);
        }

        public async Task RemoveValue(string key)
        {
            var rDatabse = _connectionMultiplexer.GetDatabase();

            if (rDatabse.KeyExists(key) && !await rDatabse.KeyDeleteAsync(key))
            {
                //Shoul be logged or apply resilience 
                throw new Exception($"Cannot delete value with key '{key}' in database");
            }
        }

        public async Task SetValue<T>(string key, T value)
        {
            var rDatabse = _connectionMultiplexer.GetDatabase();

            if (!rDatabse.StringSet(key, JsonSerializer.Serialize(value)))
            {
                //Shoul be logged or apply resilience 
                throw new Exception("Cannot insert value in database");
            }
        }

        public async Task SetValue<T>(string key, T value, TimeSpan expirationTimeSpan)
        {
            var rDatabse = _connectionMultiplexer.GetDatabase();

            await rDatabse.StringSetAsync(key, JsonSerializer.Serialize(value), expirationTimeSpan);
        }

        public async Task PublishMessage(string message)
        {
            var rDatabse = _connectionMultiplexer.GetDatabase();
            await rDatabse.PublishAsync("channelName", message);
        }
    }
}
