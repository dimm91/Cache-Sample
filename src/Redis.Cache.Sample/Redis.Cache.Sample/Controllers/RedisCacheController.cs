using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redis.Cache.Sample.Services.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Cache.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisCacheController : ControllerBase
    {
        private readonly IRedisCacheService _baseCacheService;
        public RedisCacheController(IRedisCacheService baseCacheService)
        {
            _baseCacheService = baseCacheService ?? throw new ArgumentNullException(nameof(baseCacheService));
        }

        [HttpPost("{key}")]
        public async Task<ActionResult> AddCacheVAlue(string key, [FromBody] string value)
        {
            await _baseCacheService.SetValue(key, value);
            return Ok();
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<string>> GetCacheValue(string key)
        {
            return Ok(await _baseCacheService.GetValue<string>(key));
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult<string>> DeleteCacheValue(string key)
        {
            await _baseCacheService.RemoveValue(key);
            return Ok();
        }

        [HttpPost("publish")]
        public async Task<ActionResult<string>> PublishCacheValue([FromBody] string message)
        {
            await _baseCacheService.PublishMessage(message);
            return Ok();
        }
    }
}
