using CleanArchitecture.Domain.Validations;
using CleanArhitecture.Api.Filters;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CleanArhitecture.Api.Configs
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();
            services.AddSwagger();
            services.AddCors();
            services.AddValidations();
        }

        private static void AddValidations(this IServiceCollection services)
        {
            services
                .AddControllers(configure => { configure.AllowEmptyInputInBodyModelBinding = true; })
                .AddFluentValidation(f =>   
                {
                    f.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                    f.RegisterValidatorsFromAssemblyContaining<StudentValidator>();
                })
                .AddJsonOptions(opt => { opt.JsonSerializerOptions.IgnoreNullValues = false; })
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }


        private static void AddServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddHealthChecks();
            services.AddDependencies();
        }

        public static void AddDependencies(this IServiceCollection services)
        {
            //Repos


            //Services


            //Intl - Tools


            //Mediatr
        }

        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clean Architecture WebApi Document", Version = "v1" });
                c.OperationFilter<RequiredHeadersFilter>();
            });
        }

    }
}
