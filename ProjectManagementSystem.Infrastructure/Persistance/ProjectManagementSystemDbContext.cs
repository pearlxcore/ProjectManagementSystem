using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Aggregates.Clients;
using ProjectManagementSystem.Domain.Aggregates.Projects;
using ProjectManagementSystem.Domain.Aggregates.Users;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Infrastructure.Persistance
{
    public class ProjectManagementSystemDbContext : DbContext
    {
        public ProjectManagementSystemDbContext(
            DbContextOptions<ProjectManagementSystemDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ProjectManagementSystemDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
