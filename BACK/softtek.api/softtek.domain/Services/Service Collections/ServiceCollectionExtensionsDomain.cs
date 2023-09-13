
using Microsoft.Extensions.DependencyInjection;
using softtek.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.domain.Services.Service_Collections
{
    public static class ServiceCollectionExtensionsDomain
    {
        public static IServiceCollection AddServiceCollectionsDomain(this IServiceCollection services)
        {
            services.AddScoped<MayoryBalance>();
            return services;
        }
    }
}
