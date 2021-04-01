using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Redis.Cache.Subscriber.Sample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public Worker(ILogger<Worker> logger, IConnectionMultiplexer connectionMultiplexer)
        {
            _logger = logger;
            _connectionMultiplexer = connectionMultiplexer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subscriber = _connectionMultiplexer.GetSubscriber();
            return subscriber.SubscribeAsync("channelName", (redisChannel, redisValue) =>
            {
                _logger.LogInformation($"Message received at {DateTime.UtcNow}");
                _logger.LogInformation($"\tMessage content: {redisValue}");
            });
        }
    }
}
