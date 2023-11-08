using Mapster;
using MapsterMapper;

namespace ProjectManagementSystem.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services
                .AddMapsterDependencyInjection()
                .AddControllers();
            return services;
        }

        public static IServiceCollection AddMapsterDependencyInjection(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(DependencyInjection).Assembly);
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
    }
}
