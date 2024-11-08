using Redis.OM;
using RedisLearn.Models;

namespace RedisLearn.Services;

public class IndexCreationService(RedisConnectionProvider provider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await provider.Connection.CreateIndexAsync(typeof(Person));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}