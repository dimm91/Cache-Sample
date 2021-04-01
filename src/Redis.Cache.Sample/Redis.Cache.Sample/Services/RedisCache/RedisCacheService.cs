using Redis.Cache.Sample.Services.MemoryCache;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Cache.Sample.Services.RedisCache
{
    public class RedisCacheService //: IMemoryCacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }
        public T GetValue<T>(string key)
        {
            var rDatabse = _connectionMultiplexer.GetDatabase();
            rDatabse.StringGet("");
            rDatabse.KeyDelete("");
            throw new NotImplementedException();
        }

        public void RemoveValue(string key)
        {
            throw new NotImplementedException();
        }

        public void SetValue<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public void SetValue<T>(string key, T value, TimeSpan expirationTimeSpan)
        {
            throw new NotImplementedException();
        }
    }
}
