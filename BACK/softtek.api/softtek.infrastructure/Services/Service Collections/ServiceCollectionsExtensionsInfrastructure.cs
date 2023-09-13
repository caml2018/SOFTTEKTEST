using Microsoft.Extensions.DependencyInjection;
using softtek.application.Interfaces.Mayor;
using softtek.Application.Commands.Mayor;
using softtek.Application.Interfaces.Mayor;
using softtek.infrastructure.Odbc.Context;
using softtek.Infrastructure.Repositories.Mayor;
using softtek.Infrastructure.RepositoriesOdbc.Mayor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.infrastructure.Services.Service_Collections
{
    public static class ServiceCollectionsExtensionsInfrastructure
    {
        
        public static IServiceCollection AddServiceCollectionsInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IOdbcContext, OdbcContext>();
            services.AddScoped<IMayorAddRepository, MayoryBalanceAddRepository>();
            services.AddScoped<IMayorGetRepository, MayoryBalanceGetRepository>();
            services.AddScoped<IMayorAddRepository, MayoryBalanceAddRepositoryOdbc>();
            services.AddScoped<IMayorGetRepositoryOdbc, MayoryBalanceGetRepositoryOdbc>();
            return services;
        }
        
    }
}
