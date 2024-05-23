using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Entities
{
    public class VendaItem : EntityBase
    {
        public Guid VendaId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Money { get; set; }

        /* EF Relation */
        public virtual Venda Venda { get; set; }
        public virtual Produto Produto { get; set; }
    }
}