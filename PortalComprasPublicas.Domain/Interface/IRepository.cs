using System.Linq.Expressions;
using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase, new()
    {
        Task<TEntity> Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> ObterTodos(int offset = 1, int limite = 50, Expression<Func<TEntity, object>> order = null);
        Task<TEntity> Atualizar(TEntity entity);
        Task<int> Remover(Guid id);
        Task<IEnumerable<TEntity>> Procurar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
