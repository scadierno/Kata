using Kata.Application.Order.Interfaces;
using Kata.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
