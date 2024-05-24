using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Infrastructure.Data.Context;

namespace PortalComprasPublicas.Infrastructure.Data.Repository
{
    /// <summary>
    /// Classe responsavel por realizar transações em nossa base de dados para cliente
    /// </summary>
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MySqlDbContext context) : base(context) { }
    }
}