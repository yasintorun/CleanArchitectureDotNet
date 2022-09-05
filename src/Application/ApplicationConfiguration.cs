using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LMS.Application
{
    public static class ApplicationConfiguration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
