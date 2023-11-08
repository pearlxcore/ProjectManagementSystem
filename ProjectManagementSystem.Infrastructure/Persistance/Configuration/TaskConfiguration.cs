using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Domain.Aggregates.Task.ValueObjects;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Infrastructure.Persistance.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.Task.Task> builder)
        {
            ConfigureTasks(builder);
            ConfigureTaskUserIds(builder);
        }

        private void ConfigureTaskUserIds(EntityTypeBuilder<Task> builder)
        {
            builder.OwnsMany(t => t.AssignedUserIds, builder =>
            {
                builder.ToTable("TaskUserIds");
                builder.WithOwner()
                .HasForeignKey("TaskId");
                builder.HasKey("Id");
                builder.Property(t => t.Value)
                .HasColumnName("UserId")
                .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Task.AssignedUserIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureTasks(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => TaskId.Create(value));
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(100).IsRequired();
            builder.Property(t => t.StartDate);
            builder.Property(t => t.EndDate);
            builder.Property(t => t.Status).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Priority).HasMaxLength(50).IsRequired();
        }
    }
}
