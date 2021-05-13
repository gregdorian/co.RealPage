using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using realpage.Application.Interfaces;
using realpage.Application.Services;
using realpage.Domain.Core;
using realpage.Domain.Core.Interfaces.Repositories;
using realpage.Domain.Core.Interfaces.Services;
using realpage.InfraestructureData.Model;
using realpage.InfraestructureData.Repositories;

namespace realpage.Services.UI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {



            //Servicios de la capa de aplicación con servicios
            services.AddScoped(typeof(IBaseAppService<>), typeof(BaseAppService<>));
            services.AddScoped<IProductsAppService, ProductAppService>();


            //el dominio a los de infraestructura
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IProductsService, ProductsService>();

            //infraestructura o persistencia
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
