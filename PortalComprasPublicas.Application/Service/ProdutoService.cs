using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;

namespace PortalComprasPublicas.Domain.Service
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        public ProdutoService(IRepository<Produto> repository) : base(repository)
        {
        }
    }
}