using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Infrastructure.Data.Context;

namespace PortalComprasPublicas.Infrastructure.Data.Repository
{
    /// <summary>
    /// Classe responsavel por realizar transações em nossa base de dados para produto
    /// </summary>
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MySqlDbContext context) : base(context) { }
    }
}