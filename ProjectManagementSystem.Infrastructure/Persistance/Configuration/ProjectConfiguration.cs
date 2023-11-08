using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Domain.Aggregates.Projects;
using ProjectManagementSystem.Domain.Aggregates.Projects.ValueObjects;

namespace ProjectManagementSystem.Infrastructure.Persistance.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            ConfigureProjects(builder);
            ConfigureTaskIds(builder);
        }

        private void ConfigureTaskIds(EntityTypeBuilder<Project> builder)
        {
            builder.OwnsMany(c => c.TaskIds, builder =>
            {
                builder.ToTable("TaskProjectIds");
                builder.WithOwner()
                        .HasForeignKey("ProjectId");
                builder.HasKey("Id");
                builder.Property(p => p.Value)
                .HasColumnName("TaskId")
                .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Project.TaskIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureProjects(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => ProjectId.Create(value));
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(100).IsRequired();
            builder.Property(t => t.StartDate);
            builder.Property(t => t.EndDate).IsRequired();
            builder.Property(t => t.Status).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Priority).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Budget).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(t => t.ClientId).IsRequired();
        }
    }
}
