using Kata.Application.Order.Interfaces;
using Kata.Infrastructure.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IOrderHttpClient, OrderHttpClient>();

            return services;
        }
    }
}
