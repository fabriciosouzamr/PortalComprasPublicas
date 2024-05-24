using Microsoft.EntityFrameworkCore;
using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Infrastructure.Data.Context
{
    /// <summary>
    /// Essa classe de contexto administra os objetos entidades durante o tempo de execução, o que inclui preencher objetos com dados de um banco de dados, controlar alterações, e persistir dados para o banco de dados SqlLite
    /// </summary>
    public class SqlLiteDbContext : DbContext
    {
        public SqlLiteDbContext()
        {
        }
        public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options) : base(options)
        {
        }

        public DbSet<LogSec> LogSecs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlLiteDbContext).Assembly);
        }
    }
}