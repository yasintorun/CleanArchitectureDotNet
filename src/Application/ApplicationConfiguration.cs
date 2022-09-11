using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using LMS.Application.Abstractions.Services;
using LMS.Application.Managers;

namespace LMS.Application
{
    public static class ApplicationConfiguration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddApplicationDependencyInjection();
        }

        public static void AddApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentManager>();
        }
    }
}
