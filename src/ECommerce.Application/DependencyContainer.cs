using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application
{
    public static class DependencyContainer
    {
        public static void ApplicationServiceContainer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssembly).Assembly));

            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            
            typeAdapterConfig.Scan(typeof(ApplicationAssembly).Assembly);
            var mapperConfig = new Mapper(typeAdapterConfig);
            services.AddSingleton<IMapper>(mapperConfig);
        }
    }
}
