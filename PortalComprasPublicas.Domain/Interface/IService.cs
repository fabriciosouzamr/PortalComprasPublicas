using System.Linq.Expressions;

using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Interface
{
    /// <summary>
    /// Interface que orquestra nossa camada Repository de infraestrutura que faz comunicação com o banco de dados. 
    /// </summary>
    public interface IService<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task<TEntity> Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> ObterTodos(int offset = 1, int limite = 50, Expression<Func<TEntity, object>> order = null);
        Task<TEntity> Atualizar(TEntity entity);
        Task<int> Remover(Guid id);
    }
}
