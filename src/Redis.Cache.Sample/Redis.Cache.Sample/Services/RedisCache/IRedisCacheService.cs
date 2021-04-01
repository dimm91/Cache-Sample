using Redis.Cache.Sample.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Cache.Sample.Services.RedisCache
{
    public interface IRedisCacheService : IBaseCacheService
    {
        Task PublishMessage(string message);
    }
}
