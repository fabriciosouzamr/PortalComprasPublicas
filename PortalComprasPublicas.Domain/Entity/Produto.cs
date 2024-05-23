using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Entities
{
    public class Produto : EntityBase
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}