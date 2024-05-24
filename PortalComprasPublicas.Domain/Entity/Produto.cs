using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Entities
{
    public class Produto : EntityBase
    {
        public string nome { get; set; }
        public decimal preco { get; set; }
    }
}