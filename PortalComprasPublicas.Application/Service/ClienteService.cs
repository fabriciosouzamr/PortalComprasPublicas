using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;

namespace PortalComprasPublicas.Domain.Service
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IRepository<Cliente> repository) : base(repository)
        {
        }
    }
}