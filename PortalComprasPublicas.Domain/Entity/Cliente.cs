using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Entities
{
    /// <summary>
    /// Classe de dominio que representa um cliente do nosso negocio
    /// </summary>
    public class Cliente : EntityBase
    {
        public string nome { get; set; }
        public string endereco { get; set; }
    }
}