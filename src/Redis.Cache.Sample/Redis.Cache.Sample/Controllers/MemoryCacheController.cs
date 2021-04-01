using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redis.Cache.Sample.Services.MemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Cache.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryCacheController : ControllerBase
    {
        private readonly IMemoryCacheService _memoryCacheService;
        public MemoryCacheController(IMemoryCacheService memoryCacheService)
        {
            _memoryCacheService = memoryCacheService ?? throw new ArgumentNullException(nameof(memoryCacheService));
        }

        [HttpPost("{key}")]
        public async Task<ActionResult> AddCacheVAlue(string key, [FromBody] string value)
        {
            await _memoryCacheService.SetValue(key, value);
            return Ok();
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<string>> GetCacheValue(string key)
        {
            return Ok(await _memoryCacheService.GetValue<string>(key));
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult<string>> DeleteCacheValue(string key)
        {
            await _memoryCacheService.RemoveValue(key);
            return Ok();
        }
    }
}
