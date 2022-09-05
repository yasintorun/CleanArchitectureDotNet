using LMS.Application.Abstractions.Repositories;
using LMS.Infrastructure.Database.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace LMS.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
