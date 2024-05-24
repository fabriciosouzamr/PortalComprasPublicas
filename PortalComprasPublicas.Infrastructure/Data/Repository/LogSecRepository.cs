using System.ComponentModel;

using Microsoft.EntityFrameworkCore;

using PortalComprasPublicas.Domain.Entity;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Infrastructure.Data.Context;

namespace PortalComprasPublicas.Infrastructure.Data.Repository
{
    public class LogSecRepository : ILogSecRepository
    {
        SqlLiteDbContext _context;
        protected readonly DbSet<LogSec> DbSet;

        public LogSecRepository(SqlLiteDbContext db)
        {
            this._context = db;
            db.ChangeTracker.AutoDetectChangesEnabled = false;
            DbSet = db.Set<LogSec>();
        }

        public async Task<List<LogSec>> ObterTodos(int offset = 1, int limite = 50)
        {
            return await DbSet.Skip(limite * (offset - 1)).Take(limite).ToListAsync();
        }

        public async Task Adicionar(LogSec entity)
        {
            DbSet.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
