using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalComprasPublicas.Domain.Entities;

namespace PortalComprasPublicas.Infrastructure.Data.Configurations
{
    /// <summary>
    /// Classe que configura a entiidade produto para o padrao do banco MySql
    /// </summary>
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.preco)
                .IsRequired()
                .HasColumnType("numeric(18,2");
        }
    }
}
