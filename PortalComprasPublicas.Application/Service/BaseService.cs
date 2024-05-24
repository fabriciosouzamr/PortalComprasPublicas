using System.Linq.Expressions;

using PortalComprasPublicas.Domain.Entity;
using PortalComprasPublicas.Domain.Interface;

namespace PortalComprasPublicas.Domain.Service
{
    /// <summary>
    /// Classe básica dos services, aqui terão os métodos comuns, os genéricos.
    /// </summary>
    public abstract class BaseService<TEntity> : IService<TEntity> where TEntity : EntityBase, new()
    {
        private readonly IRepository<TEntity> _repository;
        protected BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<TEntity> ObterPorId(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.ObterPorId(id, includes);
        }

        public virtual Task<TEntity> GetById(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public virtual Task<List<TEntity>> ObterTodos(int offset = 1, int limite = 50, Expression<Func<TEntity, object>> order = null)
        {
            if (limite <= 0 || limite > 50)
            {
                limite = 50;
            }
            if (offset <= 0)
            {
                limite = 1;
            }

            return _repository.ObterTodos(offset, limite, order);
        }

        public virtual async Task<TEntity> Adicionar(TEntity entity)
        {
            return await _repository.Adicionar(entity);
        }

        public virtual async Task<TEntity> Atualizar(TEntity entity)
        {
            return await _repository.Atualizar(entity);
        }

        public virtual async Task<int> Remover(Guid id)
        {
            return await _repository.Remover(id);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
