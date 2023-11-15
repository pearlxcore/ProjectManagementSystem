using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectManagementSystem.Application.Common.Interfaces.Authentication;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Application.Common.Interfaces.Providers;
using ProjectManagementSystem.Infrastructure.Authentication;
using ProjectManagementSystem.Infrastructure.Persistance;
using ProjectManagementSystem.Infrastructure.Persistance.Repositories;
using ProjectManagementSystem.Infrastructure.Providers;
using System.Text;

namespace ProjectManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuth(configuration)
                .AddProviders()
                .AddPersistance();
            return services;
        }

        private static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services
                .AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }

        private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));

            services
                .AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services
     .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtSettings.Issuer,
         ValidAudience = jwtSettings.Audience,
         IssuerSigningKey = new SymmetricSecurityKey(
             Encoding.UTF8.GetBytes(jwtSettings.Secret))
     });

            return services;
        }

        private static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<ProjectManagementSystemDbContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=ProjectManagementSystem;User Id=sa;Password=Playstation4!;Encrypt=false");
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IClientRepository, ClientRespository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            return services;
        }
    }
}
