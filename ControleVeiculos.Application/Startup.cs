using AutoMapper;
using ControleVeiculos.Application.Common.Mapper;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Context;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Infra.Data.Repositories;
using ControleVeiculos.Service.Common.Interfaces;
using ControleVeiculos.Service.Common.Services;
using ControleVeiculos.Service.Validator.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ControleVeiculos.Application
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
            services.AddEntityFrameworkNpgsql().AddDbContext<VeiculosDataContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("ApiConection"));
            });

            services.AddControllers().AddNewtonsoftJson();
            ConfigureRepositories(services);
            ConfigureValidators(services);
            ConfigureBusinessServices(services);
            services.AddAutoMapper(Assembly.Load(Assembly.GetAssembly(typeof(VeiculoMappingProfile)).FullName));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Controle de Veículos API", Version = "v1" });
            });
        }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
        }

        public void ConfigureValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<Veiculo>, VeiculoValidator>();
        }

        public void ConfigureBusinessServices(IServiceCollection services)
        {
            services.AddScoped<IVeiculoService, VeiculoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle de Veículos V1");
            });

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
