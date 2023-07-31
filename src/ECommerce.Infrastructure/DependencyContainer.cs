using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.Uow;
using ECommerce.Infrastructure.Context;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Infrastructure.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure
{
    public static class DependencyContainer
    {
        public static void InfrastractureServiceContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDbContext>(options => options.UseNpgsql(connectionString: configuration.GetConnectionString("Database")), ServiceLifetime.Scoped);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
