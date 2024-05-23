using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Infrastructure.Data.Context;

namespace PortalComprasPublicas.Infrastructure.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MySqlDbContext context) : base(context) { }
    }
}