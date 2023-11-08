using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Domain.Aggregates.Clients;
using ProjectManagementSystem.Domain.Aggregates.Clients.ValueObjects;

namespace ProjectManagementSystem.Infrastructure.Persistance.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            ConfigureClientsTable(builder);
            ConfigureProjectIdsTable(builder);
        }

        private void ConfigureProjectIdsTable(EntityTypeBuilder<Client> builder)
        {
            builder.OwnsMany(c => c.ProjectIds, builder =>
            {
                builder.ToTable("ProjectIds");
                builder.WithOwner()
                        .HasForeignKey("ClientId");
                builder.HasKey("Id");
                builder.Property(p => p.Value)
                .HasColumnName("ProjectId")
                .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Client.ProjectIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureClientsTable(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => ClientId.Create(value));
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(50).IsRequired();
            builder.OwnsOne(c => c.ClientContact, builder =>
            {
                builder.Property(cc => cc.Phone).HasMaxLength(50).IsRequired();
                builder.Property(cc => cc.Address).HasMaxLength(100).IsRequired();
            });
        }
    }
}