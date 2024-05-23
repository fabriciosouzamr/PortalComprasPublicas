using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Infrastructure.Data.Context;

namespace PortalComprasPublicas.Infrastructure.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MySqlDbContext context) : base(context) { }
    }
}