using RedisTraining.Application.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace RedisTraining.Infrastructure.Redis
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _database;
        public RedisCacheService()
        {
            var connection = ConnectionMultiplexer.Connect(
                "localhost:6379");

            _database = connection.GetDatabase();
        }
        public Task SetAsync<T>(
            string key,
            T value,
            TimeSpan? expiry = null)
        {

            return _database.StringSetAsync(
                key,
                JsonSerializer.Serialize(value),
                expiry,
                When.Always);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);

            if (!value.HasValue)
            {
                return default;
            }

            var json = value.ToString();

            return JsonSerializer.Deserialize<T>(json);
        }

        public Task RemoveAsync(string key)
        {
            return _database.KeyDeleteAsync(key);
        }
    }
}
