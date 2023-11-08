using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Domain.Aggregates.Users;
using ProjectManagementSystem.Domain.Aggregates.Users.ValueObjects;

namespace ProjectManagementSystem.Infrastructure.Persistance.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUsersTable(builder);
        }

        private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
            builder.Property(u => u.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Role).HasMaxLength(50).IsRequired();
            builder.OwnsOne(u => u.UserContact, builder =>
            {
                builder.Property(uc => uc.Phone).HasMaxLength(50).IsRequired();
                builder.Property(uc => uc.Address).HasMaxLength(100).IsRequired();
            });
        }
    }
}
