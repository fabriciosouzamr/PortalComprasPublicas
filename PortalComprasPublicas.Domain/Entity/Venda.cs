using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Entities
{
    public class Venda : EntityBase
    {
        public Guid ClienteId { get; set; }
        public DateTime DataVenda { get; set; }

        /* EF Relation */
        public virtual Cliente Cliente { get; set; }
    }
}