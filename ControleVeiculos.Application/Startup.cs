using AutoMapper;
using ControleVeiculos.Application.Common.Mapper;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Context;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Infra.Data.Repositories;
using ControleVeiculos.Service.Common.Interfaces;
using ControleVeiculos.Service.Common.Services;
using ControleVeiculos.Service.Validator.Interfaces;
using ControleVeiculos.Service.Validator.Rules;
using ControleVeiculos.Service.Validator.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace ControleVeiculos.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IWebHostEnvironment Env { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<VeiculosDataContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("ApiConection"));
            });

            services.AddControllers().AddNewtonsoftJson();
            ConfigureAuthorization(services);
            ConfigureRepositories(services);
            ConfigureValidators(services);
            ConfigureBusinessServices(services);
            services.AddAutoMapper(Assembly.Load(Assembly.GetAssembly(typeof(VeiculoMappingProfile)).FullName));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Controle de Veículos API", Version = "v1" });
            });
        }
        private void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["IssuerKey"],
                    ValidAudience = Configuration["AudienceKey"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration[GetSecurityKeyName()])),
                };
            });
        }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IAbastecimentoRepository, AbastecimentoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        public void ConfigureValidators(IServiceCollection services)
        {
            services.AddScoped<IPlacaValida, PlacaValida>();
            services.AddScoped<IValidator<Veiculo>, VeiculoValidator>();
            services.AddScoped<IValidator<Abastecimento>, AbastecimentoValidator>();
            services.AddScoped<IValidator<Usuario>, UsuarioValidator>();
        }

        public void ConfigureBusinessServices(IServiceCollection services)
        {
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IAbastecimentoService, AbastecimentoService>();            
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ISenhaService, SenhaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IConfigurationManagerService, ConfigurationManagerService>();
        }

        public string GetSecurityKeyName()
        {
            return Env.IsDevelopment() ? "SecurityKeyDev" : "SecurityKey";
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
