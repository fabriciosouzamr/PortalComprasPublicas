using PortalComprasPublicas.Domain.Entities;

namespace PortalComprasPublicas.Domain.Interface
{
    public interface IVendaService : IService<Venda>
    {
        Task<Venda> RealizarVendaAsync(Venda venda);
    }
}