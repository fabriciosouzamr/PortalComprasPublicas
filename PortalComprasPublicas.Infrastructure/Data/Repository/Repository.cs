using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PortalComprasPublicas.Domain.Entity;

using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Infrastructure.Data.Context;

namespace PortalComprasPublicas.Infrastructure.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly MySqlDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MySqlDbContext db)
        {
            Db = db;
            Db.ChangeTracker.AutoDetectChangesEnabled = false;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Procurar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            var includedData = DbSet.AsQueryable();

            if (includes != null)
                foreach (var include in includes)
                {
                    includedData = includedData.Include(include);
                }
            return await includedData.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos(int offset = 1, int limite = 50, Expression<Func<TEntity, object>>? order = null)
        {
            return await DbSet.Skip(limite * (offset - 1)).Take(limite).OrderBy(order ?? (e => e.Id)).ToListAsync();
        }

        public virtual async Task<TEntity> Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task<TEntity> Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task<int> Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            return await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
