using Microsoft.EntityFrameworkCore;
using PortalComprasPublicas.Domain.Entities;

namespace PortalComprasPublicas.Infrastructure.Data.Context
{
    /// <summary>
    /// Essa classe de contexto administra os objetos entidades durante o tempo de execução, o que inclui preencher objetos com dados de um banco de dados, controlar alterações, e persistir dados para o banco de dados MySql
    /// </summary>
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext()
        {

        }
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(250");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MySqlDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}