using Microsoft.EntityFrameworkCore;
using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Infrastructure.Data.Context
{
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