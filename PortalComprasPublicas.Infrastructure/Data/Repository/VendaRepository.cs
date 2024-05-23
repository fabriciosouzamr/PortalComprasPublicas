using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Infrastructure.Data.Context;

namespace PortalComprasPublicas.Infrastructure.Data.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(MySqlDbContext context) : base(context) { }
    }
}
