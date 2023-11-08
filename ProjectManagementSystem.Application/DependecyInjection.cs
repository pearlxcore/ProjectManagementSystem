using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.Application.Common.Behaviour;
using System.Reflection;

namespace ProjectManagementSystem.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly()));

            services
                .AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidatorBehaviour<,>));

            services
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
