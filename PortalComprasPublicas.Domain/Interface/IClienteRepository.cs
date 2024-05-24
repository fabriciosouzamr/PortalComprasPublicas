using PortalComprasPublicas.Domain.Entities;

namespace PortalComprasPublicas.Domain.Interface
{
    /// <summary>
    /// Classe que implementa operações pra gerenciamento do cliente, herda da repositorio base para não precisar implementar metodos genericos
    /// </summary>
    public interface IClienteRepository : IRepository<Cliente>
    {

    }
}