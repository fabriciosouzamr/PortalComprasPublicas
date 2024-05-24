using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalComprasPublicas.Domain.Entities;

namespace PortalComprasPublicas.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.endereco)
                .IsRequired()
                .HasColumnType("varchar(500)");
        }
    }
}
