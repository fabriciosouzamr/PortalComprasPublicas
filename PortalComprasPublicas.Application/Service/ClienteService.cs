using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;

namespace PortalComprasPublicas.Domain.Service
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        /// <summary>
        /// Classe responsavel service do cliente, ela usuario a base service e base repositorio, de modo a não precisar implementar os métodos genéricos.
        /// </summary>
        public ClienteService(IRepository<Cliente> repository) : base(repository)
        {
        }
    }
}