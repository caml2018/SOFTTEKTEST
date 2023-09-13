using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using Microsoft.OpenApi.Models;
using softtek.api.MaperProfile;
using softtek.application.Services.Service_Collections;
using softtek.domain.Services.Service_Collections;
using softtek.infrastructure.EntityFrameWorkDataAccess.Context;
using softtek.infrastructure.Odbc.Context;
using softtek.infrastructure.Services.Service_Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace softtek.api
{
    public class Startup
    {
        readonly string MiCors = "MiCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MiCors,
                    builder =>
                    {
                        //builder.WithHeaders();
                        builder.AllowAnyHeader();
                        builder.WithOrigins("http://localhost:4200", "http://{public IP}:{public port}/", "http://{public DNS name}:{public port}/");
                        builder.WithMethods();

                    });
            });
            services.AddControllers();
            services.AddDbContext<DbTestSofttekContext>(options => options.UseSqlServer(Configuration.GetConnectionString("storage")));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddServiceCollectionsDomain();
            services.AddServiceCollectionsApplication();
            services.AddServiceCollectionsInfrastructure();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "softtek.api", Version = "v1" });
            });

            //Mapper
            var mapperConfig = new MapperConfiguration(x => {
                x.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "softtek.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MiCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
