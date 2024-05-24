using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Entities
{
    public class Produto : EntityBase
    {
        /// <summary>
        /// Classe de dominio que representa um produto do nosso negocio
        /// </summary>
        public string nome { get; set; }
        public decimal preco { get; set; }
    }
}