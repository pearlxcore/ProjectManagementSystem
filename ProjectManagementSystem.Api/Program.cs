using ProjectManagementSystem.Application;
using ProjectManagementSystem.Infrastructure;

namespace ProjectManagementSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                // Add services to the container.

                builder.Services
                    .AddPresentation()
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);
            }

            var app = builder.Build();
            {
                // Configure the HTTP request pipeline.

                app.UseHttpsRedirection();
                app.UseAuthentication();
                app.UseAuthorization();
                app.MapControllers();
                app.Run();
            }
        }
    }
}