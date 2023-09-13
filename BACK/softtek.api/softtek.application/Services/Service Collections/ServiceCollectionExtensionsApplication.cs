using Microsoft.Extensions.DependencyInjection;
using softtek.Application.Commands.Mayor;
using softtek.Application.Queries.Mayor;

namespace softtek.application.Services.Service_Collections
{
    public static class ServiceCollectionExtensionsApplication
    {
        public static IServiceCollection AddServiceCollectionsApplication(this IServiceCollection services)
        {
            services.AddScoped<IWriteMayoryBalance, WriteMayoryBalance>();
            services.AddScoped<IGetMayoryBalance, GetMayoryBalance>();
            return services;
        }
    }
}
