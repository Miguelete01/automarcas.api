using Autos.Api.Repositories;

namespace Autos.Api.Services
{
    public static class IServicesCollectionExtensions
    {
        public static IServiceCollection AddBasicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMarcasAutosRepository, MarcasAutosRepository>();
            services.AddTransient<IMarcasAutosService, MarcasAutosService>();
            return services;
        }
    }
}
