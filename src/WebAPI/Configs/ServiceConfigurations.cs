using Microsoft.OpenApi.Models;
using LMS.Infrastructure;

namespace LMS.WebAPI.Configs;
public static class ServiceConfigurations
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddDependencies();
        services.AddMemoryCache();
        services.AddHealthChecks();
        services.AddCors();
        services.AddSwagger();
    }

    private static void AddDependencies(this IServiceCollection services)
    {
        services.AddInfrastructureDependencies();
    }

    private static void AddCors(this IServiceCollection services)
    {
        services.AddCors(o => o.AddPolicy("CorsPolicy", policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));
    }

    private static void AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "LMS Web API Document", Version = "v1" });
        });
    }
}

