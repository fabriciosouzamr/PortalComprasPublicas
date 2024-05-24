using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;

namespace PortalComprasPublicas.Domain.Service
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        /// <summary>
        /// Classe responsavel service do produto, ela usuario a base service e base repositorio, de modo a não precisar implementar os métodos genéricos.
        /// </summary>
        public ProdutoService(IRepository<Produto> repository) : base(repository)
        {
        }
    }
}