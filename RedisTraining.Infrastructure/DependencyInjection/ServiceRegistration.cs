using Microsoft.Extensions.DependencyInjection;
using RedisTraining.Application.Interfaces;
using RedisTraining.Infrastructure.Redis;
using RedisTraining.Infrastructure.Services;

namespace RedisTraining.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddSingleton<ICacheService, RedisCacheService>();
            services.AddSingleton<IProductService, ProductService>();

            return services;
        }
    }
}
