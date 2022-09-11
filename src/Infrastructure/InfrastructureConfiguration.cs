using LMS.Application.Abstractions.Repositories;
using LMS.Infrastructure.Database.EntityFramework.Contexts;
using LMS.Infrastructure.Database.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace LMS.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabases(services, configuration);
            AddInfrastructureDependencies(services);
        }
        
        private static void AddDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LMSContext>(options => options.UseSqlServer(configuration.GetConnectionString("LMS_DEV")));
        }

        private static void AddInfrastructureDependencies(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
